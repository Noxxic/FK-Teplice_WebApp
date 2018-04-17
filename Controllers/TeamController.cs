using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using FKTeplice.Models;
using FKTeplice.Data;

namespace FKTeplice.Controllers
{
    [Authorize]
    public class TeamController : Controller
    {
        ApplicationDbContext _context;

        public TeamController(ApplicationDbContext _context) {
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
            Team team = await _context.Teams.Where(x => x.Id == id).FirstOrDefaultAsync();
            return View(team);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Store(Team team)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _context.Teams.AddAsync(team);
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