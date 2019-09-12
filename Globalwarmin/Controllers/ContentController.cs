using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Global.Services.IService;
using Global.Services.Service;
using Global.Data;
using Globalwarmin;
using Globalwarmin.ViewModels;

namespace Globalwarmin.Controllers
{
    public class ContentController : Controller
    {
        private IContentService _ContentService;
        private IQuizService _QuizService;

        public ContentController()
        {
            _ContentService = new ContentService();
            _QuizService = new QuizService();
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
            return View(_ContentService.GetContentById(id));
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

        // GET: Content/Manage/5
        public ActionResult Manage(int id)
        {
            Content getcontent;
           getcontent = _ContentService.GetContentById(id);

            Session["contentid"] = getcontent.ContentId;

            ManageContentViewModel viewmodel = new ManageContentViewModel();
            viewmodel.content = getcontent;
            viewmodel.quizlist = _QuizService.GetQuizs();
            return View(viewmodel);
        }

        // POST: Content/Manage/5
        [HttpPost]
        public ActionResult Manage(ManageContentViewModel viewmodel)
        {
            int contentid = (int)Session["contentid"];
            Session["contentid"] = null;

            if (ModelState.IsValid)
            {
                QuizContentLink link = viewmodel.link;
                link.ContentId = contentid;
                _ContentService.makelink(link);

                _ContentService.UpdateContent(viewmodel.content);
                return RedirectToAction("Index2");
            }
            return View();
        }

        // GET: Content/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_ContentService.GetContentById(id));
        }

        // POST: Content/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            if(ModelState.IsValid)
            {
                _ContentService.DeleteContent(id);
                return RedirectToAction("Index2");
            }
            return View();
        }

        public ActionResult TopicList()
        {
            IList<Content> content;
           content = _ContentService.GetContentAz();
            return View(content);
        }
        public ActionResult ViewContent(int id)
        {
            Content content; 
            content = _ContentService.GetContentById(id);
            return View(content);
        }

        public ActionResult GetQuizzesByContentId(int id)
        {
            IList<Quiz> contentquiz;
            contentquiz = _ContentService.GetQuizzesByContentId(id);
                return View(contentquiz);
        }
    }
}
