using AutoMapper;
using System.Collections.Generic;
using SimpleSocialBlog.BLL.DTO;
using SimpleSocialBlog.BLL.Interfaces;
using SimpleSocialBlog.DAL.Entities;
using SimpleSocialBlog.DAL.Interfaces;

namespace SimpleSocialBlog.BLL.Services
{
    /// <summary>
    /// Review service
    /// </summary>
    public class ReviewService : IReviewService
    {
        /// <summary>
        /// UnitOfWork object
        /// </summary>
        private readonly IUnitOfWork database;

        /// <summary>
        /// Constructor, init database
        /// </summary>
        public ReviewService(IUnitOfWork uow)
        {
            database = uow;
        }

        /// <summary>
        /// Add new review
        /// </summary>
        /// <param name="item"></param>
        public void AddItem(ReviewDto item)
        {
            database.Reviews.Create(new Review() { Name = item.Name, Date = item.Date, Text = item.Text });
            database.Save();
        }

        /// <summary>
        /// Get Sort
        /// </summary>
        /// <returns>Sorting collection of reviews</returns>
        public IEnumerable<ReviewDto> GetSort()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Review, ReviewDto>()).CreateMapper();
            return mapper.Map<IEnumerable<Review>, List<ReviewDto>>(database.Reviews.GetSort(x => x.Date));
        }
    }
}