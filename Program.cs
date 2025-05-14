using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Media;
using System.Text.RegularExpressions;

namespace AddSoundAndEnhancedChatbot
{
    class Program
    {
        static void Main(string[] args)
        {
            // Play sound first
            try
            {
                SoundPlayer myMusic = new SoundPlayer("sound.wav");
                myMusic.Load();
                myMusic.PlayLooping();

                Console.WriteLine("Playing sound... Press Enter to continue.");
                Console.ReadLine(); // Wait until user presses Enter
                myMusic.Stop();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error playing sound: {ex.Message}");
            }

            // Proceed to the main menu
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
            Console.WriteLine("5) How to Recognizing and Avoiding Malware");
            Console.WriteLine("6) How to secure Wifi Practises");
            Console.WriteLine("7) Why are Regular software updates important");
            Console.WriteLine("8) What is Data Backup and Recovery");
            Console.WriteLine("9) Privacy Settings and data sharing");
            Console.WriteLine("10) Importance of Two Factor Authentication");
            Console.WriteLine("11) Exit");
            Console.Write("\r\nSelect an option: ");

            string userInput = Console.ReadLine().Trim();

            switch (userInput)
            {
                case "1":
                    Console.Clear();
                    new CyberSecurityChatbot(phishingTopics).StartChatbot();
                    Console.WriteLine("Press any key to return to menu...");
                    Console.ReadKey();
                    return true;
                case "2":
                    Console.Clear();
                    new CyberSecurityChatbot(passwordTopics).StartChatbot();
                    Console.WriteLine("Press any key to return to menu...");
                    Console.ReadKey();
                    return true;
                case "3":
                    Console.Clear();
                    new CyberSecurityChatbot(changePasswordTopics).StartChatbot();
                    Console.WriteLine("Press any key to return to menu...");
                    Console.ReadKey();
                    return true;
                case "4":
                    Console.Clear();
                    new CyberSecurityChatbot(linkTopics).StartChatbot();
                    Console.WriteLine("Press any key to return to menu...");
                    Console.ReadKey();
                    return true;
                case "5":
                    return false; // Exit
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid option. Try again.");
                    Console.WriteLine("Press any key...");
                    Console.ReadKey();
                    return true;
            }
        }

        // Define all topic lists
        static List<string> phishingTopics = new List<string>
        {
            "Phishing is a cyber attack that impersonates legitimate organizations to steal sensitive information.",
            "Always verify the sender's email address and avoid clicking on suspicious links."
        };

        static List<string> passwordTopics = new List<string>
        {
            "Strong passwords are crucial for protecting your accounts.",
            "Use at least 12 characters with a mix of uppercase, lowercase, numbers, and symbols."
        };

        static List<string> changePasswordTopics = new List<string>
        {
            "It's good practice to change your passwords regularly, about every 3-6 months.",
            "Immediately change your password if you suspect your account has been compromised."
        };

        static List<string> linkTopics = new List<string>
        {
            "Always hover over links to see the actual URL before clicking.",
            "Avoid clicking shortened or suspicious links."
        };

        static List<string> malwareTopics = new List<string>
        {
            "Malware can be disguised as legitimate software or email attachments; avoid downloading from untrusted sources.",
            "Use reputable antivirus software and keep it updated regularly to detect and remove threats."
        };

        static List<string> wifiTopics = new List<string>
        {
            "Use strong, unique passwords for your home Wi-Fi and enable WPA3 encryption if available.",
            "Avoid connecting to unsecured public Wi-Fi networks for sensitive activities or use a VPN for protection."
        };

        static List<string> updateTopics = new List<string>
        {
            "Keep your operating system and applications updated to patch security vulnerabilities.",
            "Updates often include important security improvements that protect against latest threats."
        };

        static List<string> backupTopics = new List<string>
        {
            "Regularly back up important data to an external drive or cloud service to prevent data loss.",
            "Ensure backups are stored securely and test recovery procedures periodically."
        };

        static List<string> privacyTopics = new List<string>
        {
            "Review and adjust privacy settings on social media and online accounts to limit data sharing.",
            "Be cautious about the information you share online to reduce the risk of identity theft and targeted attacks."
        };

        static List<string> twoFactorTopics = new List<string>
        {
            "Adds an extra layer of security by requiring a second form of verification beyond just a password.",
            "Helps prevent unauthorized access even if your password is compromised."
        };
    }

    class CyberSecurityChatbot
    {
        private List<string> topics;
        private string userName = "";
        private string favoriteInfo = ""; // Memory of user's shared info
        private Random rnd = new Random();

