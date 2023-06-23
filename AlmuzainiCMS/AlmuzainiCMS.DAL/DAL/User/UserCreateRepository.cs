using AlmuzainiCMS.DAL.Interface.User;
using AlmuzainiCMS.DataBaseContext.DataBaseContext;
using AlmuzainiCMS.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmuzainiCMS.DAL.DAL.User
{
    public class UserCreateRepository : IUserCreateRepository
    {
        ProjectDbContext DB;
        public UserCreateRepository(DbContext db)
        {
            DB = (ProjectDbContext)db;
        }
        public bool Create(UsersInfo usersInfo)
        {
            DB.usersInfos.Add(usersInfo);
            return 0 < DB.SaveChanges();
        }
        public UsersInfo GetUsersList(UsersInfo user)
        {
            var list = DB.usersInfos.Where(c => c.userName == user.userName && c.userPass == user.userPass).FirstOrDefault();

            return list;
        }
    }
}
