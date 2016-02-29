using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using ServerData;

namespace TCPServerSocket
{
    class ClientData
    {
         
        public Socket ClientSocket;
        public Thread clientThread;
        public string id;
        public ClientData()
        {
            id = Guid.NewGuid().ToString();
            clientThread = new Thread(ServerSocket.DataIn);
            clientThread.Start(ClientSocket);
        }
        public ClientData(Socket clientSocket)
        {
            ClientSocket = clientSocket;
            id = Guid.NewGuid().ToString();
            clientThread = new Thread(ServerSocket.DataIn);
            clientThread.Start(ClientSocket);
        }
        public void SendRegistrationPacket()
        {
            Packet packet = new Packet(PacketType.Registration, "server");
            packet.GeneralData.Add(id);
            ClientSocket.Send(packet.ToBytes());

        }
    }

}
