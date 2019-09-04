using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Global.Data;
using Global.Data.IDAO;
using Global.Data.DAO;
using Global.services.Iservice;
namespace Global.services.Service
{
    public class userservice : Iuserservice
    {
        private IuserDao _userdao;

        public userservice()
        {
            _userdao = new userDao();
        }

        public IList<AspNetUser> Getusers()
        {
            return _userdao.GetUsers();
        }


    }
}
