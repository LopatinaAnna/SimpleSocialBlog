using Ninject.Modules;
using SimpleSocialBlog.BLL.Interfaces;
using SimpleSocialBlog.BLL.Services;

namespace SimpleSocialBlog.Util
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IArticleService>().To<ArticleService>();
            Bind<IReviewService>().To<ReviewService>();
            Bind<IQuestionaryService>().To<QuestionaryService>();
        }
    }
}