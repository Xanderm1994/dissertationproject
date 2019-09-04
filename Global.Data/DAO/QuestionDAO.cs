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


    }
}
