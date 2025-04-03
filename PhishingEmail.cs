using System;
using System.Drawing;
using System.Text;

class PhishingEmails
{
    public void StartChatbot()
    {
        Console.WriteLine("Chatbot: Hi there! Im your chatbot.Type exit to quit");
        // ARRAY TO STORE IMAGES
        DisplayImages(new[] { "PhisingEmail.jpg" });

        while (true)
        {
            Console.Write("You: ");
            string userInput = Console.ReadLine();

            if (userInput.ToLower() == "exit")
            {
                Console.WriteLine("Chatbot: Goodbye!");
                break;
            }
            // Generate a basic response
            string botResponse = GenerateResponse(userInput);
            Console.WriteLine("Chatbot: " + botResponse);
        }
    }

    private string GenerateResponse(string input)
    {
        if (input.Contains("What is a phishing email", StringComparison.OrdinalIgnoreCase))
        {
            return "A phishing email is a type of cyber attack where attackers impersonate organizations...";
        }
        else
        {
            return "Interesting! Tell me more.";


        }
    }

    private void DisplayImages(string[] imagePaths)
    {
        foreach (var imagePath in imagePaths)
        {
            try
            {
                // Check if the image file exists before attempting to load it
                if (!System.IO.File.Exists(imagePath))
                {
                    Console.WriteLine($"Error: File '{imagePath}' does not exist.");
                    continue; // Skip to the next image path
                }

                Bitmap image = new Bitmap(imagePath);
                Console.WriteLine($"Loaded image: {imagePath}");
                Console.WriteLine($"Image size: {image.Width}x{image.Height}");

                // Convert and display image as ASCII
                string asciiArt = ConvertToAscii(image);
                Console.WriteLine(asciiArt);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading {imagePath}: {ex.Message}");
            }
        }
    }

    private string ConvertToAscii(Bitmap image)
    {
        // Define ASCII characters to use (the denser characters will represent darker areas)
        string asciiChars = "@%#*+=-:. ";

        int width = 100;  // Width to resize the image to
        int height = (int)(image.Height * ((double)width / image.Width)); // Maintain aspect ratio
        Bitmap resizedImage = new Bitmap(image, new Size(width, height));

        StringBuilder asciiArt = new StringBuilder();

        // Loop through each pixel and convert to ASCII
        for (int y = 0; y < resizedImage.Height; y++)
        {
            for (int x = 0; x < resizedImage.Width; x++)
            {
                Color pixelColor = resizedImage.GetPixel(x, y);
                // Calculate brightness as average of RGB values
                int grayValue = (int)((pixelColor.R + pixelColor.G + pixelColor.B) / 3);
                // Map gray value to an ASCII character
                int index = grayValue * (asciiChars.Length - 1) / 255;
                asciiArt.Append(asciiChars[index]);
            }
            asciiArt.AppendLine();
        }

        return asciiArt.ToString();
    }
}