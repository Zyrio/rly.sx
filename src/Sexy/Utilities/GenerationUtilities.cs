using System;

namespace Sexy.Utilities
{
    public class GenerationUtilities
    {
        public static string GenerateRandomString(int length, bool uppercase)
        {
            string characters = "";

            switch(uppercase) {
                case true:
                    characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
                    break;
                case false:
                    characters = "abcdefghijklmnopqrstuvwxyz1234567890";
                    break;
            }

            System.Text.StringBuilder randomString = new System.Text.StringBuilder();
            Random random = new Random();

            while (0 < length--)
            {
                randomString.Append(characters[random.Next(characters.Length)]);
            }

            return randomString.ToString();
        }
    }
}