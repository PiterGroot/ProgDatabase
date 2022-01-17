
namespace ProgDatabase
{
    public abstract class Review
    {
        public bool isGolden;
        public string Value { get; private set; }
        public string Message { get; private set; }
        public abstract void SetGoldenReview();

        protected Review(string value, string message) {
            this.Value = value;
            this.Message = message;
        }
    }
}
