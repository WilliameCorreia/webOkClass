using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using webOkClass.DataContext;
using webOkClass.Models;

namespace webOkClass.Controllers
{
    public class HomeController : Controller
    {       
        public readonly WebOkClassContext _webOkClassContext;

        public HomeController(WebOkClassContext webOkClassContext)
        {
            _webOkClassContext = webOkClassContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult PaginaPrincipal(string Email, string Senha)
        {
            bool resultado = ValidationLogin(Email, Senha);

            if (resultado)
            {
                return View();
            }
            else
            {
                return Redirect("Index");
            }
           
        }

        public bool ValidationLogin(string Email, string Senha)
        {
            string CfSenha = null;

            IEnumerable<Usuario> DbObjeto = from dados in _webOkClassContext.Usuarios where dados.Email == Email select dados;

            foreach (Usuario dados in DbObjeto)
            {
                CfSenha = dados.Senha;
            }

            if (CfSenha == Senha)
            {
                return true;
            }
            else
            {
                return false;
            }

                      

        }

        [HttpPost]
        public void AddUsuario(Usuario usuario)
        {
            _webOkClassContext.Add(usuario);

            _webOkClassContext.SaveChanges();
        }

        public IActionResult Cadastro()
        {
            return View();
        }

        public IActionResult RecuperarSenha()
        {
            return View();
        }

    }
}
