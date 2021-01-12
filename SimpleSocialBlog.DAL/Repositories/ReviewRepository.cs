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
    /// ReviewRepository
    /// </summary>
    public class ReviewRepository : IReviewRepository
    {
        /// <summary>
        /// DataContext
        /// </summary>
        private readonly DataContext data;

        /// <summary>
        /// DbSet
        /// </summary>
        private readonly DbSet<Review> dbSet;

        /// <summary>
        /// Constructor, takes data context as parameter
        /// </summary>
        /// <param name="context"></param>
        public ReviewRepository(DataContext context)
        {
            data = context;
            dbSet = context.Set<Review>();
        }

        public void Create(Review item)
        {
            dbSet.Add(item);
            data.SaveChanges();
        }

        public Review FindById(int id)
        {
            return dbSet.Find(id);
        }

        public IEnumerable<Review> Get()
        {
            return dbSet.AsNoTracking().ToList();
        }

        public IEnumerable<Review> Get(Func<Review, bool> predicate)
        {
            return dbSet.AsNoTracking().Where(predicate).ToList();
        }

        public IEnumerable<Review> GetSort(Func<Review, DateTime> predicate)
        {
            return dbSet.AsNoTracking().OrderByDescending(predicate).ToList();
        }

        public void Remove(Review item)
        {
            dbSet.Remove(item);
            data.SaveChanges();
        }

        public void Update(Review item)
        {
            data.Entry(item).State = EntityState.Modified;
            data.SaveChanges();
        }
    }
}