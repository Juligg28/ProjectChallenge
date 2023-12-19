using System;
using System.Collections.Generic;

namespace SoilMoistureCalculatorSystem.Parameters
{

    public class SoilTypeParameters
    {
        public int SoilTypeSelector { get; set; }
        public int IdealMoistureLevel { get; set; }
        public int IrrigationMoistureLevel { get; set; }
        public int MaxLowerLimit { get; set; }
        public int DrainageUpperLimit { get; set; }
        public string? IrrigationInstruction { get; set; }
        public string? NoIrrigationInstruction { get; set; }
        public string? DangerouslyLowAlert { get; set; }
        public string? DangerouslyHighAlert { get; set; }
    }


    public class SoilMoistureCalculator
    {
        private readonly Dictionary<string, SoilTypeParameters> _soilTypeParameters;
        private readonly IUserInterface _userInterface;

        public SoilMoistureCalculator(IUserInterface userInterface)
        {
            _userInterface = userInterface;


            _soilTypeParameters = new Dictionary<string, SoilTypeParameters>
            {
                {
                    "Fine (Clay)", new SoilTypeParameters
                    {
                        SoilTypeSelector = 1,
                        IdealMoistureLevel = 100,
                        IrrigationMoistureLevel =  79,
                        MaxLowerLimit = 59,
                        DrainageUpperLimit = 200,
                        IrrigationInstruction = "\n Irrigation to Be Applied \n",
                        NoIrrigationInstruction = "\n No Irrigation Needed \n",
                        DangerouslyLowAlert = "\n Warning! Irrigate the Clay Soil immediately because the moisture level is dangerously low.\n",
                        DangerouslyHighAlert = "\n Warning! Excess moisture detected. Clay Soil drainage is necessary to prevent waterlogging.\n"
                    }
                },
                {
                    "Medium (Loamy)", new SoilTypeParameters
                    {
                        SoilTypeSelector = 2,
                        IdealMoistureLevel = 100 ,
                        IrrigationMoistureLevel = 87,
                        MaxLowerLimit = 69,
                        DrainageUpperLimit = 200,
                        IrrigationInstruction = "\n Irrigation to Be Applied \n",
                        NoIrrigationInstruction = "\n No Irrigation Needed \n",
                        DangerouslyLowAlert = "\n Warning! Irrigate Loamy Soil immediately because the moisture level is dangerously low.\n",
                        DangerouslyHighAlert = "\n Warning! Excess moisture detected. Loamy Soil drainage is necessary to prevent waterlogging.\n"
                    }
                },
                {
                    "Coarse (Sandy)", new SoilTypeParameters
                    {
                        SoilTypeSelector = 3,
                        IdealMoistureLevel = 100,
                        IrrigationMoistureLevel = 89,
                        MaxLowerLimit = 79,
                        DrainageUpperLimit = 200,
                        IrrigationInstruction = "\n Irrigation to Be Applied \n",
                        NoIrrigationInstruction = "\n No Irrigation Needed \n",
                        DangerouslyLowAlert = "\n Warning! Irrigate Sandy Soil immediately because the moisture level is dangerously low.\n",
                        DangerouslyHighAlert = "\n Warning! Excess moisture detected. Sandy Soil drainage is necessary to prevent waterlogging.\n"
                    }
                }
            };


        }

        public SoilMoistureCalculator() : this(null)
        {

        }
        public int GetMaxMoistureValue(int soilTypeSelector)
        {
            ValidateSoilTypeSelector(soilTypeSelector);

            string soilTypeName = GetSoilTypeName(soilTypeSelector);
            if (_soilTypeParameters.TryGetValue(soilTypeName, out SoilTypeParameters? soilType))
            {
                int maxMoistureValue = soilType.IdealMoistureLevel;

                if (soilType.IrrigationMoistureLevel > maxMoistureValue)
                {
                    maxMoistureValue = soilType.IrrigationMoistureLevel;
                }

                if (soilType.MaxLowerLimit > maxMoistureValue)
                {
                    maxMoistureValue = soilType.MaxLowerLimit;
                }

                if (soilType.MaxLowerLimit > maxMoistureValue)
                {
                    maxMoistureValue = soilType.MaxLowerLimit;
                }

                if (maxMoistureValue < 0)
                {
                    maxMoistureValue = 0;
                }

                return maxMoistureValue;
            }

            throw new ArgumentException("Invalid soil type selector");
        }

        public string GetRecommendedAction(int soilTypeSelector, double moistureLevel)
        {
            ValidateSoilTypeSelector(soilTypeSelector);
            ValidateMoistureLevel(soilTypeSelector, moistureLevel);

            int moistureLevelInt = (int)Math.Round(moistureLevel);

            string soilTypeName = GetSoilTypeName(soilTypeSelector);
            if (_soilTypeParameters.TryGetValue(soilTypeName, out SoilTypeParameters? soilType))
            {
                if (moistureLevelInt <= soilType.MaxLowerLimit)
                {
                    return soilType.DangerouslyLowAlert;
                }
                else if (moistureLevelInt > soilType.IdealMoistureLevel)
                {
                    return soilType.DangerouslyHighAlert;
                }
                else
                {
                    if (moistureLevelInt > soilType.MaxLowerLimit && moistureLevelInt <= soilType.IrrigationMoistureLevel)
                    {
                        return soilType.IrrigationInstruction;
                    }
                    else
                    {
                        return soilType.NoIrrigationInstruction;
                    }
                }
            }

            throw new ArgumentException("Invalid soil type selector");
        }

        public void ValidateSoilTypeSelector(int soilTypeSelector)
        {
            if (soilTypeSelector < 1 || soilTypeSelector > 3)
            {
                throw new ArgumentException("Invalid soil type selector. Please enter a value between 1 and 3.");
            }
        }

        public void ValidateMoistureLevel(int soilTypeSelector, double moistureLevel)
        {
            ValidateSoilTypeSelector(soilTypeSelector);

            if (moistureLevel < 0 || moistureLevel > 200)
            {
                throw new ArgumentException("Moisture level should be a valid number between 0 and 200.");
            }
        }

        public string GetSoilTypeName(int soilTypeSelector)
        {
            foreach (KeyValuePair<string, SoilTypeParameters> entry in _soilTypeParameters)
            {
                if (entry.Value.SoilTypeSelector == soilTypeSelector)
                {
                    return entry.Key;
                }
            }

            throw new ArgumentException("Invalid soil type selector");
        }
    }
}

