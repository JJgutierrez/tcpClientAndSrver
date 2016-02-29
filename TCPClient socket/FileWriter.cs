using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace TCPClient_socket
{
    class FileWriter
    {
        public void Writer(string filePath, string clientdata)
        {
            File.AppendAllText(filePath,clientdata+ Environment.NewLine);
        }
        public void JasonWriter(string filepath, List<PersonInfo> datalist)
        {
            string data = JsonConvert.SerializeObject(datalist);
            File.WriteAllText(filepath, data);
            Console.ReadLine();
        }
    }
}
