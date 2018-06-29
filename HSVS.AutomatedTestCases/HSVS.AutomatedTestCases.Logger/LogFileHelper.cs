using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;

namespace HSVS.AutomatedTestCases.Logger
{
    public class LogFileHelper
    {
        private static readonly object _syncObject = new object();
        public void WriteToFile(string message, bool isdeletelog = false)
        {
            string path= Convert.ToString(ConfigurationManager.AppSettings["LogFilePath"]);
            string runDate = DateTime.Now.ToString("yyyy_MM_dd");
            string dailyRunPath = path + @"\" + runDate;
            Directory.CreateDirectory(dailyRunPath);
            string fileName = Convert.ToString(ConfigurationManager.AppSettings["LogFileName"]) + runDate + ".txt";

            string logFileFullPath = dailyRunPath + @"\" + fileName;

            //Delete log if already exists
            if (isdeletelog == true && File.Exists(logFileFullPath))
            {
                File.Delete(logFileFullPath);
            }

            lock (_syncObject)
            {

                using (StreamWriter writer = new StreamWriter(logFileFullPath, true))
                {
                    if (message.Equals(Environment.NewLine))
                    {
                        writer.WriteLine(message);
                        Console.WriteLine(message);
                    }
                    else
                    {
                        Console.WriteLine(message);
                        Console.WriteLine("");
                        writer.WriteLine(message + "    ,Time:" + DateTime.Now);
                        writer.WriteLine("");//EMPTY LINE
                    }
                }
            }
        }
    }
}
