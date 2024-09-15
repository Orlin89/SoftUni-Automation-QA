namespace _01.CountRealNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            SortedDictionary <int, int> sortedNum = new SortedDictionary<int, int>();
            foreach (int number in numbers)
            {
                if (!sortedNum.ContainsKey(number))
                {
                    sortedNum.Add(number, 1);                   
                }
                else
                {
                    sortedNum[number]++;
                }
            }
            foreach (KeyValuePair <int , int> num in sortedNum)
            {
                Console.WriteLine(num.Key + " -> " + num.Value); 
            }
        }
    }
}
