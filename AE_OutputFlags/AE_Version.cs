using System;

namespace AE_OutputFlags
{
    enum PF_Stage
    {
        DEVELOP,
        ALPHA,
        BETA,
        RELEASE
    };

    public class AE_Version
    {

        public const int PF_Vers_BUILD_BITS = 0x01ff;
        public const int PF_Vers_BUILD_SHIFT = 0;
        public const int PF_Vers_STAGE_BITS = 0x03;
        public const int PF_Vers_STAGE_SHIFT = 9;
        public const int PF_Vers_BUGFIX_BITS = 0xf;
        public const int PF_Vers_BUGFIX_SHIFT = 11;
        public const int PF_Vers_SUBVERS_BITS = 0xf;
        public const int PF_Vers_SUBVERS_SHIFT = 15;
        public const int PF_Vers_VERS_BITS = 0x7;   // incomplete without high bits, below
        public const int PF_Vers_VERS_SHIFT = 19;
        // skipping these bits for similarity to Up_Vers_ARCH_*, currently unused in PF
        public const int PF_Vers_VERS_HIGH_BITS = 0xf;  // expand version max from 7 to 127
        public const int PF_Vers_VERS_HIGH_SHIFT = 26;

        // b/c we are stripping the stand alone vers value for two fields
        public const int PF_Vers_VERS_LOW_SHIFT = 3;
        public static ulong PF_Vers_VERS_HIGH(ulong vers)
        {
            return vers >> PF_Vers_VERS_LOW_SHIFT;
        }
        public static ulong PF_VERSION(ulong vers, ulong subvers, ulong bugvers, ulong stage, ulong build)
        {
            ulong ret = 0;
            ret |= (PF_Vers_VERS_HIGH(vers) & PF_Vers_VERS_HIGH_BITS) << PF_Vers_VERS_HIGH_SHIFT;
            ret |= (vers & PF_Vers_VERS_BITS) << PF_Vers_VERS_SHIFT;
            ret |= (subvers & PF_Vers_SUBVERS_BITS) << PF_Vers_SUBVERS_SHIFT;
            ret |= (bugvers & PF_Vers_BUGFIX_BITS) << PF_Vers_BUGFIX_SHIFT;
            ret |= (stage & PF_Vers_STAGE_BITS) << PF_Vers_STAGE_SHIFT;
            ret |= (build & PF_Vers_BUILD_BITS) << PF_Vers_BUILD_SHIFT;
            return ret;
        }
        public static ulong PF_Version_VERS(ulong vers)
        {
            return ((vers >> PF_Vers_VERS_SHIFT) & PF_Vers_VERS_BITS) + (((vers >> PF_Vers_VERS_HIGH_SHIFT) & PF_Vers_VERS_HIGH_BITS) << PF_Vers_VERS_LOW_SHIFT);
        }
        public static ulong PF_Version_SUBVERS(ulong vers)
        {
            return (vers >> PF_Vers_SUBVERS_SHIFT) & PF_Vers_SUBVERS_BITS;
        }

        public static ulong PF_Version_BUGFIX(ulong vers)
        {
            return (vers >> PF_Vers_BUGFIX_SHIFT) & PF_Vers_BUGFIX_BITS;
        }

        public static ulong PF_Version_STAGE(ulong vers)
        {
            return (vers >> PF_Vers_STAGE_SHIFT) & PF_Vers_STAGE_BITS;
        }

        public static ulong PF_Version_BUILD(ulong vers)
        {
            return (vers >> PF_Vers_BUILD_SHIFT) & PF_Vers_BUILD_BITS;
        }

        private ulong m_major = 0;
        public ulong Major_Version { get { return m_major; } set { m_major = value; } }
        private ulong m_minor = 0;
        public ulong Minor_Version { get { return m_minor; } set { m_minor = value; } }
        private ulong m_bug = 0;
        public ulong Bug_Version { get { return m_bug; } set { m_bug = value; } }
        private ulong m_stage = 0;
        public ulong Stage_Version { get { return m_stage; } set { m_stage = value; } }
        private ulong m_build = 0;
        public ulong Build_Version { get { return m_build; } set { m_build = value; } }

        public AE_Version()
        {

        }
        public ulong AEVersion
        {
            get { return PF_VERSION(m_major, m_minor, m_bug, m_stage, m_build); }
            set
            {
                m_major = PF_Version_VERS(value);
                m_minor = PF_Version_SUBVERS(value);
                m_bug = PF_Version_BUGFIX(value);
                m_stage = PF_Version_STAGE(value);
                m_build = PF_Version_BUILD(value);
            }
        }
        public override string ToString()
        {
            string s =
            "#define MAJOR_VERSION	{0}\r\n" +
            "#define MINOR_VERSION	{1}\r\n" +
            "#define BUG_VERSION	{2}\r\n" +
            "#define STAGE_VERSION	{3}\r\n" +
            "#define BUILD_VERSION	{4}\r\n" +
            "\r\n" +
            "\r\n" +
            "//上の定数とVERSIONの値が違うとエラーになる\r\n" +
            "\r\n" +
            "#define VERSION {5}\r\n";

            return String.Format(
                s,
                m_major,
                m_minor,
                m_bug,
                m_stage,
                m_build,
                AEVersion);
        }

    }
}
