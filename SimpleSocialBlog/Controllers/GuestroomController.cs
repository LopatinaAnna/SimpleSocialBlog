using AutoMapper;
using PagedList;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using SimpleSocialBlog.BLL.DTO;
using SimpleSocialBlog.BLL.Interfaces;
using SimpleSocialBlog.PL.Models;

namespace SimpleSocialBlog.PL.Controllers
{
    /// <summary>
    /// Guestroom Controller, manages the page with reviews
    /// </summary>
    public class GuestroomController : Controller
    {
        private readonly IReviewService reviewService;

        /// <summary>
        /// Constructor, init service
        /// </summary>
        public GuestroomController(IReviewService service)
        {
            reviewService = service;
        }

        /// <summary>
        /// Index get
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index(int? page)
        {
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            IEnumerable<ReviewDto> articleDtos = reviewService.GetSort();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ReviewDto, ReviewViewModel>()).CreateMapper();
            var reviews = mapper.Map<IEnumerable<ReviewDto>, List<ReviewViewModel>>(articleDtos);
            return View(reviews.ToPagedList(pageNumber, pageSize));
        }

        /// <summary>
        /// Index post
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            form["Name"] = form["Name"].Trim();
            form["Text"] = form["Text"].Trim();
            if (String.IsNullOrEmpty(form["Name"]))
                ModelState.AddModelError("Name", "Please enter your name.");
            else if (form["Name"].Length < 3 || form["Name"].Length > 30)
                ModelState.AddModelError("Name", "Name must be 3-30 characters in length.");
            else if (!Regex.Match(form["Name"], "^[A-Za-zА-Яа-яЁёІі\\s]+$").Success)
                ModelState.AddModelError("Name", "Invalid name.");

            if (String.IsNullOrEmpty(form["Text"]))
                ModelState.AddModelError("Text", "Please enter your review.");
            else if (form["Text"].Length < 3 || form["Text"].Length > 300)
                ModelState.AddModelError("Text", "Review must be 3-300 characters in length.");

            if (ModelState.IsValid)
            {
                reviewService.AddItem(new ReviewDto() { Name = form["Name"], Date = DateTime.Now, Text = form["Text"] });
            }

            return Index(1);
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