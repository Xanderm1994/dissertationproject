using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Global.Data.IDAO;
namespace Global.Data.DAO
{
    public class userDao : IuserDao
    {
        private GlobalEntities _Database;
        public userDao()
        {
            _Database = new GlobalEntities();
        }


        public IList<User> GetUsers()
        {
            IQueryable<User> _users;

            _users = from user in _Database.User select user;
            return _users.ToList<User>();
        }
    }
}
