using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgDatabase
{
    public abstract class Review
    {
        public string Value { get; private set; }
        public string Message { get; private set; }
        public abstract void SetGoldenReview();

        protected Review(string value, string message) {
            this.Value = value;
            this.Message = message;
        }
    }
}
