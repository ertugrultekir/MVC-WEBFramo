using Framo.Model.Entities;
using Framo.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framo.Service.Option
{
    public class UserService : BaseService<User>
    {
        public bool CheckCredentials(string username, string password)
        {
            return Any(x => x.EmailAddress == username && x.Password == password);
        }
    }
}
