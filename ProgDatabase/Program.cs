using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ProgDatabase
{
    class Program
    {
        public static List<Review> positiveReviews = new List<Review>();
        public static List<Review> negativeReviews = new List<Review>();
        public static List<Review> mixedReviews = new List<Review>();
        public static List<Review> goldenReviews = new List<Review>();

        static void Main(string[] args) {
            ReviewDatabase dataBase = new ReviewDatabase();

            InteractionHandler interactions = new InteractionHandler(dataBase, positiveReviews, 
            mixedReviews, negativeReviews, goldenReviews);

            SetConsoleTitle("Home:");

            Console.WriteLine(InteractionHandler.commands);

            //handle input commands
            while (true) {
                interactions.HandleInput();
            }
        }
        
        //sets the console titile
        public static void SetConsoleTitle(string message) {
            Console.Title = message;
        }
    }
}
