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
    /// QuestionaryRepository
    /// </summary>
    public class QuestionaryRepository : IQuestionaryRepository
    {
        /// <summary>
        /// DataContext
        /// </summary>
        private readonly DataContext data;

        /// <summary>
        /// DbSet
        /// </summary>
        private readonly DbSet<Questionary> dbSet;

        /// <summary>
        /// Constructor, takes data context as parameter
        /// </summary>
        /// <param name="context"></param>
        public QuestionaryRepository(DataContext context)
        {
            data = context;
            dbSet = context.Set<Questionary>();
        }

        public void Create(Questionary item)
        {
            dbSet.Add(item);
            data.SaveChanges();
        }

        public Questionary FindById(int id)
        {
            return dbSet.Find(id);
        }

        public IEnumerable<Questionary> Get()
        {
            return dbSet.AsNoTracking().ToList();
        }

        public IEnumerable<Questionary> Get(Func<Questionary, bool> predicate)
        {
            return dbSet.AsNoTracking().Where(predicate).ToList();
        }

        public void Remove(Questionary item)
        {
            dbSet.Remove(item);
            data.SaveChanges();
        }

        public void Update(Questionary item)
        {
            data.Entry(item).State = EntityState.Modified;
            data.SaveChanges();
        }
    }
}