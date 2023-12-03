namespace DAL.Repos
{
    public class NewsRepo
    {
        public static string getNews(int id)
        {
            return id == 10 ? "Found" : "Not Found";
        }
    }
}
