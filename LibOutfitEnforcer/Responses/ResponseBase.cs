using System;
using System.Collections.Generic;
using System.Text;

namespace LibOutfitEnforcer.Responses
{
    public abstract class ResponseBase
    {
        protected List<CommandResponse> CmdResponses = new List<CommandResponse>();

        #region Base constructor
        public ResponseBase()
        {
            FillResponses();

        }
        #endregion

        #region Abstract Methods

        abstract protected void FillResponses();

        #endregion

        public string OutputResponse(AppCommandArgument p_arg)
        {

            return this.GetCommandResponseText(p_arg);

        }

        #region Private Methods
 
        private string GetCommandResponseText(AppCommandArgument p_arg)
        {

            foreach (CommandResponse objCmdRes in CmdResponses)
            {
                if ((int)objCmdRes.CommandID == p_arg.ArgValue) return objCmdRes.ResponseText;
            }

            return null;
        }
        #endregion
    }
}
