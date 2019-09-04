using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Global.Data.IDAO;
using Global.Data.DAO;
using Global.Data;
using Global.Services.IService;
namespace Global.Services.Service
{
    public class QuizService : IQuizService
    {
        private IQuizDAO _quizDAO;

        public QuizService()
        {
            _quizDAO = new QuizDAO();
        }

        public IList<Quiz> GetQuizs()
        {
            return _quizDAO.GetQuizs();
        }
    }
}
