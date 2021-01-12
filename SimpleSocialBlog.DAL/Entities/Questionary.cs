namespace SimpleSocialBlog.DAL.Entities
{
    /// <summary>
    /// Defines Questionary entity
    /// </summary>
    public class Questionary : BaseEntity
    {
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