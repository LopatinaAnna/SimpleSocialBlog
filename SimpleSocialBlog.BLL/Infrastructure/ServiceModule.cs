using Ninject.Modules;
using SimpleSocialBlog.DAL.Interfaces;
using SimpleSocialBlog.DAL.Repositories;

namespace SimpleSocialBlog.BLL.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        private string connectionString;

        public ServiceModule(string connection)
        {
            connectionString = connection;
        }

        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>().WithConstructorArgument(connectionString);
        }
    }
}