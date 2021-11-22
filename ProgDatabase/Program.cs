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
            ReviewDatabase database = new ReviewDatabase();

            database.AddReview(new Review("Positive", "Very good game, I like the story"));
            database.AddReview(new Review("Negative", "The game is to hard and you can't change the controls"));

            foreach (Review review in database.GetAllReviews()) {
                Console.WriteLine(review.value + " " + review.message);
            }
        }
    }
}
