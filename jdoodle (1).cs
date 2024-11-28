namespace GuessTheNumber_ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create a Random object to generate a random number
            Random random = new Random();

            // Generate a random number between 1 and 50 (inclusive)
            int guessingNumber = random.Next(1, 50);

            // Initialize variables for attempts, user input, and other checks
            int attempts = 0, userInput = 0;
            int attemptLimit = 5; // Number of guesses allowed
            bool victory = false, checkInput = false, checkRange;

            // Loop while the user has attempts left and hasn't guessed correctly
            while (attemptLimit > 0 && !victory)
            {
                do
                {
                    checkRange = false; // Reset the range check flag

                    // Prompt the user to enter a guess
                    Console.Write("Enter your guess: ");
                    checkInput = int.TryParse(Console.ReadLine(), out userInput); // Validate input is an integer

                    // Check if input is within the valid range (1 to 50)
                    if (checkInput && (userInput > 50 || userInput < 1))
                    {
                        Console.WriteLine("INPUT OUT OF RANGE! TRY AGAIN!\n");
                    }
                    else if (checkInput && userInput >= 1 && userInput <= 50)
                    {
                        checkRange = true; // Input is valid and within range
                    }
                    else
                    {
                        continue; // Invalid input, prompt again
                    }

                } while (!checkInput || !checkRange); // Repeat until valid input is provided

                // If the input is valid and in range, proceed with the game logic
                if (checkRange)
                {
                    attempts++; // Increment attempts
                    attemptLimit--; // Decrease remaining attempts

                    // Provide feedback based on the user's guess
                    if (userInput > guessingNumber)
                    {
                        Console.WriteLine("Try Lower Number!\n"); // Guess is too high
                    }
                    else if (userInput < guessingNumber)
                    {
                        Console.WriteLine("Try Higher Number!\n"); // Guess is too low
                    }
                    else if (userInput == guessingNumber)
                    {
                        // User guessed correctly
                        Console.WriteLine("You Won! Congratulations!\n");
                        Console.WriteLine($"Number of attempts: {attempts}");
                        victory = true; // Set victory flag to true
                        break; // Exit the loop
                    }
                }
            }

            // If user runs out of attempts without guessing correctly
            if (!victory)
            {
                Console.WriteLine("Sorry you lose! :(");
            }
        }
    }
}
