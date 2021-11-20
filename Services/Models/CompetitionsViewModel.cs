using System;
using System.Collections.Generic;

namespace Services.Models
{
    public class CompetitionsViewModel
    {
        public List<Competition> Competitions { get; set; }
        public string VenueName { get; set; }

        public CompetitionsViewModel()
        {
            Competitions = new List<Competition>();
        }
    }
}
