/*using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter the capacity of the water tank (Vmax):");
        double Vmax = double.Parse(Console.ReadLine());

        Console.WriteLine("Enter the average volume of water consumed during each break (Vdrink):");
        double Vdrink = double.Parse(Console.ReadLine());

        Console.WriteLine("Enter the volume of water that can be added in each refill cycle (Vfill):");
        double Vfill = double.Parse(Console.ReadLine());

        Console.WriteLine("Enter the duration between breaks (tday):");
        int tday = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the duration between refill cycles (tfill):");
        int tfill = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the total duration of the activity from start to finish of the day:");
        int totalDuration = int.Parse(Console.ReadLine());

        // Check if the conditions are met
        if (Vdrink <= Vmax && tday >= Vdrink && tday >= tfill)
        {
            double remainingWater = Vmax;
            bool hasOverflow = false;

            for (int i = 0; i < totalDuration; i++)
            {
                if (i % tday == 0)
                {
                    if (remainingWater < Vdrink)
                    {
                        Console.WriteLine("Not Enough Water");
                        return;
                    }

                    remainingWater -= Vdrink;
                }

                if (i % tfill == 0)
                {
                    double spaceAvailable = Vmax - remainingWater;
                    if (spaceAvailable > 0)
                    {
                        remainingWater += Math.Min(Vfill, spaceAvailable);
                        if (remainingWater > Vmax)
                        {
                            hasOverflow = true;
                        }
                    }
                }
            }

            if (hasOverflow)
            {
                Console.WriteLine("Overflow Water");
            }
            else
            {
                if (remainingWater == Vmax)
                {
                    Console.WriteLine("Enough Water");
                }
                else
                {
                    Console.WriteLine("{0} left", remainingWater);
                }
            }
        }
        else
        {
            Console.WriteLine("Invalid input values. Please ensure that Vdrink <= Vmax and tday >= Vdrink and tday >= tfill");
        }
    }
}
using System;

class Program
{
    static void Main()
    {
        double B1, B2, B3;
        double L = 0;

        Console.WriteLine("Enter the first miscellaneous amount (B1):");
        B1 = double.Parse(Console.ReadLine());

        Console.WriteLine("Enter the second miscellaneous amount (B2):");
        B2 = double.Parse(Console.ReadLine());

        Console.WriteLine("Enter the third miscellaneous amount (B3):");
        B3 = double.Parse(Console.ReadLine());

        while (true)
        {
            Console.WriteLine("Enter the payment amount (Enter a negative or zero value to stop):");
            double paymentAmount = double.Parse(Console.ReadLine());

            if (paymentAmount <= 0)
                break;

            if (B1 >= paymentAmount)
            {
                B1 -= paymentAmount;
            }
            else if (B2 >= paymentAmount)
            {
                B2 -= paymentAmount;
            }
            else if (B3 >= paymentAmount)
            {
                B3 -= paymentAmount;
            }
            else
            {
                L += paymentAmount;
            }
        }

        Console.WriteLine("Balance 1: {0:F2}, Balance 2: {1:F2}, Balance 3: {2:F2}", B1, B2, B3);
        Console.WriteLine("Left: {0:F2}", L);
    }
}*/
using System;

class WaterTankProgram
{
    static void Main()
    {
        double Vmax = ReadPositiveDouble("Enter the capacity of the water tank (Vmax):");
        double Vdrink = ReadPositiveDouble("Enter the average volume of water consumed during each break (Vdrink):");
        double Vfill = ReadPositiveDouble("Enter the volume of water that can be added in each refill cycle (Vfill):");
        int tday = ReadPositiveInt("Enter the duration between breaks (tday):");
        int tfill = ReadPositiveInt("Enter the duration between refill cycles (tfill):");
        int totalDuration = ReadPositiveInt("Enter the total duration of the activity from start to finish of the day:");

        WaterTankResult result = CalculateWaterTankResult(Vmax, Vdrink, Vfill, tday, tfill, totalDuration);

        Console.WriteLine(result.Message);
        if (result.RemainingWater.HasValue)
        {
            Console.WriteLine("{0:F2} left", result.RemainingWater.Value);
        }
    }

