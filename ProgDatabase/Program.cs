using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ProgDatabase
{
    class Program
    {
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
                else {
                    database.AddReview(review);
                }
            }
            
            foreach (Review review in database.GetAllReviews()) {
                Console.WriteLine("Review is:" + " " + review.Value + "; " + review.Message);
            }
        }
    }
}
