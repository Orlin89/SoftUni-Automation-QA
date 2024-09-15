using System.Diagnostics.Metrics;

namespace _09.PasswordValidator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            if (!PasswordValidationBetween6And10Characters(password))
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }
            if (!CheckPassContainOnlyLettersAndDigits(password))
            {
              Console.WriteLine("Password must consist only of letters and digits");
            }
            if (!CheckPasswordHaveAtLeast2Digits(password))
            {
                Console.WriteLine("Password must have at least 2 digits");
            }
            if (PasswordValidationBetween6And10Characters(password) && 
                CheckPassContainOnlyLettersAndDigits(password) && 
                CheckPasswordHaveAtLeast2Digits(password))
            {
                Console.WriteLine("Password is valid");
            }
        }

        static bool PasswordValidationBetween6And10Characters(string pass)
        {
            if (pass.Length >= 6 && pass.Length <= 10)
            {
                return true;
            }
            return false;
        }

        static bool CheckPassContainOnlyLettersAndDigits(string pass)
        {
            for (int i = 0; i < pass.Length; i++)
            {
              char currentChar = pass[i];
                if (!char.IsLetterOrDigit(currentChar))
                {
                    return false;
                }               
            }
            return true;
        }

        static bool CheckPasswordHaveAtLeast2Digits(string pass)
        {
            int Counter = 0;
            for (int i = 0; i < pass.Length; i++)
            {
                char currentChar = pass[i];
                if (char.IsDigit(currentChar))
                {
                    Counter++;
                    if (Counter >= 2)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
