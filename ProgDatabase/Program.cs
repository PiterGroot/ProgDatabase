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
            InteractionHandler interactions = new InteractionHandler();

            SetConsoleTitle("Home:");

            Console.WriteLine(InteractionHandler.commands);

            //setting up values
            interactions.database = dataBase;
            interactions.positiveReviews = positiveReviews;
            interactions.negativeReviews = negativeReviews;
            interactions.mixedReviews = mixedReviews;
            interactions.goldenReviews = goldenReviews;

            //handle input commands
            while (true) {
                interactions.HandleInput();
            }
        }
        //prints every review in the console
        public static void PrintAllReviews(ReviewDatabase dataBase) {
            bool clearScreen = false;
            foreach (Review review in dataBase.GetAllReviews()) {
                if (review.isGolden == false) {
                    Console.WriteLine(review.Value + " review" + "; " + review.Message);
                }
                else {
                    Console.WriteLine("GOLDEN REVIEW!" + "; " + review.Message);
                }
                if (review.error) {
                    clearScreen = true;
                }
            }
            if (clearScreen) {
                Console.Clear();
                Console.WriteLine("ERROR, please only use 'GOLDEN' value with GoldenReview class");
            }
        }
        //prints every specific review in the console
        public static void PrintSpecificReviews(List<Review> typeOfReview) {
            bool clearScreen = false;
            foreach (Review review in typeOfReview) {
                if (review.isGolden == false) {
                    Console.WriteLine(review.Value + " review" + "; " + review.Message);
                }
                else {
                    Console.WriteLine("GOLDEN REVIEW!" + "; " + review.Message);
                }
                if (review.error) {
                    clearScreen = true;
                }
            }
            if (clearScreen) {
                Console.Clear();
                Console.WriteLine("ERROR, please only use 'GOLDEN' value with GoldenReview class");
            }
        }
        //sorts all reviews in their own lists and adds them to the database
        public static void SortAllReviews(ReviewDatabase dataBase, List<Review> reviewsToAdd, bool addToDataBase) {
            foreach (Review review in reviewsToAdd) {
                switch (review.Value) {
                    case "GOLDEN":
                        goldenReviews.Add(review);
                        break;
                    case "Positive":
                        positiveReviews.Add(review);
                        break;
                    case "Mixed":
                        mixedReviews.Add(review);
                        break;
                    case "Negative":
                        negativeReviews.Add(review);
                        break;
                }
                if(review.GetReviewID() == string.Empty) {
                    var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                    var stringChars = new char[15];
                    var random = new Random();

                    for (int i = 0; i < stringChars.Length; i++) {
                        stringChars[i] = chars[random.Next(chars.Length)];
                    }
                    review.reviewID = new string(stringChars);
                }
                if (addToDataBase) {
                    dataBase.AddReview(review);
                }
            }
        }
        //adds a review inside the console at runtime
        public static void AddReview(string reviewType, string message, ReviewDatabase database) {
            List<Review> addedReview = new List<Review>();
            
            switch (reviewType) {
                case "positive":
                    Review posReview = new NormalReview("Positive", message);
                    addedReview.Add(posReview);
                    database.AddReview(posReview);
                    break;
                case "mixed":
                    Review mixReview = new NormalReview("Mixed", message);
                    addedReview.Add(mixReview);
                    database.AddReview(mixReview);
                    break;
                case "negative":
                    Review negReview = new NormalReview("Negative", message);
                    addedReview.Add(negReview);
                    database.AddReview(negReview);
                    break;
                case "golden":
                    Review goldReview = new GoldenReview("GOLDEN", message);
                    addedReview.Add(goldReview);
                    database.AddReview(goldReview);
                    break;
            }
            SortAllReviews(database, addedReview, false);
            PrintAllReviews(database);
        }

        public static void PrintAllReviewIDs(ReviewDatabase database) {
            foreach (Review review in database.GetAllReviews()) {
                Console.WriteLine(review.GetReviewID());
            }
        }
        //sets the console titile
        public static void SetConsoleTitle(string message) {
            Console.Title = message;
        }
    }
}
