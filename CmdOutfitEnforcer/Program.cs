using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibOutfitEnforcer;

namespace CmdOutfitEnforcer
{
    class Program
    {
        static void Main(string[] args)
        {
            string sInput = string.Empty;
            while (sInput != "quit")
            {
                Console.Write("\nInput: ");
                sInput = sInput = Console.ReadLine();
                ExecuteProgram obj = new ExecuteProgram();
                string sOutput = obj.Execute(sInput,new ExecuteProgram.ProcessException((new Logger()).LogExceptions));

                if (sOutput.Length > 0) Console.WriteLine("Output: " + sOutput);
            }

        }
    }
}
