using System;
using System.Collections.Generic;
using SimpleSocialBlog.DAL.Entities;

namespace SimpleSocialBlog.DAL.Interfaces
{
    /// <summary>
    /// IQuestionaryRepository
    /// </summary>
    public interface IQuestionaryRepository
    {
        /// <summary>
        /// Create
        /// </summary>
        /// <param name="item"></param>
        void Create(Questionary item);

        /// <summary>
        /// FindById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Questionary FindById(int id);

        /// <summary>
        /// Get
        /// </summary>
        /// <returns></returns>
        IEnumerable<Questionary> Get();

        /// <summary>
        /// Get with predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        IEnumerable<Questionary> Get(Func<Questionary, bool> predicate);

        /// <summary>
        /// Remove
        /// </summary>
        /// <param name="item"></param>
        void Remove(Questionary item);

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="item"></param>
        void Update(Questionary item);
    }
}