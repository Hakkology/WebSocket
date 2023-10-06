using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TCPConsole{

    class Program{

        static void Main(string[] args){
            
            // Similar to TCP Conn, listener is created.
            // Firewall should change according to TCP-UDP Client rules.
            UdpClient listener = new UdpClient(5000);
            IPEndPoint EP = new IPEndPoint(IPAddress.Any, 5000);

            try
            {
                // Encoding type should be the same for both cases, i.e UTF-8
                Console.WriteLine("waiting...");
                byte[] receivedbytes = listener.Receive(ref EP);
                Console.WriteLine("received a message");
                string data = System.Text.Encoding.ASCII.GetString(receivedbytes, 0, receivedbytes.length);
                Console.WriteLine("data received: " + data);
            }
            catch (Exception e)
            {
                
                Console.WriteLine(e.ToString());
            }
            listener.close();
        }
    }
}