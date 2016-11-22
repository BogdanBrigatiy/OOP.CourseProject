using CP.Core;
using System;
using System.IO;
using System.Text;
using System.Windows;

namespace CP.Model
{
    /*
     * клас для роботи з файлами. Здійснює перевірку існування файлу, запис в файл та читання з файлу
     * перехоплює загальні виключні ситуації та закритий доступ до файлу
     * Використана перегрузка методів для роботи з різними кодуваннями
     */
    public class FileManager
    {
        //кодування файлів, яке використовується за замовчуванням
        private readonly Encoding _defaultEncoding = Encoding.GetEncoding(1251);
        //запис в файл з заданим кодуванням
        public bool WriteToFile(string text, string filepath, Encoding encoding)
        {
            bool flag = true;
            try
            {
                File.WriteAllText(filepath, text);
            }
            catch(UnauthorizedAccessException ex)
            {
                MessageBox.Show(Constants.UnauthorizedAccessMessage + ex.Message, Constants.DefaultErrorHeader);
                flag = false;
            }
            catch(Exception ex)
            {
                flag = false;
                MessageBox.Show(ex.Message, Constants.DefaultErrorHeader);
            }
            return flag;            
        }
        //запис з кодуванням за замовчуванням
        public bool WriteToFile(string text, string filepath)
        {
            return WriteToFile(text, filepath, _defaultEncoding);
        }
        //читання з вказанням кодування
        public string ReadFromFile(string filepath, Encoding encoding)
        {
            string content = "";

            try
            {
                content = File.ReadAllText(filepath, encoding);
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show(Constants.UnauthorizedAccessMessage + ex.Message, Constants.DefaultErrorHeader);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Constants.DefaultErrorHeader);
            }
            return content;
        }
        //читання з кодуваннямза замовчуванням
        public string ReadFromFile(string filepath)
        {
            return ReadFromFile(filepath, _defaultEncoding);
        }
        //перевірка на існування
        public bool FileExists(string filepath)
        {
            return File.Exists(filepath);
        }
    }
}
