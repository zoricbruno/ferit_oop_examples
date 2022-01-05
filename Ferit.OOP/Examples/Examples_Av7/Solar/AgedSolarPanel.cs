namespace Examples.Examples_Av7.Solar
{
    public class AgedSolarPanel : SolarPanel
    {
        private const double MinEfficiency = 0.02;
        private double age;
        private double agingFactor;

        public AgedSolarPanel(double age, double agingFactor, double width, double heigh, double efficiency)
            : base(width, heigh, efficiency)
        {
            this.Age = age;
            this.AgingFactor = agingFactor;
        }

        public double AgingFactor
        {
            get { return agingFactor; }
            set {
                if (value < 0.0)
                {
                    value = 0.0;
                }
                else if (value > 0.1) 
                {
                    value = 0.1;
                }
                agingFactor = value; 
            }
        }


        public double Age
        {
            get { return age; }
            set { age = value; }
        }

        public void IncrementAge() { age++; }

        public override double GetYearlyEnergyProduction()
        {
            double currentEfficiency = Efficiency - (Age * AgingFactor);
            if (currentEfficiency < MinEfficiency)
            {
                throw new EfficiencyTooLowException(currentEfficiency);
            }
            return GetArea() * currentEfficiency * ProductionFactor;
        }
    }
}
