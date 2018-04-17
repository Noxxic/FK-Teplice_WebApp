using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using FKTeplice.Data;
using FKTeplice.Models;

namespace FKTeplice.Controllers
{
    [Authorize]
    public class PlayerController : Controller
    {
        ApplicationDbContext _context;
        public PlayerController(ApplicationDbContext _context) {
            this._context = _context;
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Show(int id)
        {
            Player player = await _context.Players.Where(x => x.Id == id).FirstOrDefaultAsync();
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Store(Player player)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _context.Players.AddAsync(player);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Update()
        {
            return RedirectToAction("Show", new {
                id = 0
            });
        }

        [HttpPost]
        public IActionResult Delete()
        {
            return RedirectToAction("Index");
        }
    }
}