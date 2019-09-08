using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Global.Data;
using Global.Services.IService;
using Global.Services.Service;

namespace Globalwarmin.Controllers
{
    public class QuizController : Controller
    {
        private IQuizService _QuizService;

        public QuizController()
        {
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
            _QuizService.DeleteQuiz(id);
            return RedirectToAction("Index");
        }

        // POST: Quiz/Delete/5
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
    }
}
