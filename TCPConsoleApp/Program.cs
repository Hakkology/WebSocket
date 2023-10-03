using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TCPConsole{

    class TCProgram{

        static void Main(string[] args){

            TcpListener listener = new TcpListener(IPAddress.Any,5000);
            listener.Start();

            var client = listener.AcceptTcpClient();
            NetworkStream networkStream = client.GetStream();
            StreamWriter writer = new StreamWriter(networkStream);
            writer.AutoFlush = true;

            while(true){
                byte [] buffer = new byte[client.ReceiveBufferSize];
                int bytesRead = networkStream.Read(buffer, 0, client.ReceiveBufferSize);

                String datareceived = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                if(bytesRead != 0){
                    Console.WriteLine("Received Request: \n" + datareceived);
                    string response = "Works";
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