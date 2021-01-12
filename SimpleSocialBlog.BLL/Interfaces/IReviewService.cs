using System.Collections.Generic;
using SimpleSocialBlog.BLL.DTO;

namespace SimpleSocialBlog.BLL.Interfaces
{
    /// <summary>
    /// Article service interface
    /// </summary>
    public interface IReviewService
    {
        /// <summary>
        /// Add new review
        /// </summary>
        /// <param name="item"></param>
        void AddItem(ReviewDto item);

        /// <summary>
        /// Get Sort
        /// </summary>
        /// <returns>Sorting collection of reviews</returns>
        IEnumerable<ReviewDto> GetSort();
    }
}