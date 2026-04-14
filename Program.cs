using System;
using System.Threading;

namespace CyberSecurityChatbot
{
    class Program
    {
        private static string _userName = "";

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            DisplayAsciiArt();
            Console.WriteLine("=== CYBER SECURITY CHATBOT ===");
            Console.ResetColor();
            Thread.Sleep(2000);
            Console.Clear();

            // Get user name
            Console.Write("Enter your name: ");
            _userName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(_userName))
                _userName = "User";

            Console.Clear();

            // Welcome message AFTER user enters name
            DisplayAsciiArt();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\n========================================");
            Console.WriteLine($"   WELCOME {_userName.ToUpper()}!");
            Console.WriteLine($"   I'm your Cybersecurity Assistant");
            Console.WriteLine($"========================================\n");
            Console.ResetColor();
            Thread.Sleep(1500);

            // Show menu
            ShowMenu();
        }

        static void DisplayAsciiArt()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            string asciiArt = @"
    ╔═══════════════════════════════════════════════════════════════════╗
    ║                                                                   ║
    ║     ██████╗██╗  ██╗ █████╗ ████████╗██████╗  ██████╗ ████████╗    ║
    ║    ██╔════╝██║  ██║██╔══██╗╚══██╔══╝██╔══██╗██╔═══██╗╚══██╔══╝    ║
    ║    ██║     ███████║███████║   ██║   ██████╔╝██║   ██║   ██║       ║
    ║    ██║     ██╔══██║██╔══██║   ██║   ██╔══██╗██║   ██║   ██║       ║
    ║    ╚██████╗██║  ██║██║  ██║   ██║   ██████╔╝╚██████╔╝   ██║       ║
    ║     ╚═════╝╚═╝  ╚═╝╚═╝  ╚═╝   ╚═╝   ╚═════╝  ╚═════╝    ╚═╝       ║
    ║                                                                   ║
    ║                CYBERSECURITY CHATBOT v1.0                         ║
    ║                                                                   ║
    ╚═══════════════════════════════════════════════════════════════════╝
";
            Console.WriteLine(asciiArt);
            Console.ResetColor();
        }

        static void ShowMenu()
        {
            while (true)
            {
                Console.Clear();
                DisplayAsciiArt();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n========== MAIN MENU ==========");
                Console.ResetColor();
                Console.WriteLine("1. How are you");
                Console.WriteLine("2. Purpose");
                Console.WriteLine("3. Topics");
                Console.WriteLine("4. Password Safety");
                Console.WriteLine("5. Phishing");
                Console.WriteLine("6. Safe Browsing");
                Console.WriteLine("7. Exit");
                Console.WriteLine("\n================================");
                Console.Write($"\n[{_userName}] Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        HowAreYou();
                        break;
                    case "2":
                        Purpose();
                        break;
                    case "3":
                        Topics();
                        break;
                    case "4":
                        PasswordSafety();
                        break;
                    case "5":
                        Phishing();
                        break;
                    case "6":
                        SafeBrowsing();
                        break;
                    case "7":
                        ExitChatbot();
                        return;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n[!] Invalid option. Please try again.");
                        Console.ResetColor();
                        Thread.Sleep(1500);
                        break;
                }
            }
        }

        static void HowAreYou()
        {
            Console.Clear();
            DisplayAsciiArt();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\n[Assistant] I'm doing great, {_userName}!");
            Console.WriteLine("[Assistant] I'm here to help you stay secure online.");
            Console.WriteLine("[Assistant] How can I assist you today?\n");
            Console.ResetColor();
            Console.WriteLine("Press any key to return to menu...");
            Console.ReadKey();
        }

        static void Purpose()
        {
            Console.Clear();
            DisplayAsciiArt();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\n[Assistant] My purpose is to help you, {_userName},");
            Console.WriteLine("[Assistant] stay safe from cyber threats like hackers,");
            Console.WriteLine("[Assistant] scams, viruses, and identity theft.");
            Console.WriteLine("[Assistant] I provide simple security tips and guidance.\n");
            Console.ResetColor();
            Console.WriteLine("Press any key to return to menu...");
            Console.ReadKey();
        }

        static void Topics()
        {
            Console.Clear();
            DisplayAsciiArt();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n[Assistant] I can teach you about:");
            Console.WriteLine("   • Password Safety");
            Console.WriteLine("   • Phishing Scams");
            Console.WriteLine("   • Safe Browsing");
            Console.WriteLine("   • Malware Protection");
            Console.WriteLine("   • Social Media Privacy\n");
            Console.ResetColor();
            Console.WriteLine("Press any key to return to menu...");
            Console.ReadKey();
        }

        static void PasswordSafety()
        {
            Console.Clear();
            DisplayAsciiArt();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n[PASSWORD SAFETY TIPS]");
            Console.WriteLine("═══════════════════════════════════════");
            Console.WriteLine("1. Use 12+ characters with letters, numbers & symbols");
            Console.WriteLine("2. Never reuse passwords across different sites");
            Console.WriteLine("3. Use a password manager to store passwords safely");
            Console.WriteLine("4. Enable Two-Factor Authentication (2FA)");
            Console.WriteLine("5. Change default passwords on new devices");
            Console.WriteLine("═══════════════════════════════════════\n");
            Console.ResetColor();
            Console.WriteLine("Press any key to return to menu...");
            Console.ReadKey();
        }

        static void Phishing()
        {
            Console.Clear();
            DisplayAsciiArt();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n[PHISHING SCAM TIPS]");
            Console.WriteLine("═══════════════════════════════════════");
            Console.WriteLine("1. Never click links from unknown senders");
            Console.WriteLine("2. Check email addresses carefully - scammers spoof");
            Console.WriteLine("3. Hover over links to see real destination");
            Console.WriteLine("4. If it's too good to be true, it's a scam");
            Console.WriteLine("5. Report suspicious emails to IT security");
            Console.WriteLine("═══════════════════════════════════════\n");
            Console.ResetColor();
            Console.WriteLine("Press any key to return to menu...");
            Console.ReadKey();
        }

        static void SafeBrowsing()
        {
            Console.Clear();
            DisplayAsciiArt();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n[SAFE BROWSING TIPS]");
            Console.WriteLine("═══════════════════════════════════════");
            Console.WriteLine("1. Look for 'https://' and padlock icon in address bar");
            Console.WriteLine("2. Avoid clicking pop-up ads");
            Console.WriteLine("3. Don't download files from untrusted websites");
            Console.WriteLine("4. Use ad-blockers and anti-tracking extensions");
            Console.WriteLine("5. Clear your browsing data regularly");
            Console.WriteLine("═══════════════════════════════════════\n");
            Console.ResetColor();
            Console.WriteLine("Press any key to return to menu...");
            Console.ReadKey();
        }

        static void ExitChatbot()
        {
            Console.Clear();
            DisplayAsciiArt();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n========================================");
            Console.WriteLine($"   GOODBYE {_userName.ToUpper()}!");
            Console.WriteLine("   Stay safe and secure online!");
            Console.WriteLine("========================================\n");
            Console.ResetColor();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}