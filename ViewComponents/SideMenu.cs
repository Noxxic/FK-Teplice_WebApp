using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FKTeplice.Models;
using FKTeplice.Data;

namespace FKTeplice.ViewComponents {
    public class SideMenu : ViewComponent {

        ApplicationDbContext _context;
        public SideMenu(ApplicationDbContext _context) : base() {
            this._context = _context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var teams = await _context.Teams
                .Include(team => team.Players)
                .ToListAsync();

            return View(teams);
        }
    }
}