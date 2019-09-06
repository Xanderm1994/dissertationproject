using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Global.Data.IDAO;

namespace Global.Data.DAO
{
    public class QuestionDAO : IQuestionDAO
    {
        private GwEntities _database;

        public QuestionDAO()
        {
            _database = new GwEntities();
        }

        public IList<Question> GetAllQuestions()
        {
            IEnumerable<Question> questions;
            questions = from question in _database.Questions select question;
            return questions.ToList();
        }

        public void CreateQuestion(Question _question)
        {
            _database.Questions.Add(_question);
            _database.SaveChanges();
        }

        public Question GetQuestionById(int id)
        {
            IQueryable<Question> question;
            question = from dbquestion in _database.Questions where dbquestion.QuestionId == id select dbquestion;
            return question.First();
        }

        public IList<int> GetQuestionByQuizId(int id)
        {
            IQueryable<int> questions;
            questions = from dbquestion in _database.Questions where dbquestion.QuizId == id select dbquestion.QuestionId;
            return questions.ToList();
        }

    }
}
