// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo
namespace OmniRigWrapper
{
    public static class OmniRigConstants
    {
        // Constants for enum RigParamX
        public const int PM_UNKNOWN = 0x00000001;
        public const int PM_FREQ = 0x00000002;
        public const int PM_FREQA = 0x00000004;
        public const int PM_FREQB = 0x00000008;
        public const int PM_PITCH = 0x00000010;
        public const int PM_RITOFFSET = 0x00000020;
        public const int PM_RIT0 = 0x00000040;
        public const int PM_VFOAA = 0x00000080;
        public const int PM_VFOAB = 0x00000100;
        public const int PM_VFOBA = 0x00000200;
        public const int PM_VFOBB = 0x00000400;
        public const int PM_VFOA = 0x00000800;
        public const int PM_VFOB = 0x00001000;
        public const int PM_VFOEQUAL = 0x00002000;
        public const int PM_VFOSWAP = 0x00004000;
        public const int PM_SPLITON = 0x00008000;
        public const int PM_SPLITOFF = 0x00010000;
        public const int PM_RITON = 0x00020000;
        public const int PM_RITOFF = 0x00040000;
        public const int PM_XITON = 0x00080000;
        public const int PM_XITOFF = 0x00100000;
        public const int PM_RX = 0x00200000;
        public const int PM_TX = 0x00400000;
        public const int PM_CW_U = 0x00800000;
        public const int PM_CW_L = 0x01000000;
        public const int PM_SSB_U = 0x02000000;
        public const int PM_SSB_L = 0x04000000;
        public const int PM_DIG_U = 0x08000000;
        public const int PM_DIG_L = 0x10000000;
        public const int PM_AM = 0x20000000;
        public const int PM_FM = 0x40000000;

        // Constants for enum RigStatusX
        public const int ST_NOTCONFIGURED = 0x00000000;
        public const int ST_DISABLED = 0x00000001;
        public const int ST_PORTBUSY = 0x00000002;
        public const int ST_NOTRESPONDING = 0x00000003;
        public const int ST_ONLINE = 0x00000004;

        public const string FLD_RX = "RX";
    }
}