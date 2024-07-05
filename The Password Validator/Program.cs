namespace The_Password_Validator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the password validator.");
            Console.WriteLine("Must have:\n1. Upper character\n2. Lower character\n3. A digit\n4. More than 6 characters\n5. 12 characters or less");
            Console.WriteLine("Cannot have:\n1. T and &");
            while (true)
            {
                Console.Write("Set a new password: ");

                string password = Console.ReadLine();

                PasswordValidator userPasswordValid = new PasswordValidator(password);

                bool isValid = userPasswordValid.PasswordChecker();

                Console.WriteLine($"It is {IsValid(isValid)}a valid password.");
            }

            string IsValid(bool isValid)
            {
                if (isValid)
                {
                    return "";
                }
                else
                {
                    return "not ";
                }
            }
        }
    }

    class PasswordValidator
    {
        public string _password { get; set; }

        public PasswordValidator(string password)
        {
            _password = password;
        }

        public bool PasswordChecker()
        {
            bool hasUpper = false;
            bool hasLower = false;
            bool hasDigit = false;
            bool illegalCharacters = false;

            foreach (char letter in _password)
            {
                if (char.IsUpper(letter))
                {
                    hasUpper = true;
                }
                else if (char.IsLower(letter))
                {
                    hasLower = true;
                }
                else if (char.IsDigit(letter))
                {
                    hasDigit = true;
                }

                if (letter == 'T')
                {
                    illegalCharacters = true;
                }
                else if (letter == '&')
                {
                    illegalCharacters = true;
                }
            }

            if (_password.Length < 6 || _password.Length > 13)
            {
                return false;
            }
            else if (!hasUpper || !hasLower || !hasDigit)
            {
                return false;
            }
            else if (illegalCharacters)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
