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
            IList<Quiz> allquiz =  _QuizService.GetQuizs();
            return View(allquiz);
        }

        // GET: Quiz/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
            try
            {
                _QuizService.CreateQuiz(_quiz);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Quiz/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Quiz/Edit/5
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

        // GET: Quiz/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
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
