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
        
        
        
    }
}