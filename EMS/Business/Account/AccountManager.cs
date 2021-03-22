using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using ViewModels;

namespace Business.Account
{
    public class AccountManager : IAccountManager
    {
        private readonly ApplicationContext _accpicationContext = new ApplicationContext();

        public void SignIn(LoginModel model)
        {
            throw new NotImplementedException();
        }

        public void SignUp(RegisterModel model)
        {
            throw new NotImplementedException();
        }
    }
}
