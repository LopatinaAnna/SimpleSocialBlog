using System.Collections.Generic;
using SimpleSocialBlog.BLL.DTO;

namespace SimpleSocialBlog.BLL.Interfaces
{
    /// <summary>
    /// ITagService
    /// </summary>
    public interface ITagService
    {
        /// <summary>
        /// Add new tag
        /// </summary>
        /// <param name="item"></param>
        void AddItem(TagDto item);

        /// <summary>
        /// Get Sort
        /// </summary>
        /// <returns>Collection of tags</returns>
        IEnumerable<TagDto> GetAll();
    }
}
