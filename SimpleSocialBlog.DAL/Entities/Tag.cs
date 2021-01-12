using System.Collections.Generic;

namespace SimpleSocialBlog.DAL.Entities
{
    /// <summary>
    /// Tag entity
    /// </summary>
    public class Tag : BaseEntity
    {
        /// <summary>
        /// Name of tag
        /// </summary>
        public string TagName { get; set; }

        /// <summary>
        /// Articles collection
        /// </summary>
        public ICollection<Article> Articles { get; set; }

        /// <summary>
        /// Tag constructor
        /// </summary>
        public Tag()
        {
            Articles = new List<Article>();
        }
    }
}