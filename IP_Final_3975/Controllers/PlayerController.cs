using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IP_Final_3975.Models;
using Microsoft.AspNetCore.Mvc;

namespace IP_Final_3975.Controllers
{
    public class PlayerController : Controller
    {
        //private readonly IPlayersRepo _context;

        //public PlayerController(IPlayersRepo context)
        //{
        //    _context = context;
        //}
        private readonly IPFinalContext _context;

        public PlayerController(IPFinalContext context)
        {
            _context = context;
        }

        public IActionResult Index(int? id)
        {
            var players = _context.Players.Where(p => p.FkSportId == id);
            TempData["id"] = id;
            return View(players.ToList());
        }

        public IActionResult Create()
        {
            TempData.Keep();
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlayerId,FullName,FkSportId,Age,Country")] Players players)
        {
            if(ModelState.IsValid)
            {
                _context.Add(players);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Sport");
            }
            return View(players);
        }
    }
}