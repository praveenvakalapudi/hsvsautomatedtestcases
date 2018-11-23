using HSVS.AutomatedTestCases.Common;
using HSVS.AutomatedTestCases.Common.Targeting;
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
        readonly DataGenerator _objDataGen;



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
            myQuery = "select * from campaign_targeting.patient_age_criteria_check(" + hid + "," + patientid + ",'" + startInterval + "','" + endInterval + "')";
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

        public int Patient_Inclusion_Check(int hid, long patientid, bool matchanyservice, string includedServiceIds, string includedInterval)
        {
            BusinessLogicLayer bll = new BusinessLogicLayer();
            int retVal = 0;
            string myQuery = "";
            myQuery = "select * from email.get_patient_by_included_list(" + hid + "," + patientid + "," + matchanyservice + "," + bll.ReturnNullIfEmpty(includedServiceIds) + "," + bll.ReturnNullIfEmpty(includedInterval) + ")";
            DataAccessLayer objDAL = new DataAccessLayer();
            DataTable dt = objDAL.GenericExecution_Source(myQuery);
            if (dt != null && dt.Rows.Count > 0)
            {

                return Convert.ToInt32(dt.Rows[0][0]);

            }
            return retVal;
        }

        public int Patient_Exclusion_Check(int hid, long patientid, bool matchanyservice, string excludedServiceIds, string excludedInterval)
        {
            BusinessLogicLayer bll = new BusinessLogicLayer();
            int retVal = 0;
            string myQuery = "";
            myQuery = "select * from email.get_patient_by_excluded_list(" + hid + "," + patientid + "," + matchanyservice + "," + bll.ReturnNullIfEmpty(excludedServiceIds) + "," + bll.ReturnNullIfEmpty(excludedInterval) + ")";
            DataAccessLayer objDAL = new DataAccessLayer();
            DataTable dt = objDAL.GenericExecution_Source(myQuery);
            if (dt != null && dt.Rows.Count > 0)
            {

                return Convert.ToInt32(dt.Rows[0][0]);

            }
            return retVal;
        }

        public DataTable Targeting(CustomEmail3_Targeting obj)
        {
            BusinessLogicLayer bll = new BusinessLogicLayer();
            string myQuery = "";
            myQuery = myQuery + "select * from email.get_targated_audience";
            myQuery = myQuery + "(";
            myQuery = myQuery + obj.in_hid + ",";
            myQuery = myQuery + obj.in_editor_verion_id + ",";
            myQuery = myQuery + obj.in_marketing_msg_id + ",";
            myQuery = myQuery + obj.in_species_ids + ",";
            myQuery = myQuery + obj.is_other_species + ",";
            myQuery = myQuery + obj.is_all_breed + ",";
            myQuery = myQuery + obj.in_breed_ids + ",";
            myQuery = myQuery + obj.in_is_age_in_range + ",";
            myQuery = myQuery + obj.in_is_specific_age + ",";
            myQuery = myQuery + obj.in_specific_age + ",";
            myQuery = myQuery + obj.in_age_range_from + ",";
            myQuery = myQuery + obj.in_age_range_to + ",";
            myQuery = myQuery + obj.in_last_service + ",";
            myQuery = myQuery + obj.in_last_service_from + ",";
            myQuery = myQuery + obj.in_last_service_to + ",";
            myQuery = myQuery + obj.in_included_service_ids + ",";
            myQuery = myQuery + obj.in_match_any_included_service + ",";
            myQuery = myQuery + obj.in_match_any_excluded_service + ",";
            myQuery = myQuery + obj.in_included_last_service + ",";
            myQuery = myQuery + obj.in_excluded_service_ids + ",";
            myQuery = myQuery + obj.in_excluded_last_service + "";
            myQuery = myQuery + ")";
            DataAccessLayer objDAL = new DataAccessLayer();
            DataTable dt = objDAL.GenericExecution_Source(myQuery);

            
            return dt;
        }

        #endregion

        #region Expected result Data

        public DataTable GetEmailTargetCountWithSpeciesProvided(string hid, string speciesids, bool otherSpecies)
        {
            BusinessLogicLayer bll = new BusinessLogicLayer();
            StringBuilder sb = new StringBuilder();
            if (!otherSpecies && speciesids != "'{}'")
            {
                sb.Append("select p.hid as out_hid, p.client_id as out_client_id, p.id as out_patient_id, c.first_name as out_first_name, c.last_name as out_last_name, c.email as email");
                sb.Append(" from public.patient p  join public.client c on c.id = p.client_id and c.hid =  p.hid");
                sb.Append(" where email.is_patient_active(p.hid, p.id, p.client_id) = 1");
                sb.Append(" and campaign_targeting.is_patient_email_contactable(p.hid, p.id) = 1");
                sb.Append(" and campaign_targeting.patient_species_check(p.hid, p.id, " + speciesids + ") = 1");
                sb.Append(" and p.hid = " + hid);
            }
            else if (!otherSpecies && speciesids == "'{}'")
            {
                sb.Append("select p.hid as out_hid, p.client_id as out_client_id, p.id as out_patient_id, c.first_name as out_first_name, c.last_name as out_last_name, c.email as email");
                sb.Append(" from public.patient p  join public.client c on c.id = p.client_id and c.hid =  p.hid");
                sb.Append(" where email.is_patient_active(p.hid, p.id, p.client_id) = 1");
                sb.Append(" and campaign_targeting.is_patient_email_contactable(p.hid, p.id) = 1");
                // sb.Append(" and campaign_targeting.patient_species_check(p.hid, p.id, " + speciesids + ") = 1");
                sb.Append(" and p.hid = " + hid);
            }
            else
            {
                sb.Append("select p.hid as out_hid, p.client_id as out_client_id, p.id as out_patient_id, c.first_name as out_first_name, c.last_name as out_last_name, c.email as email");
                sb.Append(" from public.patient p  join public.client c on c.id = p.client_id and c.hid =  p.hid");
                sb.Append(" where email.is_patient_active(p.hid, p.id, p.client_id) = 1");
                sb.Append(" and campaign_targeting.is_patient_email_contactable(p.hid, p.id) = 1");
                sb.Append(" and campaign_targeting.patient_species_check(p.hid, p.id, " + speciesids + ") = 0");
                sb.Append(" and p.hid = " + hid);
            }

            DataAccessLayer objDAL = new DataAccessLayer();
            DataTable dt = objDAL.GenericExecution_Source(sb.ToString());
            return dt;
        }
        public DataTable GetEmailTargetCountWithSpeciesAndBreedProvided(string hid, string speciesids, string breedIds)
        {
            BusinessLogicLayer bll = new BusinessLogicLayer();
            StringBuilder sb = new StringBuilder();
            if (breedIds != "'{}'")
            {
                sb.Append("select p.hid as out_hid, p.client_id as out_client_id, p.id as out_patient_id, c.first_name as out_first_name, c.last_name as out_last_name, c.email as email");
                sb.Append(" from public.patient p join public.client c on c.id = p.client_id and c.hid =  p.hid ");
                sb.Append(" where email.is_patient_active(p.hid, p.id, p.client_id) = 1");
                sb.Append(" and campaign_targeting.is_patient_email_contactable(p.hid, p.id) = 1");
                sb.Append(" and campaign_targeting.patient_species_check(p.hid, p.id, " + speciesids + ") = 1");
                sb.Append(" and campaign_targeting.species_breed_check(p.hid, p.id, "  + speciesids + " , " + breedIds + ") = 1");
                sb.Append(" and p.hid = " + hid);
            }
            else
            {
                sb.Append("select p.hid as out_hid, p.client_id as out_client_id, p.id as out_patient_id, c.first_name as out_first_name, c.last_name as out_last_name, c.email as email");
                sb.Append(" from public.patient p join public.client c on c.id = p.client_id and c.hid =  p.hid ");
                sb.Append(" where email.is_patient_active(p.hid, p.id, p.client_id) = 1");
                sb.Append(" and campaign_targeting.is_patient_email_contactable(p.hid, p.id) = 1");
                sb.Append(" and campaign_targeting.patient_species_check(p.hid, p.id, " + speciesids + ") = 1");
                sb.Append(" and p.hid = " + hid);
            }
            DataAccessLayer objDAL = new DataAccessLayer();
            DataTable dt = objDAL.GenericExecution_Source(sb.ToString());
            return dt;
        }
        public DataTable GetEmailTargetCountWithSpeciesBreedandAgeInRangeProvided(string hid, string speciesids, string breedIds, string startDate, string endDate)
        {
            BusinessLogicLayer bll = new BusinessLogicLayer();
            StringBuilder sb = new StringBuilder();

            sb.Append("select p.hid as out_hid, p.client_id as out_client_id, p.id as out_patient_id, c.first_name as out_first_name, c.last_name as out_last_name, c.email as email");
            sb.Append(" from public.patient p join public.client c on c.id = p.client_id and c.hid =  p.hid ");
            sb.Append(" where email.is_patient_active(p.hid, p.id, p.client_id) = 1");
            sb.Append(" and campaign_targeting.is_patient_email_contactable(p.hid, p.id) = 1");
            sb.Append(" and campaign_targeting.patient_species_check(p.hid, p.id, " + speciesids + ") = 1");
            sb.Append(" and campaign_targeting.species_breed_check(p.hid, p.id, " + speciesids + " , " + breedIds + ") = 1");
            sb.Append(" and campaign_targeting.patient_age_criteria_check(p.hid, p.id, '" + startDate + "', '" + endDate + "') = 1");
            sb.Append(" and p.hid = " + hid);
            DataAccessLayer objDAL = new DataAccessLayer();
            DataTable dt = objDAL.GenericExecution_Source(sb.ToString());
            return dt;
        }

        public DataTable GetEmailTargetCountWithSpesificAgeProvided(string hid, string speciesids, string breedIds, string spesificAge)
        {
            BusinessLogicLayer bll = new BusinessLogicLayer();
            StringBuilder sb = new StringBuilder();

            sb.Append("select p.hid as out_hid, p.client_id as out_client_id, p.id as out_patient_id, c.first_name as out_first_name, c.last_name as out_last_name, c.email as email");
            sb.Append(" from public.patient p join public.client c on c.id = p.client_id and c.hid =  p.hid ");
            sb.Append(" where email.is_patient_active(p.hid, p.id, p.client_id) = 1");
            sb.Append(" and campaign_targeting.is_patient_email_contactable(p.hid, p.id) = 1");
            sb.Append(" and campaign_targeting.patient_species_check(p.hid, p.id, " + speciesids + ") = 1");
            sb.Append(" and campaign_targeting.species_breed_check(p.hid, p.id, " + speciesids + " , " + breedIds + ") = 1");
            sb.Append(" and campaign_targeting.patient_age_criteria_check(p.hid, p.id, '" + spesificAge + "', '" + spesificAge + "') = 1");
            sb.Append(" and p.hid = " + hid);
            DataAccessLayer objDAL = new DataAccessLayer();
            DataTable dt = objDAL.GenericExecution_Source(sb.ToString());
            return dt;
        }

        public DataTable GetEmailTargetCountWithSpeciesBreedAgeAndLastVisit(string hid, string speciesids, string breedIds, string startDate, string endDate, string lastVisit)
        {
            BusinessLogicLayer bll = new BusinessLogicLayer();
            StringBuilder sb = new StringBuilder();

            sb.Append("select p.hid as out_hid, p.client_id as out_client_id, p.id as out_patient_id, c.first_name as out_first_name, c.last_name as out_last_name, c.email as email");
            sb.Append(" from public.patient p join public.client c on c.id = p.client_id and c.hid =  p.hid ");
            sb.Append(" where email.is_patient_active(p.hid, p.id, p.client_id) = 1");
            sb.Append(" and campaign_targeting.is_patient_email_contactable(p.hid, p.id) = 1");
            sb.Append(" and campaign_targeting.patient_species_check(p.hid, p.id, " + speciesids + ") = 1");
            sb.Append(" and campaign_targeting.species_breed_check(p.hid, p.id, " + speciesids + " , " + breedIds + ") = 1");
            sb.Append(" and campaign_targeting.patient_age_criteria_check(p.hid, p.id, " + startDate + ", " + endDate + ") = 1");
            sb.Append(" and email.get_patient_by_last_visit(p.hid, p.id, " + lastVisit + ", null, null, false) = 1");
            sb.Append(" and p.hid = " + hid);
            DataAccessLayer objDAL = new DataAccessLayer();
            DataTable dt = objDAL.GenericExecution_Source(sb.ToString());
            return dt;
        }

        public DataTable GetEmailTargetCountWithSpeciesBreedAgeAndLastVisitRange(string hid, string speciesids, string breedIds, string startDate, string endDate, string lastVisitFrom, string lastVisitTo)
        {
            BusinessLogicLayer bll = new BusinessLogicLayer();
            StringBuilder sb = new StringBuilder();

            sb.Append("select p.hid as out_hid, p.client_id as out_client_id, p.id as out_patient_id, c.first_name as out_first_name, c.last_name as out_last_name, c.email as email");
            sb.Append(" from public.patient p join public.client c on c.id = p.client_id and c.hid =  p.hid ");
            sb.Append(" where email.is_patient_active(p.hid, p.id, p.client_id) = 1");
            sb.Append(" and campaign_targeting.is_patient_email_contactable(p.hid, p.id) = 1");
            sb.Append(" and campaign_targeting.patient_species_check(p.hid, p.id, " + speciesids + ") = 1");
            sb.Append(" and campaign_targeting.species_breed_check(p.hid, p.id, " + speciesids + " , " + breedIds + ") = 1");
            sb.Append(" and campaign_targeting.patient_age_criteria_check(p.hid, p.id, " + startDate + ", " + endDate + ") = 1");
            sb.Append(" and email.get_patient_by_last_visit(p.hid, p.id, null, " + lastVisitFrom + ", " + lastVisitTo + ", false) = 1");
            sb.Append(" and p.hid = " + hid);
            DataAccessLayer objDAL = new DataAccessLayer();
            DataTable dt = objDAL.GenericExecution_Source(sb.ToString());
            return dt;
        }

        public DataTable GetEmailTargetCountWithSpeciesBreedAgeAndLastVisitRangeIncludedService(string hid, string speciesids, string breedIds, string startDate, string endDate, string lastVisitFrom, string lastVisitTo, string includedServiceList, string lastIncludedService, bool isAnyService)
        {
            BusinessLogicLayer bll = new BusinessLogicLayer();
            StringBuilder sb = new StringBuilder();
            sb.Append("select p.hid as out_hid, p.client_id as out_client_id, p.id as out_patient_id, c.first_name as out_first_name, c.last_name as out_last_name, c.email as email");
            sb.Append(" from public.patient p join public.client c on c.id = p.client_id and c.hid =  p.hid ");
            sb.Append(" where email.is_patient_active(p.hid, p.id, p.client_id) = 1");
            sb.Append(" and campaign_targeting.is_patient_email_contactable(p.hid, p.id) = 1");
            sb.Append(" and campaign_targeting.patient_species_check(p.hid, p.id, " + speciesids + ") = 1");
            sb.Append(" and campaign_targeting.species_breed_check(p.hid, p.id, " + speciesids + " , " + breedIds + ") = 1");
            sb.Append(" and campaign_targeting.patient_age_criteria_check(p.hid, p.id, " + startDate + ", " + endDate + ") = 1");
            sb.Append(" and email.get_patient_by_last_visit(p.hid, p.id, null, " + lastVisitFrom + ", " + lastVisitTo + ", false) = 1");
            if (isAnyService && lastIncludedService == null)
            {
                sb.Append(" and email.get_patient_by_included_list(p.hid, p.id, true, " + includedServiceList + ", null) = 1");
            }
            else if (!isAnyService && lastIncludedService == null)
            {
                sb.Append(" and email.get_patient_by_included_list(p.hid, p.id, false, " + includedServiceList + ", null) = 1");
            }
            else if (isAnyService && lastIncludedService != null)
            {
                sb.Append(" and email.get_patient_by_included_list(p.hid, p.id, true, " + includedServiceList + "," + lastIncludedService + ") = 1");
            }
            else if (!isAnyService && lastIncludedService != null)
            {
                sb.Append(" and email.get_patient_by_included_list(p.hid, p.id, false, " + includedServiceList + "," + lastIncludedService + ") = 1");
            }

            sb.Append(" and p.hid = " + hid);
            DataAccessLayer objDAL = new DataAccessLayer();
            DataTable dt = objDAL.GenericExecution_Source(sb.ToString());
            return dt;
        }

        public DataTable GetEmailTargetCountWithSpeciesBreedAgeAndLastVisitRangeExcludedService(string hid, string speciesids, string breedIds, string startDate, string endDate, string lastVisitFrom, string lastVisitTo, string excludedServiceList, string lastExcludedService, bool isAnyService)
        {
            BusinessLogicLayer bll = new BusinessLogicLayer();
            StringBuilder sb = new StringBuilder();
            sb.Append("select p.hid as out_hid, p.client_id as out_client_id, p.id as out_patient_id, c.first_name as out_first_name, c.last_name as out_last_name, c.email as email");
            sb.Append(" from public.patient p join public.client c on c.id = p.client_id and c.hid =  p.hid ");
            sb.Append(" where email.is_patient_active(p.hid, p.id, p.client_id) = 1");
            sb.Append(" and campaign_targeting.is_patient_email_contactable(p.hid, p.id) = 1");
            sb.Append(" and campaign_targeting.patient_species_check(p.hid, p.id, " + speciesids + ") = 1");
            sb.Append(" and campaign_targeting.species_breed_check(p.hid, p.id, " + speciesids + " , " + breedIds + ") = 1");
            sb.Append(" and campaign_targeting.patient_age_criteria_check(p.hid, p.id, " + startDate + ", " + endDate + ") = 1");
            sb.Append(" and email.get_patient_by_last_visit(p.hid, p.id, null, " + lastVisitFrom + ", " + lastVisitTo + ", false) = 1");
            if (isAnyService && lastExcludedService == null)
            {
                sb.Append(" and email.get_patient_by_excluded_list(p.hid, p.id, true, " + excludedServiceList + ", null) = 1");
            }
            else if (!isAnyService && lastExcludedService == null)
            {
                sb.Append(" and email.get_patient_by_excluded_list(p.hid, p.id, false, " + excludedServiceList + ", null) = 1");
            }
            else if (isAnyService && lastExcludedService != null)
            {
                sb.Append(" and email.get_patient_by_excluded_list(p.hid, p.id, true, " + excludedServiceList + "," + lastExcludedService + ") = 1");
            }
            else if (!isAnyService && lastExcludedService != null)
            {
                sb.Append(" and email.get_patient_by_excluded_list(p.hid, p.id, false, " + excludedServiceList + "," + lastExcludedService + ") = 1");
            }

            sb.Append(" and p.hid = " + hid);
            DataAccessLayer objDAL = new DataAccessLayer();
            DataTable dt = objDAL.GenericExecution_Source(sb.ToString());
            return dt;
        }


        #endregion

        #region PATIENTS_DECEASED_CHECK_TESTS
        public int Patient_Deceased_Check(int hid, long patientid, long clientid)
        {
            int retVal = 0;
            string myQuery = "";
            myQuery = "select * from email.is_patient_active(" + hid + "," + patientid + "," + clientid + ")";
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
