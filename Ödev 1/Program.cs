using System.Text;

namespace PasswordGenerator
{
    public class Program
    {
        
        static int Main(string[] args)
        {
            var passwordGenerator = new PasswordsGenerator();

            passwordGenerator.Greetings();

            passwordGenerator.ReadInputs();

            passwordGenerator.Generate();

            passwordGenerator.WriteLatestGeneratedPassword();

            Console.ReadLine();

            return 0;
        }
    }
}