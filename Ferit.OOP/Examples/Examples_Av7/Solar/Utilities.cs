using System;
using System.Collections.Generic;

namespace Examples.Examples_Av7.Solar
{
    public static class Utilities
    {
        public static bool AreUnique(SolarPanel[] panels)
        {
            for (int i = 0; i < panels.Length; i++)
            {
                for (int j = i+1; j < panels.Length; j++)
                {
                    if (panels[i] == panels[j]) 
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static void RunTask6()
        {
            Console.WriteLine("Enter number of elements:");
            int n = int.Parse(Console.ReadLine());
            List<SolarPanel> panels = new List<SolarPanel>();
            Random generator = new Random();
            for (int i = 0; i < n; i++)
            {
                if (i < n / 2)
                {
                    panels.Add(generator.NextSolarPanel());
                }
                else
                {
                    panels.Add(generator.NextAgedSolarPanel());
                }
            }

            double maxEnergy = panels[0].GetYearlyEnergyProduction();
            for (int i = 1; i < panels.Count; i++)
            {
                try
                {
                    double energy = panels[i].GetYearlyEnergyProduction();
                    if (energy > maxEnergy)
                    {
                        maxEnergy = energy;
                    }
                }
                catch (EfficiencyTooLowException exception)
                {
                    Console.WriteLine($"{exception.Message}, efficiency={exception.CurrentEfficiency}");
                }
            }
            Console.WriteLine($"Max energy produced: {maxEnergy}");
        }

        public static SolarPanel NextSolarPanel(this Random generator) 
        {
            return new SolarPanel(
                generator.NextDouble() * 4 + 1,
                generator.NextDouble() * 4 + 1,
                generator.NextDouble() * 0.9 + 0.1
            );
        }
        public static AgedSolarPanel NextAgedSolarPanel(this Random generator)
        {
            return new AgedSolarPanel(
                generator.NextDouble() * 10,
                generator.NextDouble() * 0.1,
                generator.NextDouble() * 4 + 1,
                generator.NextDouble() * 4 + 1,
                generator.NextDouble() * 0.9 + 0.1
            );
        }
    }
}
