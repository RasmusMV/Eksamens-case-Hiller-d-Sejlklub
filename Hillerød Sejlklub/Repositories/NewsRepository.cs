using Hillerød_Sejlklub.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hillerød_Sejlklub.Repositories
{
    internal class NewsRepository : INewsRepository
    {
        private Dictionary<int, News> _news;

        private NewsRepository()
        {
            _news = new Dictionary<int, News>();
        }
        public void AddNews(News news)
        {
            _news.Add(news.Id, news);
            
        }
        public void RemoveNews(int id)
        {
            _news.Remove(id);
        }
    }
}
