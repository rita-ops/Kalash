using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Kalash
{
    internal class ValidationHelper
    {
        // Method to check for invalid characters in a string
        public static bool IsValidInput(string input)
        {
            // Check for the presence of '<', '>', '&' characters
            if (Regex.IsMatch(input, @"[<>&]"))
            {
                MessageBox.Show("Input contains invalid characters: <, >, &");
                return false;
            }
            return true;
        }

        // Method to validate username with no special characters
        public static bool IsValidUsername(string username)
        {
            // Username can only contain letters, numbers, and underscores
            if (!Regex.IsMatch(username, @"^[a-zA-Z0-9_]+$"))
            {
                MessageBox.Show("Username can only contain letters, numbers, and underscores.");
                return false;
            }
            return true;
        }

        // Method to validate password
        public static bool IsValidPassword(string password)
        {
            // Password must contain at least one uppercase letter, one number, and can include @ or ! as special characters
            string pattern = @"^(?=.*[A-Z])(?=.*\d)(?=.*[@!]).+$";

            // Check if password matches the pattern
            if (!Regex.IsMatch(password, pattern))
            {
                MessageBox.Show("Password must contain at least one uppercase letter, one number, and can only include special characters.");
                return false;
            }

            // Password must be at least 8 characters long
            if (password.Length < 8)
            {
                MessageBox.Show("Password must be at least 8 characters long.");
                return false;
            }

            return true;
        }
    }
}
