using Moq;
using NextPermutation;
using System.Text;

namespace IntegrationTest
{
    public class NextPermutationIntegrationTest
    {
        StringBuilder _consoleOutput;
        Mock<TextReader> _consoleInput;

        public NextPermutationIntegrationTest()
        {
            _consoleOutput = new StringBuilder();
            var consoleOutputWriter = new StringWriter(_consoleOutput);
            _consoleInput = new Mock<TextReader>();
            Console.SetOut(consoleOutputWriter);
            Console.SetIn(_consoleInput.Object);
        }
        private string RunMainAndGetConsoleOutput()
        {
            Program.Main();
            return _consoleOutput.ToString().Split("\r\n")[0];
        }
        private MockSequence SetUpUserInput(string userInput)
        {
            var sequence = new MockSequence();
            _consoleInput.InSequence(sequence).Setup(x => x.ReadLine()).Returns(userInput);
            return sequence;
        }

        [Fact]
        public void ShowNextPermutation_WhenExits()
        {
            // Arrange
            string expectedOutput = "[7,99,0,11,22]";

            // Act
            SetUpUserInput("[7,22,99,11,0]");
            string response = RunMainAndGetConsoleOutput();

            // Assert
            Assert.Equal(expectedOutput, response);
        }

        [Fact]
        public void ShowArrayAsx_WhenPermutationNotExits()
        {
            // Arrange
            string expectedOutput = "[10,20,100]";

            // Act
            SetUpUserInput("[100,20,10]");
            string response = RunMainAndGetConsoleOutput();

            // Assert
            Assert.Equal(expectedOutput, response);
        }
    }
}