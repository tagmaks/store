using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace Spa.Infrastructure
{
    public class AppUserManager : UserManager<User, int>
    {
        public AppUserManager(IUserStore<User, int> store) : base(store)
        {
        }

        public static AppUserManager Create(IdentityFactoryOptions<AppUserManager> options, IOwinContext context)
        {
            var appDbContext = context.Get<AppDbContext>();

            var appUserManager = new AppUserManager(new CustomUserStore(appDbContext));

            // Configure validation logic for usernames
            appUserManager.UserValidator = new UserValidator<User, int>(appUserManager)
            {
                AllowOnlyAlphanumericUserNames = true,
                RequireUniqueEmail = true
            };

            // Configure validation logic for passwords
            appUserManager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = false,
                RequireLowercase = true,
                RequireUppercase = true,
            };

            return appUserManager;
        }
    }
}