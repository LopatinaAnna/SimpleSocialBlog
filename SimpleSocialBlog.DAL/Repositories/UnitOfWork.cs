using System;
using SimpleSocialBlog.DAL.EF;
using SimpleSocialBlog.DAL.Interfaces;

namespace SimpleSocialBlog.DAL.Repositories
{
    /// <summary>
    /// Defines access to repositories with properties and context for repositories
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// Data context
        /// </summary>
        private readonly DataContext data = new DataContext();

        /// <summary>
        /// Article repository
        /// </summary>
        private ArticleRepository articleRepository;

        /// <summary>
        /// Review repository
        /// </summary>
        private ReviewRepository reviewRepository;

        /// <summary>
        /// Questionary repository
        /// </summary>
        private QuestionaryRepository questionaryRepository;

        /// <summary>
        /// Article repository
        /// </summary>
        private TagRepository tagRepository;

        /// <summary>
        /// Articles property
        /// </summary>
        public IArticleRepository Articles
        {
            get
            {
                if (articleRepository == null)
                    articleRepository = new ArticleRepository(data);
                return articleRepository;
            }
        }

        /// <summary>
        /// Tags property
        /// </summary>
        public ITagRepository Tags
        {
            get
            {
                if (tagRepository == null)
                    tagRepository = new TagRepository(data);
                return tagRepository;
            }
        }

        /// <summary>
        /// Reviews property
        /// </summary>
        public IReviewRepository Reviews
        {
            get
            {
                if (reviewRepository == null)
                    reviewRepository = new ReviewRepository(data);
                return reviewRepository;
            }
        }

        /// <summary>
        /// Questionaries property
        /// </summary>
        public IQuestionaryRepository Questionaries
        {
            get
            {
                if (questionaryRepository == null)
                    questionaryRepository = new QuestionaryRepository(data);
                return questionaryRepository;
            }
        }

        /// <summary>
        /// Save changes
        /// </summary>
        public void Save()
        {
            data.SaveChanges();
        }

        private bool disposed = false;

        /// <summary>
        /// Dispose
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    data.Dispose();
                }
                disposed = true;
            }
        }

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}