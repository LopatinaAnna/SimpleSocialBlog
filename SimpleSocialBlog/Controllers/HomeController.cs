using AutoMapper;
using PagedList;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using SimpleSocialBlog.BLL.DTO;
using SimpleSocialBlog.BLL.Interfaces;
using SimpleSocialBlog.PL.Models;

namespace SimpleSocialBlog.Controllers
{
    public class HomeController : Controller
    {
        private readonly IArticleService articleService;

        /// <summary>
        /// Constructor, init service
        /// </summary>
        public HomeController(IArticleService service)
        {
            articleService = service;
        }

        /// <summary>
        /// Index
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index(int? page)
        {
            int pageSize = 5;
            int pageNumber = page ?? 1;

            IEnumerable<ArticleDto> articleDtos = articleService.GetSort();

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ArticleDto, ArticleViewModel>()
                .ForMember(p => p.Tags, c => c.MapFrom(card => card.Tags))).CreateMapper();

            var articles = mapper.Map<IEnumerable<ArticleDto>, List<ArticleViewModel>>(articleDtos);

            return View(articles.ToPagedList(pageNumber, pageSize));
        }

        /// <summary>
        /// Index post
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(string tag_name)
        {
            int pageSize = 5;
            int pageNumber = 1;
            ViewBag.TagName = tag_name;

            IEnumerable<ArticleDto> articleDtos = articleService.GetByTag(tag_name);

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ArticleDto, ArticleViewModel>()
                .ForMember(p => p.Tags, c => c.MapFrom(card => card.Tags))).CreateMapper();

            var articles = mapper.Map<IEnumerable<ArticleDto>, List<ArticleViewModel>>(articleDtos);

            return View(articles.ToPagedList(pageNumber, pageSize));
        }

        /// <summary>
        /// Index post
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetSort(string sort_type)
        {
            int pageSize = 5;
            int pageNumber = 1;

            IEnumerable<ArticleDto> articleDtos = articleService.GetSort();

            if (sort_type == "Title Asc")
                articleDtos = articleDtos.OrderBy(x => x.Title);
            else if(sort_type == "Title Desc")
                articleDtos = articleDtos.OrderByDescending(x => x.Title);
            else if(sort_type == "Date Asc")
                articleDtos = articleDtos.OrderBy(x => x.Date);
            else if(sort_type == "Date Desc")
                articleDtos = articleDtos.OrderByDescending(x => x.Date);

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ArticleDto, ArticleViewModel>()
                .ForMember(p => p.Tags, c => c.MapFrom(card => card.Tags))).CreateMapper();

            var articles = mapper.Map<IEnumerable<ArticleDto>, List<ArticleViewModel>>(articleDtos);

            return View("Index", articles.ToPagedList(pageNumber, pageSize));
        }
    }
}