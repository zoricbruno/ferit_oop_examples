using System;
using System.Diagnostics.CodeAnalysis;

namespace Examples.Examples_Av7.Solar
{
    public class SolarPanel
    {
        public const int ProductionFactor = 1300;
        private double width;
        private double height;
        private double efficiency; // U rasponu[0. 1 − 1. 0]

        public SolarPanel() : this(1, 1, 0.1) { }

        public SolarPanel(double width, double height, double efficiency)
        {
            this.width = width;
            this.height = height;
            this.Efficiency = efficiency;
        }

        public double Width { get { return width; } set { width = value; } }
        public double Height { get { return height; } set { height = value; } }
        public double Efficiency
        {
            get { return efficiency; }
            set
            {
                if (value < 0.1)
                {
                    value = 0.1;
                }
                else if (value > 1.0)
                {
                    value = 1.0;
                }
                efficiency = value;
            }
        }

        public double GetArea() { return Width * Height; }
        
        public virtual double GetYearlyEnergyProduction()
        {
            return GetArea() * Efficiency * ProductionFactor;
        }

        public static bool operator ==(SolarPanel left, SolarPanel right)
        {
            if (left is null) return false;
            if (right is null) return false;
            if (ReferenceEquals(left, right)) return true;
            return left.Width == right.Width &&
                left.Height == right.Height &&
                left.Efficiency == right.Efficiency;
        }

        public static bool operator !=(SolarPanel left, SolarPanel right)
        {
            return !(left == right);
        }
    }
}
