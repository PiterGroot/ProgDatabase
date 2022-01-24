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

        //handles every command and response
        public void HandleInput() {
            Console.Write("~ ");
            string command = Console.ReadLine();
            string[] words = command.Split(' ');
            Console.Clear();
            switch (command) {
                case "printAll":
                    Program.SetConsoleTitle("All reviews:");
                    Program.PrintAllReviews(database);
                    break;
                case "printPositive":
                    Program.SetConsoleTitle("Positive reviews:");
                    Program.PrintSpecificReviews(positiveReviews);
                    break;
                case "printMixed":
                    Program.SetConsoleTitle("Mixed reviews:");
                    Program.PrintSpecificReviews(mixedReviews);
                    break;
                case "printNegative":
                    Program.SetConsoleTitle("Negative reviews:");
                    Program.PrintSpecificReviews(negativeReviews);
                    break;
                case "printGolden":
                    Program.SetConsoleTitle("Golden reviews:");
                    Program.PrintSpecificReviews(goldenReviews);
                    break;
                case "reviewTypes":
                    Program.SetConsoleTitle("ReviewTypes:");
                    Console.WriteLine("Review types are: Positive, Mixed, Negative & Golden");
                    break;
                case "exit":
                    Environment.Exit(0);
                    break;
                case "":
                    Program.SetConsoleTitle("Home: ");
                    Console.WriteLine("Available commands: 'printAll' 'reviewTypes' 'print{reviewType}' 'add{reviewType} message' 'exit' 'ENTER'");
                    break;
                default:
                    if(words.Length < 2) {
                        Console.WriteLine("Available commands: 'printAll' 'reviewTypes' 'print{reviewType}' 'add{reviewType} message' 'exit' 'ENTER'");
                        Console.WriteLine($"'{command}' doesnt exists?");
                    }
                    break;
            }
            //seperate check for adding reviews inside the console
            if (words[0] == "addPositive") {
                Program.AddReview("positive", PackAddedMessage(words), database);
            }
            else if (words[0] == "addMixed") {
                Program.AddReview("mixed", PackAddedMessage(words), database);
            }
            else if (words[0] == "addNegative") {
                Program.AddReview("negative", PackAddedMessage(words), database);
            }
            else if (words[0] == "addGolden") {
                Program.AddReview("golden", PackAddedMessage(words), database);
            }
        }

        private string PackAddedMessage(string[] commandWords) {
            string reviewMessage = string.Empty;
            for (int i = 1; i < commandWords.Length; i++) {
                reviewMessage += " " + commandWords[i];
            }
            return reviewMessage;
        }
    }
}
