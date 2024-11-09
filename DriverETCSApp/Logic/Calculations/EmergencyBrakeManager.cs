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
        private static (bool, bool) brakeLock = (false, false); //SpeedBrake, AckBrake
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
            return !brakeLock.Item1 && !brakeLock.Item2;
        }

        public async static void CheckSpeed() {

            double currentSpeedLimitation = AuthorityData.Speeds.Count > 0 ? AuthorityData.Speeds[0] + AuthorityData.WARNING_SPEED_RANGE : 0;
            await Semaphore.WaitAsync();
            if (TrainData.IsETCSActive && TrainData.ActiveMode.Equals(ETCSModes.FS)) //check if in FS mode
            {
                if (TrainData.CurrentSpeed > currentSpeedLimitation)
                {
                    if (!isBraking && CheckLock()) {
                        _ = sender.SendBrakeSignal(true);
                        isBraking = true;
                        EmptyCForm.BrakingImage(true);
                        Console.WriteLine("CheckSpeed() start");
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
                        Console.WriteLine("CheckSpeed() stop");
                    }
                }
            }
            else if(TrainData.ActiveMode.Equals(ETCSModes.SB)) //if in STAND BY mode brake if train is moving
            {
                if(TrainData.CurrentSpeed > 0 && !isBraking)
                {
                    _ = sender.SendBrakeSignal(true);
                    isBraking = true;
                    EmptyCForm.BrakingImage(true);
                    Console.WriteLine("CheckSpeed() start SB");
                }
                else if(TrainData.CurrentSpeed <= 0 && isBraking)
                {
                    _ = sender.SendBrakeSignal(false);
                    isBraking = false;
                    EmptyCForm.BrakingImage(false);
                    Console.WriteLine("CheckSpeed() stop SB");
                }
            }
            else if(TrainData.ActiveMode.Equals(ETCSModes.STM)) //if in SHP mode brake if train is moving faster then Vmax
            {
                if (TrainData.CurrentSpeed > Double.Parse(TrainData.VMax) + 5)
                {
                    if (!isBraking && CheckLock())
                    {
                        _ = sender.SendBrakeSignal(true);
                        isBraking = true;
                        EmptyCForm.BrakingImage(true);
                        Console.WriteLine("CheckSpeed() start STM");
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
                        Console.WriteLine("CheckSpeed() stop STM");
                    }
                }
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
                    Console.WriteLine("BrakeAfterAck(object _sender, BrakeChangeInfo e) start");
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
                    Console.WriteLine("BrakeAfterAck(object _sender, BrakeChangeInfo e) stop");
                }
            }
            Semaphore.Release();
        }
    }
}
