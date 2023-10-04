using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TCPConsole{

    class Program{

        static void Main(string[] args){

            // Add a TCPListener to port 5000, tested through localhost
            TcpListener listener = new TcpListener(IPAddress.Any,5000);
            listener.Start();

            // The program then waits to accept a TCP client. Once a client connects, 
            // the network stream for that client is retrieved, and a stream writer is set up to send data back to the client. 
            // The AutoFlush property ensures that data written using the writer is immediately sent without buffering.
            var client = listener.AcceptTcpClient();
            NetworkStream networkStream = client.GetStream();
            StreamWriter writer = new StreamWriter(networkStream);
            writer.AutoFlush = true;

            while(true){

                // A buffer is set up to receive data. Data is read from the client into the buffer. 
                // That data is then converted from bytes into an ASCII string.
                byte [] buffer = new byte[client.ReceiveBufferSize];
                int bytesRead = networkStream.Read(buffer, 0, client.ReceiveBufferSize);

                string datareceived = Encoding.ASCII.GetString(buffer, 0, bytesRead);

                if(bytesRead != 0){
                    Console.WriteLine("Received Request: \n" + datareceived);
                    string response = "It works.";
                    Console.WriteLine("response is \n" + response);
                    writer.WriteLine(response);
                } else {
                    break;
                }

            }
            Console.ReadKey();
        }
    }
}