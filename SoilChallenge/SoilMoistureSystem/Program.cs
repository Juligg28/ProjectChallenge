using SoilMoistureCalculatorSystem.Parameters;
using static SoilMoistureCalculatorSystem.Parameters.SoilMoistureCalculator;

namespace SoilMoistureCalculatorSystem
{
    public interface IUserInterface
    {
        string ReadLine();
        void WriteLine(string value);
    }

    public class ConsoleUserInterface : IUserInterface
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void WriteLine(string value)
        {
            Console.WriteLine(value);
        }
    }

    public class Program
    {
        public static IUserInterface UserInterface = new ConsoleUserInterface();

        public static void Main(string[] args)
        {
            SoilMoistureCalculator soilMoistureCalculator = new SoilMoistureCalculator(new ConsoleUserInterface());

            const int maxAttempts = 3;

            int soilTypeSelector;
            int moistureLevel;

            try
            {
                soilTypeSelector = GetSoilTypeSelection(maxAttempts, soilMoistureCalculator, UserInterface);
                int maxMoistureValue = soilMoistureCalculator.GetMaxMoistureValue(soilTypeSelector);

                moistureLevel = GetMoistureLevel(maxMoistureValue, maxAttempts, UserInterface);

                if (moistureLevel >= 0)
                {
                    string recommendedAction = soilMoistureCalculator.GetRecommendedAction(soilTypeSelector, moistureLevel);
                    UserInterface.WriteLine(recommendedAction);
                    UserInterface.WriteLine("Application executed successfully.");
                }
                else
                {
                    UserInterface.WriteLine($"Invalid moisture level. Please enter a non-negative integer.");
                }
            }
            catch (FormatException ex)
            {
                UserInterface.WriteLine($"Error: Invalid input. {ex.Message}");
            }
            catch (Exception ex)
            {
                UserInterface.WriteLine($"Error: {ex.Message}");
                UserInterface.WriteLine("Please contact support for further assistance.");
            }
        }

        public static int GetSoilTypeSelection(int maxAttempts, SoilMoistureCalculator soilMoistureCalculator, IUserInterface userInterface)
        {
            int soilTypeSelector;
            int attempts = 0;

            do
            {
                if (attempts > 0)
                {
                    userInterface.WriteLine("Invalid Soil Type Selector. Please enter a value between 1 and 3.");
                }

                userInterface.WriteLine("Enter Soil Type Selector (1, 2, 3): ");
                string soilTypeInput = userInterface.ReadLine();

                if (int.TryParse(soilTypeInput, out soilTypeSelector) && soilTypeSelector >= 1 && soilTypeSelector <= 3)
                {
                    break;
                }

                userInterface.WriteLine("Invalid input. Please enter a valid number corresponding to the given options.");
                attempts++;

                if (attempts == maxAttempts)
                {
                    userInterface.WriteLine("Exceeded the maximum number of attempts for Soil Type Selector.");
                    userInterface.WriteLine("Restart the application to try again.");
                    Environment.Exit(0);
                }
            } while (true);

            return soilTypeSelector;
        }

        public static int GetMoistureLevel(int maxMoistureValue, int maxAttempts, IUserInterface userInterface)
        {
            for (int attempts = 0; attempts < maxAttempts; attempts++)
            {
                if (attempts == maxAttempts - 1)
                {
                    userInterface.WriteLine($"You have one more attempt. Please enter a valid non-negative integer.");
                }
                else if (attempts > 0)
                {
                    userInterface.WriteLine($"Invalid input. Please enter a valid non-negative integer.");
                }

                userInterface.WriteLine($"Enter the soil moisture value according to the current sensor measurement:");
                string input = userInterface.ReadLine();

                if (int.TryParse(input, out int moistureLevel) && moistureLevel >= 0)
                {
                    return moistureLevel;
                }
            }

            throw new InvalidOperationException("Exceeded the maximum number of attempts for moisture level input.");
        }

    }
}
