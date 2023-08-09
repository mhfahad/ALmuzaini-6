using AlmuzainiCMS.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmuzainiCMS.BLL.Abstraction
{
    public interface IUserCreateManager
    {
        bool Create(UsersInfo usersInfo);
        UsersInfo GetUsersList(UsersInfo user);
    }
}
