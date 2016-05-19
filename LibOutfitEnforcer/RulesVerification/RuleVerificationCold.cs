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
            bool bTempIsValid;
            //Socks must be put on before shoes
            if (p_arg.ArgValue == (int)Commands.PutOnFootwear)
            {
                for (int i = 0; i < p_arg.ArgSeqNo; i++)
                {
                    if (p_arg.ArgValue == AppArgs.Value(i)) return false;
                }
            }

            //The shirt must be put on before the jacket
            if (p_arg.ArgValue == (int)Commands.PutOnJacket)
            {
                bTempIsValid = false;
                for (int i = 0; i < p_arg.ArgSeqNo; i++)
                {
                    //If Shirt is worn
                    if (AppArgs.Value(i) == (int)Commands.PutOnShirt)
                    {
                        bTempIsValid = true;
                        break;
                    }
                }
                if (!bTempIsValid) return false;
            }

            return true;
        }
    }
}
