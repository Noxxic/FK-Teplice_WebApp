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
        public async Task<IActionResult> Index()
        {
            var teams = await _context.Teams
                                       .Include(t => t.Matches)
                                       .Include(t => t.Players)
                                       .ToListAsync();
            return View(teams);
        }

        [HttpGet]
        public async Task<IActionResult> Show(int id)
        {
            Team team = await _context.Teams
                .Where(t => t.Id == id)
                .Include(t => t.Players)
                .Include(t => t.Matches)
                .FirstOrDefaultAsync();
            
            return View(team);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Team team = await _context.Teams.Where(t => t.Id == id).FirstOrDefaultAsync();
            return View(team);
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
        public async Task<IActionResult> Update(int id, Team team)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            team.Id = id;

            _context.Teams.Update(team);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Team team)
        {
             _context.Teams.Remove(team);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}