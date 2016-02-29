using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace TCPClient_socket
{
    class Program
    {
        
           static void Main()
        {
            //Console.WriteLine("enter Your name:");
            //string name = Console.ReadLine();
            ClientSocket cs = new ClientSocket();
            cs.Start();
            //DisplayOptions dp = new DisplayOptions();

            //dp.DisplayChatFile(@"juan.txt");

            LoginPasswordEntry lp = new LoginPasswordEntry();
            lp.CheckingLoginPassword();
        } 
        
    }
}
