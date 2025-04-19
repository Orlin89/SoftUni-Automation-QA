namespace _08.ArrayRotation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numArray = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rotation = int.Parse(Console.ReadLine());

            for (int i = 0; i < rotation; i++)
            {
                int firstElement = numArray[0];

                for (int j = 1; j < numArray.Length; j++)
                {
                    numArray[j - 1] = numArray[j]; 
                }
                numArray[numArray.Length - 1] = firstElement;
            }
            Console.WriteLine(string.Join(" ", numArray));
        }
    }
}
