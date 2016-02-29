using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using ServerData;
using System.IO;

namespace TCPClient_socket
{
    class ClientSocket
    {
        private static string name;
        private static string  id;
        private static int port = 8085;
        private string Input;
        private static Socket socketMaster;
        private static Thread DataThread;
        public static string GetIp()
        {
            string defaultIpNumber = "10.2.20.22";
            IPAddress[] ips = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress i in ips)
            {
                if (i.AddressFamily == AddressFamily.InterNetwork)
                    return i.ToString();
            }
            return defaultIpNumber;
        }


        public void Start()
        {
            Console.WriteLine("Enter your name:  ");
           // Name = name;
            name = Console.ReadLine();
        A: Console.Clear();
            Console.Title = string.Format("{0}'s Chat", name.ToUpper());
            Console.CursorVisible = false;
            socketMaster = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint IpEnd = new IPEndPoint(IPAddress.Parse(GetIp()), port);
            try
            {
                socketMaster.Connect(IpEnd);
            }
            catch
            {
                Console.WriteLine("Unable to connect to host ...");
                Thread.Sleep(1000);
                goto A;
            }
            DataThread = new Thread(DataIn);
            DataThread.Start();
            while (true)
            {
                string time = DateTime.Now.ToString("t");
                Console.Write("{0}::>>", time);
                Input = Console.ReadLine();
                Packet pChat = new Packet(PacketType.Chat, id);
                pChat.GeneralData.Add(name);
                pChat.GeneralData.Add(Input);
                pChat.GeneralData.Add(time);
                try
                {
                    socketMaster.Send(pChat.ToBytes());
                }
                catch(SocketException)
                {
                    Console.WriteLine("Unable to send message");
                }

            }
        }
        public static void DataIn()
        {
            byte[] Buffer;
            int readBytes;
            while(true)
            {
                try {
                    Buffer = new byte[socketMaster.SendBufferSize];
                    readBytes = socketMaster.Receive(Buffer);
                    if (readBytes > 0)
                    {
                        DataManager(new Packet(Buffer));
                    }
                }
                catch(SocketException)
                {
                    Console.WriteLine("The server has disconnected !");
                    Console.ReadLine();

                  

                    Environment.Exit(0);
                   
                }
            }
        }
        static void DataManager(Packet p)
        {
            switch (p.Packettype)
            {
                case PacketType.Registration:
                    id = p.GeneralData[0];
                    break;
                case PacketType.Chat:
                    ConsoleColor color = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    string data = string.Format(p.GeneralData[0] + ":  " + p.GeneralData[1]+"  " + DateTime.Now.ToString("F"));
                    Console.WriteLine(p.GeneralData[0] + ":  " + p.GeneralData[1] );
                    Console.ForegroundColor = color;
                    string filename = string.Format(@"{0}.txt", name);
                    FileWriter fw = new FileWriter();
                    fw.Writer(filename,data);
                    break;
            }
        }
     
    }
}
