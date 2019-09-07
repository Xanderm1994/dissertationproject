using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Global.Data;
using Global.Services.IService;
using Global.Data.DAO;
using Global.Data.IDAO;

namespace Global.Services.Service
{
    public class QuestionService : IQuestionService
    {
        private IQuestionDAO _questionDAO;

        public QuestionService()
        {
            _questionDAO = new QuestionDAO();
        }

        public IList<Question> GetAllQuestions()
        {
            return _questionDAO.GetAllQuestions();
        }

        public void CreateQuestion(Question _question)
        {
            _questionDAO.CreateQuestion(_question);
        }

        public Question GetQuestionById(int id)
        {
            return _questionDAO.GetQuestionById(id);
        }

        public IList<int> GetQuestionByQuizId(int id)
        {
            return _questionDAO.GetQuestionByQuizId(id);
        }

        public int GetNextID()
        {
            return _questionDAO.GetNextID();
        }

    }
}
