using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WEBService
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var tcpListener = new TcpListener(IPAddress.Any, 80);
            tcpListener.Start();

            while (true)
            {
                const string NL = "\r\n";
                var client = tcpListener.AcceptTcpClient();
                var stream = client.GetStream();


                byte[] buffer = new byte[1024 * 1024];
                var numberOfBytesReaden =
                    stream.Read(buffer, 0, buffer.Length);

                var requestString =
                    Encoding.UTF8.GetString(buffer, 0, numberOfBytesReaden);

                Console.WriteLine(requestString);

                var requestURL = requestString.Substring(0, requestString.IndexOf("HTTP"));

                string response = Controller.MainController(requestURL);

                byte[] responseBytes = Encoding.UTF8.GetBytes(response);
                stream.Write(responseBytes);
                stream.Close();
                Console.WriteLine(new string('=', 70));
            }
        }
    }
}
