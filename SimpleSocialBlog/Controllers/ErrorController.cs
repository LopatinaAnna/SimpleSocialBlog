using System.Web.Mvc;

namespace SimpleSocialBlog.PL.Controllers
{
    /// <summary>
    /// Error Controller, manages the not found page
    /// </summary>
    public class ErrorController : Controller
    {
        /// <summary>
        /// Index
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
    }
}