        // Recognized keywords for cybersecurity
        private Dictionary<string, List<string>> keywordResponses = new Dictionary<string, List<string>>()
        {
            {"phishing", new List<string>{
                "Phishing is a cyber attack that impersonates legitimate organizations to steal sensitive information.",
                "Be cautious of emails asking for personal info."
            }},
            {"password", new List<string>{
                "A strong password includes uppercase, lowercase, numbers, and symbols.",
                "Change passwords regularly to stay secure."
            }},
            {"update software", new List<string>{
                "Keeping your software up to date patches security vulnerabilities.",
                "Enable automatic updates whenever possible."
            }},
            {"link", new List<string>{
                "Hover over links to check their authenticity.",
                "Avoid clicking on suspicious links."
            }}
        };

        // Sentiment/emotion keywords
        private Dictionary<string, string> emotionKeywords = new Dictionary<string, string>()
        {
            {"worried", "worried"},
            {"nervous", "worried"},
            {"confused", "frustrated"},
            {"lost", "frustrated"},
            {"happy", "happy"},
            {"excited", "happy"},
            {"sad", "sad"},
            {"upset", "sad"},
            {"angry", "angry"}
        };

        private Dictionary<string, string> emotionResponses = new Dictionary<string, string>()
        {
            {"worried", "It's understandable to feel concerned. I'm here to help."},
            {"frustrated", "Learning new things can be confusing, but you're doing great."},
            {"happy", "That's wonderful! Keep up the good work."},
            {"sad", "I'm here for you. Let's learn together."},
            {"angry", "It's okay to feel upset. Let's focus on staying safe online."}
        };

        public CyberSecurityChatbot(List<string> topics)
        {
            this.topics = topics;
        }

        public void StartChatbot()
        {
            Console.Clear();
            Console.WriteLine("Hello! What's your name?");
            userName = Console.ReadLine();

            // Immediately ask about their feelings
            Console.WriteLine($"Hi {userName}! How are you feeling today?");
            string emotionInput = Console.ReadLine()?.ToLower();

            // Detect and respond to user emotion
            HandleEmotion(emotionInput);

            Console.WriteLine($"Great! Ask me anything about cybersecurity, or type 'exit' to leave.");

            while (true)
            {
                Console.WriteLine("\nYou:");
                var stopwatch = Stopwatch.StartNew();
                string input = Console.ReadLine()?.ToLowerInvariant();
                stopwatch.Stop();

                if (stopwatch.ElapsedMilliseconds <= 20)
                {
                    Console.WriteLine("Chatbot: That was fast! Take your time, I'm here when you're ready.");
                    continue;
                }

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Chatbot: Please say something so I can assist you.");
                    continue;
                }

                if (input.Contains("exit") || input.Contains("bye") || input.Contains("quit"))
                {
                    Console.WriteLine($"Chatbot: Goodbye, {userName}! Stay safe online.");
                    break;
                }

                // Detect and respond to user emotions
                HandleEmotion(input);

                // Check for cybersecurity keywords
                bool keywordFound = false;
                foreach (var key in keywordResponses.Keys)
                {
                    if (Regex.IsMatch(input, $@"\b{Regex.Escape(key)}\b"))
                    {
                        keywordFound = true;
                        favoriteInfo = key; // store last keyword for recall
                        var responses = keywordResponses[key];
                        Console.WriteLine($"Chatbot: {responses[rnd.Next(responses.Count)]}");
                        break;
                    }
                }

                // If no keyword, check if user asks for more info
                if (!keywordFound)
                {
                    if (!string.IsNullOrEmpty(favoriteInfo) && input.Contains("more"))
                    {
                        var responses = keywordResponses[favoriteInfo];
                        Console.WriteLine($"Chatbot: Here's more about {favoriteInfo}: {responses[rnd.Next(responses.Count)]}");
                    }
                    else
                    {
                        Console.WriteLine("Chatbot: I'm not sure I understand. Could you rephrase or ask about a specific topic?");
                    }
                }
            }
        }

        private void HandleEmotion(string input)
        {
            foreach (var pair in emotionKeywords)
            {
                if (Regex.IsMatch(input, $@"\b{pair.Key}\b"))
                {
                    string emotion = pair.Value;
                    if (emotionResponses.ContainsKey(emotion))
                    {
                        Console.WriteLine($"Chatbot: {emotionResponses[emotion]}");
                    }
                    break;
                }
            }
        }
    }
}