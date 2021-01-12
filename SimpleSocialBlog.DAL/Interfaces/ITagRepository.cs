using System.Collections.Generic;
using SimpleSocialBlog.DAL.Entities;

namespace SimpleSocialBlog.DAL.Interfaces
{
    /// <summary>
    /// ITagRepository
    /// </summary>
    public interface ITagRepository
    {
        /// <summary>
        /// Create
        /// </summary>
        /// <param name="item"></param>
        void Create(Tag item);

        /// <summary>
        /// FindById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Tag FindById(int id);

        /// <summary>
        /// FindByIdWithDetails
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Tag FindByIdWithDetails(int id);

        /// <summary>
        /// Get Tag By Name
        /// </summary>
        /// <param name="tag_name">Name</param>
        /// <returns>Tag By Name</returns>
        Tag GetTagByName(string tag_name);

        /// <summary>
        /// Get
        /// </summary>
        /// <returns></returns>
        IEnumerable<Tag> GetAllTags();

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="item"></param>
        void Update(Tag item);

        /// <summary>
        /// Remove
        /// </summary>
        /// <param name="item"></param>
        void Remove(Tag item);
    }
}