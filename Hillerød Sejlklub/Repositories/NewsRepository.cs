using Hillerød_Sejlklub.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hillerød_Sejlklub.Repositories
{
    public class NewsRepository : INewsRepository
    {
        private static NewsRepository _instance = null;

        private Dictionary<int, News> _news;

        private NewsRepository()
        {
            _news = new Dictionary<int, News>();
        }

        public static NewsRepository GetInstance()
        {
            if (_instance == null)
            {
                _instance = new NewsRepository();
            }
            return _instance;
        }

        public void AddNews(News news)
        {
            _news.Add(news.Id, news);
            
        }
        public void RemoveNews(int id)
        {
            _news.Remove(id);
        }
        public List<News> GetNewsByName(string name)
        {
            List<News> news = new List<News>();

            foreach (var newss in _news)
            {
                if (newss.Value.Name != null && newss.Value.Name.Contains(name, StringComparison.InvariantCultureIgnoreCase) == true)
                {
                    news.Add(newss.Value);
                }
            }

            return news;

        }
    }
}
