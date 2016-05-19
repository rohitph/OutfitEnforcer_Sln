using System;
using System.Collections.Generic;
using System.Text;

namespace LibOutfitEnforcer.Responses
{
    class ResponseHot : Responses.ResponseBase
    {
        public ResponseHot() : base() { }

        protected override void FillResponses()
        {
            CmdResponses.Add(new CommandResponse(Commands.PutOnFootwear, "sandals"));
            CmdResponses.Add(new CommandResponse(Commands.PutOnHeadwear, "sun visor"));
            CmdResponses.Add(new CommandResponse(Commands.PutOnSocks, "fail"));
            CmdResponses.Add(new CommandResponse(Commands.PutOnShirt, "t-shirt"));
            CmdResponses.Add(new CommandResponse(Commands.PutOnJacket, "fail"));
            CmdResponses.Add(new CommandResponse(Commands.PutOnPants, "shorts"));
            CmdResponses.Add(new CommandResponse(Commands.LeaveHouse, "leaving house"));
            CmdResponses.Add(new CommandResponse(Commands.TakeOffPajamas, "Removing PJs"));
        }

    }

    
}
