using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Global.Data;
using Global.Data.IDAO;
using Global.Data.DAO;
using Global.Services.IService;

namespace Global.Services.Service
{
    public class UserService : IUserService
    {
        private IUserDao _userdao;

        public UserService()
        {
            _userdao = new UserDAO();
        }

        public IList<AspNetUser> Getusers()
        {
            return _userdao.GetUsers();
        }
        public string GetUserIdForUserName(string username)
        {
            string userid = _userdao.GetUserIdForUserName(username);

            return userid;
        }

        public AspNetUser GetUserByID(string id)
        {
            return _userdao.GetUserByID(id);
        }

    }
}
