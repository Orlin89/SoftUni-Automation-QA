public class Program
{
    public static void Main(string[] args)
    {
        
      int n = int.Parse(Console.ReadLine());
        List<Songs> songsList = new List<Songs>();
       for (int i = 1; i <= n; i ++)
        {
           string songInfo = Console.ReadLine();
           string typeList = songInfo.Split("_")[0];
           string name = songInfo.Split("_")[1];
           string time = songInfo.Split("_")[2];

            Songs song = new Songs(typeList, name, time);  
            songsList.Add(song);
        }
        string typeSongToPrint = Console.ReadLine();

        foreach (Songs item in songsList)
        {
            if(typeSongToPrint == "all" || typeSongToPrint == item.TypeList)
            {
                Console.WriteLine(item.Name);
            }
        }
    }
}

