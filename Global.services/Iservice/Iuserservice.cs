using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Global.Data;

namespace Global.Services.IService
{
   public interface IUserService 
    {
        IList<AspNetUser> Getusers();

        string GetUserIdForUserName(string username);
        IList<Score> GetAllScoresForAllUsers(string userid);
        IList<Score> GetQuizScoresForUserId(string userid, int quizid);

        AspNetUser GetUserByID(string id);

    }
}
