using System;
using System.Diagnostics;

namespace Examples.Examples_Av7.Solar
{
    public static class SolarExample
    {
        public static void RunDemo()
        {
            // Z1
            SolarPanel smallPanel = new SolarPanel();
            SolarPanel largePanel = new SolarPanel(2, 2, 0.7);
            smallPanel.Efficiency = 0.9;
            Console.WriteLine($" Panel size: { smallPanel.Width } { smallPanel.Height }");

            SolarPanel testPanel = new SolarPanel(2, 2, 1.7);
            Debug.Assert(testPanel.Efficiency == 1.0, "Panel efficiency should not exceed bounds.");
            testPanel.Efficiency = -0.1;
            Debug.Assert(testPanel.Efficiency == 0.1, "Panel efficiency should not exceed bounds.");

            // Z2
            testPanel = new SolarPanel(2, 2, 1.0);
            double totalEnergy = testPanel.GetYearlyEnergyProduction();
            Debug.Assert(totalEnergy == 5200, "Yearly energy production calculation is incorrect.");

            testPanel = new SolarPanel(2, 2, 0.5);
            totalEnergy = testPanel.GetYearlyEnergyProduction();
            Debug.Assert(totalEnergy == 2600, "Yearly energy production calculation is incorrect.");

            // Z3
            SolarPanel[] panels = new SolarPanel[] {
                new SolarPanel(1,1,1.0),
                new SolarPanel(2,2,1.0),
                new SolarPanel(3,4,1.0),
                new SolarPanel(1,1,0.9),
                new SolarPanel(4,4,0.5),
            };
            Debug.Assert(Utilities.AreUnique(panels) == true, "Panels are unique");
            panels[0].Efficiency = 0.9;
            Debug.Assert(Utilities.AreUnique(panels) == false, "Panels are not unique");

            // Z4
            AgedSolarPanel agedPanel = new AgedSolarPanel(3, 0.2, 2, 2, 1.0);
            Debug.Assert(agedPanel.AgingFactor == 0.1, "Aging factor should not be out of bounds");
            agedPanel.IncrementAge();
            Debug.Assert(agedPanel.Age == 4, "Age should increment.");

            // Z5
            agedPanel = new AgedSolarPanel(10, 0.1, 2, 2, 1.0);
            try
            {
                agedPanel.GetYearlyEnergyProduction();
            }
            catch (EfficiencyTooLowException exception)
            {
                Console.WriteLine(exception.Message);
                Console.WriteLine(exception.CurrentEfficiency);
            }
            agedPanel = new AgedSolarPanel(10, 0.0, 2, 2, 1.0);
            Debug.Assert(agedPanel.GetYearlyEnergyProduction() == 5200);

            // Z6
            Utilities.RunTask6();
        }
    }
}
