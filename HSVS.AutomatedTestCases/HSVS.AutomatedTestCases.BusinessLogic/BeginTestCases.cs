using HSVS.AutomatedTestCases.Common;
using HSVS.AutomatedTestCases.Dao;
using HSVS.AutomatedTestCases.DataGeneration;
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
        DataGenerator _objDataGen;



        public BeginTestCases()
        {
            _logger = new LogFileHelper();
            _objDataGen = new DataGenerator();
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
            myQuery = "truncate table " + tableName;
            DataAccessLayer objDAL = new DataAccessLayer();
            objDAL.GenericExecution_Destination(myQuery);
        }

        public void InsertDatatoLineItem()
        {

            List<public_lineitem> lstLineItem = _objDataGen.GenerateLineItem();

            BusinessLogicLayer objBusiness = new BusinessLogicLayer();
            DataTable dt = objBusiness.CreateDataTable(lstLineItem);
            //INSERT 
            objBusiness.InsertDatatoTable("public.lineitem", dt);

        }
        public DataTable GetActivePatients_Assert(int hid, string rundate, string interval)
        {
            List<public_lineitem> lstLineItem = _objDataGen.GenerateLineItem();
            BusinessLogicLayer objBusiness = new BusinessLogicLayer();
            DataTable dt = objBusiness.CreateDataTable(lstLineItem);
            return dt;
        }



        public DataTable GetActivePatients(int hid, string rundate, string interval)
        {
            string myQuery = "";
            myQuery = "select * from campaign_targeting.get_active_patients(" + hid + ",'" + interval + "','" + rundate + "')";
            DataAccessLayer objDAL = new DataAccessLayer();
            DataTable dt = objDAL.GenericExecution_Destination(myQuery);
            return dt;
        }
        public List<public_lineitem> GetActivePatientsConvert(int hid, string rundate, string interval)
        {
            List<public_lineitem> lst = new List<public_lineitem>();
            DataTable dtResult = GetActivePatients(hid, rundate, interval);
            for (var i = 0; i < dtResult.Rows.Count; i++)
            {
                public_lineitem pb = new public_lineitem();
                pb.client_id = Convert.ToInt32(dtResult.Rows[i]["client_id"]);
                pb.patient_id = Convert.ToInt32(dtResult.Rows[i]["patient_id"]);
                pb.hid = Convert.ToInt32(dtResult.Rows[i]["hid"]);
                lst.Add(pb);
            }
            return lst;
        }

        public bool GetDifferentRecords(DataTable FirstDataTable, DataTable SecondDataTable)
        {

            //Create Empty Table 
            DataTable ResultDataTable = new DataTable("ResultDataTable");

            //use a Dataset to make use of a DataRelation object 
            using (DataSet ds = new DataSet())
            {

                //Add tables 
                ds.Tables.AddRange(new DataTable[] { FirstDataTable.Copy(), SecondDataTable.Copy() });

                //Get Columns for DataRelation 
                DataColumn[] firstColumns = new DataColumn[ds.Tables[0].Columns.Count];
                for (int i = 0; i < firstColumns.Length; i++)
                {
                    firstColumns[i] = ds.Tables[0].Columns[i];
                }

                DataColumn[] secondColumns = new DataColumn[ds.Tables[1].Columns.Count];
                for (int i = 0; i < secondColumns.Length; i++)
                {
                    secondColumns[i] = ds.Tables[1].Columns[i];
                }

                //Create DataRelation 
                DataRelation r1 = new DataRelation(string.Empty, firstColumns, secondColumns, false);
                ds.Relations.Add(r1);

                DataRelation r2 = new DataRelation(string.Empty, secondColumns, firstColumns, false);
                ds.Relations.Add(r2);

                //Create columns for return table 
                for (int i = 0; i < FirstDataTable.Columns.Count; i++)
                {
                    ResultDataTable.Columns.Add(FirstDataTable.Columns[i].ColumnName, FirstDataTable.Columns[i].DataType);
                }

                //If FirstDataTable Row not in SecondDataTable, Add to ResultDataTable. 
                ResultDataTable.BeginLoadData();
                foreach (DataRow parentrow in ds.Tables[0].Rows)
                {
                    DataRow[] childrows = parentrow.GetChildRows(r1);
                    if (childrows == null || childrows.Length == 0)
                        ResultDataTable.LoadDataRow(parentrow.ItemArray, true);
                }

                //If SecondDataTable Row not in FirstDataTable, Add to ResultDataTable. 
                foreach (DataRow parentrow in ds.Tables[1].Rows)
                {
                    DataRow[] childrows = parentrow.GetChildRows(r2);
                    if (childrows == null || childrows.Length == 0)
                        ResultDataTable.LoadDataRow(parentrow.ItemArray, true);
                }
                ResultDataTable.EndLoadData();
            }
            if (ResultDataTable.Rows.Count == 0)
            {
                return true;

            }
            else
            {
                return false;
            }
            //return ResultDataTable;
        }

        #region EMAIL
        public int Patient_Species_Check(int hid, long patientid, string speciesIds)
        {
            int retVal = 0;
            string myQuery = "";
            myQuery = "select * from campaign_targeting.patient_species_check(" + hid + "," + patientid + ",'" + speciesIds + "')";
            DataAccessLayer objDAL = new DataAccessLayer();
            DataTable dt = objDAL.GenericExecution_Source(myQuery);
            if (dt != null && dt.Rows.Count > 0)
            {

                return Convert.ToInt32(dt.Rows[0][0]);

            }
            return retVal;
        }

        public int Patient_Age_Criteria_Check(int hid, long patientid, string startInterval, string endInterval)
        {
            int retVal = 0;
            string myQuery = "";
            myQuery = "select * from campaign_targeting.patient_age_criteria_check(" + hid + ","+ patientid + ",'"+ startInterval + "','"+ endInterval + "')";
            DataAccessLayer objDAL = new DataAccessLayer();
            DataTable dt = objDAL.GenericExecution_Source(myQuery);
            if (dt != null && dt.Rows.Count > 0)
            {

                return Convert.ToInt32(dt.Rows[0][0]);

            }
            return retVal;
        }


        public int Patient_Species_Breed_Check(int hid, long patientid, string speciesIds, string breedIds)
        {
            int retVal = 0;
            string myQuery = "";
            myQuery = "select * from campaign_targeting.species_breed_check(" + hid + "," + patientid + ",'" + speciesIds + "','" + breedIds + "')";
            DataAccessLayer objDAL = new DataAccessLayer();
            DataTable dt = objDAL.GenericExecution_Source(myQuery);
            if (dt != null && dt.Rows.Count > 0)
            {

                return Convert.ToInt32(dt.Rows[0][0]);

            }
            return retVal;
        }

        public int Patient_Last_Visit_Check(int hid, long patientid, string lastvisit, string lastvisitFrom, string lastvisitTo)
        {
            BusinessLogicLayer bll = new BusinessLogicLayer();
            int retVal = 0;
            string myQuery = "";
            myQuery = "select * from email.get_patient_by_last_visit(" + hid + "," + patientid + "," + bll.ReturnNullIfEmpty(lastvisit) + "," + bll.ReturnNullIfEmpty(lastvisitFrom) + "," + bll.ReturnNullIfEmpty(lastvisitTo) + ", false)";
            DataAccessLayer objDAL = new DataAccessLayer();
            DataTable dt = objDAL.GenericExecution_Source(myQuery);
            if (dt != null && dt.Rows.Count > 0)
            {

                return Convert.ToInt32(dt.Rows[0][0]);

            }
            return retVal;
        }
        #endregion


    }
}
