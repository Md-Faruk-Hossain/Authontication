using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authorization.Controllers
{
    [Authorize(Roles ="Executive,Admin")]
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult All()
        {
            return View();
        }
        public IActionResult Search()
        {
            return View();
        }
    }
}
