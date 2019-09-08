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

        public void CreateQuiz(Quiz _quiz)
        {
            _quizDAO.CreateQuiz(_quiz);
        }

        public Quiz GetQuizById(int id)
        {
            return _quizDAO.GetQuizById(id);
        }

        public void UpdateQuiz(Quiz quiz)
        {
            _quizDAO.UpdateQuiz(quiz);
        }

        public void DeleteQuiz(int id)
        {
            _quizDAO.DeleteQuiz(id);
        }
    }
}
