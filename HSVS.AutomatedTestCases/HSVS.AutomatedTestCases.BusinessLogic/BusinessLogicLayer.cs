using HSVS.AutomatedTestCases.Dao;
using HSVS.AutomatedTestCases.Logger;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        public DataTable GetDatafromQuery(string sql, string tableName)
        {
            DataAccessLayer objDAL = new DataAccessLayer();
            DataTable dt = objDAL.CustomQuery(sql);
            return dt;
        }

        public DataTable GetDatafromQueryandInsert(string sql, string tableName)
        {
            DataAccessLayer objDAL = new DataAccessLayer();
            DataTable dt = objDAL.CustomQuery(sql);
            InsertDatatoTable(tableName, dt);
            return dt;
        }

        public void InsertDatatoTable(string tablename, DataTable dt)
        {
            try
            {

                Console.WriteLine("Inserting to table : " + tablename);
                for (int rowCount = 0; rowCount < dt.Rows.Count; rowCount++)
                {
                    string sql = "insert into " + tablename + " values(";
                    string values = "";
                    for (int columnCount = 0; columnCount < dt.Columns.Count; columnCount++)
                    {
                        string columnvalue = Convert.ToString(dt.Rows[rowCount][columnCount]); ;
                        if (dt.Rows[rowCount][columnCount].GetType().Name == "String" || dt.Rows[rowCount][columnCount].GetType().Name == "DateTime" || dt.Rows[rowCount][columnCount].GetType().Name == "TimeSpan")
                        {

                            if (columnvalue.Contains("'"))
                            {
                                columnvalue = columnvalue.Replace("'", "''");
                            }
                            else if (columnvalue.Contains("\\"))
                            {
                                columnvalue = columnvalue.Replace("\\", "\\\\");
                            }
                            if (columnvalue == "\\")
                            {
                                columnvalue = "E'\\\\'";
                            }
                            else
                            {

                                if (!string.IsNullOrEmpty(columnvalue))
                                {
                                    if (dt.Rows[rowCount][columnCount].GetType().Name == "TimeSpan")
                                    {
                                        //Code for converting TimeSpan to Interval
                                        if (columnvalue.Split('.').Length == 3)
                                        {
                                            var regex = new Regex(Regex.Escape("."));
                                            columnvalue = regex.Replace(columnvalue, "days ", 1);
                                        }
                                    }
                                }
                                columnvalue = "'" + columnvalue + "'";

                            }
                        }
                        else if (dt.Rows[rowCount][columnCount].GetType().Name.ToLower() == ("DBNull").ToLower())
                        {
                            //columnvalue = DBNull.Value;
                            var nullable = DBNull.Value;
                            columnvalue = "null";
                        }
                        values = values + "," + columnvalue;
                    }
                    if (!string.IsNullOrEmpty(values))
                    {
                        values = values.Substring(1, values.Length - 1);
                    }
                    string insertQuery = sql + values + ");";
                    DataAccessLayer objDAL = new DataAccessLayer();
                    objDAL.GenericExecution_Destination(insertQuery);
                }

            }
            catch (Exception ex)
            {
                _logger.WriteToFile("InsertDatatoTable - Exception :" + ex.Message);
            }
        }

        public void CleanData(string tableName)
        {
            DataAccessLayer objDAL = new DataAccessLayer();
            objDAL.CleanTableData_Destination(tableName);
        }
    }
}
