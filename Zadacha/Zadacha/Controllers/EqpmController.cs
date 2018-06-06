using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Zadacha.Models;
namespace Zadacha.Controllers
{
    public class EqpmController : Controller
    {
        //int GlobCrit = 2;
        public IActionResult Index(int criteria)
        {
            //GlobCrit = criteria;
            DbContext context = HttpContext.RequestServices.GetService(typeof(Zadacha.Models.DbContext)) as DbContext;
            return View(context.GetAllEqpm(criteria));
        }

        public IActionResult CSV(int crit)
        {
            DbContext context = HttpContext.RequestServices.GetService(typeof(Zadacha.Models.DbContext)) as DbContext;
            var comlumHeadrs = new string[]
            {
                "Name:"
            };

            var eqpmRec = (from eqpm in context.GetAllEqpm(crit)
                                   select new object[]
                                   {
                                            eqpm.name,                                           
                                   }).ToList();
            var eqpmcsv = new StringBuilder();
            eqpmRec.ForEach(line =>
            {
                eqpmcsv.AppendLine(string.Join(",", line));
            });

            byte[] buffer = Encoding.ASCII.GetBytes($"{string.Join(",", comlumHeadrs)}\r\n{eqpmcsv.ToString()}");
            return File(buffer, "text/csv", $"eqpm.csv");

        }
    }
}