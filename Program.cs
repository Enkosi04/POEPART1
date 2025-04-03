using System;
using System.Drawing;
using System.Media;
using System.Text;

namespace AddSoundAndMenu
{
    class Program
    {
        static void Main(string[] args)
        {
            // Play a sound (optional)
            if (OperatingSystem.IsWindows())
            {
                try
                {
                    SoundPlayer myMusic = new SoundPlayer("sound.wav");
                    myMusic.Load(); // Load the sound file
                    myMusic.PlayLooping(); // Play the sound in a loop

                    Console.WriteLine("Playing sound... Press Enter to stop.");
                    Console.ReadLine(); // Keep the console app running until Enter is pressed
                    myMusic.Stop();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error playing sound: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("This application only runs on Windows.");
            }

            // Show menu and run the selected class method
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu();
            }
        }

        private static bool MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) What is a phishing email?");
            Console.WriteLine("2) Importance of Strong Passwords");
            Console.WriteLine("3) How often should I change my passwords?");
            Console.WriteLine("4) How can I identify safe and suspicious links?");
            Console.WriteLine("5) Exit");
            Console.Write("\r\nSelect an option: ");

            // Read user input and trim whitespace
            string userInput = Console.ReadLine().Trim();

            switch (userInput)
            {
                case "1":
                    var phishingEmails = new PhishingEmails();
                    phishingEmails.StartChatbot();
                    return true;
                case "2":
                    var strongPasswords = new StrongPasswords();
                    strongPasswords.StartChatbot();
                    return true;
                case "3":
                    var changePasswords = new ChangePasswords();
                    changePasswords.StartChatbot();
                    return true;
                case "4":
                    var safeAndSuspiciousLinks = new SafeAndSuspiciousLinks();
                    safeAndSuspiciousLinks.StartChatbot();
                    return true;
                case "5":
                    return false; // Exit the application
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    return true; // Show the menu again
            }
        }
    }

    // PhishingEmails Class
    class PhishingEmails
    {
        private string[] imagePaths = { "PhisingEmail.jpg" }; // Store image paths in an array

        public void StartChatbot()
        {
            Console.Clear();
            Console.WriteLine("A phishing email is a type of cyber attack where attackers impersonate legitimate organizations to steal sensitive information. " +
                "Always check the sender's address and look for signs such as poor grammar.");

            DisplayImages(imagePaths);

            // Interaction Loop
            ChatLoop();
        }

        private void ChatLoop()
        {
            while (true)
            {
                Console.Write("You: ");
                string userInput = Console.ReadLine();

                if (userInput.ToLower() == "exit")
                {
                    Console.WriteLine("Chatbot: Goodbye!");
                    break;
                }

                string botResponse = GenerateResponse(userInput);
                Console.WriteLine("Chatbot: " + botResponse);
            }
        }

        private string GenerateResponse(string input)
        {
            return input.Contains("What is a phishing email", StringComparison.OrdinalIgnoreCase)
                ? "A phishing email is a type of cyber attack where attackers impersonate organizations..."
                : "Interesting! Tell me more.";
        }

        private void DisplayImages(string[] imagePaths)
        {
            Console.WriteLine($"Attempting to load images at: {string.Join(", ", imagePaths)}");
            foreach (var imagePath in imagePaths)
            {
                if (!System.IO.File.Exists(imagePath))
                {
                    Console.WriteLine($"Error: File '{imagePath}' does not exist.");
                    continue; // Skip if the file does not exist
                }

                using (Bitmap image = new Bitmap(imagePath))
                {
                    string asciiArt = ConvertToAscii(image);
                    Console.WriteLine(asciiArt);
                }
            }
        }

        private string ConvertToAscii(Bitmap image)
        {
            string asciiChars = "@%#*+=-:. ";
            int width = 100;  // Width to resize the image to
            int height = (int)(image.Height * ((double)width / image.Width));
            using (Bitmap resizedImage = new Bitmap(image, new Size(width, height)))
            {
                StringBuilder asciiArt = new StringBuilder();
                for (int y = 0; y < resizedImage.Height; y++)
                {
                    for (int x = 0; x < resizedImage.Width; x++)
                    {
                        Color pixelColor = resizedImage.GetPixel(x, y);
                        int grayValue = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;
                        int index = grayValue * (asciiChars.Length - 1) / 255;
                        asciiArt.Append(asciiChars[index]);
                    }
                    asciiArt.AppendLine();
                }
                return asciiArt.ToString();
            }
        }
    }

    // StrongPasswords Class
    class StrongPasswords
    {
        private string[] imagePaths = { "StrongPasswords.jpg" };

        public void StartChatbot()
        {
            Console.Clear();
            Console.WriteLine("Strong passwords are vital for protecting your accounts. They should be at least 12 characters long and include a mix of upper and lower-case letters, numbers, and symbols.");
            DisplayImages(imagePaths);
            ChatLoop();
        }

        private void ChatLoop()
        {
            while (true)
            {
                Console.Write("You: ");
                string userInput = Console.ReadLine();

                if (userInput.ToLower() == "exit")
                {
                    Console.WriteLine("Chatbot: Goodbye!");
                    break;
                }

                string botResponse = GenerateResponse(userInput);
                Console.WriteLine("Chatbot: " + botResponse);
            }
        }

        private string GenerateResponse(string input)
        {
            return input.Contains("Importance of strong passwords", StringComparison.OrdinalIgnoreCase)
                ? "Strong passwords help protect your accounts from unauthorized access."
                : "Interesting! Tell me more.";
        }

        private void DisplayImages(string[] imagePaths)
        {
            Console.WriteLine($"Attempting to load images at: {string.Join(", ", imagePaths)}");
            foreach (var imagePath in imagePaths)
            {
                if (!System.IO.File.Exists(imagePath))
                {
                    Console.WriteLine($"Error: File '{imagePath}' does not exist.");
                    continue; // Skip if the file does not exist
                }

                using (Bitmap image = new Bitmap(imagePath))
                {
                    string asciiArt = ConvertToAscii(image);
                    Console.WriteLine(asciiArt);
                }
            }
        }

        private string ConvertToAscii(Bitmap image)
        {
            string asciiChars = "@%#*+=-:. ";
            int width = 100;  // Width to resize the image to
            int height = (int)(image.Height * ((double)width / image.Width));
            using (Bitmap resizedImage = new Bitmap(image, new Size(width, height)))
            {
                StringBuilder asciiArt = new StringBuilder();
                for (int y = 0; y < resizedImage.Height; y++)
                {
                    for (int x = 0; x < resizedImage.Width; x++)
                    {
                        Color pixelColor = resizedImage.GetPixel(x, y);
                        int grayValue = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;
                        int index = grayValue * (asciiChars.Length - 1) / 255;
                        asciiArt.Append(asciiChars[index]);
                    }
                    asciiArt.AppendLine();
                }
                return asciiArt.ToString();
            }
        }
    }

    // ChangePasswords Class
    class ChangePasswords
    {
        private string[] imagePaths = { "ChangePassword.jpg" };

        public void StartChatbot()
        {
            Console.Clear();
            Console.WriteLine("It is recommended to change your passwords every 3-6 months and immediately if you suspect your account has been compromised.");
            DisplayImages(imagePaths);
            ChatLoop();
        }

        private void ChatLoop()
        {
            while (true)
            {
                Console.Write("You: ");
                string userInput = Console.ReadLine();

                if (userInput.ToLower() == "exit")
                {
                    Console.WriteLine("Chatbot: Goodbye!");
                    break;
                }

                string botResponse = GenerateResponse(userInput);
                Console.WriteLine("Chatbot: " + botResponse);
            }
        }

        private string GenerateResponse(string input)
        {
            return input.Contains("How often should I change my passwords", StringComparison.OrdinalIgnoreCase)
                ? "It is recommended to change your passwords every 3-6 months."
                : "Interesting! Tell me more.";
        }

        private void DisplayImages(string[] imagePaths)
        {
            Console.WriteLine($"Attempting to load images at: {string.Join(", ", imagePaths)}");
            foreach (var imagePath in imagePaths)
            {
                if (!System.IO.File.Exists(imagePath))
                {
                    Console.WriteLine($"Error: File '{imagePath}' does not exist.");
                    continue; // Skip if the file does not exist
                }

                using (Bitmap image = new Bitmap(imagePath))
                {
                    string asciiArt = ConvertToAscii(image);
                    Console.WriteLine(asciiArt);
                }
            }
        }

        private string ConvertToAscii(Bitmap image)
        {
            string asciiChars = "@%#*+=-:. ";
            int width = 100;  // Width to resize the image to
            int height = (int)(image.Height * ((double)width / image.Width));
            using (Bitmap resizedImage = new Bitmap(image, new Size(width, height)))
            {
                StringBuilder asciiArt = new StringBuilder();
                for (int y = 0; y < resizedImage.Height; y++)
                {
                    for (int x = 0; x < resizedImage.Width; x++)
                    {
                        Color pixelColor = resizedImage.GetPixel(x, y);
                        int grayValue = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;
                        int index = grayValue * (asciiChars.Length - 1) / 255;
                        asciiArt.Append(asciiChars[index]);
                    }
                    asciiArt.AppendLine();
                }
                return asciiArt.ToString();
            }
        }
    }

    // SafeAndSuspiciousLinks Class
    class SafeAndSuspiciousLinks
    {
        private string[] imagePaths = { "SafeAndSuspiciouslinks.jpg" };

        public void StartChatbot()
        {
            Console.Clear();
            Console.WriteLine("Always hover over links to check the destination before clicking. Look for HTTPS in the URL.");
            DisplayImages(imagePaths);
            ChatLoop();
        }

        private void ChatLoop()
        {
            while (true)
            {
                Console.Write("You: ");
                string userInput = Console.ReadLine();

                if (userInput.ToLower() == "exit")
                {
                    Console.WriteLine("Chatbot: Goodbye!");
                    break;
                }

                string botResponse = GenerateResponse(userInput);
                Console.WriteLine("Chatbot: " + botResponse);
            }
        }

        private string GenerateResponse(string input)
        {
            return input.Contains("safe and suspicious links", StringComparison.OrdinalIgnoreCase)
                ? "To identify safe links, hover over them to see the actual URL. Look for HTTPS."
                : "Interesting! Tell me more.";
        }

        private void DisplayImages(string[] imagePaths)
        {
            Console.WriteLine($"Attempting to load images at: {string.Join(", ", imagePaths)}");
            foreach (var imagePath in imagePaths)
            {
                if (!System.IO.File.Exists(imagePath))
                {
                    Console.WriteLine($"Error: File '{imagePath}' does not exist.");
                    continue; // Skip if the file does not exist
                }

                using (Bitmap image = new Bitmap(imagePath))
                {
                    string asciiArt = ConvertToAscii(image);
                    Console.WriteLine(asciiArt);
                }
            }
        }

        private string ConvertToAscii(Bitmap image)
        {
            string asciiChars = "@%#*+=-:. ";
            int width = 100;  // Width to resize the image to
            int height = (int)(image.Height * ((double)width / image.Width));
            using (Bitmap resizedImage = new Bitmap(image, new Size(width, height)))
            {
                StringBuilder asciiArt = new StringBuilder();
                for (int y = 0; y < resizedImage.Height; y++)
                {
                    for (int x = 0; x < resizedImage.Width; x++)
                    {
                        Color pixelColor = resizedImage.GetPixel(x, y);
                        int grayValue = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;
                        int index = grayValue * (asciiChars.Length - 1) / 255;
                        asciiArt.Append(asciiChars[index]);
                    }
                    asciiArt.AppendLine();
                }
                return asciiArt.ToString();
            }
        }
    }
}