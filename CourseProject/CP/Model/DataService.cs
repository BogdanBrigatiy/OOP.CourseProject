using CP.Core;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace CP.Model
{
    //провайдер даних
    public class DataService : IDataService
    {
        //екзмепляр файлового менеджера для роботи з файлами
        FileManager _fileManager = new FileManager();
        //імпорт списку транспорту за допомогою делегату дії, який дозволяє повернути викликаючому коду тип помилки
        public void GetTrasportList(Action<List<PublicTransport>, Exception> callback)
        {
            var transportList = new List<PublicTransport>();
            callback(transportList, null);
        }
        //метод для імпорту списку транспорту
        public List<PublicTransport> GetTrasportListNoCallback()
        {
            var transportList = JsonHelper.Deserealize<List<PublicTransport>>(_fileManager.ReadFromFile(Constants.DefaultFilePath, Encoding.UTF8));
            return transportList;
        }
        //експорт списку
        public bool ExportTransportList(List<PublicTransport> exportable)
        {
            SaveFileDialog _sfd = new SaveFileDialog();
            _sfd.FileName = Constants.DefaultFilePath;
            try
            {
                if ((bool)_sfd.ShowDialog())
                {
                    return _fileManager.WriteToFile(JsonHelper.Serialize(exportable), _sfd.FileName, Encoding.UTF8);
                }
            }
            catch (Exception ex) //перехоплення виключних ситуацій
            {
                MessageBox.Show("An error occured!\r\nAdditional info:\r\n" + ex.Message, Constants.DefaultErrorHeader);
            }
            return false;
        }
        //імпорт
        public List<PublicTransport> ImportTransportList()
        {
            OpenFileDialog _ofd = new OpenFileDialog();
            _ofd.FileName = Constants.DefaultFilePath;

            if ((bool)_ofd.ShowDialog())
            {
                try
                {
                    return JsonHelper.Deserealize<List<PublicTransport>>(_fileManager.ReadFromFile(_ofd.FileName, Encoding.UTF8));
                }
                catch (Exception ex)//перехоплення виключниз ситуацій
                {
                    MessageBox.Show("An error occured!\r\nAdditional info:\r\n" + ex.Message, Constants.DefaultErrorHeader);
                }
            }

            return new List<PublicTransport>();
        }
        //експорт одиничного екземпляру в файл
        public bool ExportSingle(PublicTransport t)
        {
            var flag = true;

            SaveFileDialog _sfd = new SaveFileDialog();
            _sfd.FileName = "myExportedFile.txt";
            try
            {
                if ((bool)_sfd.ShowDialog()) { return t.SaveToFile(_sfd.FileName); }
            }
            catch (Exception ex)//перехоплення виключниз ситуацій
            {
                MessageBox.Show("Exportation error! \r\n Additional informational\r\n" + ex.Message, "An error occured!");
                flag = true;
            }

            return flag;//t.SaveToFile();
        }
        //імпорт одиничного екземпляру з файлу
        public PublicTransport ImportSingle(PublicTransport t)
        {
            OpenFileDialog _ofd = new OpenFileDialog();

            try
            {
                if ((bool)_ofd.ShowDialog())
                {
                    if (t==null) { t = new PublicTransport(); }
                    if (!t.LoadFromFile(_ofd.FileName)) return t;
                }
            }
            catch (Exception ex) //перехоплення виключниз ситуацій
            {
                MessageBox.Show("Data was not imported! \r\n" + ex.Message, "An error occured!");
            }
            return t;
        }
    }
}