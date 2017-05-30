

namespace SmartCardReader.ServiceLayer.Base.Account
{
    public abstract class AbstractAccountService : IAccountService
    {
//        private ApplicationSignInManager _signInManager;
//        private ApplicationUserManager _userManager;

        public abstract void Register();

        public abstract void Login();
    }
}