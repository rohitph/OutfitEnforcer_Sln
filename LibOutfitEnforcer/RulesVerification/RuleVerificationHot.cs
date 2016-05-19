using System;
using System.Collections.Generic;
using System.Text;

namespace LibOutfitEnforcer.RulesVerification
{
    //"Hot" responses
    //You cannot put on socks when it is hot
    //You cannot put on a jacket when it is hot
    class RuleVerificationHot : RulesVerification.RulesVerificationBase
    {
        public RuleVerificationHot(AppArguments AppArgs) : base(AppArgs) { }

        protected override void SetClothingItemsRequired()
        {
            ClothingItemsRequired.Add(Commands.PutOnFootwear);
            ClothingItemsRequired.Add(Commands.PutOnHeadwear);
            ClothingItemsRequired.Add(Commands.PutOnShirt);
            ClothingItemsRequired.Add(Commands.PutOnPants);

        }

        protected override bool VerifySpecificRules(AppCommandArgument p_arg)
        {
            if (p_arg.ArgValue == (int)Commands.PutOnSocks) return false;

            if (p_arg.ArgValue == (int)Commands.PutOnJacket) return false;

            return true;
        }
    }
}
