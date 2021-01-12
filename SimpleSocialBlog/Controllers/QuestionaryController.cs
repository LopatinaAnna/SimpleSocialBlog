using System.Text.RegularExpressions;
using System.Web.Mvc;
using SimpleSocialBlog.BLL.DTO;
using SimpleSocialBlog.BLL.Interfaces;
using SimpleSocialBlog.PL.Models;

namespace SimpleSocialBlog.PL.Controllers
{
    /// <summary>
    /// Questionary Controller, manages the page with questionary and result
    /// </summary>
    public class QuestionaryController : Controller
    {
        private readonly IQuestionaryService questionaryService;

        /// <summary>
        /// Constructor, init service
        /// </summary>
        public QuestionaryController(IQuestionaryService service)
        {
            questionaryService = service;
        }

        /// <summary>
        /// Index get
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Index post
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(QuestionaryViewModel questionary)
        {
            questionary.Name = questionary.Name.Trim();
            if (string.IsNullOrEmpty(questionary.Name))
                ModelState.AddModelError("Name", "Please enter your name.");
            else if (questionary.Name.Length < 3 || questionary.Name.Length > 30)
                ModelState.AddModelError("Name", "Name must be 3-30 characters in length.");
            else if (!Regex.Match(questionary.Name, "^[A-Za-zА-Яа-яЁёІі\\s]+$").Success)
                ModelState.AddModelError("Name", "Invalid name.");

            if (questionary.Rate == 0)
                ModelState.AddModelError("Rate", "Please choose rating.");

            if (ModelState.IsValid)
            {
                questionaryService.AddItem(new QuestionaryDto() { Name = questionary.Name, Rate = questionary.Rate, Recommend = questionary.Recommend });
                ViewBag.SiteRate = questionaryService.GetRate();
                return View("QuestionaryResult", questionary);
            }
            else
            {
                return View(questionary);
            }
        }

        /// <summary>
        /// Validate length of input name
        /// </summary>
        /// <param name="name"></param>
        /// <returns>JsonResult</returns>
        public JsonResult ValidateNameLength(string name)
        {
            if (name.Length < 3)
            {
                return Json("Name length must be not less then 3 characters.", JsonRequestBehavior.AllowGet);
            }
            else if (name.Length > 30)
            {
                return Json("Name length must be not more then 30 characters.", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }
    }
}