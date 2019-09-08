using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Global.Data;

namespace Global.Data.IDAO
{
    public interface IUserDao
    {
        IList<AspNetUser> GetUsers();

        string GetUserIdForUserName(string username);
        IList<Score> GetAllScoresForAllUsers(string userid);
        IList<Score> GetQuizScoresForUserId(string userid, int quizid);
    }
}
