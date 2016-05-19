using System;
using System.Collections.Generic;
using System.Text;

namespace LibOutfitEnforcer
{
    public class AppCommandArgument
    {
        public AppCommandArgument(int p_ArgSeqNo, int p_ArgValue)
        {
            this.ArgSeqNo = p_ArgSeqNo;
            this.ArgValue = p_ArgValue;
        }
        public int ArgSeqNo;
        public int ArgValue;
    }
}
