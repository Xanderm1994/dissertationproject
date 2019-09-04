﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Global.Data.IDAO;
namespace Global.Data.DAO
{
    public class userDao : IuserDao
    {
        private GwEntities _Database;
        public userDao()
        {
            _Database = new GwEntities();
        }


        public IList<AspNetUser> GetUsers()
        {
            IQueryable<AspNetUser> _users;

            _users = from user in _Database.AspNetUsers select user;
            return _users.ToList<AspNetUser>();
        }
    }
}
