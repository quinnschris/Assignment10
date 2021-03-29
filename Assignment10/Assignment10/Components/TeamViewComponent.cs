using System;
using System.Linq;
using Assignment10.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment10.Components
{
    public class TeamViewComponent : ViewComponent
    {

        private BowlingLeagueContext _context { get; set; }

        public TeamViewComponent(BowlingLeagueContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            return View(_context.Teams
                .OrderBy(x => x.TeamName)
                .ToList());
        }
    }
}
