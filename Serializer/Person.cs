using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Xml.Serialization;


namespace Serializer
{
    [Serializable()]
    public class Person
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }


        private DateTime CreationDate { get; set; }
        [NonSerialized]
        private int SerialNumber;
        private static int Count = 0;

        public Person() { }

        public Person(string name, string address, string phone)
        {
            Name = name;
            Address = address;
            Phone = phone;

            CreationDate = DateTime.Now;
            SerialNumber = Count;
            Count++;
        }

        public Person(SerializationInfo info, StreamingContext context)
        {
            Name = (string)info.GetValue("Name", typeof(string));
            Address = (string)info.GetValue("Address", typeof(string));
            Phone = (string)info.GetValue("Phone", typeof(string));
            CreationDate = (DateTime)info.GetValue("CreationDate", typeof(DateTime));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", Name);
            info.AddValue("Address", Address);
            info.AddValue("Phone", Phone);
            info.AddValue("CreationDate", CreationDate);
        }

        public void Serialize(string FilePath="Person0.dat")
        {
            FilePath = "Person" + this.SerialNumber + ".dat";
            Stream stream = File.Open(FilePath, FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();

            bf.Serialize(stream, this);
            stream.Close();
        }

        public static Person Deserialize(string FilePath = "Person0.dat")
        {
            Stream stream = File.Open(FilePath, FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();

            Person person = (Person)bf.Deserialize(stream);
            stream.Close();
            return person;
        }

    }
}
