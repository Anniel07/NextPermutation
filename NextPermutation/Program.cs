

namespace NextPermutation
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine(NextPermutation(Console.ReadLine()!));
        }


        /// <summary>
        /// find the nextpermutation of an array of integers, if not found sort the array in increasing order
        /// </summary>
        /// <param name="line">the array in string format</param>
        /// <returns>An array of integers with the next permutation</returns>
        public static string NextPermutation(string line)
        {
            int[] numbers = Array.ConvertAll(line.Trim('[', ']').Split(','), int.Parse);
            List<int> temp = new();
            List<int> nextPermutation = new();
            int i;
            for (i = numbers.Length - 1; i >= 0; i--)
            {
                int current = numbers[i];
                //get minimun grather than current in temp
                var filter = temp.Where(x => x > current);
                if (filter.Any())
                {
                    int grather = filter.Min();
                    numbers[i] = grather;
                    temp.Remove(grather);
                    temp.Add(current);
                    nextPermutation.AddRange(new ArraySegment<int>(numbers, 0, i + 1));
                    nextPermutation.AddRange(temp.Order());
                    break;
                }
                else
                {
                    temp.Add(current);
                }
            }
            if (i < 0)
            {
                //next permutation not found, ordering asc
                nextPermutation.AddRange(numbers.Order());
            }
            return $"[{string.Join(",", nextPermutation)}]";
        }
    }
}