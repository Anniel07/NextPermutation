using NextPermutation;

namespace NextPermutationAppTest
{
    public class NextPermutationIntegrationTest
    {
        [Fact]
        public void NextPermutation_ShouldReturnNextPermutation_WhenExits()
        {
            //Arreange
            string[] inputs = { "[1,2,3]", "[1,1,5]", "[1,19,9]", "[1,5,11,10]", "[9,10,100,20,8,9,9,10,8,100,100,50]" };
            string[] expectedOutputs = { "[1,3,2]", "[1,5,1]", "[9,1,19]", "[1,10,5,11]", "[9,10,100,20,8,9,9,10,50,8,100,100]" };
            for (int i = 0; i < inputs.Length; i++)
            {
                //Act
                string output = Program.NextPermutation(inputs[i]);
                //Assert
                Assert.Equal(expectedOutputs[i], output);
            }
        }

        [Fact]
        public void NextPermutation_ShouldReturnArrayAsc_WhenNotExits()
        {
            //Arreange
            string[] inputs = { "[3,2,1]", "[1]", "[0]", "[100,100]" };
            string[] expectedOutputs = { "[1,2,3]", "[1]", "[0]", "[100,100]" };
            for (int i = 0; i < inputs.Length; i++)
            {
                //Act
                string output = Program.NextPermutation(inputs[i]);
                //Assert
                Assert.Equal(expectedOutputs[i], output);
            }
        }
    }
}