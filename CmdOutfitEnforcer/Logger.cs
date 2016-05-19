using System;
using System.Collections.Generic;
using System.Text;

namespace CmdOutfitEnforcer
{
    class Logger
    {
        public void LogExceptions(Exception p_ex)
        {
            Console.WriteLine(p_ex.Message);

            //Code to save log file
        }
    }
}
