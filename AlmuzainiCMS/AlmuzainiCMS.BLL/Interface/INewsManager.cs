using AlmuzainiCMS.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmuzainiCMS.BLL.Interface
{
    public interface INewsManager
    {
       Task<bool> AddNews(News news);
        List<News> GetAllNews();   
    }
}
