using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using webOkClass.DataContext;
using webOkClass.Models;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

namespace webOkClass.Controllers
{
    public class HomeController : Controller
    {
        //instanciando uma classe de serviço por injeção
        public readonly WebOkClassContext _webOkClassContext;      

        public string Message { get; private set; } = string.Empty;

        //instanciando uma classe de serviço por injeção
        private IUserService _userService;

        public HomeController(IUserService userService, WebOkClassContext webOkClassContext)
        {
            _userService = userService;
            _webOkClassContext = webOkClassContext;
        }

        //fazendo bind da model para ser usada no front-end
        [BindProperty]
        public Login login { get; set; }

        Login LoginUsuario = new Login();

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
       
        [HttpPost]
        public IActionResult Index(Login login)
        {
            //verifica se o usuário está autenticado
            if (ModelState.IsValid)
            {
                if(AutenticacaoUsuario() == null)
                {
                    ViewBag.mensagem = "usuario não cadastrado";
                    return View();
                }
                else
                {
                    return RedirectToAction("_PaginaPrincipal");
                }                
            }
            else
            {
                return View(login);
            }
            
        }

        public IActionResult _PaginaPrincipal()
        {
            //verifica se o usuário está autenticado
            if (User.Identity.IsAuthenticated)
            {
                var Email = User.Claims.ToList();

                LoginUsuario.Email = Email[0].Value;

                return View(LoginUsuario);

            }
            else
            {
                return RedirectToAction("Index");
            }            
        }

        public IActionResult Painel()
        {
            //verifica se o usuário está autenticado
            if (User.Identity.IsAuthenticated)
            {
                var Email = User.Claims.ToList();

                LoginUsuario.Email = Email[0].Value;

                return View(LoginUsuario);

            }
            else
            {
                return RedirectToAction("Index");
            }   
        }

        public IActionResult PerfilUsuario()
        {
            //verifica se o usuário está autenticado
            if (User.Identity.IsAuthenticated)
            {
                var Email = User.Claims.ToList();

                LoginUsuario.Email = Email[0].Value;

                return View(LoginUsuario);

            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public IActionResult Historico()
        {
            //verifica se o usuário está autenticado
            if (User.Identity.IsAuthenticated)
            {
                var Email = User.Claims.ToList();

                LoginUsuario.Email = Email[0].Value;

                return View(LoginUsuario);

            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public IActionResult Cadastro()
        {
            return View();
        }

        //metodo post do formulario
        public IActionResult AutenticacaoUsuario()
        {
            if (!ModelState.IsValid || ModelState.Count == 0)
            {
                return RedirectToAction("Index");
            }

            //faz a busca do usuário e verifica se existe
            var user = _userService.Authenticate(login.Email, login.Password);

            LoginUsuario = user;

            if (user == null)
                return null;

            //declara claim de identidade
            var claim = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Token.ToString())
                });

            var claims = new[]
            {
                 new Claim(ClaimTypes.Email, user.Email.ToString())
            }.ToAsyncEnumerable().ToEnumerable();


            //faz autenticação via Cookie
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(identity));

            return RedirectToAction("_PaginaPrincipal",LoginUsuario);
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Cadastro(Usuario usuario)
        {
            usuario.Token = "token";

            usuario.CreateDate = DateTime.Now.ToLocalTime();

            bool status = _userService.VerificaExiste(usuario);

            if (ModelState.IsValid && status)
            {
                _webOkClassContext.Add(usuario);

                _webOkClassContext.SaveChanges();

                return AutenticacaoUsuario();
            }
            if (!status)
            {
                ViewBag.Mensagem = "Usuario Já Cadastrado";
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
        public void UpdateSala(int valor, int id, int statusReserva = 0, int usuario = 0)
        {
            if (valor != 0 && id != 0)
            {
                SalaDeAula sala = new SalaDeAula();
                ReservaSala reserva = new ReservaSala();

                if (statusReserva == 1 && statusReserva != 0)
                {
                    IEnumerable<ReservaSala> DbSalas = from dbReserva in _webOkClassContext.reservas
                              where dbReserva.UsuarioId == usuario && dbReserva.StatusReserva == 1
                              select dbReserva;

                    if(DbSalas.Count() != 0)
                    {
                        reserva = DbSalas.First();

                        reserva.StatusReserva = 2;
                    }
                    
                }
                

                sala = _webOkClassContext.Salas.Find(id);

                sala.StatusDaSala = valor;

                _webOkClassContext.SaveChanges();
            }
            else
            {

            }


        }       

        [HttpPost]
        public void SalaReservar(int valor, int id, int usuario)
        {
            ReservaSala reservaSala = new ReservaSala();
            reservaSala.StatusReserva = 1;
            reservaSala.SalaDeAulaId = id;
            reservaSala.UsuarioId = usuario;

            _webOkClassContext.Add(reservaSala);
            _webOkClassContext.SaveChanges();

            UpdateSala(valor, id);

        }
       
        public JsonResult CarregarUsuario(string email)
        {
            ReservaSala reserva = new ReservaSala();
            Usuario usuario = new Usuario();
            

            IEnumerable<ReservaSala> DbSalas = from salas in _webOkClassContext.reservas.Include(x => x.Usuario).Include(x=>x.SalaDeAula)
                                               where salas.Usuario.Email == email && salas.StatusReserva == 1 select salas;
          
            if (DbSalas.Count() != 0)
            {
                reserva = DbSalas.First();
                return Json(reserva);
            }
            else
            {
                IEnumerable<Usuario> DbObjeto = from dados in _webOkClassContext.Usuarios where dados.Email == email select dados;
                usuario = DbObjeto.First();
                return Json(usuario);
            }                       
            
        }

    }
}
