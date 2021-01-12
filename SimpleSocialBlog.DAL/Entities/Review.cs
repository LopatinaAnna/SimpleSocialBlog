using System;

namespace SimpleSocialBlog.DAL.Entities
{
    /// <summary>
    /// Defines Review entity
    /// </summary>
    public class Review : BaseEntity
    {
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