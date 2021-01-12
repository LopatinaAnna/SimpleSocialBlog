using System;

namespace SimpleSocialBlog.DAL.Interfaces
{
    /// <summary>
    /// IUnitOfWork interface
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Articles property
        /// </summary>
        IArticleRepository Articles { get; }

        /// <summary>
        /// Reviews property
        /// </summary>
        IReviewRepository Reviews { get; }

        /// <summary>
        /// Questionaries property
        /// </summary>
        IQuestionaryRepository Questionaries { get; }

        /// <summary>
        /// Questionaries property
        /// </summary>
        ITagRepository Tags { get; }

        /// <summary>
        /// Save changes
        /// </summary>
        void Save();
    }
}