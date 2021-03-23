using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using DataModels;

namespace Business.Account
{
    public class AccountManager : IAccountManager
    {
        private readonly ApplicationContext _applicationContext;

        public AccountManager(ApplicationContext appContext)
        {
            _applicationContext = appContext;
        }

        public List<UserModel> GetAllUsers()
        {
            return null;
        }

        public UserModel GetUserById(Guid id)
        {
            return null;
        }

        public void SignIn(UserModel model)
        {
            throw new NotImplementedException();
        }

        public void SignUp(RegisterModel model)
        {
            throw new NotImplementedException();
        }
    }
}
