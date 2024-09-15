namespace _02.Articles
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ");
            string title = input[0];
            string content = input[1];
            string author = input[2];
            Article article = new Article(title, content, author);
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] inputCommand = Console.ReadLine().Split(": ");
                string command = inputCommand[0];
                string data = inputCommand[1];
                if (command == "Edit")
                {
                    article.Edit(data);
                }
                else if (command == "ChangeAuthor")
                {
                    article.ChangeAuthor(data);
                }
                else if (command =="Rename")
                {
                    article.Rename(data);
                }               
            }
            Console.WriteLine(article);
        }
    }
    public class Article
    {
        public Article(string title, string content, string author)
        {
            Title = title;
            Content = content;
            Author = author;
        }

        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public void Edit (string newContent)
        {
            Content = newContent;
        }
        public void ChangeAuthor (string newAuthor)
        {
            Author = newAuthor;
        }
        public void Rename (string newTitle)
        {
            Title = newTitle;
        }
        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }
}
