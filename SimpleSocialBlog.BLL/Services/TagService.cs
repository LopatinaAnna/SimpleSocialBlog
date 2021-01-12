using AutoMapper;
using System.Collections.Generic;
using SimpleSocialBlog.BLL.DTO;
using SimpleSocialBlog.BLL.Interfaces;
using SimpleSocialBlog.DAL.Entities;
using SimpleSocialBlog.DAL.Interfaces;

namespace SimpleSocialBlog.BLL.Services
{
    class TagService : ITagService
    {
        /// <summary>
        /// UnitOfWork object
        /// </summary>
        public IUnitOfWork Database { get; set; }

        /// <summary>
        /// Constructor, init database
        /// </summary>
        public TagService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void AddItem(TagDto item)
        {
            Database.Tags.Create(new Tag() {  TagName = item.TagName });
            Database.Save();
        }

        public IEnumerable<TagDto> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Tag, TagDto>()).CreateMapper();
            return mapper.Map<IEnumerable<Tag>, IEnumerable<TagDto>>(Database.Tags.GetAllTags());
        }
    }
}
