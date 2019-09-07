using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Windows;
using System.Web.Mvc;
using Global.Data;
using Global.Services.IService;
using Global.Services.Service;

namespace Globalwarmin.Controllers
{
    public class QuestionController : Controller
    {
        IQuestionService _questionService;
        IUserService _userService;
        IScoreService _scoreService;
        public QuestionController()
        {
            _questionService = new QuestionService();
            _userService = new UserService();
            _scoreService = new ScoreService();
        }


        // GET: Question
        public ActionResult Index()
        {
            IList<Question> questions = _questionService.GetAllQuestions();
            return View(questions);
        }

        // GET: Question/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Question/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Question/Create
        [HttpPost]
        public ActionResult Create(Question _question)
        {
            if (ModelState.IsValid)
            {
                int questionId = _questionService.GetNextID();
                _question.QuestionId = questionId;
                _questionService.CreateQuestion(_question);
                return RedirectToAction("Index");
            }
            return View(_question);
        }

        // GET: Question/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Question/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Question/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Question/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult AskQuestion(int id)
        {
            if (Session["CurrentScore"] == null)
            {
                Session["CurrentScore"] = 0;
            }

            Question question = _questionService.GetQuestionById(id);
            return View(question);
        }

        public ActionResult AnswerQuestion(int thisquestionid, string clickedanswer)
        {
            Question thisquestion = _questionService.GetQuestionById(thisquestionid);

            if (thisquestion.RightAnswer == clickedanswer)
            {
                int currentscore = (int)Session["CurrentScore"];
                currentscore += thisquestion.Score;
                Session["CurrentScore"] = currentscore;
                return View("success", thisquestion);
            }
            else
            {
                return View("wrong", thisquestion);
            }
        }
        public ActionResult GetQuestionsForQuizId(int id)
        {
            IList<int> questionsids = _questionService.GetQuestionByQuizId(id);
            int nextquestion = questionsids[0];
            questionsids.RemoveAt(0);
            Session["questionstoask"] = questionsids;
            Session["quizid"] = id;
            return RedirectToAction("AskQuestion", new { id = nextquestion });

        }
        public ActionResult NextQuestion()
        {
            IList<int> questionsids = (IList<int>)Session["questionstoask"];
            try
            {
                int nextquestion = questionsids[0];
                questionsids.RemoveAt(0);
                Session["questionstoask"] = questionsids;
                return RedirectToAction("AskQuestion", new { id = nextquestion });
            }
            catch
            {
                int finalscore = (int)Session["CurrentScore"];
                Session.Abandon();
                string Username = User.Identity.Name;
                string userid = _userService.GetUserIdForUserName(Username);
                int quizid = (int)Session["quizid"];

                Score NewScore = new Score();
                NewScore.DateTime = DateTime.Now;
                NewScore.Score1 = finalscore;
                NewScore.quizid = quizid;
                NewScore.UserId = userid;
                _scoreService.createscore(NewScore);

                return View("Endofquiz", finalscore);
            }
        }
    }
}
