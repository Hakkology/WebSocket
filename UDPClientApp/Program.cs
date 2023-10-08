using System.Net;
using Newtonsoft.Json;
using System.Net.Sockets;
using System.Text;

namespace UDPClient{

    class Program{

        static void Main(string[] args){
            // new scoket object is created
            // InterNetwork specifies that this is an IPv4 socket
            // SocketType.Dgram means that this socket is a datagram (UDP) socket
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            // IP Addresses to send and the endpoint, which is the local machine in this case.
            IPAddress sendto = IPAddress.Parse("127.0.0.1");
            IPEndPoint endPoint = new IPEndPoint(sendto,5000);

            // Creation of a sample list
            List<string> strLst = new List<string>
            {
                "test1",
                "test2",
                "test3"
            };

            // Serializing the data using JSON Convert
            string serializedList = JsonConvert.SerializeObject(strLst);

            // Turns serializedList into a byte array for transmission over the network
            // Sends this to the endpoint, which is defined above to local machine as 127.0.0.1 and port 5000.
            socket.SendTo(Encoding.ASCII.GetBytes(serializedList), endPoint);
        }

    }
}