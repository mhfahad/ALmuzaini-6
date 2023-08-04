using AlmuzainiCMS.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmuzainiCMS.DAL.Interface.User
{
    public interface IUserCreateRepository
    {
        bool Create(UsersInfo usersInfo);
        UsersInfo GetUsersList(UsersInfo user);
        
    }
}
