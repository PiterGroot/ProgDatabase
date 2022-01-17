using System;

namespace ProgDatabase
{
    class GoldenReview : Review
    {
        public GoldenReview(string value, string message) : base(value, message){

        }
        public override void SetGoldenReview() {
            Console.WriteLine($"'{Message}' Review is golden!");
            base.isGolden = true;
        }
    }
}
