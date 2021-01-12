using System;
using System.Collections.Generic;
using SimpleSocialBlog.DAL.Entities;

namespace SimpleSocialBlog.DAL.Interfaces
{
    /// <summary>
    /// IReviewRepository
    /// </summary>
    public interface IReviewRepository
    {
        /// <summary>
        /// Create
        /// </summary>
        /// <param name="item"></param>
        void Create(Review item);

        /// <summary>
        /// FindById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Review FindById(int id);

        /// <summary>
        /// Get
        /// </summary>
        /// <returns></returns>
        IEnumerable<Review> Get();

        /// <summary>
        /// Get with predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        IEnumerable<Review> Get(Func<Review, bool> predicate);

        /// <summary>
        /// GetSort with predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        IEnumerable<Review> GetSort(Func<Review, DateTime> predicate);

        /// <summary>
        /// Remove
        /// </summary>
        /// <param name="item"></param>
        void Remove(Review item);

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="item"></param>
        void Update(Review item);
    }
}