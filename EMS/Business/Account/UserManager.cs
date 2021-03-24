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
    public class UserManager : IUserManager
    {
        private readonly ApplicationContext _applicationContext;

        public UserManager(ApplicationContext appContext)
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

        public void AddNewUser(UserModel model) 
        {
            if (model != null)
            {
                _applicationContext.Users.Add(model);
                
            }
        }
    }
}
