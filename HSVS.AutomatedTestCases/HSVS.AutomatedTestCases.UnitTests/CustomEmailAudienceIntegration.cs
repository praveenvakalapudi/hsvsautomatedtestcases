using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HSVS.AutomatedTestCases.BusinessLogic;

namespace HSVS.AutomatedTestCases.UnitTests
{
    [TestClass]
    public class CustomEmailAudienceIntegration
    {
        public class Patient
        {
            public int patientid { get; set; }
            public int hid { get; set; }
            public string speciesIdTrueCase { get; set; }
            public string speciesIdFalseCase { get; set; }
            public string breedIdsTrueCase { get; set; }
            public string breedIdsFalseCase { get; set; }
            public string startIntervalMonthsTrueCase { get; set; }
            public string startIntervalMonthsFalseCase { get; set; }
            public string startIntervalYearsTrueCase { get; set; }
            public string startIntervalYearsFalseCase { get; set; }
        }
        //public Patient LoadPatientDetails(int patientIndex)
        //{
        //    Patient objPatient = new Patient();
        //    if (patientIndex == 1)
        //    {

        //    }
        //}

        #region SPECIES CHECK
        [TestMethod]
        public void patient_species_check_returns_true_if_patient_species_meets_targeting_criteria()
        {

            BeginTestCases obj = new BeginTestCases();
            int hid = 2882;
            long patientId = 287240615;
            string speciesIds = "{7}";

            var result = obj.Patient_Species_Check(hid, patientId, speciesIds);
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void patient_species_check_returns_false_if_patient_species_does_not_meet_targeting_criteria()
        {

            BeginTestCases obj = new BeginTestCases();
            int hid = 2882;
            long patientId = 287240615;
            string speciesIds = "{3}";

            var result = obj.Patient_Species_Check(hid, patientId, speciesIds);
            Assert.AreEqual(0, result);
        }
        #endregion

        #region BREED CHECK
        [TestMethod]
        public void species_breed_check_returns_True_if_species_breed_meets_targeting_criteria()
        {

            BeginTestCases obj = new BeginTestCases();
            int hid = 2882;
            long patientId = 287240615;
            string speciesIds = "{7}";// Only one species
            string breedIds = "{1647942}";
            var result = obj.Patient_Species_Breed_Check(hid, patientId, speciesIds, breedIds);
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void species_breed_check_returns_false_if_species_breed_does_not_meet_targeting_criteria()
        {

            BeginTestCases obj = new BeginTestCases();
            int hid = 2882;
            long patientId = 287240615;
            string speciesIds = "{3}";// Only one species
            string breedIds = "{1973}";
            var result = obj.Patient_Species_Breed_Check(hid, patientId, speciesIds, breedIds);
            Assert.AreEqual(0, result);
        }
        #endregion

        #region SPECIFIC AGE CHECK
        #region MONTHS
        [TestMethod]
        public void patient_specific_age_check_returns_true_if_patient_age_meets_the_targeting_criteria_in_months()
        {
            // This patient with Id: 164445457 DOB: 2005-12-12
            BeginTestCases obj = new BeginTestCases();
            int hid = 2882;
            long patientId = 164445457;
            string startInterval = "154 month";
            string endInterval = "154 month";
            var result = obj.Patient_Age_Criteria_Check(hid, patientId, startInterval, endInterval);
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void patient_specific_age_check_returns_false_if_patient_age_does_not_meet_targeting_criteria_in_months()
        {

            BeginTestCases obj = new BeginTestCases();
            int hid = 2882;
            long patientId = 164445457;
            string startInterval = "153 month";
            string endInterval = "153 month";
            var result = obj.Patient_Age_Criteria_Check(hid, patientId, startInterval, endInterval);
            Assert.AreEqual(0, result);
        }
        #endregion

        #region YEAR
        [TestMethod]
        public void patient_specific_age_check_returns_true_if_patient_age_meets_the_targeting_criteria_in_years()
        {
            // This patient with Id: 164445457 DOB: 2005-12-12
            BeginTestCases obj = new BeginTestCases();
            int hid = 2882;
            long patientId = 164445457;
            string startInterval = "12 year";
            string endInterval = "12 year";
            var result = obj.Patient_Age_Criteria_Check(hid, patientId, startInterval, endInterval);
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void patient_specific_age_check_returns_false_if_patient_age_does_not_meet_targeting_criteria_in_years()
        {

            BeginTestCases obj = new BeginTestCases();
            int hid = 2882;
            long patientId = 164445457;
            string startInterval = "11 year";
            string endInterval = "11 year";
            var result = obj.Patient_Age_Criteria_Check(hid, patientId, startInterval, endInterval);
            Assert.AreEqual(0, result);
        }
        #endregion


        #endregion

        #region AGE RANGE CHECK

        #region MONTHS
        [TestMethod]
        public void patient_age_check_returns_true_if_patient_age_meets_the_targeting_criteria_in_months()
        {
            // This patient with Id: 164445457 DOB: 2005-12-12
            BeginTestCases obj = new BeginTestCases();
            int hid = 2882;
            long patientId = 164445457;
            string startInterval = "1 month";
            string endInterval = "154 month";
            var result = obj.Patient_Age_Criteria_Check(hid, patientId, startInterval, endInterval);
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void patient_age_check_returns_false_if_patient_age_does_not_meet_targeting_criteria_in_months()
        {

            BeginTestCases obj = new BeginTestCases();
            int hid = 2882;
            long patientId = 164445457;
            string startInterval = "1 month";
            string endInterval = "153 month";
            var result = obj.Patient_Age_Criteria_Check(hid, patientId, startInterval, endInterval);
            Assert.AreEqual(0, result);
        }
        #endregion

        #region YEAR
        [TestMethod]
        public void patient_age_check_returns_true_if_patient_age_meets_the_targeting_criteria_in_years()
        {
            // This patient with Id: 164445457 DOB: 2005-12-12
            BeginTestCases obj = new BeginTestCases();
            int hid = 2882;
            long patientId = 164445457;
            string startInterval = "1 year";
            string endInterval = "13 year";
            var result = obj.Patient_Age_Criteria_Check(hid, patientId, startInterval, endInterval);
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void patient_age_check_returns_false_if_patient_age_does_not_meet_targeting_criteria_in_years()
        {

            BeginTestCases obj = new BeginTestCases();
            int hid = 2882;
            long patientId = 164445457;
            string startInterval = "1 year";
            string endInterval = "11 year";
            var result = obj.Patient_Age_Criteria_Check(hid, patientId, startInterval, endInterval);
            Assert.AreEqual(0, result);
        }
        #endregion

        #endregion

        #region LAST VISIT

        #region LAST VISIT IN DAYS
        [TestMethod]
        public void patient_last_visit_check_returns_true_if_patient_lst_visit_meets_the_targeting_criteria_in_days()
        {
            BeginTestCases obj = new BeginTestCases();
            int hid = 2882;
            long patientId = 164445457;
            string lastvisit = "41 day";
            string lastVistiFrom = "";
            string lastVistiTo = "";
            var result = obj.Patient_Last_Visit_Check(hid, patientId, lastvisit, lastVistiFrom, lastVistiTo);
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void patient_last_visit_check_returns_false_if_patient_lst_visit_meets_the_targeting_criteria_in_days()
        {
            BeginTestCases obj = new BeginTestCases();
            int hid = 2882;
            long patientId = 164445457;
            string lastvisit = "1 day";
            string lastVistiFrom = "";
            string lastVistiTo = "";
            var result = obj.Patient_Last_Visit_Check(hid, patientId, lastvisit, lastVistiFrom, lastVistiTo);
            Assert.AreEqual(0, result);
        }
        #endregion

        #region LAST VISIT IN MONTHS

        [TestMethod]
        public void patient_last_visit_check_returns_true_if_patient_lst_visit_meets_the_targeting_criteria_in_months()
        {
            BeginTestCases obj = new BeginTestCases();
            int hid = 2882;
            long patientId = 164445457;
            string lastvisit = "2 month";
            string lastVistiFrom = "";
            string lastVistiTo = "";
            var result = obj.Patient_Last_Visit_Check(hid, patientId, lastvisit, lastVistiFrom, lastVistiTo);
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void patient_last_visit_check_returns_false_if_patient_lst_visit_meets_the_targeting_criteria_in_months()
        {
            BeginTestCases obj = new BeginTestCases();
            int hid = 2882;
            long patientId = 164445457;
            string lastvisit = "1 month";
            string lastVistiFrom = "";
            string lastVistiTo = "";
            var result = obj.Patient_Last_Visit_Check(hid, patientId, lastvisit, lastVistiFrom, lastVistiTo);
            Assert.AreEqual(0, result);
        }
        #endregion

        #region LAST VISIT IN RANGE

        [TestMethod]
        public void patient_last_visit_check_returns_true_if_patient_lst_visit_meets_the_targeting_criteria_in_range()
        {
            BeginTestCases obj = new BeginTestCases();
            int hid = 2882;
            long patientId = 164445457;
            string lastvisit = "";
            string lastVistiFrom = "2018-09-01";
            string lastVistiTo = "2018-10-12";
            var result = obj.Patient_Last_Visit_Check(hid, patientId, lastvisit, lastVistiFrom, lastVistiTo);
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void patient_last_visit_check_returns_false_if_patient_lst_visit_meets_the_targeting_criteria_in_range()
        {
            BeginTestCases obj = new BeginTestCases();
            int hid = 2882;
            long patientId = 164445457;
            string lastvisit = "";
            string lastVistiFrom = "2018-09-02";
            string lastVistiTo = "2018-10-12";
            var result = obj.Patient_Last_Visit_Check(hid, patientId, lastvisit, lastVistiFrom, lastVistiTo);
            Assert.AreEqual(0, result);
        }
        #endregion

        #region LAST VISIT IN DAYS AND RANGE

        [TestMethod]
        public void patient_last_visit_check_returns_true_if_patient_lst_visit_meets_the_targeting_criteria_in_days_and_range()
        {
            BeginTestCases obj = new BeginTestCases();
            int hid = 2882;
            long patientId = 164445457;
            string lastvisit = "2 day";
            string lastVistiFrom = "2018-09-01";
            string lastVistiTo = "2018-10-12";
            var result = obj.Patient_Last_Visit_Check(hid, patientId, lastvisit, lastVistiFrom, lastVistiTo);
            Assert.AreEqual(1, result);
        }
        [TestMethod]
        public void patient_last_visit_check_returns_false_if_patient_lst_visit_meets_the_targeting_criteria_in_days_and_range()
        {
            BeginTestCases obj = new BeginTestCases();
            int hid = 2882;
            long patientId = 164445457;
            string lastvisit = "1 day";
            string lastVistiFrom = "2018-09-02";
            string lastVistiTo = "2018-10-12";
            var result = obj.Patient_Last_Visit_Check(hid, patientId, lastvisit, lastVistiFrom, lastVistiTo);
            Assert.AreEqual(0, result);
        }
        #endregion

        #region LAST VISIT IN MONTHS AND RANGE

        [TestMethod]
        public void patient_last_visit_check_returns_true_if_patient_lst_visit_meets_the_targeting_criteria_in_months_and_range()
        {
            BeginTestCases obj = new BeginTestCases();
            int hid = 2882;
            long patientId = 164445457;
            string lastvisit = "2 month";
            string lastVistiFrom = "2018-09-01";
            string lastVistiTo = "2018-10-12";
            var result = obj.Patient_Last_Visit_Check(hid, patientId, lastvisit, lastVistiFrom, lastVistiTo);
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void patient_last_visit_check_returns_false_if_patient_lst_visit_meets_the_targeting_criteria_in_months_and_range()
        {
            BeginTestCases obj = new BeginTestCases();
            int hid = 2882;
            long patientId = 164445457;
            string lastvisit = "1 month";
            string lastVistiFrom = "2018-09-02";
            string lastVistiTo = "2018-10-12";
            var result = obj.Patient_Last_Visit_Check(hid, patientId, lastvisit, lastVistiFrom, lastVistiTo);
            Assert.AreEqual(0, result);
        }
        #endregion

        #endregion


        #region INCLUSION
        #region WHEN MATCH ANY SERVICE TRUE
        [TestMethod]
        public void patient_inclusion_check_returns_true_if_patient_inclusion_meets_the_targeting_criteria_when_match_service_true()
        {
            BeginTestCases obj = new BeginTestCases();
            int hid = 2882;
            long patientId = 164445457;
            bool matchAnyService = true;
            string inclusionServiceIds = "{25202410,25153625,25153576,53285157,25153624,26098532,26098532}";
            string includedInterval = "12 year";
           
            var result = obj.Patient_Inclusion_Check(hid, patientId, matchAnyService, inclusionServiceIds, includedInterval);
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void patient_inclusion_check_returns_false_if_patient_inclusion_meets_the_targeting_criteria_when_match_service_true()
        {
            BeginTestCases obj = new BeginTestCases();
            int hid = 2882;
            long patientId = 164445457;
            bool matchAnyService = true;
            string inclusionServiceIds = "{25202410,25153625,25153576,53285157,25153624,26098532,26098532}";
            string includedInterval = "1 year";

            var result = obj.Patient_Inclusion_Check(hid, patientId, matchAnyService, inclusionServiceIds, includedInterval);
            Assert.AreEqual(0, result);
        }
        #endregion

        #region WHEN MATCH ANY SERVICE FALSE
        [TestMethod]
        public void patient_inclusion_check_returns_true_if_patient_inclusion_meets_the_targeting_criteria_when_match_service_false()
        {
            BeginTestCases obj = new BeginTestCases();
            int hid = 2882;
            long patientId = 164445457;
            bool matchAnyService = false;
            string inclusionServiceIds = "{25202410,25153625,25153576,53285157,25153624,26098532,26098532}";
            string includedInterval = "12 year";

            var result = obj.Patient_Inclusion_Check(hid, patientId, matchAnyService, inclusionServiceIds, includedInterval);
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void patient_inclusion_check_returns_false_if_patient_inclusion_meets_the_targeting_criteria_when_match_service_false()
        {
            BeginTestCases obj = new BeginTestCases();
            int hid = 2882;
            long patientId = 164445457;
            bool matchAnyService = false;
            string inclusionServiceIds = "{25202410,25153625,25153576,53285157,25153624,26098532,26098532}";
            string includedInterval = "1 year";

            var result = obj.Patient_Inclusion_Check(hid, patientId, matchAnyService, inclusionServiceIds, includedInterval);
            Assert.AreEqual(0, result);
        }

        #endregion
        #endregion

        #region EXCLUSION
        #endregion
    }
}
