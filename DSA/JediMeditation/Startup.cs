namespace JediMeditation
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Startup
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var jedis = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var knight = new Queue<string>();
            var padawan = new Queue<string>();

            var sb = new StringBuilder();

            foreach (var jedi in jedis)
            {
                switch (jedi[0])
                {
                    case 'm':
                    case 'M':
                        sb.AppendFormat(jedi + " ");
                        break;
                    case 'k':
                    case 'K':
                        knight.Enqueue(jedi);
                        break;
                    case 'p':
                    case 'P':
                        padawan.Enqueue(jedi);
                        break;
                }
            }

            sb.AppendFormat(string.Join(" ", knight));
            sb.Append(" ");
            sb.AppendFormat(string.Join(" ", padawan));
            Console.Write(sb);
        }
    }
}
