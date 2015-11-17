namespace ChatAppIronMq
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading;
    using IronMQ;
    using IronMQ.Data;

    public class Startup
    {
        static void Main(string[] args)
        {
            var myIp = GetInternalIP();
            if(myIp == "No IP")
            {
                myIp = GetInternalIP();
            }

            Client client = new Client(
                "5648e1b79195a800070000a0",
                "H5thSqUOWRX1KVID3Yc3");
            var queue = client.Queue("SimpleChat");
            Console.WriteLine("Enter messages to be sent to the IronMQ server:");
            while (true)
            {
                Message msg = queue.Get();
                if (msg != null)
                {
                    Console.WriteLine(msg.Body);
                    //Thread.Sleep(100);
                    //queue.DeleteMessage(msg);
                }

                Thread.Sleep(1000);
                while (Console.KeyAvailable)
                {
                    string message = Console.ReadLine();
                    queue.Push(myIp + " : " + message);
                    Console.WriteLine("Message sent to the IronMQ server.");
                }
            }
        }

        private static string GetExternalIp()
        {
            try
            {
                WebRequest myRequest = WebRequest.Create("http://network-tools.com");
                using (WebResponse res = myRequest.GetResponse())
                {
                    using (Stream s = res.GetResponseStream())
                    using (StreamReader sr = new StreamReader(s, Encoding.UTF8))
                    {
                        string html = sr.ReadToEnd();
                        Regex regex = new Regex(@"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b");
                        string ipString = regex.Match(html).Value;
                        return ipString;
                    }
                }
            }
            catch (Exception ex)
            {
                return "No IP";
            }
        }

        private static string GetInternalIP()
        {
            var hostEntry = Dns.GetHostEntry(Dns.GetHostName());
            var ip = (
                      from addr in hostEntry.AddressList
                      where addr.AddressFamily.ToString() == "InterNetwork"
                      select addr.ToString()).FirstOrDefault();
            return ip;
        }
    }
}
