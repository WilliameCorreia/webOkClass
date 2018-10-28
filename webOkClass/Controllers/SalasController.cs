using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using webOkClass.DataContext;
using webOkClass.Models;

namespace webOkClass.Controllers
{
    public class SalasController : Controller
    {
        public readonly WebOkClassContext _webOkClassContext;

        public SalasController(WebOkClassContext webOkClassContext)
        {
            _webOkClassContext = webOkClassContext;
        }

        public IActionResult Index()
        {
            return View();
        }        
        
        public IActionResult _PaginaPrincipal()
        {
            IEnumerable<SalaDeAula> DbSalas = from sala in _webOkClassContext.Salas select sala;

            var Dbjson = Json(DbSalas);
            
            return View(DbSalas);

        }

        public IActionResult Painel()
        {
            return View();
        }

        public IActionResult PerfilUsuario()
        {
            return View();
        }

        public IActionResult Historico()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UpdateSala(int valor, int id)
        {
            SalaDeAula sala = new SalaDeAula();

            sala = _webOkClassContext.Salas.Find(id);

            sala.StatusDaSala = valor;

            _webOkClassContext.SaveChanges();

            return RedirectToAction("_PaginaPrincipal", "Salas");

        }

        [HttpGet]
        public JsonResult JsonResult()
        {
            IEnumerable<SalaDeAula> DbSalas = from sala in _webOkClassContext.Salas select sala;

            var db = DbSalas.ToList();

            return Json(DbSalas);
        }
    }
}