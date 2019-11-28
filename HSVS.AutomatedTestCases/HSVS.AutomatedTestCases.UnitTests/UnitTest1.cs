using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HSVS.AutomatedTestCases.BusinessLogic;
using HSVS.AutomatedTestCases.Common;
using System.Collections.Generic;

namespace HSVS.AutomatedTestCases.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CheckHospitalCount()
        {
            BeginTestCases obj = new BeginTestCases();
            /*
            1. GET SCHEMA - PENDING
            2. INSERT WITH DUMMY DATA
            3. EXECUTE FUNCTION
            4. ASSERT THE RESULT
            */
            //Insert dummy data to sample table
            obj.InsertSampleData(1, "Praveen", "999999999");
            // Executing function and Asserting the result
            Assert.AreEqual(1, obj.GetSampleTableDataCount());
        }
        [TestMethod]
        public void GetActivePatients()
        {
            int hid = 2882;
            string my_run_date = "2018-09-17";
            string myinterval = "1 day";
            //DateTime dt = new DateTime();
            BeginTestCases obj = new BeginTestCases();
            BusinessLogicLayer objBusiness = new BusinessLogicLayer();

            /*
            1. GET SCHEMA - 
            2. INSERT WITH DUMMY DATA
            3. EXECUTE FUNCTION
            4. ASSERT THE RESULT
            */
            //Insert dummy data to sample table
            obj.InsertDatatoLineItem();
            // Executing function and Asserting the result
            List<public_lineitem> lstResult = obj.GetActivePatientsConvert(hid, my_run_date, myinterval);

            List<public_lineitem> lstExpected = new List<public_lineitem>();
            public_lineitem pl = new public_lineitem();
            pl.client_id = 96772283;
            pl.patient_id = 164445456;
            pl.hid = 2882;
            lstExpected.Add(pl);

            pl = new public_lineitem();
            pl.client_id = 96772284;
            pl.patient_id = 164445457;
            pl.hid = 2882;
            lstExpected.Add(pl);
            var dtExpected = objBusiness.CreateDataTable(lstExpected);
            var dtResult = objBusiness.CreateDataTable(lstResult);
            Assert.AreEqual(true, obj.GetDifferentRecords(dtExpected, dtResult));
        }





        [TestMethod]
        public void GetActivePatients_True()
        {
            /*
            1. Get Schema to Local Database from Source Connections
            2. Generate Mock data and insert into desctination local database
            3. Execute function in local database
            4. Assert with Mock expected data(expected results) and result set of function(result data)
             */

            BeginTestCases obj = new BeginTestCases();
            BusinessLogicLayer objBusiness = new BusinessLogicLayer();

            #region INPUT
            int hid = 2882;
            string my_run_date = "2018-09-17";
            string myinterval = "1 day";
            #endregion
            
            #region INSERTING DATA
            //Insert dummy data to sample table
            obj.InsertDatatoLineItem();
            #endregion

            #region EXECUTING FUNCTION
            // Executing function and Asserting the result
            List<public_lineitem> lstResult = obj.GetActivePatientsConvert(hid, my_run_date, myinterval);
            #endregion

            //Expected PatientIds
            string expectedPatientIds = "164445456,164445457";
            var pIds = expectedPatientIds.Split(',');
            bool result = false;
            for (int i = 0; i < lstResult.Count; i++)
            {
                result = false;
                if(CheckExisting(lstResult[i].patient_id, pIds))
                {
                    result = true;
                }
            }
            
            Assert.AreEqual(true, result);
        }


        [TestMethod]
        public void GetActivePatients_False()
        {
            /*
           1. Get Schema to Local Database from Source Connections
           2. Generate Mock data and insert into desctination local database
           3. Execute function in local database
           4. Assert with Mock expected data(expected results) and result set of function(result data)
            */


            int hid = 2882;
            string my_run_date = "2018-09-17";
            string myinterval = "1 day";
            //DateTime dt = new DateTime();
            BeginTestCases obj = new BeginTestCases();
            BusinessLogicLayer objBusiness = new BusinessLogicLayer();

            //Insert dummy data to sample table
            obj.InsertDatatoLineItem();
            // Executing function and Asserting the result
            List<public_lineitem> lstResult = obj.GetActivePatientsConvert(hid, my_run_date, myinterval);


            //Expected PatientIds
            string expectedPatientIds = "164445456";
            var pIds = expectedPatientIds.Split(',');
            bool result = false;
            for (int i = 0; i < lstResult.Count; i++)
            {
                result = false;
                if (CheckExisting(lstResult[i].patient_id, pIds))
                {
                    result = true;
                   
                }
            }

            Assert.AreEqual(false, result);
        }
        private bool CheckExisting(int patient_id, string[] pIds)
        {
            int pos = Array.IndexOf(pIds, Convert.ToString(patient_id));
            if (pos > -1)
            {
                return true;
            }
            return false;
        }
    }
}
