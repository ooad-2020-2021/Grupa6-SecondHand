using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecondHand.Models
{
    public class Review
    {
        public int rating { get; set; }
        public User owner { get; set; }

        public Review(int rating, User owner)
        {
            this.rating = rating;
            this.owner = owner;
        }
    }
}
