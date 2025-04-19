namespace _03.MergingLists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> firstList = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            
            List<int> secondList = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<int> output = new List<int>();

            int iteration = 0;
            if (firstList.Count > secondList.Count)
            {
                iteration = firstList.Count;
            }
            else
            {
               iteration = secondList.Count;
            }
            for (int i = 0; i < iteration; i++)
            {
                if (i < firstList.Count)
                {
                    int currentElementFirstList = firstList[i];
                    output.Add(currentElementFirstList);
                }
                if (i < secondList.Count)
                {
                    int currentElementSecondtList = secondList[i];
                    output.Add(secondList[i]);
                }                            
            }
            Console.WriteLine(string.Join(" ", output));

        }
    }
}
