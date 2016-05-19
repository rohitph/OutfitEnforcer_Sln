using System;
using System.Collections.Generic;
using System.Text;

namespace LibOutfitEnforcer.RulesVerification
{
    public abstract class RulesVerificationBase
    {
        private AppArguments m_AppArgs;
        protected List<Commands> ClothingItemsRequired = new List<Commands>();

        #region Base constructor
        public RulesVerificationBase(AppArguments p_AppArgs)
        {
            m_AppArgs = p_AppArgs;
            SetClothingItemsRequired();

        }
        #endregion

        #region Abstract Methods

        abstract protected bool VerifySpecificRules(AppCommandArgument p_arg);
        abstract protected void SetClothingItemsRequired();

        #endregion

        protected AppArguments AppArgs
        {
            get
            {
                return m_AppArgs;
            }
        }

        public bool Verify(AppCommandArgument p_arg)
        {

            return (VerifyCommonRules(p_arg) && VerifySpecificRules(p_arg));

        }

        #region Private Methods
        //Common
        //•	Pajamas must be taken off before anything else can be put on
        //•	Only 1 piece of each type of clothing may be put on
        //•	Pants must be put on before shoes
        //•	The shirt must be put on before the headwear or jacket
        //•	You cannot leave the house until all items of clothing are on 
        private bool VerifyCommonRules(AppCommandArgument p_arg)
        {
            bool bTempIsValid;
            //Make sure pajamas are taken off before anything else can be put on
            if (p_arg.ArgSeqNo == 0 && p_arg.ArgValue != (int)Commands.TakeOffPajamas) return false;

            //Only 1 piece of each type of clothing may be put on
            for (int i = 0; i < p_arg.ArgSeqNo; i++)
            {
                if (p_arg.ArgValue == m_AppArgs.Value(i)) return false;
            }

            //Pants must be put on before shoes
            if (p_arg.ArgValue == (int)Commands.PutOnFootwear) //1 = Shoes ; 6 = pants
            {
                bTempIsValid = false;
                for (int i = 0; i < p_arg.ArgSeqNo; i++)
                {
                    //If Pants are worn
                    if (m_AppArgs.Value(i) == (int)Commands.PutOnPants)
                    {
                        bTempIsValid = true;
                        break;
                    }
                }
                if (!bTempIsValid) return false;
            }

            //The shirt must be put on before the headwear
            if (p_arg.ArgValue == (int)Commands.PutOnHeadwear) //2 = headwear ; 4 = Shirt
            {
                bTempIsValid = false;
                for (int i = 0; i < p_arg.ArgSeqNo; i++)
                {
                    //If Shirt is worn
                    if (m_AppArgs.Value(i) == (int)Commands.PutOnShirt)
                    {
                        bTempIsValid = true;
                        break;
                    }
                }
                if (!bTempIsValid) return false;
            }

            //You cannot leave the house until all items of clothing are on
            if (p_arg.ArgValue == (int)Commands.LeaveHouse)
            {
                int iTotalItemsBeforeLeaving = ClothingItemsRequired.Count + 1; //1 step of removing Pj's
                if (p_arg.ArgSeqNo < iTotalItemsBeforeLeaving) return false;

            }
            return true;

        }
        #endregion
    }
}
