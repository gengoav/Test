using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Zadacha.Models;
namespace Zadacha.Controllers
{
    public class EqpmController : Controller
    {
        public IActionResult Index(int criteria)
        {
            DbContext context = HttpContext.RequestServices.GetService(typeof(Zadacha.Models.DbContext)) as DbContext;
            return View(context.GetAllEqpm(criteria));
        }       
    }
}