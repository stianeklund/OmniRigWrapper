using System;
using System.Runtime.InteropServices;
using OmniRig;

namespace OmniRigWrapper
{
    /// <summary>
    ///     This is a wrapper class for OmniRig which targets NET Framework in order to be used in NET code & up
    /// </summary>
    public class OmniRigWrapperClass
    {
        public string RX;
        public string TX;

        public OmniRigWrapperClass(RigX rig, OmniRigX omniRigEngine)
        {
            Rig = rig;
            OmniRigEngine = omniRigEngine;
        }

        public OmniRigWrapperClass()
        {
            OmniRigEngine = OmniRigEngine =
                (OmniRigX)Activator.CreateInstance(Type.GetTypeFromProgID("OmniRig.OmniRigX"));
            Rig = OmniRigEngine.Rig1;
            if (OmniRigEngine.InterfaceVersion < 0x101 && OmniRigEngine.InterfaceVersion > 0x299)
                OmniRigEngine = null;
            //("OmniRig is not installed or has unsupported version.");
            SelectRig(1);
        }

        public OmniRigX OmniRigEngine { get; set; }

        // The rig
        public RigX Rig { get; set; }

        public int CurrentRigNo { get; set; }

        public string Status { get; set; }

        public string Frequency { get; set; }

        public string Mode { get; set; }

        public void StartOmniRig()
        {
            try
            {
                if (OmniRigEngine != null)
                {
                    Console.WriteLine("OmniRig is running");
                    if (CurrentRigNo != 1)
                        SelectRig(1);
                }
                else
                {
                    OmniRigEngine = (OmniRigX)Activator.CreateInstance(Type.GetTypeFromProgID("OmniRig.OmniRigX"));
                    // we want OmniRig interface V.1.1 to 1.99
                    // as V2.0 will likely be incompatible  with 1.x
                    if (OmniRigEngine.InterfaceVersion < 0x101 && OmniRigEngine.InterfaceVersion > 0x299)
                        OmniRigEngine = null;
                    //("OmniRig is not installed or has unsupported version.");
                    SelectRig(1);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message} {e.StackTrace}");
            }
        }

        public void SelectRig(int newRigNo)
        {
            if (OmniRigEngine == null)
                return;

            CurrentRigNo = newRigNo;
            switch (newRigNo)
            {
                case 1:
                    Rig = OmniRigEngine.Rig1;
                    break;
                case 2:
                    Rig = OmniRigEngine.Rig2;
                    break;
            }

            ShowRigStatus();
            ShowRigParams();
        }

        public void ShowRigStatus()
        {
            if (Rig != null)
                Status = Rig.StatusStr;
        }

        public void ShowRigParams()
        {
            if (Rig == null)
                return;

            RX = Rig.GetRxFrequency().ToString();
            TX = Rig.GetTxFrequency().ToString();
            Frequency = Rig.Freq.ToString();

            switch (Rig.Mode)
            {
                case (RigParamX)OmniRigConstants.PM_CW_L:
                    Mode = "CW";
                    break;
                case (RigParamX)OmniRigConstants.PM_CW_U:
                    Mode = "CW-R";
                    break;
                case (RigParamX)OmniRigConstants.PM_SSB_L:
                    Mode = "LSB";
                    break;
                case (RigParamX)OmniRigConstants.PM_SSB_U:
                    Mode = "USB";
                    break;
                case (RigParamX)OmniRigConstants.PM_FM:
                    Mode = "FM";
                    break;
                case (RigParamX)OmniRigConstants.PM_AM:
                    Mode = "AM";
                    break;
                case RigParamX.PM_UNKNOWN:
                case RigParamX.PM_FREQ:
                case RigParamX.PM_FREQA:
                case RigParamX.PM_FREQB:
                case RigParamX.PM_PITCH:
                case RigParamX.PM_RITOFFSET:
                case RigParamX.PM_RIT0:
                case RigParamX.PM_VFOAA:
                case RigParamX.PM_VFOAB:
                case RigParamX.PM_VFOBA:
                case RigParamX.PM_VFOBB:
                case RigParamX.PM_VFOA:
                case RigParamX.PM_VFOB:
                case RigParamX.PM_VFOEQUAL:
                case RigParamX.PM_VFOSWAP:
                case RigParamX.PM_SPLITON:
                case RigParamX.PM_SPLITOFF:
                case RigParamX.PM_RITON:
                case RigParamX.PM_RITOFF:
                case RigParamX.PM_XITON:
                case RigParamX.PM_XITOFF:
                case RigParamX.PM_RX:
                case RigParamX.PM_TX:
                case RigParamX.PM_DIG_U:
                case RigParamX.PM_DIG_L:
                default:
                    Mode = "Other";
                    break;
            }
        }

        public void Dispose()
        {
            try
            {
                if (OmniRigEngine != null && RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    Marshal.ReleaseComObject(OmniRigEngine);
                }
            }
            catch (Exception e)
            {
                throw new AggregateException(e);
            }
        }
    }
}