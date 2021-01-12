using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using SimpleSocialBlog.BLL.DTO;
using SimpleSocialBlog.BLL.Interfaces;
using SimpleSocialBlog.DAL.Entities;
using SimpleSocialBlog.DAL.Interfaces;

namespace SimpleSocialBlog.BLL.Services
{
    /// <summary>
    /// Questionary service
    /// </summary>
    public class QuestionaryService : IQuestionaryService
    {
        /// <summary>
        /// UnitOfWork object
        /// </summary>
        private readonly IUnitOfWork database;

        /// <summary>
        /// Constructor, init database
        /// </summary>
        public QuestionaryService(IUnitOfWork uow)
        {
            database = uow;
        }

        /// <summary>
        /// Add new questionary
        /// </summary>
        /// <param name="item"></param>
        public void AddItem(QuestionaryDto item)
        {
            database.Questionaries.Create(new Questionary() { Name = item.Name, Rate = item.Rate, Recommend = item.Recommend });
            database.Save();
        }

        /// <summary>
        /// Get Rate
        /// </summary>
        /// <returns>Rate</returns>
        public decimal GetRate()
        {
            decimal sum = 0;
            var questionaries = database.Questionaries.Get().ToList();
            questionaries.ForEach(item => sum += item.Rate);
            return decimal.Round(sum / questionaries.Count, 2);
        }

        /// <summary>
        /// Get Sort
        /// </summary>
        /// <returns>Sorting collection of reviews</returns>
        public IEnumerable<QuestionaryDto> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Questionary, QuestionaryDto>()).CreateMapper();
            return mapper.Map<IEnumerable<Questionary>, List<QuestionaryDto>>(database.Questionaries.Get());
        }
    }
}