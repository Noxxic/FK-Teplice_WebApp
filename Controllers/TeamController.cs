using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace FKTeplice.Controllers
{
    [Authorize]
    public class TeamController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Show(int id)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Store()
        {
            return RedirectToAction("Show", new {
                id = 0
            });
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