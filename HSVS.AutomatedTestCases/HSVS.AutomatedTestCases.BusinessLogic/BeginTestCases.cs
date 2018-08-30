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
    public class BeginTestCases
    {
        readonly LogFileHelper _logger;
        public BeginTestCases()
        {
            _logger = new LogFileHelper();
        }
        public void InsertSampleData(int id, string name, string mobile)
        {
            TruncateTable_Destination("mysample");
            string myQuery = "";
            myQuery = "insert into mysample values(" + id + ", '" + name + "', '" + mobile + "')";
            DataAccessLayer objDAL = new DataAccessLayer();
            objDAL.GenericExecution_Destination(myQuery);
        }
        public int GetSampleTableDataCount()
        {
            int retVal = 0;
            string myQuery = "";
            myQuery = "select * from GetSampleTableDataCount()";
            DataAccessLayer objDAL = new DataAccessLayer();
            DataTable dt = objDAL.GenericExecution_Destination(myQuery);
            if (dt != null && dt.Rows.Count > 0)
            {

                return Convert.ToInt32(dt.Rows[0][0]);

            }
            return retVal;
        }
        public void TruncateTable_Destination(string tableName)
        {
            string myQuery = "";
            myQuery = "truncate table "+tableName;
            DataAccessLayer objDAL = new DataAccessLayer();
            objDAL.GenericExecution_Destination(myQuery);
        }
    }
}
