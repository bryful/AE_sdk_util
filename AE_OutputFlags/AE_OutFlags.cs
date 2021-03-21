using Codeplex.Data;
using System;

namespace AE_OutputFlags
{
    public class AE_OutFlags
    {
        private AE_OutFlag[] m_flags = new AE_OutFlag[0];

        public int Count { get { return m_flags.Length; } }
        public AE_OutFlag[] Flags
        {
            get { return m_flags; }
        }

        public AE_OutFlags()
        {

        }
        public void Add(AE_OutFlag itm)
        {
            Array.Resize(ref m_flags, m_flags.Length + 1);
            m_flags[m_flags.Length - 1] = itm;
        }
        public void Clear()
        {
            m_flags = new AE_OutFlag[0];
        }
        public object[] ToObj
        {
            get
            {
                object[] ret = new object[m_flags.Length];
                if (m_flags.Length > 0)
                {
                    for (int i = 0; i < m_flags.Length; i++)
                    {
                        ret[i] = m_flags[i].ToObj();
                    }
                }
                return ret;

            }
        }
        public void FromObj(dynamic obj)
        {
            Clear();
            if (((DynamicJson)obj).IsArray)
            {
                dynamic[] a = (dynamic[])obj;

                if (a.Length > 0)
                {
                    m_flags = new AE_OutFlag[a.Length];
                    for (int i = 0; i < a.Length; i++)
                    {
                        AE_OutFlag of = new AE_OutFlag();
                        of.FromObj(a[i]);
                        m_flags[i] = of;

                    }
                }

            }
        }
    }
}
