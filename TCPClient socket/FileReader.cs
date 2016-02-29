using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Web.Script.Serialization;
using Newtonsoft.Json;


namespace TCPClient_socket
{
    class FileReader
    {
        public string Reader(string filepath)
        {
            string info = File.ReadAllText(filepath);
            return info;
        }
        public List<PersonInfo> JsonFileReader(string filepath)
        {

            JavaScriptSerializer ser = new JavaScriptSerializer();
            string readJson = File.ReadAllText(filepath);
            List<PersonInfo> myList = JsonConvert.DeserializeObject<List<PersonInfo>>(readJson);
            if (myList == null)
                myList = new List<PersonInfo>();
            return myList;
        }
    }
}
