using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPClient_socket
{
    class DisplayOptions
    {
        public void ChooseUserOption(string name)
        {
            Console.WriteLine("... Press 1 for Chat"
                             +"... Press 2 to display previews chats"
                             +"**********************************");
        }
        public void DisplayChatFile(string filePath)
        {
            FileReader fr = new FileReader();
            Console.WriteLine(fr.Reader(filePath));
        }

        public void EntryUserOptions()
        {
            Console.WriteLine("... Press 1 for Login "
                             +"... Press 2 for Create an acount"
                             +"... Press 3 for Exit."
                             +"...................................");
        }
    }
}
