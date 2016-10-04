using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Utility
{
    public static class XmlSerializationHelper
    {
        public static void Serialize(Type type, object objectToSerialize, string filePath)
        {
            XmlSerializer mySerializer = new XmlSerializer(type);

            // To write to a file, create a StreamWriter object.
            using (StreamWriter myWriter = new StreamWriter(filePath))
            {
                mySerializer.Serialize(myWriter, objectToSerialize);
                myWriter.Close();
            }
        }

        public static T Deserialize<T>(string filePath)
        {
            T myObject;

            XmlSerializer mySerializer = new XmlSerializer(typeof(T));
            // To read the file, create a FileStream.
            using (FileStream myFileStream = new FileStream(filePath, FileMode.Open))
            {
                // Call the Deserialize method and cast to the object type.

                try
                {
                    myObject = (T)mySerializer.Deserialize(myFileStream);
                    return myObject;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
