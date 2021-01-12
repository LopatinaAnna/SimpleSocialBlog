using System;

namespace SimpleSocialBlog.BLL.DTO
{
    /// <summary>
    /// Defines Review entity
    /// </summary>
    public class ReviewDto
    {
        /// <summary>
        /// Review id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Author's name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Create date
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Review's text
        /// </summary>
        public string Text { get; set; }
    }
}