using System;
using System.Collections.Generic;
using System.Text;


namespace LibOutfitEnforcer
{
    public class AppArguments : System.Collections.IEnumerable
    {
#region "Private member variables"
        private List<AppCommandArgument> m_listArguments = new List<AppCommandArgument>();
        private string m_TempType;
#endregion
        
#region "Constructors"
        public AppArguments(string p_ArgumentString)
        {
            int iCommandArg;
            bool bValidCommand;

            string sArgumentString = p_ArgumentString.Trim();
            this.SetTemperatureType(sArgumentString);

            sArgumentString = sArgumentString.Remove(0,m_TempType.Length);

            string[] arrArgs = sArgumentString.Split(',');
            for (int i = 0; i <= arrArgs.Length-1; i++)
            {
                bValidCommand = int.TryParse(arrArgs[i].Trim(), out iCommandArg);
                if (!bValidCommand) throw new InvalidCommandArgument("Invalid command: " + arrArgs[i].Trim() + "; Integer values are accepted");

                //Verify command input
                bValidCommand = false;
                               
                foreach (int iCmd in Enum.GetValues(typeof(Commands)))
                {
                    if (iCommandArg == iCmd)
                    {
                        bValidCommand = true;
                        break;
                    }
                }
                if (!bValidCommand) throw new InvalidCommandArgument("Invalid command: " + arrArgs[i].Trim() + "; Valid Commands are: " + this.ValidArgValues());

                m_listArguments.Add(new AppCommandArgument(i, iCommandArg));

            }

        }
        #endregion
        
#region "Public Properties"
        public string TemperatureType
        {
            get
            {
                return m_TempType;
            }
        }

        #endregion
        
        public int Count()
        {
            return m_listArguments.Count;
        }

        /// <summary>
        /// Returns argument value for a given sequence number
        /// </summary>
        /// <param name="p_SeqNo"></param>
        /// <returns>Argument Value</returns>
        public int Value(int p_SeqNo)
        {
            foreach (AppCommandArgument objArg in m_listArguments)
            {
                if (objArg.ArgSeqNo == p_SeqNo) return objArg.ArgValue;
            }
            return -1;
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return m_listArguments.GetEnumerator();

        }

#region "Private methods"

        private void SetTemperatureType(string p_ArgumentString)
        {
            char[] cArgs = p_ArgumentString.ToCharArray();
            StringBuilder sTempType = new StringBuilder("");
            for (int i = 0; i < cArgs.Length; i++)
            {
                if ((! char.IsNumber(cArgs[i])) & (! cArgs[i].Equals(' ')))
                {
                    sTempType.Append(cArgs[i]);
                }
                else break;
            }
            m_TempType = sTempType.ToString().Trim().ToUpper();

            if ((m_TempType.Length == 0) | ((m_TempType != TemperatureTypes.HotTemp) & (m_TempType != TemperatureTypes.ColdTemp)))
                throw new TemperatureTypeMissing("Valid temperature types are HOT and COLD. Need to be the 1st argument");
        }

        private string ValidArgValues()
        {
            StringBuilder sb = new StringBuilder("");
            Array Vals = Enum.GetValues(typeof(Commands));
            foreach (Commands cmd in Vals)
            {
                sb.Append((int)cmd + ",");

            }
            sb.Remove(sb.Length - 1, 1);
            return sb.ToString();
        }
#endregion
    } 
}
