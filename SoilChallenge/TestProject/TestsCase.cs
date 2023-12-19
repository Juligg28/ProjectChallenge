using NUnit.Framework;
using SoilMoistureCalculatorSystem;
using SoilMoistureCalculatorSystem.Parameters;
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Reflection.Emit;

namespace SoilMoistureCalculatorSystemChalenge.Tests
{
    [TestFixture]
    public class SoilMoistureCalculatorTests
    {
      
        [Test, CancelAfter(5000)]
        public void GetRecommendedAction_Case1_ReturnsNoIrrigationInstruction()
        {
            SoilMoistureCalculator calculator = new SoilMoistureCalculator(null);
            string result = calculator.GetRecommendedAction(1, 0);
            Assert.That(result, Is.EqualTo("\n Warning! Irrigate the Clay Soil immediately because the moisture level is dangerously low.\n"));
        }

        [Test, CancelAfter(5000)]
        public void GetRecommendedAction_Case2_ReturnsNoIrrigationInstruction()
        {
            SoilMoistureCalculator calculator = new SoilMoistureCalculator(null);
            string result = calculator.GetRecommendedAction(1, 150);
            Assert.That(result, Is.EqualTo("\n Warning! Excess moisture detected. Clay Soil drainage is necessary to prevent waterlogging.\n"));
        }

        [Test, CancelAfter(5000)]
        public void GetRecommendedAction_Case3_ReturnsDrainageRequiredInstruction()
        {
            SoilMoistureCalculator calculator = new SoilMoistureCalculator(null);
            string result = calculator.GetRecommendedAction(1, 151);
            Assert.That(result, Is.EqualTo("\n Warning! Excess moisture detected. Clay Soil drainage is necessary to prevent waterlogging.\n"));
        }

        [Test, CancelAfter(5000)]
        public void GetRecommendedAction_Case4_ReturnsNoIrrigationInstruction()
        {
            SoilMoistureCalculator calculator = new SoilMoistureCalculator(null);
            string result = calculator.GetRecommendedAction(2, 70);
            Assert.That(result, Is.EqualTo("\n Irrigation to Be Applied \n"));
        }

        [Test, CancelAfter(5000)]
        public void GetRecommendedAction_Case5_ReturnsNoIrrigationInstruction()
        {
            SoilMoistureCalculator calculator = new SoilMoistureCalculator(null);
            string result = calculator.GetRecommendedAction(2, 87);
            Assert.That(result, Is.EqualTo("\n Irrigation to Be Applied \n"));
        }

        [Test, CancelAfter(5000)]
        public void GetRecommendedAction_Case6_ReturnsIrrigationInstruction()
        {
            SoilMoistureCalculator calculator = new SoilMoistureCalculator(null);
            string result = calculator.GetRecommendedAction(2, 88);
            Assert.That(result, Is.EqualTo("\n No Irrigation Needed \n"));
        }

        [Test, CancelAfter(5000)]
        public void GetRecommendedAction_Case7_ReturnsNoIrrigationInstruction()
        {
            SoilMoistureCalculator calculator = new SoilMoistureCalculator(null);
            string result = calculator.GetRecommendedAction(3, 80);
            Assert.That(result, Is.EqualTo("\n Irrigation to Be Applied \n"));
        }

        [Test, CancelAfter(5000)]
        public void GetRecommendedAction_Case8_ReturnsNoIrrigationInstruction()
        {
            SoilMoistureCalculator calculator = new SoilMoistureCalculator(null);
            string result = calculator.GetRecommendedAction(3, 89);
            Assert.That(result, Is.EqualTo("\n Irrigation to Be Applied \n"));
        }

        [Test, CancelAfter(5000)]
        public void GetRecommendedAction_Case9_ReturnsIrrigationInstruction()
        {
            SoilMoistureCalculator calculator = new SoilMoistureCalculator(null);
            string result = calculator.GetRecommendedAction(3, 90);
            Assert.That(result, Is.EqualTo("\n No Irrigation Needed \n"));
        }

        [Test, CancelAfter(5000)]
        public void GetRecommendedAction_Case10_ReturnsDrainageRequiredInstruction()
        {
            SoilMoistureCalculator calculator = new SoilMoistureCalculator(null);
            string result = calculator.GetRecommendedAction(3, 101);
            Assert.That(result, Is.EqualTo("\n Warning! Excess moisture detected. Sandy Soil drainage is necessary to prevent waterlogging.\n"));
        }

        [Test, CancelAfter(5000)]
        public void GetRecommendedAction_Case11_ReturnsErrorInvalidMoistureLevel()
        {
            SoilMoistureCalculator calculator = new SoilMoistureCalculator(null);
            string result = calculator.GetRecommendedAction(3, 200);
            Assert.That(result, Is.EqualTo("\n Warning! Excess moisture detected. Sandy Soil drainage is necessary to prevent waterlogging.\n"));
        }

