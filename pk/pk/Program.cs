using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets; 
using System.Net;
using System.Threading;

namespace pk
{
    internal class Program
    {
        class Chat
        {
            private UdpClient udpclient;
            private IPAddress multicastaddress;
            private IPEndPoint remoteep;

            public Chat()
            {                
                multicastaddress = IPAddress.Parse("239.0.0.222"); 
                udpclient = new UdpClient();
                udpclient.JoinMulticastGroup(multicastaddress);
                remoteep = new IPEndPoint(multicastaddress, 2222);
            }
            public void SendMessage(string data)
            {
                Byte[] buffer = Encoding.UTF8.GetBytes(data);
                udpclient.Send(buffer, buffer.Length, remoteep);
            }

            public void Listen()
            {
                UdpClient client = new UdpClient();
                client.ExclusiveAddressUse = false;
                IPEndPoint localEp = new IPEndPoint(IPAddress.Any, 2222);
                client.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                client.ExclusiveAddressUse = false;
                client.Client.Bind(localEp);
                client.JoinMulticastGroup(multicastaddress);
                Console.WriteLine();
                string formatted_data;
                while (true)
                {
                    Byte[] data = client.Receive(ref localEp);
                    formatted_data = Encoding.UTF8.GetString(data);
                    Console.WriteLine(formatted_data);                   
                }                
            }

            static void Main(string[] args)
            {
                Chat chat = new Chat();
                Thread ListenThread = new Thread(new ThreadStart(chat.Listen));
                ListenThread.Start();
                string data = "";
                Console.WriteLine("Start connection.");
                do {                                                       
                    Console.Write("\nInput message:");
                    data = Console.ReadLine();
                    chat.SendMessage(data);                    
                }
                while (data != "quit");                
                ListenThread.Abort();
                Console.WriteLine("Stop connection.");
            }

        }
    }
}
