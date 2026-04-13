using System;
using System.Threading;
using System.Collections.Generic;

namespace CyberSecurityBot
{
    #region Person and User Classes
    public abstract class Person
    {
        public string Name { get; set; }
    }

    public class User : Person { }
    #endregion

    #region Response Handler Class
    public class ResponseHandler
    {
        private Dictionary<string, string> responses;

        public ResponseHandler()
        {
            InitializeResponses();
        }

        private void InitializeResponses()
        {
            responses = new Dictionary<string, string>()
            {
                { "how are you", "I'm functioning perfectly! Thanks for asking. Ready to help you learn about cybersecurity." },
                { "what is your purpose", "My purpose is to educate and protect users from cybersecurity threats. I provide information about password safety, phishing, and safe browsing." },
                { "what can i ask you about", "You can ask me about:\n- Password Safety\n- Phishing Attacks\n- Safe Browsing\n- General cybersecurity tips" },
                { "password", "PASSWORD SAFETY TIPS:\n\n- Use 12+ characters with uppercase, lowercase, numbers, and symbols\n- Never reuse passwords across different sites\n- Enable Two-Factor Authentication (2FA)\n- Use a password manager like Bitwarden or LastPass\n- Change passwords every 3-6 months" },
                { "phishing", "PHISHING AWARENESS:\n\n- Never click suspicious links in emails or messages\n- Check sender email addresses carefully for spoofing\n- Look for spelling errors and urgent language\n- Verify requests through official channels (call the company directly)\n- 90% of data breaches start with phishing!\n- Use email filtering and anti-phishing tools" },
                { "browsing", "SAFE BROWSING TIPS:\n\n- Always check for HTTPS before entering personal info (look for the padlock icon)\n- Keep your browser and extensions updated\n- Use ad-blockers and privacy extensions (uBlock Origin, Privacy Badger)\n- Avoid public Wi-Fi for sensitive transactions like banking\n- Clear cookies and cache regularly\n- Use a VPN on untrusted networks" },
                { "help", "AVAILABLE COMMANDS:\n\n- 'how are you' - Check bot status\n- 'purpose' - Learn about my mission\n- 'topics' - See what I can teach\n- 'password' - Password safety tips\n- 'phishing' - Phishing awareness\n- 'browsing' - Safe browsing tips\n- 'exit' - End the conversation" },
                { "topics", "I CAN HELP YOU WITH:\n\n1. Password Security\n2. Phishing Prevention\n3. Safe Browsing Practices\n4. General Cybersecurity Awareness\n\nType any topic to learn more!" }
            };
        }

        public string GetResponse(string input, string userName)
        {
            // Check for exit
            if (input == "8" || input == "exit" || input == "quit" || input == "goodbye")
            {
                return "EXIT";
            }

            // Check menu numbers
            switch (input)
            {
                case "1": return responses["how are you"];
                case "2": return responses["what is your purpose"];
                case "3": return responses["topics"];
                case "4": return responses["password"];
                case "5": return responses["phishing"];
                case "6": return responses["browsing"];
                case "7": return responses["help"];
            }

            // Check for keywords in responses
            foreach (var kvp in responses)
            {
                if (input.Contains(kvp.Key))
                {
                    return kvp.Value;
                }
            }

            // Default response for invalid input
            return $"I didn't quite understand that, {userName}. Could you rephrase?\n\nType 'help' to see available commands.";
        }
    }
    #endregion

    #region UI Manager Class
    public class UIManager
    {
        private const int BoxWidth = 76;

        public void DisplayAsciiLogo()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;

