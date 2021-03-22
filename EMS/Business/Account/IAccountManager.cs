using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        void SignIn();

        /// <summary>
        /// SignUp
        /// <returns></returns>
        void SignUp();
    }
}
