using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibOutfitEnforcer
{
    public delegate void ProcessException(Exception ex);
    public interface IExecute
    {
        string Execute(string p_sCommandParams, ProcessException p_exProcessException);
    }
}