            string asciiArt = @"
    ╔══════════════════════════════════════════════════════════════════════╗
    ║                                                                      ║
    ║     ██████╗██╗   ██╗██████╗ ███████╗██████╗ ███████╗ ██████╗██╗  ██╗  ║
    ║    ██╔════╝╚██╗ ██╔╝██╔══██╗██╔════╝██╔══██╗██╔════╝██╔════╝╚██╗██╔╝  ║
    ║    ██║      ╚████╔╝ ██████╔╝█████╗  ██████╔╝█████╗  ██║      ╚███╔╝   ║
    ║    ██║       ╚██╔╝  ██╔══██╗██╔══╝  ██╔══██╗██╔══╝  ██║      ██╔██╗   ║
    ║    ╚██████╗   ██║   ██████╔╝███████╗██║  ██║███████╗╚██████╗██╔╝ ██╗  ║
    ║     ╚═════╝   ╚═╝   ╚═════╝ ╚══════╝╚═╝  ╚═╝╚══════╝ ╚═════╝╚═╝  ╚═╝  ║
    ║                                                                      ║
    ║              ██████╗  ██████╗ ████████╗                             ║
    ║             ██╔══██╗██╔═══██╗╚══██╔══╝                             ║
    ║             ██████╔╝██║   ██║   ██║                                ║
    ║             ██╔══██╗██║   ██║   ██║                                ║
    ║             ██████╔╝╚██████╔╝   ██║                                ║
    ║             ╚═════╝  ╚═════╝    ╚═╝                                ║
    ║                                                                      ║
    ║              ┌─────────────────────────────────────┐                ║
    ║              │    CYBERSECURITY AWARENESS BOT      │                ║
    ║              │    Your Digital Safety Companion    │                ║
    ║              └─────────────────────────────────────┘                ║
    ║                                                                      ║
    ╚══════════════════════════════════════════════════════════════════════╝
";

            Console.WriteLine(asciiArt);
            Console.ResetColor();
            Thread.Sleep(2000);
        }

