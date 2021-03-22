using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;
using DataModels;

namespace Business.Account
{
    /// <summary>
    ///  IAccountManager
    /// </summary>
    public interface IAccountManager
    {
        /// <summary>
        /// SignIn
        /// </summary>
        /// <returns></returns>
        void SignIn(LoginModel model);

        /// <summary>
        /// SignUp
        /// <returns></returns>
        void SignUp(RegisterModel model);

        User GetUserById(Guid id);

        List<User> GetAllUsers();
    }
}
