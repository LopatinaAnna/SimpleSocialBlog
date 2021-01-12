using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace SimpleSocialBlog.Models
{
    public class AppDbInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            var role1 = new IdentityRole { Name = "admin" };
            var role2 = new IdentityRole { Name = "user" };

            roleManager.Create(role1);
            roleManager.Create(role2);

            var admin = new ApplicationUser { Email = "admin@mail.ru", UserName = "admin@mail.ru" };
            var result1 = userManager.Create(admin, "Admin-1");

            var user = new ApplicationUser { Email = "user@mail.ru", UserName = "user@mail.ru" };
            var result2 = userManager.Create(user, "User-1");

            if (result1.Succeeded)
            {
                userManager.AddToRole(admin.Id, role1.Name);
                userManager.AddToRole(admin.Id, role2.Name);
            }
            if (result2.Succeeded)
            {
                userManager.AddToRole(user.Id, role2.Name);
            }

            base.Seed(context);
        }
    }
}