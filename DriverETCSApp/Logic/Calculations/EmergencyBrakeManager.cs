using DriverETCSApp.Communication;
using DriverETCSApp.Communication.Unity;
using DriverETCSApp.Data;
using DriverETCSApp.Events;
using DriverETCSApp.Events.ETCSEventArgs;
using DriverETCSApp.Forms.CForms;
using DriverETCSApp.Forms.EForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DriverETCSApp.Logic.Calculations {
    public static class EmergencyBrakeManager {

        private static bool isBraking = false;
        private static UnitySender sender = new UnitySender("127.0.0.1", Port.Unity);
        private static (bool, bool, bool) brakeLock = (false, false, false); //SpeedBrake, AckBrake, TripMode
        private static SemaphoreSlim Semaphore = new SemaphoreSlim(1, 1);

        public static void SetUp()
        {
            ETCSEvents.BrakeChange += BrakeAfterAck;
        }

        public static void Destroy()
        {
            ETCSEvents.BrakeChange -= BrakeAfterAck;
        }

        private static bool CheckLock()
        {
            //return true;
            return !brakeLock.Item1 && !brakeLock.Item2 && !brakeLock.Item3;
        }

        public async static void CheckSpeed() {

            double currentSpeedLimitation;
            if(AuthorityData.CalculatedSpeedLimit > 0) {
                currentSpeedLimitation = AuthorityData.CalculatedSpeedLimit + AuthorityData.WARNING_SPEED_RANGE;
            }
            else {
                currentSpeedLimitation = AuthorityData.Speeds.Count > 0 ? AuthorityData.Speeds[0] + AuthorityData.WARNING_SPEED_RANGE : 0;
            }
            currentSpeedLimitation = Math.Max(currentSpeedLimitation, AuthorityData.MIN_SPEED_LIMIT + AuthorityData.WARNING_SPEED_RANGE);
            Console.WriteLine(currentSpeedLimitation);

            await Semaphore.WaitAsync();
            if (TrainData.ActiveMode.Equals(ETCSModes.FS)) //check if in FS mode
            {
                if (TrainData.CurrentSpeed > currentSpeedLimitation)
                {
                    if (!isBraking && CheckLock())
                    {
                        _ = sender.SendBrakeSignal(true);
                        isBraking = true;
                        EmptyCForm.BrakingImage(true);
                    }
                    brakeLock.Item1 = true;
                }
                else //TrainData.CurrentSpeed <= currentSpeedLimitation
                {
                    brakeLock.Item1 = false;
                    if (isBraking && CheckLock())
                    {
                        _ = sender.SendBrakeSignal(false);
                        isBraking = false;
                        EmptyCForm.BrakingImage(false);
                    }
                }
            }
            else if (TrainData.ActiveMode.Equals(ETCSModes.SB) || TrainData.ActiveMode.Equals(ETCSModes.PT)) //if in STAND BY or POST TRIP mode brake if train is moving
            {
                if(TrainData.ActiveMode.Equals(ETCSModes.PT) && brakeLock.Item3)
                {
                    brakeLock.Item3 = false;
                }

                if (TrainData.CurrentSpeed > 0 && !isBraking)
                {
                    _ = sender.SendBrakeSignal(true);
                    isBraking = true;
                    EmptyCForm.BrakingImage(true);
                }
                else if (TrainData.CurrentSpeed <= 0 && isBraking)
                {
                    _ = sender.SendBrakeSignal(false);
                    isBraking = false;
                    EmptyCForm.BrakingImage(false);
                }
            }
            else if (TrainData.ActiveMode.Equals(ETCSModes.STM)) //if in SHP mode brake if train is moving faster then Vmax
            {
                if (TrainData.CurrentSpeed > Double.Parse(TrainData.VMax) + 5)
                {
                    if (!isBraking && CheckLock())
                    {
                        _ = sender.SendBrakeSignal(true);
                        isBraking = true;
                        EmptyCForm.BrakingImage(true);
                    }
                    brakeLock.Item1 = true;
                }
                else if (TrainData.CurrentSpeed <= Double.Parse(TrainData.VMax) + 5)
                {
                    brakeLock.Item1 = false;
                    if (isBraking && CheckLock())
                    {
                        _ = sender.SendBrakeSignal(false);
                        isBraking = false;
                        EmptyCForm.BrakingImage(false);
                    }
                }
            }
            else if (TrainData.ActiveMode.Equals(ETCSModes.OS)) //if in OS mode brake if train is moving faster than 20 (+5 tolerance)
            {
                if (TrainData.CurrentSpeed > 25)
                {
                    if (!isBraking && CheckLock())
                    {
                        _ = sender.SendBrakeSignal(true);
                        isBraking = true;
                        EmptyCForm.BrakingImage(true);
                    }
                    brakeLock.Item1 = true;
                }
                else if (TrainData.CurrentSpeed <= 25)
                {
                    brakeLock.Item1 = false;
                    if (isBraking && CheckLock())
                    {
                        _ = sender.SendBrakeSignal(false);
                        isBraking = false;
                        EmptyCForm.BrakingImage(false);
                    }
                }
            }
            else if (TrainData.ActiveMode.Equals(ETCSModes.TR)) //if in TR mode brake
            {
                if (!isBraking && CheckLock())
                {
                    _ = sender.SendBrakeSignal(true);
                    isBraking = true;
                    EmptyCForm.BrakingImage(true);
                }
                brakeLock.Item1 = false;
                brakeLock.Item2 = false;
                brakeLock.Item3 = true;
            }
            Semaphore.Release();
        }

        public async static void BrakeAfterAck(object _sender, BrakeChangeInfo e)
        {
            await Semaphore.WaitAsync();
            if (e.RequestBrake)
            {
                if (!isBraking && CheckLock())
                {
                    _ = sender.SendBrakeSignal(true);
                    isBraking = true;
                    EmptyCForm.BrakingImage(true);
                }
                brakeLock.Item2 = true;
            }
            else
            {
                brakeLock.Item2 = false;
                if (isBraking && CheckLock())
                {
                    _ = sender.SendBrakeSignal(false);
                    isBraking = false;
                    EmptyCForm.BrakingImage(false);
                }
            }
            Semaphore.Release();
        }
    }
}
