using System;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using SimpleSocialBlog.BLL.Interfaces;

namespace SimpleSocialBlog.Controllers
{
    [Authorize(Roles = "admin")]
    public class RemoveArticleController : Controller
    {
        private readonly IArticleService articleService;

        /// <summary>
        /// Constructor, init service
        /// </summary>
        public RemoveArticleController(IArticleService service)
        {
            articleService = service;
        }
        // GET: RemoveArticle
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            form["Title"] = form["Title"].Trim();
            
            if (String.IsNullOrEmpty(form["Title"]))
                ModelState.AddModelError("Title", "Please enter title.");
            else if (form["Title"].Length < 3 || form["Title"].Length > 30)
                ModelState.AddModelError("Title", "Title must be 3-30 characters in length.");
            else if (!Regex.Match(form["Title"], "^[A-Za-zА-Яа-яЁёІі1-9\\s]+$").Success)
                ModelState.AddModelError("Title", "Invalid title.");

            if (ModelState.IsValid)
            {
                try
                {
                    articleService.RemoveArticle(form["Title"]);
                    return RedirectToAction("Index", "Home");
                }
                catch
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            return Index();
        }
    }
}