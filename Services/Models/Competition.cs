using System.Collections.Generic;

namespace Services.Models
{
    public class Competition
    {
        public string CompetitionTypeName { get; set; }
        public string VenueName { get; set; }
        public string CompetitionOrganizerName { get; set; }
        public List<Competitor> Competitors { get; set; }

        public Competition()
        {
            Competitors = new List<Competitor>();
        }
    }
}
