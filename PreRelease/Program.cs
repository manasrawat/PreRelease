using System;
using System.Collections.Generic;
using static System.Console;

namespace PreRelease {
    class Program {

        static List<bool> tempsInRange = new List<bool>();
        static double tempRange;
        
        static void Main(string[] args) {
            Title = "Manas Rawat 10W: EoY Pre-Release Task";
            #region Task 3
            IterateOverTemps();
            int outOfRanges = 0;
            foreach (bool inRange in tempsInRange) if (!inRange) outOfRanges += 1;
            WriteLine("This baby is " + (tempRange > 1 || outOfRanges > 2 ? "in urgent need of medical attention!" : "healthy"));
            #endregion
            Read();
        }

        static void CheckIfTempIsInRange(double temp) {
            #region Task 1
            bool tooLow = temp < 36.0, tooHigh = temp > 37.5;
            tempsInRange.Add(tooLow || tooHigh ? false : true);
            WriteLine("The temperature is " + (tooLow ? "too low" : tooHigh ? "too high" : "in the acceptable range") + ". Press <enter> to continue");
            #endregion
        }

        static void IterateOverTemps() {
            #region Task 2
            double[] temps = new double[19];
            for (int i = 0; i < temps.Length; i++) {
                int mins = i * 10, hours = Convert.ToInt32(mins / 60);
                WriteLine("Please enter the temperature of the baby " +
                    (mins == 0 ? "at the start" : "after " +
                    (mins < 60 ? mins + " mins" : hours + " hour" +
                    (mins == 60 ? "" : mins % 60 == 0 ? "s" : ", " + (mins % 60) + " mins")
                    )));
                double input;
                while (!Double.TryParse(ReadLine(), out input)) WriteLine("Invalid input. Try again");
                temps[i] = Math.Round(Convert.ToDouble(input), 1);
                CheckIfTempIsInRange(temps[i]);
                ConsoleKeyInfo c;
                do {
                    c = ReadKey();
                } while (c.Key != ConsoleKey.Enter);
                Clear();
            }
            double max = temps[0], min = temps[0];
            for (int i = 1; i < temps.Length; i++) {
                if (temps[i] > max)  max = temps[i];
                else if (temps[i] < min) min = temps[i];
            }
            tempRange = max - min;
            WriteLine("Greatest temperature: " + max + "\nLowest temperature: " + min + "\nTemperature range: " + tempRange);
            #endregion
        }
    }
}