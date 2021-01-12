using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SimpleSocialBlog.DAL.EF;
using SimpleSocialBlog.DAL.Entities;
using SimpleSocialBlog.DAL.Interfaces;

namespace SimpleSocialBlog.DAL.Repositories
{
    /// <summary>
    /// ArticleRepository
    /// </summary>
    public class ArticleRepository : IArticleRepository
    {
        /// <summary>
        /// DataContext
        /// </summary>
        private readonly DataContext data;

        /// <summary>
        /// DbSet
        /// </summary>
        private readonly DbSet<Article> dbSet;

        /// <summary>
        /// Constructor, takes data context as parameter
        /// </summary>
        /// <param name="context"></param>
        public ArticleRepository(DataContext context)
        {
            data = context;
            dbSet = context.Set<Article>();
        }

        public void Create(Article item)
        {
            dbSet.Add(item);
            data.SaveChanges();
        }

        public Article FindById(int id)
        {
            return dbSet.Find(id);
        }

        public Article FindByIdWithDetails(int id)
        {
            return data.Articles.Include(x => x.Tags).FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Article> Get()
        {
            return dbSet.AsNoTracking().ToList();
        }

        public IEnumerable<Article> Get(Func<Article, bool> predicate)
        {
            return dbSet.AsNoTracking().Where(predicate).ToList();
        }

        public IEnumerable<Article> GetArticlesByTag(string tag_name)
        {
            return data.Articles.Include(x => x.Tags)
                .Where(x => x.Tags.Select(y => y.TagName).Contains(tag_name))
                .OrderByDescending(x => x.Date);
        }

        public IEnumerable<Article> GetSort(Func<Article, DateTime> predicate)
        {
            return dbSet.AsNoTracking().OrderByDescending(predicate).ToList();
        }

        public IEnumerable<Article> GetSortArticles()
        {
            return dbSet.Include(x => x.Tags).OrderByDescending(x => x.Date);
        }

        public void Remove(Article item)
        {
            dbSet.Remove(item);
            data.SaveChanges();
        }

        public void Update(Article item)
        {
            data.Entry(item).State = EntityState.Modified;
            data.SaveChanges();
        }
    }
}