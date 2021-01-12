using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SimpleSocialBlog.PL.Models
{
    /// <summary>
    /// Defines Review entity
    /// </summary>
    public class ReviewViewModel
    {
        /// <summary>
        /// Review id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Author's name
        /// </summary>
        [Required(ErrorMessage = "Name is required")]
        [RegularExpression("^[A-Za-zА-Яа-яЁёІі\\s]+$", ErrorMessage = "Incorrect name")]
        [Remote("ValidateNameLength", "Guestroom")]
        public string Name { get; set; }

        /// <summary>
        /// Create date
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Review's text
        /// </summary>
        [Required(ErrorMessage = "Review is required")]
        public string Text { get; set; }
    }
}