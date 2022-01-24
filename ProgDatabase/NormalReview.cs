using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgDatabase
{
    class NormalReview : Review
    {
        public NormalReview(string value, string message) : base(value, message) {
            if(value == "GOLDEN") {
                base.error = true;
            }
        }
        public override void SetGoldenReview() {
            
        }
    }
}
