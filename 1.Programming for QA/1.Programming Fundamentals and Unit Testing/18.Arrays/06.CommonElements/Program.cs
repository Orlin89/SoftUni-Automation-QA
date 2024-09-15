namespace _06.CommonElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] firstArray = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            int[] secondArray = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();



            for (int i = 0; i < firstArray.Length; i++)
            {
                int currentNum = firstArray[i];
                foreach (int num in secondArray)
                {
                    if (currentNum == num)
                    {
                        Console.Write($"{currentNum} ");
                    }
                }

            }
         
        }
    }
}
