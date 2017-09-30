using System;
using Sexy.Data.Constants;

namespace Sexy.Utilities
{
    public class StartupUtilities
    {
        public static string GetCopyrightYear()
        {
            return VersionConstant.Release.ToString().Substring(0, 2);
        }

        public static string GetRelease()
        {
            string FullVersion = "";

            if(Sexy.Data.Constants.VersionConstant.Unstable) {
                FullVersion = "dev." + Sexy.Data.Constants.VersionConstant.Patch.ToString() 
                            + " (" + VersionConstant.Release.ToString()
                            + "." + VersionConstant.Patch.ToString() + ")";
                return FullVersion;
            } else {
                    if(VersionConstant.Patch == 0) {
                        FullVersion = VersionConstant.Release.ToString();
                    } else {
                        FullVersion = VersionConstant.Release.ToString()
                            + "." + VersionConstant.Patch.ToString();
                    }

                    if (String.IsNullOrEmpty(VersionConstant.Codename)) {
                        return FullVersion;
                    } else {
                        return FullVersion + " '" + VersionConstant.Codename + "'";
                    }
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

            Console.WriteLine("© Zyrio 20" + GetCopyrightYear() + ". Licensed under MIT.");

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