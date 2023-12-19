using Moq;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using SoilMoistureCalculatorSystem;
using SoilMoistureCalculatorSystem.Parameters;

namespace SoilMoistureCalculatorSystemChalenge.Tests
{
    [TestFixture]
    public class ParametersProgramUnitTests
    {
        [Test, CancelAfter(5000)]
        public void ValidateMoistureLevel_InvalidMoistureLevel_ThrowsArgumentException()
        {
            SoilMoistureCalculator calculator = new SoilMoistureCalculator(new Mock<IUserInterface>().Object);

            ArgumentException? exception = Assert.Throws<ArgumentException>(() => calculator.ValidateMoistureLevel(1, 201));

            Assert.That(exception.Message, Is.EqualTo("Moisture level should be a valid number between 0 and 200."));
        }

        [Test, CancelAfter(5000)]
        public void ValidateSoilTypeSelector_InvalidInput_ThrowsArgumentException()
        {
            Mock<IUserInterface> mockUserInterface = new Mock<IUserInterface>();
            SoilMoistureCalculator calculator = new SoilMoistureCalculator(mockUserInterface.Object);

            Assert.Throws<ArgumentException>(() => calculator.ValidateSoilTypeSelector(0));
        }

        [Test, CancelAfter(5000)]
        public void GetRecommendedAction_ValidInputs_ReturnsCorrectAction()
        {
            Mock<IUserInterface> mockUserInterface = new Mock<IUserInterface>();
            SoilMoistureCalculator calculator = new SoilMoistureCalculator(mockUserInterface.Object);

            int soilTypeSelector = 1;
            double moistureLevel = 90.0;

            string result = calculator.GetRecommendedAction(soilTypeSelector, moistureLevel);

            Assert.That(result, Is.EqualTo("\n No Irrigation Needed \n"));

        }

        [Test, CancelAfter(5000)]
        public void GetSoilTypeName_ValidSelector_ReturnsCorrectName()
        {
            Mock<IUserInterface> mockUserInterface = new Mock<IUserInterface>();
            SoilMoistureCalculator calculator = new SoilMoistureCalculator(mockUserInterface.Object);

            int soilTypeSelector = 1;

            string result = calculator.GetSoilTypeName(soilTypeSelector);

            Assert.That(result, Is.EqualTo("Fine (Clay)"));
        }

        [Test, CancelAfter(5000)]
        public void GetSoilTypeSelection_ValidInput_ReturnsSoilTypeSelector()
        {
            Mock<SoilMoistureCalculator> mockCalculator = new Mock<SoilMoistureCalculator>(MockBehavior.Loose);
            Mock<IUserInterface> mockUserInterface = new Mock<IUserInterface>();
            mockUserInterface.SetupSequence(x => x.ReadLine())
                .Returns("2");

            int result = Program.GetSoilTypeSelection(3, mockCalculator.Object, mockUserInterface.Object);

            Assert.That(result, Is.EqualTo(2));
        }

        [Test, CancelAfter(5000)]
        public void GetSoilTypeSelection_InvalidInputOnceThenValid_ReturnsSoilTypeSelector()
        {
            Mock<SoilMoistureCalculator> mockCalculator = new Mock<SoilMoistureCalculator>(MockBehavior.Loose);
            Mock<IUserInterface> mockUserInterface = new Mock<IUserInterface>();
            mockUserInterface.SetupSequence(x => x.ReadLine())
                .Returns("invalid")
                .Returns("2");

            int result = Program.GetSoilTypeSelection(3, mockCalculator.Object, mockUserInterface.Object);

            Assert.That(result, Is.EqualTo(2));
        }

        [Test, CancelAfter(5000)]
        public void GetMoistureLevel_InvalidInput_ThrowsInvalidOperationException()
        {
            Mock<IUserInterface> mockUserInterface = new Mock<IUserInterface>();

            mockUserInterface.SetupSequence(x => x.ReadLine())
                .Returns("invalid")
                .Returns("invalid")
                .Returns("invalid");

            Assert.Throws<InvalidOperationException>(() => Program.GetMoistureLevel(100, 3, mockUserInterface.Object));
        }


    }
}


