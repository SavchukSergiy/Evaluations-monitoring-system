using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
            return _applicationContext.Users.ToList();
        }

        public UserModel GetUserById(Guid id)
        {
            return _applicationContext.Users.FirstOrDefault(u => u.Id == id);
        }
    }
}
