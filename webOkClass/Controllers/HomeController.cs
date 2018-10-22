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
            if (ModelState.IsValid)
            {
                string CfSenha = null;
                Usuario Dbusuario = null;

                IEnumerable<Usuario> DbObjeto = from dados in _webOkClassContext.Usuarios where dados.Email == Email select dados;

                foreach (Usuario dados in DbObjeto)
                {
                    Dbusuario = dados;
                    CfSenha = dados.Senha;
                }

                if (CfSenha == Senha)
                {
                    return View(Dbusuario);
                }
                else
                {
                    return View("Index");
                }
            }
            return View("Index");       
           
        }


        [HttpPost]
        public IActionResult AddUsuario(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _webOkClassContext.Add(usuario);

                _webOkClassContext.SaveChanges();
            }

            return View("Cadastro");
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
