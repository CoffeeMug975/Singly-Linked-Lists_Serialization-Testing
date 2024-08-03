using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using OO2_Assignment3_Group4;

namespace SerializationTests
{
    public static class SerializationHelper
    {
        public static void SerializeUsers(SLL<User> users, string fileName)
        {
            DataContractSerializer serializer = new DataContractSerializer(typeof(SLL<User>));
            using (FileStream stream = File.Create(fileName))
            {
                serializer.WriteObject(stream, users);
            }
        }

        public static SLL<User> DeserializeUsers(string fileName)
        {
            DataContractSerializer serializer = new DataContractSerializer(typeof(SLL<User>));
            using (FileStream stream = File.OpenRead(fileName))
            {
                return (SLL<User>)serializer.ReadObject(stream);
            }
        }
    }
}
