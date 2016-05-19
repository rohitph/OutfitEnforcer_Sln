using System;
using System.Collections.Generic;
using System.Text;

namespace LibOutfitEnforcer
{
    public class CommandResponse
    {
        public Commands CommandID;
        public string ResponseText;


        public CommandResponse(Commands p_iCommandID, string p_sResponseText)
        {
            this.CommandID = p_iCommandID;
            this.ResponseText = p_sResponseText;

        }
    }
}
