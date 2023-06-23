using AlmuzainiCMS.BLL.Interface;
using AlmuzainiCMS.DAL.Interface.User;
using AlmuzainiCMS.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmuzainiCMS.BLL.BLL
{
    public class UserCreateManager : IUserCreateManager
    {
        IUserCreateRepository _Repository;

        public UserCreateManager(IUserCreateRepository Repository)
        {
            _Repository = Repository;
        }

        public bool Create(UsersInfo menus)
        {
            return _Repository.Create(menus);
        }
        public UsersInfo GetUsersList(UsersInfo user)
        {
            return _Repository.GetUsersList(user); ;
        }

    }
}
