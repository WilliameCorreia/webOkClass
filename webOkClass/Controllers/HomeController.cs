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

        Usuario UsuarioLogin = new Usuario();
       
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(Login login)
        {
            if (ValidacaoLogin(login))
            {
                return RedirectToAction("_PaginaPrincipal", UsuarioLogin);
            }
            else
            {
                return View(login);
            }
            
        }

        //autenticação de usuário
        public bool ValidacaoLogin(Login login)
        {
            if (ModelState.IsValid)
            {
                IEnumerable<Usuario> DbObjeto = from dados in _webOkClassContext.Usuarios where dados.Email == login.Email select dados;

                UsuarioLogin = DbObjeto.First();

                if (UsuarioLogin.Senha == login.Senha)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
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

        [HttpGet]
        public JsonResult Dbsalas()
        {
            IEnumerable<SalaDeAula> DbSalas = from sala in _webOkClassContext.Salas select sala;

            var db = DbSalas.ToList();

            return Json(DbSalas);
        }

        [HttpPost]
        public void UpdateSala(int valor, int id)
        {
            if (valor != 0 && id != 0)
            {
                SalaDeAula sala = new SalaDeAula();

                sala = _webOkClassContext.Salas.Find(id);

                sala.StatusDaSala = valor;

                _webOkClassContext.SaveChanges();
            }
            else
            {              
                       
            }


        }

        public IActionResult _PaginaPrincipal(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                return View(usuario);
            }
            else
            {
                return RedirectToAction("Index",usuario);
            }
           
        }

        public IActionResult Painel()
        {
            return View("Painel");
        }

        public IActionResult PerfilUsuario()
        {
            return View();
        }

        public IActionResult Historico()
        {
            return View();
        }

    }
}
