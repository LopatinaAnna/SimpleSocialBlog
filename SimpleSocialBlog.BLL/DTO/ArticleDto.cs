using System;
using System.Collections.Generic;

namespace SimpleSocialBlog.BLL.DTO
{
    /// <summary>
    /// Defines Article entity
    /// </summary>
    public class ArticleDto
    {
        /// <summary>
        /// Id of article
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Title of article
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Creating date of article
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Text of article
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Article's tags
        /// </summary>
        public IEnumerable<string> Tags { get; set; }
    }
}