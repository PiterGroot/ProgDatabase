using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgDatabase
{
    class GoldenReview : Review
    {
        public GoldenReview(string value, string message) : base(value, message){
            base.isGolden = true;
        }
        public override string GetReviewID() {
            return base.reviewID;
        }
    }
}
