﻿using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ProgDatabase
{
    class ReviewDatabase
    {
        private List<Review> _reviews;
        public ReviewDatabase() { 
            _reviews = new List<Review>();
        }
        public void AddReview(Review reviewToAdd) {
            _reviews.Add(reviewToAdd);
        }
        public List<Review> GetAllReviews() {
            return _reviews;
        }
    }
}
