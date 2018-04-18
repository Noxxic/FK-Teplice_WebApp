using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace FKTeplice.ViewComponents {
    public class TopMenu : ViewComponent {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var menuItems = new List<Tuple<string, string, string>>() {
                Tuple.Create("Domů", "Home", "Index"),
                Tuple.Create("Hráči", "Player", "Index"),
                Tuple.Create("Týmy", "Team", "Index")
            };

            return View(menuItems);
        }
    }
}