using Newtonsoft.Json;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UDPConsole{

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

                // conversion from byte array to a list of strings
                // Json for serialization of list of strings
                string receivedJson = Encoding.ASCII.GetString(receivedbytes);
                List<string>? deserializedList = JsonConvert.DeserializeObject<List<string>>(receivedJson);

                string data = "";
                if (deserializedList.ElementAt(0) != null)
                {
                    data = deserializedList.ElementAt(0);
                } 
                Console.WriteLine("data received: " + data);

            }
            catch (Exception e)
            {
                
                Console.WriteLine(e.ToString());
            }
            listener.Close();
        }
    }
}