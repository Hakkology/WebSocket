using System;
using System.Net.Sockets;
using System.Text;

namespace ClientApp
{
    class Program{
        static void Main(string[] args){
            
            // Make the client socket
            // the client tries to connect to a server located at localhost on port 5000
            TcpClient clientSocket = new TcpClient();
            clientSocket.Connect("localhost", 5000);
            Console.WriteLine(clientSocket.Connected);

            // Every TcpClient object has an associated network stream (NetworkStream)
            var stream = clientSocket.GetStream();

            // clientSocket.SendTimeout = 30;
            // clientSocket.ReceiveTimeout = 30;

            var txt = Encoding.ASCII.GetBytes("\ntest");
            stream.Write(txt, 0, txt.Length);

            // This sets up a byte buffer of size 1024 to receive data from the server. 
            // The Receive method waits for the server to send data and fills the buffer with this data. 
            // The method returns the number of bytes read.
            byte[] bt = new byte[1024];
            int bytesread = clientSocket.Client.Receive(bt);
            string result = Encoding.ASCII.GetString(bt, 0, bytesread);

            Console.Write(result);
            Console.ReadLine();
        }
    }
}