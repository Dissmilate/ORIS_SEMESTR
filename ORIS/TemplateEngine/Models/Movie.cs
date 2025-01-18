using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Movie
    {
        public int MovieId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ReleaseDate { get; set; }
        
        public decimal IMdbRating { get; set; }

        public int ImdbVotes { get; set; }

        public string PosterUrl { get; set; }

        public string Country { get; set; }

        public string Director { get; set;}
        
        public string Genre { get; set;}
        
        public string Quality { get; set;}
        
        public string AgeRating { get; set;}
        
        public int Duration { get; set;}
        
    }
}
