using System;
using System.Collections.Generic;

namespace SimpleSocialBlog.DAL.Entities
{
    /// <summary>
    /// Defines Article entity
    /// </summary>
    public class Article : BaseEntity
    {
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
        public ICollection<Tag> Tags { get; set; }

        /// <summary>
        /// Article constructor
        /// </summary>
        public Article()
        {
            Tags = new List<Tag>();
        }
    }
}