using HSVS.AutomatedTestCases.BusinessLogic;
using HSVS.AutomatedTestCases.Logger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HSVS.AutomatedTestCases
{
    class Program
    {
        public static void Main(string[] args)
        {
            LogFileHelper log = new LogFileHelper();
            string message = "Program Initiated";
            log.WriteToFile(message);
            Console.Write("Enter your Option");
            Console.Write("1. Load Functions from Path");
            Console.Write("2. Load Table data");
            var choice = Console.ReadLine();
            switch(choice)
            {
                case "1":
                    LoadScripts();
                    break;
                    
            }

            message = "Program end";
            log.WriteToFile(message);
        }
      
        public static void LoadScripts()
        {
            BusinessLogicLayer objBusiness = new BusinessLogicLayer();
            LogFileHelper logger = new LogFileHelper();
            try
            {
                string path = @"D:\AccionLabs\Help\LocalDB\Functions";
                foreach (string fileName in Directory.GetFiles(path))
                {
                    //GET EACH FILE
                    var fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                    using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
                    {
                        string functionContent = streamReader.ReadToEnd();
                        if (!string.IsNullOrEmpty(functionContent))
                        {
                            //SEND FILENAME AND FILECONTENT FOR EACH FILE
                            objBusiness.CreateFunctionfromFile(fileName, functionContent);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                logger.WriteToFile("Main function exception : "+ex.Message)
            }
        }
    }
}
