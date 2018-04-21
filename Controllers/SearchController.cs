using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using FKTeplice.Data;
using FKTeplice.Models;
using FKTeplice.Models.SearchViewModels;

namespace FKTeplice.Controllers
{
    [Authorize]
    public class SearchController : Controller
    {
        ApplicationDbContext _context;
        public SearchController(ApplicationDbContext _context) {
            this._context = _context;
        }

        [HttpGet]
        public async Task<IActionResult> Index([FromQuery(Name = "q")] string q)
        {
            SearchModel model = new SearchModel();
            
            string query = $"%{q?.ToLower()}%";
            model.Teams = await _context.Teams
                                .Where(x => EF.Functions.Like(x.Name.ToLower(), query))
                                .Take(10)
                                .ToListAsync();

            model.Players = await _context.Players
                                .Where(x => EF.Functions.Like(x.FirstName.ToLower(), query) 
                                         || EF.Functions.Like(x.LastName.ToLower(), query))
                                .Take(10)
                                .ToListAsync();

            model.Query = q;
            return View(model);
        }

    }
}