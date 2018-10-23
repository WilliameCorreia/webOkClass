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
        [ValidateAntiForgeryToken]
        public IActionResult Index(Login login)
        {
            if (ModelState.IsValid)
            {
                string CfSenha = null;
                Usuario Dbusuario = null;

                IEnumerable<Usuario> DbObjeto = from dados in _webOkClassContext.Usuarios where dados.Email == login.Email select dados;

                foreach (Usuario dados in DbObjeto)
                {
                    Dbusuario = dados;
                    CfSenha = dados.Senha;
                }

                if (CfSenha == login.Senha)
                {
                    return View("PaginaPrincipal",Dbusuario);
                }
                else
                {
                    string msg = "Usuario ou senha inválido";
                    return View("Index");
                }
            }
            return View(login);
        }      
       

        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Cadastro(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _webOkClassContext.Add(usuario);

                _webOkClassContext.SaveChanges();

                return View();
            }
            else
            {
                return View(usuario);
            }
        }
    }
}
