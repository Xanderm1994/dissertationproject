using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Global.services.Iservice;
using Global.services.Service;
using Global.Data;
namespace Globalwarmin.Controllers
{
    public class ContentController : Controller
    {
        private IContentService _ContentService;

        public ContentController()
        {
            _ContentService = new contentservice();
        }
        public ActionResult Index()
        {
            return RedirectToAction("Index2");
        }

        // GET: Content
        public ActionResult Index2()
        {
            return View("Index",_ContentService.GetContents());
        }

        // GET: Content/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Content/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Content/Create
        [HttpPost]
        public ActionResult Create(Content _content)
        {
            try
            {
                _ContentService.CreateContent(_content);
                return RedirectToAction("Index2");
            }
            catch
            {
                return View("Index");
            }
        }

        // GET: Content/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Content/Edit/5
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

        // GET: Content/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Content/Delete/5
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
