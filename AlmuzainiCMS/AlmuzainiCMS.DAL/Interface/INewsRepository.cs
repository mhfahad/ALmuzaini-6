using AlmuzainiCMS.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmuzainiCMS.DAL.Interface
{
    public interface INewsRepository
    {
        Task<bool> AddNews(News model);

        List<News> GetAllNews();


    }
}
