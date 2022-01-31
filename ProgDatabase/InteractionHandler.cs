using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgDatabase {
    class InteractionHandler {

        public ReviewDatabase database = new ReviewDatabase();

        public List<Review> positiveReviews = new List<Review>();
        public List<Review> negativeReviews = new List<Review>();
        public List<Review> mixedReviews = new List<Review>();
        public List<Review> goldenReviews = new List<Review>();

        public static string commands = "Available commands: 'printAll' 'reviewTypes' 'print{reviewType}' 'add{reviewType} message' 'reviewIDs' 'ENTER' 'exit'";

        public InteractionHandler(ReviewDatabase database, List<Review> posReviews, List<Review> mixReviews, List<Review> negReviews, List<Review> goldReviews) {
            this.database = database;
            this.positiveReviews = posReviews;
            this.negativeReviews = negReviews;
            this.mixedReviews = mixReviews;
            this.goldenReviews = goldReviews;

            database.SetUp(posReviews, mixReviews, negReviews, goldReviews);
        }

        //handles every command and response
        public void HandleInput() {
            Console.Write("~ ");
            string command = Console.ReadLine();
            string[] words = command.Split(' ');
            Console.Clear();
            switch (command) {
                case "printAll":
                    Program.SetConsoleTitle("All reviews:");
                    ReviewDatabase.PrintAllReviews(database);
                    break;
                case "printPositive":
                    Program.SetConsoleTitle("Positive reviews:");
                    ReviewDatabase.PrintSpecificReviews(positiveReviews);
                    break;
                case "printMixed":
                    Program.SetConsoleTitle("Mixed reviews:");
                    ReviewDatabase.PrintSpecificReviews(mixedReviews);
                    break;
                case "printNegative":
                    Program.SetConsoleTitle("Negative reviews:");
                    ReviewDatabase.PrintSpecificReviews(negativeReviews);
                    break;
                case "printGolden":
                    Program.SetConsoleTitle("Golden reviews:");
                    ReviewDatabase.PrintSpecificReviews(goldenReviews);
                    break;
                case "reviewTypes":
                    Program.SetConsoleTitle("ReviewTypes:");
                    Console.WriteLine("Review types are: Positive, Mixed, Negative & Golden");
                    break;
                case "reviewIDs":
                    Program.SetConsoleTitle("Review IDS");
                    ReviewDatabase.PrintAllReviewIDs(database);
                    break;
                case "exit":
                    Environment.Exit(0);
                    break;
                case "":
                    Program.SetConsoleTitle("Home: ");
                    Console.WriteLine(commands);
                    break;
                default:
                    if(words.Length < 2) {
                        Console.WriteLine(commands);
                        Console.WriteLine($"'{command}' doesnt exists?");
                    }
                    break;
            }
            //seperate check for adding reviews inside the console
            if (words[0] == "addPositive") {
                ReviewDatabase.AddReview("positive", PackAddedMessage(words), database);
            }
            else if (words[0] == "addMixed") {
                ReviewDatabase.AddReview("mixed", PackAddedMessage(words), database);
            }
            else if (words[0] == "addNegative") {
                ReviewDatabase.AddReview("negative", PackAddedMessage(words), database);
            }
            else if (words[0] == "addGolden") {
                ReviewDatabase.AddReview("golden", PackAddedMessage(words), database);
            }
        }

        //add spaces between the words
        private string PackAddedMessage(string[] commandWords) {
            string reviewMessage = string.Empty;
            for (int i = 1; i < commandWords.Length; i++) {
                reviewMessage += " " + commandWords[i];
            }
            return reviewMessage;
        }
    }
}
