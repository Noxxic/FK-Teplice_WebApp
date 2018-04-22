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
            var vm = new UpdateStorePlayerModel();
            vm.Teams = await _context.Teams.ToListAsync();
            vm.Positions = await _context.Positions.ToListAsync();
            
            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Show(int id)
        {
            Player player = await _context.Players
                                    .Where(x => x.Id == id)
                                    .Include(x => x.Team)
                                    .Include(x => x.PlayerMatch)
                                    .Include(x => x.AltPosition)
                                    .Include(x => x.Position)
                                    .FirstOrDefaultAsync();

            player.Contracts = await _context.Documents
                                    .Where(x => x.EntityId == id)
                                    .Where(x => x.EntityTable == "User")
                                    .ToListAsync();
            
            if(player == null)
                return NotFound();
                
            return View(player);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        { 
            var vm = new UpdateStorePlayerModel();
            vm.Teams = await _context.Teams.ToListAsync();
            vm.Positions = await _context.Positions.ToListAsync();

            Player player = _context.Players.Where(x => x.Id == id).FirstOrDefault();
            vm.FirstName =  player.FirstName;
            vm.LastName = player.LastName;
            vm.Birthday = player.Birthday;
            vm.School = player.School;
            vm.Fat = player.Fat;
            vm.Weight = player.Weight;
            vm.Height = player.Height;
            vm.TeamId = player.TeamId;
            vm.PositionId = player.PositionId;
            vm.AltPositionId = player.AltPositionId;

            return View(vm);
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
                TeamId = playerModel.TeamId,
                PositionId = playerModel.PositionId,
                AltPositionId = playerModel.AltPositionId
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
        public async Task<IActionResult> Update(int id, UpdateStorePlayerModel playerModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Player player = new Player {
                Id = (int) playerModel.Id,
                FirstName = playerModel.FirstName,
                LastName = playerModel.LastName,
                Birthday = playerModel.Birthday,
                School = playerModel.School,
                Fat = playerModel.Fat,
                Weight = playerModel.Weight,
                Height = playerModel.Height,
                TeamId = playerModel.TeamId,
                PositionId = playerModel.PositionId,
                AltPositionId = playerModel.AltPositionId
            };

            byte[] _photo = null;
            if(playerModel.Photo != null) {
                _photo = new byte[playerModel.Photo.Length];
                using (var mem = new MemoryStream(_photo)) {
                    await playerModel.Photo.CopyToAsync(mem);
                }
            }

            player.Photo = _photo;

            _context.Players.Update(player);
            await _context.SaveChangesAsync();

            return RedirectToAction("Show", new {
                id = player.Id
            });
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