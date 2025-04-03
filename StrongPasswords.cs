using System;
using System.Drawing;
using System.Text;

class StrongPasswords
{
    public void StartChatbot()
    {
        Console.WriteLine("Chatbot: Hi there! Im your chatbot.Type exit to quit.");

        // ARRAY TO STORE IMAGES 
        DisplayImages(new[] { "StrongPasswords.jpg" });

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
        if (input.Contains("Importance of Strong passwords", StringComparison.OrdinalIgnoreCase))
        {
            return "Strong passwords are vital for protecting your accounts. They should be at least 12 characters long and include a mix of upper and lower-case letters, numbers, and symbols.";
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
        string asciiChars = "@%#*+=-:. ";

        int width = 100;  // Width to resize the image to
        int height = (int)(image.Height * ((double)width / image.Width)); // Maintain aspect ratio
        Bitmap resizedImage = new Bitmap(image, new Size(width, height));

        StringBuilder asciiArt = new StringBuilder();

        for (int y = 0; y < resizedImage.Height; y++)
        {
            for (int x = 0; x < resizedImage.Width; x++)
            {
                Color pixelColor = resizedImage.GetPixel(x, y);
                int grayValue = (int)((pixelColor.R + pixelColor.G + pixelColor.B) / 3);
                int index = grayValue * (asciiChars.Length - 1) / 255;
                asciiArt.Append(asciiChars[index]);
            }
            asciiArt.AppendLine();
        }

        return asciiArt.ToString();
    }
}