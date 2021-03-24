using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModels;

namespace Business.Account
{
    /// <summary>
    ///  IAccountManager
    /// </summary>
    public interface IUserManager
    {
        UserModel GetUserById(Guid id);

        List<UserModel> GetAllUsers();

        void AddNewUser(UserModel model);
    }
}
