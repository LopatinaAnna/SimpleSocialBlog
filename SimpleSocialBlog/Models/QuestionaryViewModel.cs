using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SimpleSocialBlog.PL.Models
{
    /// <summary>
    /// Defines Questionary entity
    /// </summary>
    public class QuestionaryViewModel
    {
        /// <summary>
        /// Id of questionary
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Person's name
        /// </summary>
        [Required(ErrorMessage = "Name is required")]
        [RegularExpression("^[A-Za-zА-Яа-яЁёІі\\s]+$", ErrorMessage = "Incorrect name")]
        [Remote("ValidateNameLength", "Questionary")]
        public string Name { get; set; }

        /// <summary>
        /// Rate of site
        /// </summary>
        [Required(ErrorMessage = "Rate is required")]
        public int Rate { get; set; }

        /// <summary>
        /// Recommend
        /// </summary>
        public bool Recommend { get; set; }
    }
}