using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using DataModels;
using ViewModels;

namespace Business.Account
{
    public class AccountManager : IAccountManager
    {
        private readonly ApplicationContext _applicationContext;

        public AccountManager(ApplicationContext appContext)
        {
            _applicationContext = appContext;
        }

        public List<User> GetAllUsers()
        {
            return null;
        }

        public User GetUserById(Guid id)
        {
            return null;
        }

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
