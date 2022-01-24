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
            List<Review> reviewsToAdd = new List<Review>();
            InteractionHandler interactions = new InteractionHandler();

            SetConsoleTitle("Home:");

            //creating reviews
            reviewsToAdd.Add(new GoldenReview("GOLDEN", "BEST GAME I HAVE EVER PLAYED"));
            reviewsToAdd.Add(new GoldenReview("GOLDEN", "THIS GAME DESERVES GAME OF THE YEAR AWARD"));
            reviewsToAdd.Add(new NormalReview("Positive", "Very good game, I like the story"));
            reviewsToAdd.Add(new NormalReview("Positive", "Hahaha one the funniest games I have ever played!"));
            reviewsToAdd.Add(new NormalReview("Positive", "I finally had some spare time to play this game, and im not disappointed"));
            reviewsToAdd.Add(new NormalReview("Negative", "The game is to hard and you can't change the controls"));
            reviewsToAdd.Add(new NormalReview("Negative", "The community is so toxic omg, instant uninstall"));
            reviewsToAdd.Add(new NormalReview("Mixed", "The game is okay. Not bad not good"));
            reviewsToAdd.Add(new NormalReview("Mixed", "I couldn't connect my xbox controller"));
            reviewsToAdd.Add(new NormalReview("Mixed", "The server keeps on crashing? Gameplay is fun though"));

            SortAllReviews(dataBase, reviewsToAdd, true);
            Console.WriteLine("Available commands: 'printAll' 'reviewTypes' 'print{reviewType}' 'add{reviewType} message' 'exit' 'ENTER'");

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
                        review.SetGoldenReview();
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

        //sets the console titile
        public static void SetConsoleTitle(string message) {
            Console.Title = message;
        }
    }
}
