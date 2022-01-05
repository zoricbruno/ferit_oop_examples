using System;
using System.Runtime.Serialization;

namespace Examples.Examples_Av7.Solar
{
    [Serializable]
    internal class EfficiencyTooLowException : Exception
    {
        private double currentEfficiency;

        public EfficiencyTooLowException()
        {
        }

        public EfficiencyTooLowException(double currentEfficiency):
            base($"Efficiency of {currentEfficiency} is too low.")
        {
            CurrentEfficiency = currentEfficiency;
        }

        public EfficiencyTooLowException(string message) : base(message)
        {
        }

        public double CurrentEfficiency { get => currentEfficiency; set => currentEfficiency = value; }
    }
}