using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Global.Data.IDAO;
namespace Global.Data.DAO
{
    public class QuizDAO : IQuizDAO
    {
        private GwEntities _Database;
        public QuizDAO()
        {
            _Database = new GwEntities();
        }


        public IList<Quiz> GetQuizs()
        {
            IQueryable<Quiz> _Quiz;

            _Quiz = from quiz in _Database.Quizs select quiz;
            return _Quiz.ToList();
        }
    }
}
