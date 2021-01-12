using System.Collections.Generic;

namespace SimpleSocialBlog.BLL.DTO
{
    /// <summary>
    /// Defines Tag entity
    /// </summary>
    public class TagDto
    {
        /// <summary>
        /// Id of tag
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string TagName { get; set; }

        /// <summary>
        /// Articles collection
        /// </summary>
        public IEnumerable<ArticleDto> Articles { get; set; }
    }
}