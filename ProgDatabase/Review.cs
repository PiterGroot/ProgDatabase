using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgDatabase
{
    public abstract class Review
    {
        public bool error;
        public bool isGolden;
        public string reviewID = string.Empty;
        public string Value { get; private set; }
        public string Message { get; private set; }
        //public abstract void SetGoldenReview();
        public abstract string GetReviewID();

        protected Review(string value, string message) {
            this.Value = value;
            this.Message = message;
        }

    }
}
