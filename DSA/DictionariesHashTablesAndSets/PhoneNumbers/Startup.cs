namespace PhoneNumbers
{
    using System;
    using System.IO;
    using System.Linq;

    public class Startup
    {
        private static string phonesPath = "../../Files/phones.txt";
        private static string commandsPath = "../../Files/commands.txt";

        public static void Main()
        {
            var allContacts = File.ReadAllLines(phonesPath);
            var commands = File.ReadAllLines(commandsPath);

            var phonebook = new Phonebook();

            foreach (var line in allContacts)
            {
                phonebook.Add(line);
            }

            foreach (var command in commands)
            {
                Console.WriteLine("Current command " + command);
                var checkCommand = command.IndexOf("find", StringComparison.InvariantCultureIgnoreCase);

                if (checkCommand < 0)
                {
                    Console.WriteLine("Invalid command!");
                    continue;
                }

                if (command.IndexOf(", ", StringComparison.InvariantCultureIgnoreCase) < 0)
                {
                    var name = command.Substring(checkCommand + 4).Trim(new[] { '(', ')' });

                    Console.WriteLine(string.Join(Environment.NewLine, phonebook.Find(name)));
                }
                else
                {
                    var nameAndTown = command.Substring(checkCommand + 4).Trim(new[] { '(', ')' }).Split(',').Select(x => x.Trim()).ToList();

                    Console.WriteLine(string.Join(Environment.NewLine, phonebook.Find(nameAndTown[0], nameAndTown[1])));
                }

                Console.WriteLine(new string('-', 50));
            }
        }
    }
}
