using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace DnD5e
{
    class Log
    {
        public Log(string name)
        {
            LogLocation = Path.GetDirectoryName(Application.ExecutablePath) + "\\" + name;
        }
        private string LogLocation;

        public void WriteLog(string line)
        {
            using (StreamWriter LogFile = new StreamWriter(LogLocation, false, Encoding.ASCII))
            {
                LogFile.Write(DateTime.Now + " : " + line + "\r\n");
            }
        }
    }
}
