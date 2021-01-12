namespace SimpleSocialBlog.BLL.DTO
{
    /// <summary>
    /// Defines Questionary entity
    /// </summary>
    public class QuestionaryDto
    {
        /// <summary>
        /// Id of questionary
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Person's name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Rate of site
        /// </summary>
        public int Rate { get; set; }

        /// <summary>
        /// Recommend
        /// </summary>
        public bool Recommend { get; set; }
    }
}