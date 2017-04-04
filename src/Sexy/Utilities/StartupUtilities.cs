using System;

namespace Sexy.Utilities
{
    public class StartupUtilities
    {
        public static string GetCopyrightYear(string Release)
        {
            return Release.Substring(0, 2);
        }

        public static string GetRelease()
        {
            string FullVersion = "";

            if(Version.Patch == 0) {
                FullVersion = Version.Release.ToString();
            } else {
                FullVersion = Version.Release.ToString()
                    + "." + Version.Patch.ToString();
            }

            if (String.IsNullOrEmpty(Version.Codename)) {
                return FullVersion;
            } else {
                return FullVersion + " '" + Version.Codename + "'";
            }
        }

        public static void WriteFailure(string Message)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("× " + Message);
            Console.ResetColor();
        }

        public static void WriteInfo(string Message)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("» " + Message);
            Console.ResetColor();
        }

        public static void WriteStartupMessage(string Release, ConsoleColor LogoColor)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            Console.ForegroundColor = LogoColor;
           







            Console.WriteLine(@" ____                  ");
            Console.WriteLine(@"/ ___|  _____  ___   _ ");
            Console.WriteLine(@"\___ \ / _ \ \/ | | | |");
            Console.WriteLine(@" ___) |  __/>  <| |_| |");
            Console.WriteLine(@"|____/ \___/_/\_\\__, |");
            Console.WriteLine(@"                 |___/ " + Environment.NewLine);
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("---------------------------" + Environment.NewLine);
            Console.ResetColor();

            Console.WriteLine("Release " + Release + Environment.NewLine);

            Console.WriteLine("© Zyrio 20" + GetCopyrightYear(Release) + ". All rights reserved.");
            Console.WriteLine("Do not redistribute this code." + Environment.NewLine);

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("===" + Environment.NewLine);
            Console.ResetColor();
        }

        public static void WriteSuccess(string Message)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("✓ " + Message);
            Console.ResetColor();
        }

        public static void WriteWarning(string Message)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("! " + Message);
            Console.ResetColor();
        }
    }
}