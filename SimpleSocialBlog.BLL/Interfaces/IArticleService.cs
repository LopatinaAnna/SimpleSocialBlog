using System.Collections.Generic;
using SimpleSocialBlog.BLL.DTO;

namespace SimpleSocialBlog.BLL.Interfaces
{
    /// <summary>
    /// Article service interface
    /// </summary>
    public interface IArticleService
    {
        /// <summary>
        /// Add new article
        /// </summary>
        /// <param name="item">Article</param>
        void AddItem(ArticleDto item);

        /// <summary>
        /// Get Sort
        /// </summary>
        /// <returns>Sorting collection of articles</returns>
        IEnumerable<ArticleDto> GetSort();

        /// <summary>
        /// GetByTag
        /// </summary>
        /// <param name="tag_name">Tag</param>
        /// <returns>Articles collection</returns>
        IEnumerable<ArticleDto> GetByTag(string tag_name);

        /// <summary>
        /// Add Tag To Article
        /// </summary>
        /// <param name="articleId">Article Id</param>
        /// <param name="tagDto">Tag</param>
        void AddTagToArticle(int articleId, TagDto tagDto);

        void RemoveArticle(string articleTitle);
    }
}