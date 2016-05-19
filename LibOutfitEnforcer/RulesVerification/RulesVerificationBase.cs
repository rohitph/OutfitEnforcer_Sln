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

        protected bool IsClothingItemWornBefore(Commands p_RequiredClothingItem, AppCommandArgument p_arg)
        {
            bool bTempIsValid = false;
            for (int i = 0; i < p_arg.ArgSeqNo; i++)
            {
                if (m_AppArgs.Value(i) == (int)p_RequiredClothingItem)
                {
                    bTempIsValid = true;
                    break;
                }
            }
            return bTempIsValid;
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
            //Make sure pajamas are taken off before anything else can be put on
            if (p_arg.ArgSeqNo == 0 && p_arg.ArgValue != (int)Commands.TakeOffPajamas) return false;

            //Only 1 piece of each type of clothing may be put on
            for (int i = 0; i < p_arg.ArgSeqNo; i++)
            {
                if (p_arg.ArgValue == m_AppArgs.Value(i)) return false;
            }

            switch (p_arg.ArgValue)
            {
                case (int)Commands.PutOnFootwear:
                    //Pants must be put on before shoes
                    return this.IsClothingItemWornBefore(Commands.PutOnPants, p_arg);

                case (int)Commands.PutOnHeadwear:
                    //The shirt must be put on before the headwear 
                    return this.IsClothingItemWornBefore(Commands.PutOnShirt, p_arg);

                case (int)Commands.LeaveHouse:
                    //You cannot leave the house until all items of clothing are on 

                    int iTotalItemsBeforeLeaving = ClothingItemsRequired.Count + 1; //1 step of removing Pj's
                    return (p_arg.ArgSeqNo < iTotalItemsBeforeLeaving) ? false : true;

                default:
                    return true;
            }

        }
        #endregion

    }
}
