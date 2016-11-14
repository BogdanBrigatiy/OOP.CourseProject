using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CP.Model
{
    public class FileManager
    {
        private readonly Encoding _defaultEncoding = Encoding.GetEncoding(1251);
        public bool WriteToFile(string text, string filepath, Encoding encoding)
        {
            bool flag = true;
            try
            {
                File.WriteAllText(filepath, text);
            }
            catch(UnauthorizedAccessException ex)
            {
                MessageBox.Show(ex.Message, "Access denied!");
                flag = false;
            }
            catch(Exception ex)
            {
                flag = false;
                MessageBox.Show(ex.Message, "Some error occured!");
            }
            return flag;            
        }
        public bool WriteToFile(string text, string filepath)
        {
            return WriteToFile(text, filepath, _defaultEncoding);
        }
        public string ReadFromFile(string filepath, Encoding encoding)
        {
            string content = "";

            try
            {
                content = File.ReadAllText(filepath, encoding);
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show(ex.Message, "Access denied!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Some error occured!");
            }
            return content;
        }
        public string ReadFromFile(string filepath)
        {
            return ReadFromFile(filepath, _defaultEncoding);
        }
        public bool FileExists(string filepath)
        {
            return File.Exists(filepath);
        }
    }
}
