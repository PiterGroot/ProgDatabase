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

        }
        public override void SetGoldenReview() {
            Console.WriteLine($"'{Message}' Review is golden!");
        }
    }
}
