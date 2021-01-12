using System.Data.Entity;

namespace SimpleSocialBlog.Logger
{
    public class LoggerContext : DbContext
    {
        public LoggerContext() : base("LoggerContext")
        {
        }

        public DbSet<ExceptionDetail> ExceptionDetails { get; set; }
    }
}