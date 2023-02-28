using System;
using System.Text.RegularExpressions;
using CodeShare.Library.Passwords;

public class Program
{
    public static void Main()
    {
        bool includeLowercase = true;
        bool includeUppercase = true;
        bool includeNumeric = true;
        bool includeSpecial = true;
        bool includeSpaces = false;
        string Lowercase;
        string Uppercase;
        string Numeric;
        string Special;
        string lengthOfPassword ;
        int val;

        Console.WriteLine("Do you want to include numbers ? [Y/N]");
        Lowercase = Console.ReadLine();
        Console.WriteLine("OK! How about lowercase characters?? [Y/N]");
        Uppercase = Console.ReadLine();
        Console.WriteLine("Very Nice! How about uppercase characters? ? [Y/N]");
        Numeric= Console.ReadLine();
        Console.WriteLine("All Right! We are almost done. Would you also want to add special characters? ? [Y/N]");
        Special = Console.ReadLine();

        if (Lowercase == "N")
        {
            includeLowercase = false;
        }
        if (Uppercase == "N")
        {
            includeUppercase = false;
        }
        if (Numeric=="N")
        {
            includeNumeric = false;
        }
        
       

        Console.WriteLine("Great! Lastly. How long do you want to keep your password length? ");
        lengthOfPassword = Console.ReadLine();
        val = Convert.ToInt32(lengthOfPassword);

        string password = PasswordGenerator.GeneratePassword(includeLowercase, includeUppercase, includeNumeric, includeSpecial, includeSpaces, val);

        while (!PasswordGenerator.PasswordIsValid(includeLowercase, includeUppercase, includeNumeric, includeSpecial, includeSpaces, password))
        {
            password = PasswordGenerator.GeneratePassword(includeLowercase, includeUppercase, includeNumeric, includeSpecial, includeSpaces, val);
        }

        Console.WriteLine(password);
    }
}

namespace CodeShare.Library.Passwords
{
    public static class PasswordGenerator
    {
        /// Parametrelerde iletilen kurallara göre rastgele bir parola oluşturur.

        public static string GeneratePassword(bool includeLowercase, bool includeUppercase, bool includeNumeric, bool includeSpecial, bool includeSpaces, int lengthOfPassword)
        {
            const int MAXIMUM_IDENTICAL_CONSECUTIVE_CHARS = 2;
            const string LOWERCASE_CHARACTERS = "abcdefghijklmnopqrstuvwxyz";
            const string UPPERCASE_CHARACTERS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string NUMERIC_CHARACTERS = "0123456789";
            const string SPECIAL_CHARACTERS = @"!#$%&*@\";

            string characterSet = "";

            if (includeLowercase)
            {
                characterSet += LOWERCASE_CHARACTERS;
            }

            if (includeUppercase)
            {
                characterSet += UPPERCASE_CHARACTERS;
            }

            if (includeNumeric)
            {
                characterSet += NUMERIC_CHARACTERS;
            }

            if (includeSpecial)
            {
                characterSet += SPECIAL_CHARACTERS;
            }

        
            char[] password = new char[lengthOfPassword];
            int characterSetLength = characterSet.Length;

            System.Random random = new System.Random();
            for (int characterPosition = 0; characterPosition < lengthOfPassword; characterPosition++)
            {
                password[characterPosition] = characterSet[random.Next(characterSetLength - 1)];

                bool moreThanTwoIdenticalInARow =
                    characterPosition > MAXIMUM_IDENTICAL_CONSECUTIVE_CHARS
                    && password[characterPosition] == password[characterPosition - 1]
                    && password[characterPosition - 1] == password[characterPosition - 2];

                if (moreThanTwoIdenticalInARow)
                {
                    characterPosition--;
                }
            }

            return string.Join(null, password);
        }

   
        /// Oluşturulan parolanın geçerli olup olmadığını kontrol eder
        public static bool PasswordIsValid(bool includeLowercase, bool includeUppercase, bool includeNumeric, bool includeSpecial, bool includeSpaces, string password)
        {
            const string REGEX_LOWERCASE = @"[a-z]"; 
            const string REGEX_UPPERCASE = @"[A-Z]";
            const string REGEX_NUMERIC = @"[\d]";
            const string REGEX_SPECIAL = @"([!#$%&*@\\])+";

            bool lowerCaseIsValid = !includeLowercase || (includeLowercase && Regex.IsMatch(password, REGEX_LOWERCASE));
            bool upperCaseIsValid = !includeUppercase || (includeUppercase && Regex.IsMatch(password, REGEX_UPPERCASE));
            bool numericIsValid = !includeNumeric || (includeNumeric && Regex.IsMatch(password, REGEX_NUMERIC));
            bool symbolsAreValid = !includeSpecial || (includeSpecial && Regex.IsMatch(password, REGEX_SPECIAL));

            return lowerCaseIsValid && upperCaseIsValid && numericIsValid && symbolsAreValid;
        }
    }
}