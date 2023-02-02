using System.Text;

namespace PasswordGenerator
{
    internal class Program
    {
        //Possible characters and numbers that we can put in a password

        public const string capitalCharacters = "QWERTYUIOPASDFGHJKLZXCVBNM";
        public const string smallCharacters = "qwertyuiopasdfghjklzxcvbnm";
        public const string numbers = "0123456789";
        public const string specialCharacters = "!@#$%^&*()-_=+<,>.";

        //Putting questions in string values

        public string lowerCharCase = "Do you want include lowercase characters? ";
        public string upperCharCase = "Do you want include uppercase characters? ";
        public string numberCase = "Dou you want include numbers? ";
        public string specialCharCase = "How abaout special characters? ";
        public static string? allPasword;

        static public void Generator(string question)
        {
            bool i = true;

            // asking questions and getting answer with while
            while (i)
            {
                Console.WriteLine(question);
                string answer = Console.ReadLine();
                
                //according to answer, putting characters into password
                //i use if for yes or no, switch case for questions

                if (answer != null && (answer.toUpper() == "Y" || answer.ToUpper() == "YES"))
                {
                    switch (answer)
                    {
                        case lowerCharCase:
                            allPasword = string.Concat(allPasword, smallCharacters);
                            break;
                        case upperCharCase:
                            allPasword = string.Concat(allPasword, capitalCharacters);
                            break;
                        case numberCase:
                            allPasword = string.Concat(allPasword, numbers);
                            break;
                        case specialCharCase:
                            allPasword = string.Concat(allPasword, specialCharacters);
                            break;
                        default:
                            Console.WriteLine("Please select at least one. ");
                            break;
                    }
                    break;
                }
                else if (answer != null && (answer.ToUpper() == "NO" || answer.ToUpper() == "N"))
                {
                    break;
                }
                else
                {
                    Console.Write("You can say only yes or no \n");
                }
            }

        }

        static void Main(string[] args)
        {
            int passwordLength = 0;
            bool valid = false;

            Generator(lowerCharCase);
            Generator(upperCharCase);
            Generator(numberCase);
            Generator(SpeacialCharCase);

            while (valid == false)
            {
                Console.WriteLine("Enter the password length:");
                string answer = Console.ReadLine();

                if (int.TryParse(answer, out passwordLength))
                {
                    passwordLength = int.Parse(answer);

                    if (passwordLength < 1)
                    {
                        Console.WriteLine("Please enter a value greater than zero ");
                    }
                    else
                    {
                        valid = true;
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a number ");
                }
            }
            StringBuilder res = new StringBuilder();
            Random rndm = new Random();
            while (0 < passwordLength--)
            {
                res.Append(allPasword[rndm.Next(allPasword.Length)]);
            }
            Console.WriteLine("Your password is: " + res.ToString());
        }
    }
}