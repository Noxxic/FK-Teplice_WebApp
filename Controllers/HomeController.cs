using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FKTeplice.Models;
using FKTeplice.Models.HomeViewModels;
using FKTeplice.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace FKTeplice.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        ApplicationDbContext _context;

        public HomeController(ApplicationDbContext _context) {
            this._context = _context;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            var model = new IndexHomeModel();
            model.TeamsCount = _context.Teams.Count();
            model.PlayersCount = _context.Players.Count();
            return View(model);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
