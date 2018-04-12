using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FKTeplice.ViewComponents {
    public class TopMenu : ViewComponent {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}