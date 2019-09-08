using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Global.Data.IDAO;

namespace Global.Data.DAO
{
    public class UserDAO : IUserDao
    {
        private GwEntities _Database;
        public UserDAO()
        {
            _Database = new GwEntities();
        }


        public IList<AspNetUser> GetUsers()
        {
            IQueryable<AspNetUser> _users;

            _users = from user in _Database.AspNetUsers select user;
            return _users.ToList<AspNetUser>();
        }
        public string GetUserIdForUserName(string username)
        {
            IQueryable<string> userid;

            userid = from user 
                     in _Database.AspNetUsers
                     where user.UserName == username
                     select user.Id;
            return userid.First();

        }
        public IList<Score> GetAllScoresForAllUsers(string userid)
        {
            IQueryable<Score> scores;
            scores = from score in _Database.Scores where score.UserId == userid select score;
            return scores.ToList();
        }
        public IList<Score> GetQuizScoresForUserId(string userid,int quizid)
        {
            IQueryable<Score> scores;
            scores = from score 
                     in _Database.Scores
                     where score.UserId == userid
                     where score.quizid == quizid
                     select score;
            return scores.ToList();

        }

        public AspNetUser GetUserByID(string id)
        {
            IQueryable<AspNetUser> users = from user in _Database.AspNetUsers where user.Id == id select user;
            return users.First();
        }
    }
}
