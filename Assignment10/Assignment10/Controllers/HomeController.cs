using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Assignment10.Models;
using Microsoft.EntityFrameworkCore;
using Assignment10.Models.ViewModels;

namespace Assignment10.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private BowlingLeagueContext _context { get; set; }



        public HomeController(ILogger<HomeController> logger, BowlingLeagueContext context)
        {
            _logger = logger;
            _context = context;
        }

        
        public IActionResult Index(long? TeamId, string teamname, int PageNum = 0)
        {
            int PageSize = 5;

            return View(new IndexViewModel
            {
                // Stores a list of bowlers according to the slected team id
                Bowlers = _context.Bowlers
                    .Where(x => x.TeamId == TeamId || TeamId == null).
                    OrderBy(x => x.BowlerFirstName).
                    Skip((PageNum - 1) * PageSize).
                    Take(PageSize).
                    ToList(),

                // Creats new pagenumberingo object
                PageNumberingInfo = new PageNumberingInfo
                {
                    NumItemsPerPage = PageSize,
                    CurrentPage = PageNum,
                    TotalNumItems = (TeamId == null ? _context.Bowlers.Count() :
                            _context.Bowlers.Where(x => x.TeamId == TeamId).Count())
                },

                // Stores team name in a string. Lit.
                TeamName = teamname
            });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
