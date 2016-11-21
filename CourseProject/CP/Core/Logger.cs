using System;
using System.IO;
using System.Text;

namespace CP.Core
{
    //клас для запису лог-файлу
    public class Logger
    {
        const string DEFAULT_LOGFILE_PATH = "D:\\CourseProjectLog.txt";

        private static Logger instance;

        private Logger()
        {

        }

        public static Logger getInstance()
        {
            if (instance == null)
                instance = new Logger();
            return instance;
        }
        StreamWriter _wr;
        public void Write(string log)
        {
            _wr.WriteLine(log);
        }
        public void StartLog(string filepath = DEFAULT_LOGFILE_PATH, bool appendFlag = true)
        {
            if (!File.Exists(filepath))
                appendFlag = false;

            _wr = new StreamWriter(filepath, appendFlag, Encoding.UTF8);
            _wr.WriteLine("|----------------------------------------------------------------------|");
            _wr.WriteLine("\t<!>START of log<!>");
            _wr.WriteLine("\tStarted at: " + DateTime.Now.ToShortDateString() + "--" + DateTime.Now.ToLongTimeString());
            _wr.WriteLine("|----------------------------------------------------------------------|");
        }
        public void ResetLog(string filepath = DEFAULT_LOGFILE_PATH)
        {
            StartLog(filepath, false);
        }
        public void EndLog()
        {
            _wr.WriteLine("|----------------------------------------------------------------------|");
            _wr.WriteLine("\t<!>End of log<!>");
            _wr.WriteLine("\tEnded at: " + DateTime.Now.ToShortDateString() + "--" + DateTime.Now.ToLongTimeString());
            _wr.WriteLine("|----------------------------------------------------------------------|");
            _wr.Close();
        }
        ~Logger()
        {
            _wr.Dispose();
        }
    }
}
