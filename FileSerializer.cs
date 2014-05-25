using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Permissions;
using System.IO;

namespace SoundCycle
{
    public class FileSerializer<T>
        where T : class, ISerializable
    {
        public FileSerializer()
        {
        }

        public void SerializeObject(string filename, T objectToSerialize)
        {
            using(Stream stream = File.Open(filename, FileMode.Create)) {

                BinaryFormatter binFormatter = new BinaryFormatter();
                binFormatter.Serialize(stream, objectToSerialize);

                stream.Close();
            }
        }

        public T DeSerializeObject(string filename)
        {
            T objectToSerialize = null;
            using(Stream stream = File.Open(filename, FileMode.Open)) 
            {
                BinaryFormatter bFormatter = new BinaryFormatter();
                objectToSerialize = (T)bFormatter.Deserialize(stream);
                stream.Close();
            }
            return objectToSerialize;
        }
    }
}
