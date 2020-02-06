using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IP_Final_3975.Models;
using Microsoft.AspNetCore.Mvc;

namespace IP_Final_3975.Controllers
{
    public class SportController : Controller
    {
        private readonly ISportRepo _context;
        
        public SportController(ISportRepo context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.GetSports());
        }
    }
}