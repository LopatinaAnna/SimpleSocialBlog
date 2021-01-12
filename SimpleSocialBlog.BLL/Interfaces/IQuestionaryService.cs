using System.Collections.Generic;
using SimpleSocialBlog.BLL.DTO;

namespace SimpleSocialBlog.BLL.Interfaces
{
    /// <summary>
    /// Article service interface
    /// </summary>
    public interface IQuestionaryService
    {
        /// <summary>
        /// Add new questionary
        /// </summary>
        /// <param name="item"></param>
        void AddItem(QuestionaryDto item);

        /// <summary>
        /// Get Rate
        /// </summary>
        /// <returns>Rate</returns>
        decimal GetRate();

        /// <summary>
        /// Get Sort
        /// </summary>
        /// <returns>Sorting collection of reviews</returns>
        IEnumerable<QuestionaryDto> GetAll();
    }
}