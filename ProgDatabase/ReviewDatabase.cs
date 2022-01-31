using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgDatabase
{
    class ReviewDatabase
    {
        public List<Review> positiveReviews = new List<Review>();
        public List<Review> negativeReviews = new List<Review>();
        public List<Review> mixedReviews = new List<Review>();
        public List<Review> goldenReviews = new List<Review>();

        private List<Review> _reviews;
        public ReviewDatabase() { 
            _reviews = new List<Review>();
        }
        public void AddReviewToDataBase(Review reviewToAdd) {
            _reviews.Add(reviewToAdd);
        }
        public List<Review> GetAllReviews() {
            return _reviews;
        }

        public void SetUp(List<Review> posReviews, List<Review> mixReviews, List<Review> negReviews, List<Review> goldReviews) {
            positiveReviews = posReviews;
            mixedReviews = mixReviews;
            negativeReviews = negReviews;
            goldenReviews = goldReviews;
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

                dataBase.GetList(review.Value).Add(review);

                if (review.GetReviewID() == string.Empty) {
                    var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                    var stringChars = new char[15];
                    var random = new Random();

                    for (int i = 0; i < stringChars.Length; i++) {
                        stringChars[i] = chars[random.Next(chars.Length)];
                    }
                    review.reviewID = new string(stringChars);
                }
                if (addToDataBase) {
                    dataBase.AddReviewToDataBase(review);
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
                    database.AddReviewToDataBase(posReview);
                    break;
                case "mixed":
                    Review mixReview = new NormalReview("Mixed", message);
                    addedReview.Add(mixReview);
                    database.AddReviewToDataBase(mixReview);
                    break;
                case "negative":
                    Review negReview = new NormalReview("Negative", message);
                    addedReview.Add(negReview);
                    database.AddReviewToDataBase(negReview);
                    break;
                case "golden":
                    Review goldReview = new GoldenReview("GOLDEN", message);
                    addedReview.Add(goldReview);
                    database.AddReviewToDataBase(goldReview);
                    break;
            }
            SortAllReviews(database, addedReview, false);
            PrintAllReviews(database);
        }
        public List<Review> GetList(string typeOfList) {
            List<Review> result = new List<Review>();
            switch (typeOfList) {
                case "Positive":
                    result = positiveReviews;
                    break;
                case "Mixed":
                    result = mixedReviews;
                    break;
                case "Negative":
                    result = negativeReviews;
                    break;
                case "GOLDEN":
                    result = goldenReviews;
                    break;
            }
            return result;
        }
        public static void PrintAllReviewIDs(ReviewDatabase database) {
            foreach (Review review in database.GetAllReviews()) {
                Console.WriteLine(review.GetReviewID());
            }
        }
    }
}
