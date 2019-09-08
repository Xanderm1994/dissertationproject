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

        public void CreateQuiz(Quiz _quiz)
        {
            _quiz.QuizID = GetNextID();
            _Database.Quizs.Add(_quiz);
            _Database.SaveChanges();
        }

        public Quiz GetQuizById(int id)
        {
            IQueryable<Quiz> _Quiz;
            _Quiz = from quiz in _Database.Quizs where quiz.QuizID == id select quiz;
            return _Quiz.First();
        }

        public void UpdateQuiz(Quiz quiz)
        {
            _Database.Entry(quiz).State = System.Data.Entity.EntityState.Modified;
            _Database.SaveChanges();
        }

        public void DeleteQuiz(int id)
        {
            Quiz quiz = GetQuizById(id);
            _Database.Quizs.Remove(quiz);
            _Database.SaveChanges();
        }

        public int GetNextID()
        {
            IQueryable<int> id;
            id = from quiz in _Database.Quizs orderby quiz.QuizID descending select quiz.QuizID;
            return id.First() + 1;
        }
    }
}
