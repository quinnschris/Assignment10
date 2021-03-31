using System;
using System.Collections.Generic;

namespace Assignment10.Models.ViewModels
{
    // Model to store everything that needs to be passed into the view

    public class IndexViewModel
    {
        public List<Bowler> Bowlers { get; set; }

        public PageNumberingInfo PageNumberingInfo { get; set; }

        public string TeamName { get; set; }
    }
}
