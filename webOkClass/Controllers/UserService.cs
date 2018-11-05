using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webOkClass.DataContext;
using webOkClass.Models;

namespace webOkClass.Controllers
{
    public interface IUserService
    {
        Login Authenticate(string email, string password);
    }

    public class UserService : IUserService
    {
        public readonly WebOkClassContext _webOkClassContext;

        public UserService(WebOkClassContext webOkClassContext)
        {
            _webOkClassContext = webOkClassContext;
        }

        public Login Authenticate(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                return null;
            }

            Login user = new Login();

            IEnumerable<Usuario> DbObjeto = from dados in _webOkClassContext.Usuarios where dados.Email == email select dados;

            user = DbObjeto.First();

            if (user.Email == email && user.Password == password)
            {
                return user;
            }

            return null;

            
        }
    }
}
