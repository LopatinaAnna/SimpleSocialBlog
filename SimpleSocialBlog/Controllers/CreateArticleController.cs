using System;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using SimpleSocialBlog.BLL.DTO;
using SimpleSocialBlog.BLL.Interfaces;
using SimpleSocialBlog.Filters;
using SimpleSocialBlog.Logger;

namespace SimpleSocialBlog.Controllers
{
    [Authorize]
    public class CreateArticleController : Controller
    {
        private readonly IArticleService articleService;
        private readonly LoggerContext loggerDb = new LoggerContext();
        /// <summary>
        /// Constructor, init service
        /// </summary>
        public CreateArticleController(IArticleService service)
        {
            articleService = service;
        }

        // GET: CreateArticle
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Index post
        /// </summary>
        /// <returns></returns>
        [ExceptionLogger]
        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            form["Title"] = form["Title"].Trim();
            form["Text"] = form["Text"].Trim();
            if (String.IsNullOrEmpty(form["Title"]))
            { 
                loggerDb.ExceptionDetails.Add(new ExceptionDetail() { Date = DateTime.Now, ActionName = "Index", ControllerName = "CreateArticle", ExceptionMessage = "Title of article is empty" });
                loggerDb.SaveChanges();
            }
            if (String.IsNullOrEmpty(form["Text"]))
            {
                loggerDb.ExceptionDetails.Add(new ExceptionDetail() { Date = DateTime.Now, ActionName = "Index", ControllerName = "CreateArticle", ExceptionMessage = "Content of article is empty" });
                loggerDb.SaveChanges();
            }
            if (String.IsNullOrEmpty(form["Title"]))
                ModelState.AddModelError("Title", "Please enter title.");
            else if (form["Title"].Length < 3 || form["Title"].Length > 30)
                ModelState.AddModelError("Title", "Title must be 3-30 characters in length.");
            else if (!Regex.Match(form["Title"], "^[A-Za-zА-Яа-яЁёІі1-9\\s]+$").Success)
                ModelState.AddModelError("Title", "Invalid title.");

            if (String.IsNullOrEmpty(form["Text"]))
                ModelState.AddModelError("Text", "Please enter your article.");
            else if (form["Text"].Length < 3 || form["Text"].Length > 1000)
                ModelState.AddModelError("Text", "Article must be 3-300 characters in length.");

            if (ModelState.IsValid)
            {
                articleService.AddItem(new ArticleDto() { Title = form["Title"], Date = DateTime.Now, Text = form["Text"] });
                return RedirectToAction("Index", "Home");
            }

            return Index();
        }
    }
}