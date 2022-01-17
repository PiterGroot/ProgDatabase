using System.Threading.Tasks;
using System.Linq;
using System.Text;
using System;
using System.Collections.Generic;
namespace ProgDatabase
{
    class Program
    {
        public static ReviewDatabase _database = new ReviewDatabase();
        static void Main(string[] args) {
            List<Review> reviewsToAdd = new List<Review>();
            ReviewDatabase database = new ReviewDatabase();

            reviewsToAdd.Add(new GoldenReview("GOLDEN", "GOLDEN REVIEEEEEWWWWWW"));
            reviewsToAdd.Add(new NormalReview("Positive", "Very good game, I like the story"));
            reviewsToAdd.Add(new NormalReview("Negative", "The game is to hard and you can't change the controls"));
            reviewsToAdd.Add(new NormalReview("Mixed", "The game is okay. Not bad not good"));
            
            foreach (Review review in reviewsToAdd) {
                if (review.Value == "GOLDEN") {
                    review.SetGoldenReview();
                }
                database.AddReview(review);
            }
            
            foreach (Review review in database.GetAllReviews()) {
                if(review.isGolden == false) {
                    Console.WriteLine("Review is:" + " " + review.Value + "; " + review.Message);
                }
            }
            _database = database;
            while (true) {
                CheckInput();
            }
        }

        private static void CheckInput() {
            Console.WriteLine("/-");
            string input = Console.ReadLine();
            string[] words = input.Split(' ');
            if (words[0] == "addPositive") {
                string[] message = new string[words.Length];
                string testmessage = string.Empty;
                for (int i = 1; i < words.Length; i++) {
                    testmessage += " " + words[i];
                }
                AddReview("positive", testmessage);
            }
            switch (input) {
                case "printAll":
                    Console.Clear();
                    foreach (Review review in _database.GetAllReviews()) {
                        if (review.isGolden == false) {
                            Console.WriteLine("Review is:" + " " + review.Value + ";" + review.Message);
                        }
                    }
                    break;
            }
        }

        private static void AddReview(string reviewType, string message) {
            string unpackedMessage = string.Empty;
            switch (reviewType) {
                case "positive":
                    Review review = new NormalReview("Positive", message);
                    _database.AddReview(review);
                    break;
            }
        }
    }
}
