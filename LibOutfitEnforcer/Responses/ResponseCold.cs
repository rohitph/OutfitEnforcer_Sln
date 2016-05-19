using System;
using System.Collections.Generic;
using System.Text;


namespace LibOutfitEnforcer.Responses
{
    public class ResponseCold : Responses.ResponseBase
    {
        public ResponseCold() : base() { }

        protected override void FillResponses()
        {
            CmdResponses.Add(new CommandResponse(Commands.PutOnFootwear, "boots"));
            CmdResponses.Add(new CommandResponse(Commands.PutOnHeadwear, "hat"));
            CmdResponses.Add(new CommandResponse(Commands.PutOnSocks, "socks"));
            CmdResponses.Add(new CommandResponse(Commands.PutOnShirt, "shirt"));
            CmdResponses.Add(new CommandResponse(Commands.PutOnJacket, "jacket"));
            CmdResponses.Add(new CommandResponse(Commands.PutOnPants, "pants"));
            CmdResponses.Add(new CommandResponse(Commands.LeaveHouse, "leaving house"));
            CmdResponses.Add(new CommandResponse(Commands.TakeOffPajamas, "Removing PJs"));
        }

    }
}
