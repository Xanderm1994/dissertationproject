using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Global.Services.IService;
using Global.Services.Service;
using Global.Data;
using Globalwarmin.ViewModels;

namespace Globalwarmin.Controllers
{
    public class UserController : Controller
    {
        private IUserService _userservice;
        private IQuizService _quizservice;

        public UserController()
        {
            _userservice = new UserService();
            _quizservice = new QuizService();

        }
        // GET: User
        public ActionResult Index()
        {
            return View(_userservice.Getusers());
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: User/Edit/5
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

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
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
        public ActionResult GetAllScoresForAllUsers(string userid)
        {
            IList<Score> scores;
           scores = _userservice.GetAllScoresForAllUsers(userid);
            IList<HighScoresViewModel> viewModelList = new List<HighScoresViewModel>();

            foreach (Score score in scores)
            {
                HighScoresViewModel viewModel = new HighScoresViewModel()
                {
                    Score = score.Score1,
                    UserName = _userservice.GetUserByID(score.UserId).UserName.Split('@')[0],
                    QuizName = _quizservice.GetQuizById(score.quizid).Title,
                    Date = score.DateTime
                };
                viewModelList.Add(viewModel);
            }
            return View(viewModelList);
        }

        public ActionResult GetQuizScoresForUserId(int id)
        {
            IList<Score> scores;
            scores = _userservice.GetQuizScoresForUserId(_userservice.GetUserIdForUserName(User.Identity.Name),id);
            IList<HighScoresViewModel> viewModelList = new List<HighScoresViewModel>();

            foreach (Score score in scores)
            {
                HighScoresViewModel viewModel = new HighScoresViewModel()
                {
                    Score = score.Score1,
                    UserName = _userservice.GetUserByID(score.UserId).UserName.Split('@')[0],
                    QuizName = _quizservice.GetQuizById(score.quizid).Title,
                    Date = score.DateTime
                };
                viewModelList.Add(viewModel);
            }
            return View(viewModelList);

        }
    }
}
