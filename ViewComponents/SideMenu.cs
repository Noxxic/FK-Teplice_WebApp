using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FKTeplice.ViewComponents {
    public class SideMenu : ViewComponent {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            //TODO: Získat týmy a hráče
            List<string> array = new List<string>() {
                "Test",
                "test"
            };
            return View(array);
        }
    }
}