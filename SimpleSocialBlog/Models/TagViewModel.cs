using System.Collections.Generic;
using SimpleSocialBlog.BLL.DTO;

namespace SimpleSocialBlog.Models
{
    public class TagViewModel
    {
        public string TagName { get; set; }

        public IEnumerable<ArticleDto> Articles { get; set; }
    }
}