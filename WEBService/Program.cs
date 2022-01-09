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
                var NL = "\r\n";
                var client = tcpListener.AcceptTcpClient();
                var stream = client.GetStream();

                byte[] buffer = new byte[1024 * 1024];
                var numberOfBytesReaden =
                    stream.Read(buffer, 0, buffer.Length);

                var requestString =
                    Encoding.UTF8.GetString(buffer, 0, numberOfBytesReaden);

                Console.WriteLine(requestString);

                string html = $"<h3>ESRI REST API {DateTime.Now}</h3>";

                string response = "HTTP/1.1 200 OK" + NL
                    + "Server: slav4o.com " + NL
                    + "Content-Type: text/html; charset=utf-8" + NL
                    + "Content-Length: " + html.Length + NL
                    + NL
                    + html + NL;

                byte[] responseBytes = Encoding.UTF8.GetBytes(response);
                stream.Write(responseBytes);
                Console.WriteLine(new string('=', 70));
            }
        }
    }
}
