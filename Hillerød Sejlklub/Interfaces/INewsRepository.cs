using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hillerød_Sejlklub.Interfaces
{
    public interface INewsRepository
    {
        public void AddNews(News news);

        public void RemoveNews(int id);

        public List<News> GetNewsByName(string name);



    }
}