        [Test, CancelAfter(5000)]
        public void GetRecommendedAction_InvalidCase1_ThrowsArgumentException()
        {
            SoilMoistureCalculator calculator = new SoilMoistureCalculator(null);

            try
            {
                calculator.GetRecommendedAction(1, -2);
            }
            catch (ArgumentException ex)
            {
                Assert.That(ex.Message, Is.EqualTo("Moisture level should be a valid number between 0 and 200."));
                return; 
            }

            Assert.Fail("Expected ArgumentException was not thrown.");
        }    

        [Test, CancelAfter(5000)]
        public void GetRecommendedAction_InvalidCase2_ReturnsErrorInvalidSoilType()
        {
            SoilMoistureCalculator calculator = new SoilMoistureCalculator(null);

                try
                {
                    calculator.GetRecommendedAction(4, 0);
                }
                catch (ArgumentException ex)
                {
                    Assert.That(ex.Message, Is.EqualTo("Invalid soil type selector. Please enter a value between 1 and 3."));
                    return;
                }

                Assert.Fail("Expected ArgumentException was not thrown.");
            }         
        

        [Test, CancelAfter(5000)]
        public void GetRecommendedAction_InvalidCase3_ReturnsErrorInvalidMoistureLevel()
        {
            SoilMoistureCalculator calculator = new SoilMoistureCalculator(null);

        try
        {
            calculator.GetRecommendedAction(2, -1);
    }
    catch (ArgumentException ex)
    {
        Assert.That(ex.Message, Is.EqualTo("Moisture level should be a valid number between 0 and 200."));
            return;
    }
    Assert.Fail("Expected ArgumentException was not thrown.");
}

        [Test, CancelAfter(5000)]
        public void GetRecommendedAction_InvalidCase4_ReturnsErrorInvalidMoistureLevel()
        {
            SoilMoistureCalculator calculator = new SoilMoistureCalculator(null);

            try
            {
                calculator.GetRecommendedAction(1, 201);
            }
            catch (ArgumentException ex)
            {
                Assert.That(ex.Message, Is.EqualTo("Moisture level should be a valid number between 0 and 200."));
                return;
            }
            Assert.Fail("Expected ArgumentException was not thrown.");
        }

        [Test, CancelAfter(5000)]
        public void GetRecommendedAction_InvalidCase5_ReturnsErrorInvalidMoistureLevel()
        {
            SoilMoistureCalculator calculator = new SoilMoistureCalculator(null);

            try
            {
                calculator.GetRecommendedAction(3, 1000);
            }
            catch (ArgumentException ex)
            {
                Assert.That(ex.Message, Is.EqualTo("Moisture level should be a valid number between 0 and 200."));
                return;
            }
            Assert.Fail("Expected ArgumentException was not thrown.");
        }

        [Test, CancelAfter(5000)]
        public void GetRecommendedAction_InvalidCase6_ReturnsErrorInvalidSoilType()
        {
            SoilMoistureCalculator calculator = new SoilMoistureCalculator(null);

            try
            {
                calculator.GetRecommendedAction(6, -0);
            }
            catch (ArgumentException ex)
            {
                Assert.That(ex.Message, Is.EqualTo("Invalid soil type selector. Please enter a value between 1 and 3."));
                return;
            }
            Assert.Fail("Expected ArgumentException was not thrown.");
        }

        [Test, CancelAfter(5000)]
        public void GetRecommendedAction_InvalidCase7_ReturnsErrorInvalidSoilType()
        {
            SoilMoistureCalculator calculator = new SoilMoistureCalculator(null);

            try
            {
                calculator.GetRecommendedAction(3, -1);
            }
            catch (ArgumentException ex)
            {
                Assert.That(ex.Message, Is.EqualTo("Moisture level should be a valid number between 0 and 200."));
                return;
            }
            Assert.Fail("Expected ArgumentException was not thrown.");
        }
        [Test, CancelAfter(5000)]
        public void GetRecommendedAction_InvalidCase8_ReturnsErrorInvalidMoistureLevel()
        {
            SoilMoistureCalculator calculator = new SoilMoistureCalculator(null);

                try
                {
                    calculator.GetRecommendedAction(2, 9999);
            }
            catch (ArgumentException ex)
            {
                Assert.That(ex.Message, Is.EqualTo("Moisture level should be a valid number between 0 and 200."));
                    return;
            }
            Assert.Fail("Expected ArgumentException was not thrown.");
        }
        
        [Test, CancelAfter(5000)]
        public void GetRecommendedAction_InvalidCase9_ReturnsErrorInvalidMoistureLevel()
        {
            SoilMoistureCalculator calculator = new SoilMoistureCalculator(null);

            try
            {
                calculator.GetRecommendedAction(1, -9999);
            }
            catch (ArgumentException ex)
            {
                Assert.That(ex.Message, Is.EqualTo("Moisture level should be a valid number between 0 and 200."));
                return;
            }
            Assert.Fail("Expected ArgumentException was not thrown.");
        }
    }
}
