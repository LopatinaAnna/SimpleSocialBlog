using System;
using System.Collections.Generic;
using SimpleSocialBlog.DAL.Entities;

namespace SimpleSocialBlog.DAL.Interfaces
{
    /// <summary>
    /// IArticleRepository
    /// </summary>
    public interface IArticleRepository
    {
        /// <summary>
        /// Create
        /// </summary>
        /// <param name="item"></param>
        void Create(Article item);

        /// <summary>
        /// FindById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Article FindById(int id);

        /// <summary>
        /// FindByIdWithDetails
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Article FindByIdWithDetails(int id);

        /// <summary>
        /// Get
        /// </summary>
        /// <returns></returns>
        IEnumerable<Article> Get();

        /// <summary>
        /// Get with predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        IEnumerable<Article> Get(Func<Article, bool> predicate);

        /// <summary>
        /// GetSort with predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        IEnumerable<Article> GetSort(Func<Article, DateTime> predicate);

        /// <summary>
        /// Remove
        /// </summary>
        /// <param name="item"></param>
        void Remove(Article item);

        /// <summary>
        /// Get Sort Articles
        /// </summary>
        /// <returns></returns>
        IEnumerable<Article> GetSortArticles();

        /// <summary>
        /// Get Sort Articles
        /// </summary>
        /// <returns></returns>
        IEnumerable<Article> GetArticlesByTag(string tag_name);

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="item"></param>
        void Update(Article item);
    }
}