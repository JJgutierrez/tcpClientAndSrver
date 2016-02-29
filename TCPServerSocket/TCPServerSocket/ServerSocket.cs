using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using ServerData;

namespace TCPServerSocket
{
    class ServerSocket
    {
        private static Socket listenerSocket;
        private static IPAddress ip;
        private  Thread listenThread;
        static List<ClientData> clients;
        private string ServerRightNow = DateTime.Now.ToString("f");
        private static int port = 8085;

        public static string GetIp()
        {
            Console.Title= "SERVER ....";
            string DefaultIpNumber = "10.2.20.22";
            IPAddress[] ips = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress i in ips)
            {
                if (i.AddressFamily == AddressFamily.InterNetwork)
                    return i.ToString();
            }
            return DefaultIpNumber;
        }
        public void Start()
        {
            Console.CursorVisible = false;
            Console.WriteLine("starting server ....." + GetIp()  + "\n"+ ServerRightNow);
            listenerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            clients = new List<ClientData>();
            IPEndPoint ip = new IPEndPoint(IPAddress.Parse(GetIp()), port);
            listenerSocket.Bind(ip);
            listenThread = new Thread(ListenThread);
            listenThread.Start();
        }
        public void ListenThread()
        {
            while (true)
            {
                listenerSocket.Listen(0);
                clients.Add(new ClientData(listenerSocket.Accept()));
            }
        }
        public static void DataIn(object cSocket)
        {
            Socket clientsocket = (Socket)cSocket;
            byte[] Buffer;
            int readBytes;
            while (true)
            {
                try {
                    Buffer = new byte[clientsocket.SendBufferSize];
                    readBytes = clientsocket.Receive(Buffer);
                    if (readBytes > 0)
                    {
                        Packet packet = new Packet(Buffer);
                        DataMananger(packet);
                    }
                }
                catch(SocketException)
                {
                    Console.WriteLine(" A client Disconected!");
                    Console.ReadLine();
                    Environment.Exit(0);
                }
             
            }
        }
        static void DataMananger(Packet p)
        {
           
                switch (p.Packettype)
                {
                    case PacketType.Chat:
                   
                        foreach (ClientData c in clients)
                        {
                            string id = c.id;
                            c.ClientSocket.Send(p.ToBytes());
                            Console.WriteLine(id);
                       
                        }
                        break;
                }
            
        }
    }
}

