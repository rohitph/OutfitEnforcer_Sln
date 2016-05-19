using System;

namespace LibOutfitEnforcer
{
    public class TemperatureTypeMissing : Exception
    {
        public TemperatureTypeMissing(string message): base(message)
        {
        }

        public TemperatureTypeMissing(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}