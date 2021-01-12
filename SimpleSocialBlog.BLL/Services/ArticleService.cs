using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using SimpleSocialBlog.BLL.DTO;
using SimpleSocialBlog.BLL.Interfaces;
using SimpleSocialBlog.DAL.Entities;
using SimpleSocialBlog.DAL.Interfaces;

namespace SimpleSocialBlog.BLL.Services
{
    /// <summary>
    /// Article service
    /// </summary>
    public class ArticleService : IArticleService
    {
        /// <summary>
        /// UnitOfWork object
        /// </summary>
        public IUnitOfWork Database { get; set; }

        /// <summary>
        /// Constructor, init database
        /// </summary>
        public ArticleService(IUnitOfWork uow)
        {
            Database = uow;
        }

        /// <summary>
        /// Add new article
        /// </summary>
        /// <param name="item"></param>
        public void AddItem(ArticleDto item)
        {
            Database.Articles.Create(new Article() { Title = item.Title, Date = item.Date, Text = item.Text });
            Database.Save();
        }

        /// <summary>
        /// Get Sort
        /// </summary>
        /// <returns>Sorting collection of articles</returns>
        public IEnumerable<ArticleDto> GetSort()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Article, ArticleDto>()
                .ForMember(p => p.Tags, c => c.MapFrom(card => card.Tags.Select(x => x.TagName)))).CreateMapper();
            return mapper.Map<IEnumerable<Article>, List<ArticleDto>>(Database.Articles.GetSortArticles());
        }

        /// <summary>
        /// Get By Tag
        /// </summary>
        /// <param name="tag_name">Tag</param>
        /// <returns>Articles collection filtered by tag</returns>
        public IEnumerable<ArticleDto> GetByTag(string tag_name)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Article, ArticleDto>()
                .ForMember(p => p.Tags, c => c.MapFrom(card => card.Tags.Select(x => x.TagName)))).CreateMapper();
            return mapper.Map<IEnumerable<Article>, List<ArticleDto>>(Database.Articles.GetArticlesByTag(tag_name));
        }

        /// <summary>
        /// Add Tag To Article
        /// </summary>
        /// <param name="articleId"></param>
        /// <param name="tagDto"></param>
        public void AddTagToArticle(int articleId, TagDto tagDto)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TagDto, Tag>()).CreateMapper();
            var tag = mapper.Map<TagDto, Tag>(tagDto);
            if (Database.Tags.GetTagByName(tag.TagName) != null)
            {
                var article = Database.Articles.FindByIdWithDetails(articleId);
                article.Tags.Add(tag);
            }
        }

        public void RemoveArticle(string articleTitle)
        {
            var article = Database.Articles.Get().FirstOrDefault(x=>x.Title == articleTitle);
            if (article != null)
            {
                Database.Articles.Remove(article);
                Database.Save();
            }
        }
    }
}