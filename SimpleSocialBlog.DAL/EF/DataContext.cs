using System;
using System.Collections.Generic;
using System.Data.Entity;
using SimpleSocialBlog.DAL.Entities;

namespace SimpleSocialBlog.DAL.EF
{
    /// <summary>
    /// Define db context and include DbSet of models
    /// </summary>
    public class DataContext : DbContext
    {
        /// <summary>
        /// Constructor, call base with connection string
        /// </summary>
        public DataContext() : base("DefaultConnection")
        {
            Database.SetInitializer(new DataContextInitializer());
        }

        /// <summary>
        /// Constructor, call base with connection string
        /// </summary>
        static DataContext()
        {
            Database.SetInitializer(new DataContextInitializer());
        }

        /// <summary>
        /// DbSets for Articles
        /// </summary>
        public DbSet<Article> Articles { get; set; }

        /// <summary>
        /// DbSets for Reviews
        /// </summary>
        public DbSet<Review> Reviews { get; set; }

        /// <summary>
        /// DbSets for Questionaries
        /// </summary>
        public DbSet<Questionary> Questionaries { get; set; }

        /// <summary>
        /// DbSets for Tags
        /// </summary>
        public DbSet<Tag> Tags { get; set; }
    }

    /// <summary>
    /// DataContext Initializer
    /// </summary>
    public class DataContextInitializer : CreateDatabaseIfNotExists<DataContext>
    {
        /// <summary>
        /// Add data to the context
        /// </summary>
        /// <param name="context"></param>
        protected override void Seed(DataContext context)
        {
            Tag tag1 = new Tag() { TagName = "lorem" };
            Tag tag2 = new Tag() { TagName = "sit amet" };
            Tag tag3 = new Tag() { TagName = "adipisicing" };

            IList<Tag> defaultTags = new List<Tag>
            {
                tag1,
                tag2,
                tag3
            };

            context.Tags.AddRange(defaultTags);

            IList<Article> defaultArticles = new List<Article>
            {
                new Article()
                {
                    Title = "Consectetur",
                    Date = new DateTime(2020, 8, 1),
                    Tags = new List<Tag>
                    {
                        tag1,
                        tag2,
                        tag3
                    },
                    Text = "Lorem ipsum dolor, sit amet consectetur adipisicing elit. Eum harum, veritatis aut, ratione laborum quibusdam expedita magnam laboriosam corrupti sint, animi natus adipisci earum voluptates id perspiciatis incidunt error assumenda."
                },
                new Article()
                {
                    Title = "Animi natus",
                    Date = new DateTime(2020, 4, 14),
                    Tags = new List<Tag>
                    {
                        tag1
                    },
                    Text = "Eum harum, veritatis aut, ratione laborum quibusdam expedita magnam laboriosam corrupti sint, animi natus adipisci earum voluptates id perspiciatis incidunt error assumenda. Lorem ipsum dolor, sit amet consectetur adipisicing elit. Eum harum, veritatis aut, ratione laborum quibusdam expedita magnam laboriosam corrupti sint, animi natus adipisci earum voluptates id perspiciatis incidunt error assumenda."
                },
                new Article()
                {
                    Title = "Voluptates",
                    Date = new DateTime(2020, 3, 9),
                    Tags = new List<Tag>
                    {
                        tag3
                    },
                    Text = "Lorem ipsum dolor, sit amet consectetur adipisicing elit. Lorem ipsum dolor, sit amet consectetur adipisicing elit. Eum harum, veritatis aut, ratione laborum quibusdam expedita magnam laboriosam corrupti sint, animi natus adipisci earum voluptates id perspiciatis incidunt error assumenda."
                },
                new Article()
                {
                    Title = "Assumenda",
                    Date = new DateTime(2020, 2, 26),
                    Tags = new List<Tag>
                    {
                        tag1
                    },
                    Text = "Lorem ipsum dolor, sit amet consectetur adipisicing elit. Eum harum, veritatis aut, ratione laborum quibusdam expedita magnam laboriosam corrupti sint, animi natus adipisci earum voluptates id perspiciatis incidunt error assumenda."
                },
                new Article()
                {
                    Title = "Veritatis aut",
                    Date = new DateTime(2020, 2, 13),
                    Tags = new List<Tag>
                    {
                        tag2,
                        tag3
                    },
                    Text = "Lorem ipsum dolor, sit amet consectetur adipisicing elit. Eum harum, veritatis aut, ratione lam expedita magnam laboriosam corrupti sint, animi natus adipisci earum voluptates id perspiciatis incidunt error assumen daborum quibusda. Eum harum, veritatis aut, ratione laborum quibusdam expedita magnam laboriosam corrupti sint, animi natus adipisci earum voluptates id perspiciatis incidunt error assumenda."
                },
                new Article()
                {
                    Title = "Amet consectetur",
                    Date = new DateTime(2020, 2, 6),
                    Tags = new List<Tag>
                    {
                        tag3
                    },
                    Text = "Lorem ipsum dolor, sit amet consectetur adipisicing elit. Eum harum, veritatis aut, ratione laborum quibusdam expedita magnam laboriosam corrupti sint, animi natus adipisci earum voluptates id perspiciatis incidunt error assumenda."
                }
            };

            IList<Review> defaultReviews = new List<Review>
            {
                new Review()
                {
                    Name = "Lorem",
                    Date = new DateTime(2020, 3, 15),
                    Text = "Eum harum, veritatis aut, ratione laborum quibusdam expedita magnam laboriosam corrupti sint, animi natus adipisci earum voluptates id perspiciatis incidunt error assumenda."
                },
                new Review()
                {
                    Name = "Eum",
                    Date = new DateTime(2020, 3, 20),
                    Text = "Lorem ipsum dolor, sit amet consectetur adipisicing elit. Eum harum, veritatis aut, ratione laborum quibusdam expedita magnam laboriosam corrupti sint, animi natus adipisci earum voluptates id perspiciatis incidunt error assumenda."
                },
                new Review()
                {
                    Name = "Eum",
                    Date = new DateTime(2020, 4, 12),
                    Text = "Lorem ipsum dolor, sit amet consectetur adipisicing elit. Eum harum, veritatis aut, ratione laborum quibusdam expedita magnam laboriosam corrupti sint, animi natus adipisci earum voluptates id perspiciatis incidunt error assumenda."
                },
                new Review()
                {
                    Name = "Eum",
                    Date = new DateTime(2020, 4, 15),
                    Text = "Lorem ipsum dolor, sit amet consectetur adipisicing elit. Eum harum, veritatis aut, ratione laborum quibusdam expedita magnam laboriosam corrupti sint, animi natus adipisci earum voluptates id perspiciatis incidunt error assumenda."
                },
                new Review()
                {
                    Name = "Eum",
                    Date = new DateTime(2020, 6, 23),
                    Text = "Lorem ipsum dolor, sit amet consectetur adipisicing elit. Eum harum, veritatis aut, ratione laborum quibusdam expedita magnam laboriosam corrupti sint, animi natus adipisci earum voluptates id perspiciatis incidunt error assumenda."
                }
            };

            context.Articles.AddRange(defaultArticles);
            context.Reviews.AddRange(defaultReviews);
            context.Tags.AddRange(defaultTags);

            base.Seed(context);
        }
    }
}