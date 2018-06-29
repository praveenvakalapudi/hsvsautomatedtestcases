using HSVS.AutomatedTestCases.Dao;
using HSVS.AutomatedTestCases.Logger;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSVS.AutomatedTestCases.BusinessLogic
{
    public class BusinessLogicLayer
    {
        readonly LogFileHelper _logger;
        public BusinessLogicLayer()
        {
            _logger = new LogFileHelper();
        }
        public void CreateFunctionfromFile(string fileName, string fileContent)
        {
            try
            {
                _logger.WriteToFile("BEGIN - Executing file :" + fileName);
                _logger.WriteToFile("BEGIN");
                DataAccessLayer obj = new DataAccessLayer();
                DataTable dt = obj.GenericExecution_Destination(fileContent);
                _logger.WriteToFile("END - Executing file :" + fileName);
            }
            catch (Exception ex)
            {
                _logger.WriteToFile("Exception - Executing file :" + fileName + ", Exception: " + ex.Message);
            }
        }
    }
}
