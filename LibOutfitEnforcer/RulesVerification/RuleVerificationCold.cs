using System;
using System.Collections.Generic;
using System.Text;

namespace LibOutfitEnforcer.RulesVerification
{
    //"Cold" rules
    //Socks must be put on before shoes
    //The shirt must be put on before the jacket
    class RuleVerificationCold : RulesVerification.RulesVerificationBase
    {
        public RuleVerificationCold(AppArguments AppArgs) : base(AppArgs) { }

        protected override void SetClothingItemsRequired()
        {
            ClothingItemsRequired.Add(Commands.PutOnFootwear);
            ClothingItemsRequired.Add(Commands.PutOnHeadwear);
            ClothingItemsRequired.Add(Commands.PutOnSocks);
            ClothingItemsRequired.Add(Commands.PutOnShirt);
            ClothingItemsRequired.Add(Commands.PutOnJacket);
            ClothingItemsRequired.Add(Commands.PutOnPants);
        }

        protected override bool VerifySpecificRules(AppCommandArgument p_arg)
        {
            switch (p_arg.ArgValue)
            {
                case (int)Commands.PutOnFootwear:
                    return base.IsClothingItemWornBefore(Commands.PutOnSocks, p_arg);

                case (int)Commands.PutOnJacket:
                    return base.IsClothingItemWornBefore(Commands.PutOnShirt, p_arg);

                default:
                    return true;
            }
            
        }
    }
}
