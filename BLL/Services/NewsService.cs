using DAL.Repos;

namespace BLL.Services
{
    public class NewsService
    {
        public static string getNews(int id)
        {
            var data = NewsRepo.getNews(id);
            return data;
        }
    }
}
