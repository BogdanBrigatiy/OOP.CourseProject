using CP.Core;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace CP.Model
{
    public class DataService : IDataService
    {
        FileManager _fileManager = new FileManager();
        public void GetTrasportList(Action<List<PublicTransport>, Exception> callback)
        {
            // Use this to connect to the actual data service

            var transportList = new List<PublicTransport>();
            callback(transportList, null);
        }
        public List<PublicTransport> GetTrasportListNoCallback()
        {
            //var fm = new FileManager();
            var transportList = JsonHelper.Deserealize<List<PublicTransport>>(_fileManager.ReadFromFile(Constants.DefaultFilePath, Encoding.UTF8));
            return transportList;
        }
        public bool ExportTransportList(List<PublicTransport> exportable)
        {
            SaveFileDialog _sfd = new SaveFileDialog();
            _sfd.FileName = Constants.DefaultFilePath;

            if ((bool)_sfd.ShowDialog())
            {
                var fm = new FileManager();
                return fm.WriteToFile(JsonHelper.Serialize(exportable), _sfd.FileName, Encoding.UTF8);
            }
            return false;
        }
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
                catch (Exception ex)
                {
                    MessageBox.Show("An error occured!\r\nAdditional info:\r\n" + ex.Message, Constants.DefaultErrorHeader);
                }
            }

            return new List<PublicTransport>();//JsonHelper.Deserealize<List<PublicTransport>>(_fileManager.ReadFromFile(Constants.DefaultFilePath, Encoding.UTF8));

        }
        public bool ExportSingle(PublicTransport t)
        {
            var flag = true;

            SaveFileDialog _sfd = new SaveFileDialog();
            _sfd.FileName = "myExportedFile.txt";
            try
            {
                if ((bool)_sfd.ShowDialog()) { return t.SaveToFile(_sfd.FileName); }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "An error occured!");
                flag = true;
            }

            return flag;//t.SaveToFile();
        }
        public PublicTransport ImportSingle(PublicTransport t)
        {
            //string filepath = "";

            OpenFileDialog _ofd = new OpenFileDialog();

            try
            {
                if ((bool)_ofd.ShowDialog())
                {
                    if (t==null) { t = new PublicTransport(); }
                    if (!t.LoadFromFile(_ofd.FileName)) return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data was not imported! \r\n" + ex.Message, "An error occured!");
            }
            return t;
        }
    }
}