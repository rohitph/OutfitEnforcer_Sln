using System;
using System.Collections.Generic;
using System.Text;

namespace LibOutfitEnforcer
{
    public class ExecuteProgram
    {

        public delegate void ProcessException(Exception ex);

        public ExecuteProgram()
        {
        }

        public string Execute(string p_sCommandParams, ProcessException p_exProcessException)
        {
            AppArguments m_AppArgs;
        
            StringBuilder sbOutputString = new StringBuilder("");
            Responses.ResponseBase objResponse;
            RulesVerification.RulesVerificationBase objRulesVerify;

            string sTempResult;
            try
            {
                m_AppArgs = new AppArguments(p_sCommandParams);

                switch (m_AppArgs.TemperatureType)
                {
                    case TemperatureTypes.HotTemp:
                        objResponse = new Responses.ResponseHot();
                        objRulesVerify = new RulesVerification.RuleVerificationHot(m_AppArgs);
                        break;
                    case TemperatureTypes.ColdTemp:
                        objResponse = new Responses.ResponseCold();
                        objRulesVerify = new RulesVerification.RuleVerificationCold(m_AppArgs);
                        break;
                    default:
                        throw new TemperatureTypeMissing(m_AppArgs.TemperatureType + " currently not supported");
                }

                foreach (AppCommandArgument arg in m_AppArgs)
                {
                    sTempResult = "fail";

                    if (objRulesVerify.Verify(arg)) sTempResult = objResponse.OutputResponse(arg);

                    sbOutputString.Append(sTempResult + ", ");

                    if (sTempResult == "fail") break;

                }

                sbOutputString.Remove(sbOutputString.Length-2 , 2);
                return sbOutputString.ToString();
            }
            catch (Exception ex)
            {
                p_exProcessException(ex);
                return "";
            }
        }     
        
    }
}
