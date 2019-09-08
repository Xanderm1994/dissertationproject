using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Global.Data;
using Global.Services.IService;
using Global.Services.Service;
using Globalwarmin.ViewModels;

namespace Globalwarmin.Controllers
{
    public class QuizController : Controller
    {
        private IQuizService _QuizService;
        private IUserService _UserService;

        public QuizController()
        {
            _UserService = new UserService();
            _QuizService = new QuizService();
        }

        // GET: Quiz
        public ActionResult Index()
        {
            IList<Quiz> allquiz = _QuizService.GetQuizs();
            return View(allquiz);
        }

        // GET: Quiz/Details/5
        public ActionResult Details(int id)
        {
            Quiz quiz;
            quiz = _QuizService.GetQuizById(id);
            return View(quiz);
        }

        // GET: Quiz/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Quiz/Create
        [HttpPost]
        public ActionResult Create(Quiz _quiz)
        {
            if (ModelState.IsValid)
            {
                _QuizService.CreateQuiz(_quiz);
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Quiz/Edit/5
        public ActionResult Edit(int id)
        {
            Quiz quiz = _QuizService.GetQuizById(id);
            return View(quiz);
        }

        // POST: Quiz/Edit/5
        [HttpPost]
        public ActionResult Edit(Quiz quiz)
        {
            if(ModelState.IsValid)
            {
                _QuizService.UpdateQuiz(quiz);
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Quiz/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_QuizService.GetQuizById(id));
        }

        // POST: Quiz/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                _QuizService.DeleteQuiz(id);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult ShowHighScoresForQuizID(int id)
        {
            IList<Score> scores;
            scores = _QuizService.GetScoresForQuizID(id);

            IList<HighScoresViewModel> viewModelList = new List<HighScoresViewModel>();

            foreach(Score score in scores)
            {
                HighScoresViewModel viewModel = new HighScoresViewModel()
                {
                    Score = score.Score1,
                    UserName = _UserService.GetUserByID(score.UserId).UserName.Split('@')[0],
                    QuizName = _QuizService.GetQuizById(score.quizid).Title,
                    Date = score.DateTime
                };
                viewModelList.Add(viewModel);
            }
            return View(viewModelList);
        }
    }
}
