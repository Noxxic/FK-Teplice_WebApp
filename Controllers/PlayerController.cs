using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using FKTeplice.Data;
using FKTeplice.Models;
using System.IO;
using FKTeplice.Models.PlayerViewModels;

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
        public async Task<IActionResult> Index()
        {
            var players = await _context.Players
                                    .Include(p => p.Team)
                                    .ToListAsync();
            return View(players);
        }

        [HttpGet]
        public async Task<IActionResult> Create() 
        {
            var teams = await _context.Teams.ToListAsync();
            var vm = new UpdateStorePlayerModel();
            vm.Teams = teams;
            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Show(int id)
        {
            Player player = await _context.Players
                                    .Where(x => x.Id == id)
                                    .Include(x => x.Team)
                                    .FirstOrDefaultAsync();
            
            if(player == null)
                return NotFound();
                
            return View(player);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Store(UpdateStorePlayerModel playerModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Player player = new Player {
                FirstName = playerModel.FirstName,
                LastName = playerModel.LastName,
                Birthday = playerModel.Birthday,
                School = playerModel.School,
                Fat = playerModel.Fat,
                Weight = playerModel.Weight,
                Height = playerModel.Height,
                TeamId = playerModel.TeamId
            };

            byte[] _photo = null;
            if(playerModel.Photo != null) {
                _photo = new byte[playerModel.Photo.Length];
                using (var mem = new MemoryStream(_photo)) {
                    await playerModel.Photo.CopyToAsync(mem);
                }
            }

            player.Photo = _photo;

            await _context.Players.AddAsync(player);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Update(int id, Player player)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return RedirectToAction("Show", id);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Player player)  
        {
            _context.Players.Remove(player);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}