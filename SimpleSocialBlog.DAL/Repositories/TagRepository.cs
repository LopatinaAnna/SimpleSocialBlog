using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SimpleSocialBlog.DAL.EF;
using SimpleSocialBlog.DAL.Entities;
using SimpleSocialBlog.DAL.Interfaces;

namespace SimpleSocialBlog.DAL.Repositories
{
    /// <summary>
    /// TagRepository
    /// </summary>
    public class TagRepository : ITagRepository
    {
        /// <summary>
        /// DataContext
        /// </summary>
        private readonly DataContext data;

        /// <summary>
        /// DbSet
        /// </summary>
        private readonly DbSet<Tag> dbSet;

        /// <summary>
        /// Constructor, takes data context as parameter
        /// </summary>
        /// <param name="context"></param>
        public TagRepository(DataContext context)
        {
            data = context;
            dbSet = context.Set<Tag>();
        }

        public void Create(Tag item)
        {
            dbSet.Add(item);
            data.SaveChanges();
        }

        public Tag FindById(int id)
        {
            return dbSet.Find(id);
        }

        public Tag FindByIdWithDetails(int id)
        {
            return dbSet.Include(x => x.Articles).FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Tag> GetAllTags()
        {
            return dbSet.AsNoTracking().ToList();
        }

        public Tag GetTagByName(string tag_name)
        {
            return dbSet.Include(x => x.Articles).FirstOrDefault(x => x.TagName == tag_name);
        }

        public void Remove(Tag item)
        {
            dbSet.Remove(item);
            data.SaveChanges();
        }

        public void Update(Tag item)
        {
            data.Entry(item).State = EntityState.Modified;
            data.SaveChanges();
        }
    }
}