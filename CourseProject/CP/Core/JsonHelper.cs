using Newtonsoft.Json;
using System;
using System.Windows;

namespace CP.Core
{
    public class JsonHelper
    {
        public static string Serialize<T>(T obj2conv)
        {
            string serializedObjectString = string.Empty;

            try
            {
                serializedObjectString = JsonConvert.SerializeObject(obj2conv, Formatting.Indented);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured!\r\nAdditional information:\r\n" + ex.Message, Constants.DefaultErrorHeader);
                serializedObjectString = JsonConvert.SerializeObject(null, Formatting.Indented);
            }

            return serializedObjectString;
        }
        public static T Deserealize<T>(string jsonString)
        {
            T deSerializedObjectString = default(T);// = string.Empty;

            try
            {
                deSerializedObjectString = JsonConvert.DeserializeObject<T>(jsonString);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured!\r\nAdditional information:\r\n" + ex.Message, Constants.DefaultErrorHeader);
            }

            return deSerializedObjectString;
        }
    }
}