    static WaterTankResult CalculateWaterTankResult(double Vmax, double Vdrink, double Vfill, int tday, int tfill, int totalDuration)
    {
        if (Vdrink <= Vmax && tday >= Vdrink && tday >= tfill)
        {
            double remainingWater = Vmax;
            bool hasOverflow = false;

            for (int i = 0; i < totalDuration; i++)
            {
                if (i % tday == 0)
                {
                    if (remainingWater < Vdrink)
                    {
                        return new WaterTankResult("Not Enough Water");
                    }

                    remainingWater -= Vdrink;
                }

                if (i % tfill == 0)
                {
                    double spaceAvailable = Vmax - remainingWater;
                    if (spaceAvailable > 0)
                    {
                        remainingWater += Math.Min(Vfill, spaceAvailable);
                        if (remainingWater > Vmax)
                        {
                            hasOverflow = true;
                        }
                    }
                }
            }

            if (hasOverflow)
            {
                return new WaterTankResult("Overflow Water");
            }
            else
            {
                if (remainingWater == Vmax)
                {
                    return new WaterTankResult("Enough Water");
                }
                else
                {
                    return new WaterTankResult("Enough Water", remainingWater);
                }
            }
        }
        else
        {
            return new WaterTankResult("Invalid input values. Please ensure that Vdrink <= Vmax and tday >= Vdrink and tday >= tfill");
        }
    }

    static double ReadPositiveDouble(string message)
    {
        while (true)
        {
            Console.WriteLine(message);
            double value = double.Parse(Console.ReadLine());

            if (value > 0)
                return value;

            Console.WriteLine("Invalid input. Please enter a positive number.");
        }
    }

    static int ReadPositiveInt(string message)
    {
        while (true)
        {
            Console.WriteLine(message);
            int value = int.Parse(Console.ReadLine());

            if (value > 0)
                return value;

            Console.WriteLine("Invalid input. Please enter a positive number.");
        }
    }

    class WaterTankResult
    {
        public string Message { get; }
        public double? RemainingWater { get; }

        public WaterTankResult(string message)
        {
            Message = message;
            RemainingWater = null;
        }

        public WaterTankResult(string message, double remainingWater)
        {
            Message = message;
            RemainingWater = remainingWater;
        }
    }
}
class TreasurerProgram
{
    static void Treasurer()
    {
        double B1 = ReadPositiveDouble("Enter the first miscellaneous amount (B1):");
        double B2 = ReadPositiveDouble("Enter the second miscellaneous amount (B2):");
        double B3 = ReadPositiveDouble("Enter the third miscellaneous amount (B3):");
        double L = CalculateLeftAmount(B1, B2, B3);

        Console.WriteLine("Balance 1: {0:F2}, Balance 2: {1:F2}, Balance 3: {2:F2}", B1, B2, B3);
        Console.WriteLine("Left: {0:F2}", L);
    }

    static double CalculateLeftAmount(double B1, double B2, double B3)
    {
        double L = 0;

        while (true)
        {
            Console.WriteLine("Enter the payment amount (Enter a negative or zero value to stop):");
            double paymentAmount = double.Parse(Console.ReadLine());

            if (paymentAmount <= 0)
                break;

            if (B1 >= paymentAmount)
            {
                B1 -= paymentAmount;
            }
            else if (B2 >= paymentAmount)
            {
                B2 -= paymentAmount;
            }
            else if (B3 >= paymentAmount)
            {
                B3 -= paymentAmount;
            }
            else
            {
                L += paymentAmount;
            }
        }

        return L;
    }

    static double ReadPositiveDouble(string message)
    {
        while (true)
        {
            Console.WriteLine(message);
            double value = double.Parse(Console.ReadLine());

            if (value > 0)
                return value;

            Console.WriteLine("Invalid input. Please enter a positive number.");
        }
    }
}