using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Global.Services.IService;
using Global.Services.Service;
using Global.Data;
namespace Globalwarmin.Controllers
{
    public class UserController : Controller
    {
        private IUserService _userservice;

        public UserController()
        {
            _userservice = new UserService();
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
            return View(scores);
        }
         
        public ActionResult GetQuizScoresForUserId(string userid, int quizid)
        {
            IList<Score> scores;
            scores = _userservice.GetQuizScoresForUserId(userid, quizid);
            return View(scores);

        }
    }
}
