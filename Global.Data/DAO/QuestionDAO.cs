﻿using System;
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

        public int GetNextID()
        {
            IQueryable<int> id;
            id = from dbquestion 
                 in _database.Questions
                 orderby dbquestion.QuestionId descending
                 select dbquestion.QuestionId;
            if (id.ToList().Count == 0) return 0;
            return (id.First())+1;
        }

        public void UpdateQuestion(Question question)
        {
            _database.Entry(question).State = System.Data.Entity.EntityState.Modified;
            _database.SaveChanges();
        }

        public void DeleteQuestion(int id)
        {
            Question question = GetQuestionById(id);
            _database.Questions.Remove(question);
        }
    }
}