        public void DisplayWelcomeMessage(string name)
        {
            Console.Clear();
            DrawBox("WELCOME", ConsoleColor.Green);

            string[] welcomeLines = {
                $"Hello {name}!",
                "",
                "I am your Cybersecurity Awareness Bot.",
                "I'm here to help you stay safe online.",
                "",
                "I can teach you about:",
                "  • Password Safety",
                "  • Phishing Attacks",
                "  • Safe Browsing",
                "",
                "Type 'help' anytime to see available commands."
            };

            foreach (string line in welcomeLines)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"  {line}");
                Thread.Sleep(80);
            }

            Console.ResetColor();
            Thread.Sleep(1500);
        }

        public void DisplayMenu()
        {
            Console.Clear();
            DrawBox("MAIN MENU", ConsoleColor.Yellow);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(@"  
    ╔════════════════════════════════════════════════════════════╗
    ║                                                            ║
    ║    [1] How are you?                                       ║
    ║    [2] What is your purpose?                              ║
    ║    [3] What topics can I ask about?                       ║
    ║    [4] Password Safety Tips                               ║
    ║    [5] Phishing Awareness                                 ║
    ║    [6] Safe Browsing Guide                                ║
    ║    [7] Help                                               ║
    ║    [8] Exit                                               ║
    ║                                                            ║
    ╚════════════════════════════════════════════════════════════╝
    ");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("\n  ┌─[ Enter your choice (1-8) or type a question ]\n  └─> ");
            Console.ResetColor();
        }

        public void DisplayResponse(string response)
        {
            Console.Clear();
            DrawBox("RESPONSE", ConsoleColor.Magenta);

            Console.ForegroundColor = ConsoleColor.White;
            string[] lines = response.Split('\n');
            foreach (string line in lines)
            {
                Console.WriteLine($"  {line}");
            }
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n  ┌─────────────────────────────────────────────────┐");
            Console.WriteLine("  │  Press any key to continue...                    │");
            Console.WriteLine("  └─────────────────────────────────────────────────┘");
            Console.ResetColor();
            Console.ReadKey();
        }

        public void DisplayFarewell(string name)
        {
            Console.Clear();
            DrawBox("GOODBYE", ConsoleColor.Red);

            string[] farewellLines = {
                $"Thank you for using the Cybersecurity Awareness Bot, {name}!",
                "",
                "Remember:",
                "  • Use strong and unique passwords",
                "  • Never click suspicious links",
                "  • Always verify email senders",
                "  • Keep your software updated",
                "  • Enable 2FA whenever possible",
                "",
                "Stay safe online!"
            };

            foreach (string line in farewellLines)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"  {line}");
                Thread.Sleep(80);
            }
            Console.ResetColor();
            Thread.Sleep(2000);
        }

        public void DisplayError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n  [ERROR] {message}");
            Console.ResetColor();
            Thread.Sleep(1500);
        }

        public void DisplaySuccess(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n  [SUCCESS] {message}");
            Console.ResetColor();
            Thread.Sleep(1000);
        }

        public void DisplayPrompt(string message)
        {
            Console.Clear();
            DrawBox(message, ConsoleColor.Cyan);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("  ┌─> ");
            Console.ResetColor();
        }

        public void TypingEffect()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("\n  Bot is typing");
            for (int i = 0; i < 3; i++)
            {
                Thread.Sleep(300);
                Console.Write(".");
            }
            Console.ResetColor();
            Thread.Sleep(500);
        }

        private void DrawBox(string title, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine($"\n  ╔{new string('═', BoxWidth)}╗");
            Console.WriteLine($"  ║{CenterText(title, BoxWidth)}║");
            Console.WriteLine($"  ╚{new string('═', BoxWidth)}╝");
            Console.WriteLine();
            Console.ResetColor();
        }

        private string CenterText(string text, int width)
        {
            if (text.Length >= width) return text;
            int padding = (width - text.Length) / 2;
            return new string(' ', padding) + text + new string(' ', width - text.Length - padding);
        }
    }
    #endregion

    #region ChatBot Main Class
    public class CyberSecurityChatBot : User
    {
        private string userName;
        private bool isRunning;
        private UIManager ui;
        private ResponseHandler responses;

        public CyberSecurityChatBot()
        {
            ui = new UIManager();
            responses = new ResponseHandler();
            isRunning = true;
        }

        public void Run()
        {
            // Display ASCII logo
            ui.DisplayAsciiLogo();

            // Get user name
            GetUserName();

            // Show welcome message
            ui.DisplayWelcomeMessage(userName);

            // Start main interaction loop
            MainLoop();
        }

        private void GetUserName()
        {
            while (string.IsNullOrWhiteSpace(userName))
            {
                ui.DisplayPrompt("Enter your name");
                userName = Console.ReadLine()?.Trim();

                if (string.IsNullOrWhiteSpace(userName))
                {
                    ui.DisplayError("Name cannot be empty. Please try again.");
                }
            }

            ui.DisplaySuccess($"Nice to meet you, {userName}!");
            Thread.Sleep(1000);
        }

        private void MainLoop()
        {
            while (isRunning)
            {
                ui.DisplayMenu();
                string input = Console.ReadLine()?.ToLower().Trim();

                // Input validation
                if (string.IsNullOrEmpty(input))
                {
                    ui.DisplayError("Please enter a valid option or question.");
                    continue;
                }

                ProcessInput(input);
            }
        }

        private void ProcessInput(string input)
        {
            // Show typing effect
            ui.TypingEffect();

            // Get response
            string response = responses.GetResponse(input, userName);

            // Check for exit
            if (response == "EXIT")
            {
                isRunning = false;
                ui.DisplayFarewell(userName);
                return;
            }

            // Display the response
            ui.DisplayResponse(response);
        }
    }
    #endregion

    #region Main Program Entry Point
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Cybersecurity Awareness Bot";
            Console.WindowWidth = 100;
            Console.WindowHeight = 45;
            Console.CursorVisible = true;
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            try
            {
                CyberSecurityChatBot bot = new CyberSecurityChatBot();
                bot.Run();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n╔{'═' * 78}╗");
               
                Console.WriteLine($"╠{'═' * 78}╣");
                Console.WriteLine($"║ {ex.Message.PadRight(76)}║");
                Console.WriteLine($"╚{'═' * 78}╝");
                Console.ResetColor();
                Console.WriteLine("\nPress any key to exit...");
                Console.ReadKey();
            }
        }
    }

    public static class StringExtensions
    {
        public static string Center(this string text, int width)
        {
            if (string.IsNullOrEmpty(text)) return new string(' ', width);
            if (text.Length >= width) return text.Substring(0, width);
            int padding = (width - text.Length) / 2;
            return new string(' ', padding) + text + new string(' ', width - text.Length - padding);
        }
    }
    #endregion
}