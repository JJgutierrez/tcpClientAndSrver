using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace ServerData
{
    
    public enum PacketType
    {
        Registration,
        Chat
    }

    [Serializable]
    public class Packet
    {
        public List<string> GeneralData;
        public int packetInt;
        public bool packetBool;
        public string SenderID;
        public PacketType Packettype;

        public Packet(PacketType pack, string senderId)
        {
            GeneralData = new List<string>();
            SenderID = senderId;
            Packettype = pack;
        }
        public Packet(byte[] packetbytes)
        {
            BinaryFormatter bform = new BinaryFormatter();
            MemoryStream memo = new MemoryStream(packetbytes);
            Packet p = (Packet)bform.Deserialize(memo);
            memo.Close();
            GeneralData = p.GeneralData;
            packetBool = p.packetBool;
            packetInt = p.packetInt;
            SenderID = p.SenderID;
            Packettype = p.Packettype;
        }

        public byte[] ToBytes()
        {
            BinaryFormatter bform = new BinaryFormatter();
            MemoryStream memo = new MemoryStream();
            bform.Serialize(memo, this);
            byte[] databytes = memo.ToArray();
            memo.Close();
            return databytes;
        }
    }
}
