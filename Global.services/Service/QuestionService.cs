﻿using System;
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



    }
}