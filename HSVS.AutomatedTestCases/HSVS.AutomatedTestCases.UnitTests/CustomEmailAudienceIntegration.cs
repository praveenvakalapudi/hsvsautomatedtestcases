using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HSVS.AutomatedTestCases.BusinessLogic;
using HSVS.AutomatedTestCases.Common.Targeting;
using System.Data;

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
            string endInterval = "179 month";
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
        public void patient_last_visit_check_returns_false_if_patient_lst_visit_does_not_meets_the_targeting_criteria_in_days()
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
        public void patient_last_visit_check_returns_false_if_patient_lst_visit_does_not_meets_the_targeting_criteria_in_months()
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
        public void patient_last_visit_check_returns_false_if_patient_lst_visit_does_not_meets_the_targeting_criteria_in_range()
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
        public void patient_last_visit_check_returns_false_if_patient_lst_visit_does_not_meets_the_targeting_criteria_in_days_and_range()
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
        public void patient_last_visit_check_returns_false_if_patient_lst_visit_does_not_meets_the_targeting_criteria_in_months_and_range()
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
        public void patient_inclusion_check_returns_false_if_patient_inclusion_does_not_meets_the_targeting_criteria_when_match_service_true()
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
        public void patient_inclusion_check_returns_false_if_patient_inclusion_does_not_meets_the_targeting_criteria_when_match_service_false()
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
        #region WHEN MATCH ANY SERVICE TRUE
        [TestMethod]
        public void patient_exclusion_check_returns_true_if_patient_inclusion_meets_the_targeting_criteria_when_match_service_true()
        {
            BeginTestCases obj = new BeginTestCases();
            int hid = 2882;
            long patientId = 164445457;
            bool matchAnyService = true;
            string inclusionServiceIds = "{26098531}";
            string includedInterval = "12 year";

            var result = obj.Patient_Exclusion_Check(hid, patientId, matchAnyService, inclusionServiceIds, includedInterval);
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void patient_exclusion_check_returns_false_if_patient_inclusion_does_not_meets_the_targeting_criteria_when_match_service_true()
        {
            BeginTestCases obj = new BeginTestCases();
            int hid = 2882;
            long patientId = 164445457;
            bool matchAnyService = true;
            string inclusionServiceIds = "{26098531}";
            string includedInterval = "1 year";

            var result = obj.Patient_Exclusion_Check(hid, patientId, matchAnyService, inclusionServiceIds, includedInterval);
            Assert.AreEqual(0, result);
        }
        #endregion

        #region WHEN MATCH ANY SERVICE FALSE
        [TestMethod]
        public void patient_exclusion_check_returns_true_if_patient_inclusion_meets_the_targeting_criteria_when_match_service_false()
        {
            BeginTestCases obj = new BeginTestCases();
            int hid = 2882;
            long patientId = 164445457;
            bool matchAnyService = false;
            string inclusionServiceIds = "{26098531}";
            string includedInterval = "12 year";

            var result = obj.Patient_Exclusion_Check(hid, patientId, matchAnyService, inclusionServiceIds, includedInterval);
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void patient_exclusion_check_returns_false_if_patient_inclusion_does_not_meets_the_targeting_criteria_when_match_service_false()
        {
            BeginTestCases obj = new BeginTestCases();
            int hid = 2882;
            long patientId = 164445457;
            bool matchAnyService = false;
            string inclusionServiceIds = "{26098531}";
            string includedInterval = "1 year";

            var result = obj.Patient_Exclusion_Check(hid, patientId, matchAnyService, inclusionServiceIds, includedInterval);
            Assert.AreEqual(0, result);
        }

        #endregion
        #endregion

        #region MAIN FUNCTION

        #region Species Checks

        [TestMethod]
        public void email_target_return_true_if_species_provided()
        {
            BeginTestCases objBegin = new BeginTestCases();
            CustomEmail3_Targeting obj = new CustomEmail3_Targeting();
            obj.in_hid = 2882;
            obj.in_editor_verion_id = 3;
            obj.in_marketing_msg_id = 82904;
            obj.in_species_ids = "'{3,7}'";
            obj.is_other_species = false;
            obj.is_all_breed = false;
            obj.in_breed_ids = "'{}'";
            obj.in_is_age_in_range = false;
            obj.in_is_specific_age = false;
            obj.in_specific_age = "null";
            obj.in_age_range_from = "null";
            obj.in_age_range_to = "null";
            obj.in_last_service = "null";
            obj.in_last_service_from = "null";
            obj.in_last_service_to = "null";
            obj.in_included_service_ids = "'{}'";
            obj.in_match_any_included_service = false;
            obj.in_match_any_excluded_service = false;
            obj.in_included_last_service = "null";
            obj.in_excluded_service_ids = "'{}'";
            obj.in_excluded_last_service = "null";
            DataTable dtExpected = new DataTable();

            DataTable dtResult = objBegin.Targeting(obj);

            DataTable expectedValue = objBegin.GetEmailTargetCountWithSpeciesProvided("2882", "'{3,7}'", false);
            Assert.AreEqual(expectedValue.Rows.Count, dtResult.Rows.Count);
        }

        [TestMethod]
        public void email_target_return_true_if_other_species_false_and_species_blank()
        {
            BeginTestCases objBegin = new BeginTestCases();
            CustomEmail3_Targeting obj = new CustomEmail3_Targeting();
            obj.in_hid = 2882;
            obj.in_editor_verion_id = 3;
            obj.in_marketing_msg_id = 82904;
            obj.in_species_ids = "'{}'";
            obj.is_other_species = false;
            obj.is_all_breed = false;
            obj.in_breed_ids = "'{}'";
            obj.in_is_age_in_range = false;
            obj.in_is_specific_age = false;
            obj.in_specific_age = "null";
            obj.in_age_range_from = "null";
            obj.in_age_range_to = "null";
            obj.in_last_service = "null";
            obj.in_last_service_from = "null";
            obj.in_last_service_to = "null";
            obj.in_included_service_ids = "'{}'";
            obj.in_match_any_included_service = false;
            obj.in_match_any_excluded_service = false;
            obj.in_included_last_service = "null";
            obj.in_excluded_service_ids = "'{}'";
            obj.in_excluded_last_service = "null";
            DataTable dtExpected = new DataTable();

            DataTable dtResult = objBegin.Targeting(obj);

            DataTable expectedValue = objBegin.GetEmailTargetCountWithSpeciesProvided("2882", "'{}'", false);
            Assert.AreEqual(expectedValue.Rows.Count, dtResult.Rows.Count);
        }

        [TestMethod]
        public void email_target_return_true_if_other_species_true_and_species_not_blank()
        {
            BeginTestCases objBegin = new BeginTestCases();
            CustomEmail3_Targeting obj = new CustomEmail3_Targeting();
            obj.in_hid = 2882;
            obj.in_editor_verion_id = 3;
            obj.in_marketing_msg_id = 82904;
            obj.in_species_ids = "'{3}'";
            obj.is_other_species = true;
            obj.is_all_breed = false;
            obj.in_breed_ids = "'{}'";
            obj.in_is_age_in_range = false;
            obj.in_is_specific_age = false;
            obj.in_specific_age = "null";
            obj.in_age_range_from = "null";
            obj.in_age_range_to = "null";
            obj.in_last_service = "null";
            obj.in_last_service_from = "null";
            obj.in_last_service_to = "null";
            obj.in_included_service_ids = "'{}'";
            obj.in_match_any_included_service = false;
            obj.in_match_any_excluded_service = false;
            obj.in_included_last_service = "null";
            obj.in_excluded_service_ids = "'{}'";
            obj.in_excluded_last_service = "null";
            DataTable dtExpected = new DataTable();

            DataTable dtResult = objBegin.Targeting(obj);

            DataTable expectedValue = objBegin.GetEmailTargetCountWithSpeciesProvided("2882", "'{3}'", true);
            Assert.AreEqual(expectedValue.Rows.Count, dtResult.Rows.Count);
        }

        #endregion

        #region Breed Checks
        [TestMethod]
        public void email_target_return_true_if_species_and_breed_provided()
        {
            BeginTestCases objBegin = new BeginTestCases();
            CustomEmail3_Targeting obj = new CustomEmail3_Targeting();
            obj.in_hid = 2882;
            obj.in_editor_verion_id = 3;
            obj.in_marketing_msg_id = 82904;
            obj.in_species_ids = "'{3,7}'";
            obj.is_other_species = false;
            obj.is_all_breed = false;
            obj.in_breed_ids = "'{3531346,4994701,1647936,4016004,3019668,3266186,6797245}'";
            obj.in_is_age_in_range = false;
            obj.in_is_specific_age = false;
            obj.in_specific_age = "null";
            obj.in_age_range_from = "null";
            obj.in_age_range_to = "null";
            obj.in_last_service = "null";
            obj.in_last_service_from = "null";
            obj.in_last_service_to = "null";
            obj.in_included_service_ids = "'{}'";
            obj.in_match_any_included_service = false;
            obj.in_match_any_excluded_service = false;
            obj.in_included_last_service = "null";
            obj.in_excluded_service_ids = "'{}'";
            obj.in_excluded_last_service = "null";
            DataTable dtExpected = new DataTable();
            DataTable dtResult = objBegin.Targeting(obj);
            DataTable expectedValue = objBegin.GetEmailTargetCountWithSpeciesAndBreedProvided("2882", "'{3,7}'", "'{3531346,4994701,1647936,4016004,3019668,3266186,6797245}'");
            Assert.AreEqual(expectedValue.Rows.Count, dtResult.Rows.Count);
        }

        [TestMethod]
        public void email_target_return_true_if_species_and_breed_not_provided()
        {
            BeginTestCases objBegin = new BeginTestCases();
            CustomEmail3_Targeting obj = new CustomEmail3_Targeting();
            obj.in_hid = 2882;
            obj.in_editor_verion_id = 3;
            obj.in_marketing_msg_id = 82904;
            obj.in_species_ids = "'{3,7}'";
            obj.is_other_species = false;
            obj.is_all_breed = false;
            obj.in_breed_ids = "'{}'";
            obj.in_is_age_in_range = false;
            obj.in_is_specific_age = false;
            obj.in_specific_age = "null";
            obj.in_age_range_from = "null";
            obj.in_age_range_to = "null";
            obj.in_last_service = "null";
            obj.in_last_service_from = "null";
            obj.in_last_service_to = "null";
            obj.in_included_service_ids = "'{}'";
            obj.in_match_any_included_service = false;
            obj.in_match_any_excluded_service = false;
            obj.in_included_last_service = "null";
            obj.in_excluded_service_ids = "'{}'";
            obj.in_excluded_last_service = "null";
            DataTable dtExpected = new DataTable();
            DataTable dtResult = objBegin.Targeting(obj);
            DataTable expectedValue = objBegin.GetEmailTargetCountWithSpeciesAndBreedProvided("2882", "'{3,7}'", "'{}'");
            Assert.AreEqual(expectedValue.Rows.Count, dtResult.Rows.Count);
        }
        #endregion

        #region Age Checks
        [TestMethod]
        public void email_target_return_true_if_species_Breed_and_age_in_Range_provided()
        {
            BeginTestCases objBegin = new BeginTestCases();
            CustomEmail3_Targeting obj = new CustomEmail3_Targeting();
            obj.in_hid = 2882;
            obj.in_editor_verion_id = 3;
            obj.in_marketing_msg_id = 82904;
            obj.in_species_ids = "'{3,7}'";
            obj.is_other_species = false;
            obj.is_all_breed = false;
            obj.in_breed_ids = "'{3531346,4994701,1647936,4016004,3019668,3266186,6797245}'";
            obj.in_is_age_in_range = true;
            obj.in_is_specific_age = false;
            obj.in_specific_age = "null";
            obj.in_age_range_from = "'1 month'";
            obj.in_age_range_to = "'100 months'";
            obj.in_last_service = "null";
            obj.in_last_service_from = "null";
            obj.in_last_service_to = "null";
            obj.in_included_service_ids = "'{}'";
            obj.in_match_any_included_service = true;
            obj.in_match_any_excluded_service = true;
            obj.in_included_last_service = "null";
            obj.in_excluded_service_ids = "'{}'";
            obj.in_excluded_last_service = "null";
            DataTable dtExpected = new DataTable();
            DataTable dtResult = objBegin.Targeting(obj);
            DataTable expectedValue = objBegin.GetEmailTargetCountWithSpeciesBreedandAgeInRangeProvided("2882", "'{3,7}'", "'{3531346,4994701,1647936,4016004,3019668,3266186,6797245}'", "1 month", "100 months");
            Assert.AreEqual(expectedValue.Rows.Count, dtResult.Rows.Count);
        }

        [TestMethod]
        public void email_target_return_true_if_species_Breed_and_spesific_age_provided()
        {
            BeginTestCases objBegin = new BeginTestCases();
            CustomEmail3_Targeting obj = new CustomEmail3_Targeting();
            obj.in_hid = 2882;
            obj.in_editor_verion_id = 3;
            obj.in_marketing_msg_id = 82904;
            obj.in_species_ids = "'{3,7}'";
            obj.is_other_species = false;
            obj.is_all_breed = false;
            obj.in_breed_ids = "'{3531346,4994701,1647936,4016004,3019668,3266186,6797245}'";
            obj.in_is_age_in_range = false;
            obj.in_is_specific_age = true;
            obj.in_specific_age = "'97 months'";
            obj.in_age_range_from = "null";
            obj.in_age_range_to = "null";
            obj.in_last_service = "null";
            obj.in_last_service_from = "null";
            obj.in_last_service_to = "null";
            obj.in_included_service_ids = "'{}'";
            obj.in_match_any_included_service = true;
            obj.in_match_any_excluded_service = true;
            obj.in_included_last_service = "null";
            obj.in_excluded_service_ids = "'{}'";
            obj.in_excluded_last_service = "null";
            DataTable dtExpected = new DataTable();
            DataTable dtResult = objBegin.Targeting(obj);
            DataTable expectedValue = objBegin.GetEmailTargetCountWithSpesificAgeProvided("2882", "'{3,7}'", "'{3531346,4994701,1647936,4016004,3019668,3266186,6797245}'", "97 month");
            Assert.AreEqual(expectedValue.Rows.Count, dtResult.Rows.Count);
        }

        #endregion

        #region Last Visit Test
        [TestMethod]
        public void email_target_return_true_if_species_Breed_age_and_in_last_visit_provided()
        {
            BeginTestCases objBegin = new BeginTestCases();
            CustomEmail3_Targeting obj = new CustomEmail3_Targeting();
            obj.in_hid = 2882;
            obj.in_editor_verion_id = 3;
            obj.in_marketing_msg_id = 82904;
            obj.in_species_ids = "'{3,7}'";
            obj.is_other_species = false;
            obj.is_all_breed = false;
            obj.in_breed_ids = "'{3531346,4994701,1647936,4016004,3019668,3266186,6797245}'";
            obj.in_is_age_in_range = true;
            obj.in_is_specific_age = false;
            obj.in_specific_age = "null";
            obj.in_age_range_from = "'1 month'";
            obj.in_age_range_to = "'200 months'";
            obj.in_last_service = "'60 months'";
            obj.in_last_service_from = "null";
            obj.in_last_service_to = "null";
            obj.in_included_service_ids = "'{}'";
            obj.in_match_any_included_service = true;
            obj.in_match_any_excluded_service = true;
            obj.in_included_last_service = "null";
            obj.in_excluded_service_ids = "'{}'";
            obj.in_excluded_last_service = "null";
            DataTable dtExpected = new DataTable();
            DataTable dtResult = objBegin.Targeting(obj);
            DataTable expectedValue = objBegin.GetEmailTargetCountWithSpeciesBreedAgeAndLastVisit("2882", "'{3,7}'", "'{3531346,4994701,1647936,4016004,3019668,3266186,6797245}'", "'1 month'", "'200 months'", "'60 months'");
            Assert.AreEqual(expectedValue.Rows.Count, dtResult.Rows.Count);
        }

        [TestMethod]
        public void email_target_return_true_if_species_Breed_age_and_last_visit_range_provided()
        {
            BeginTestCases objBegin = new BeginTestCases();
            CustomEmail3_Targeting obj = new CustomEmail3_Targeting();
            obj.in_hid = 2882;
            obj.in_editor_verion_id = 3;
            obj.in_marketing_msg_id = 82904;
            obj.in_species_ids = "'{3,7}'";
            obj.is_other_species = false;
            obj.is_all_breed = false;
            obj.in_breed_ids = "'{3531346,4994701,1647936,4016004,3019668,3266186,6797245}'";
            obj.in_is_age_in_range = true;
            obj.in_is_specific_age = false;
            obj.in_specific_age = "null";
            obj.in_age_range_from = "'1 month'";
            obj.in_age_range_to = "'200 months'";
            obj.in_last_service = "null";
            obj.in_last_service_from = "'2010-01-01'";
            obj.in_last_service_to = "'2018-01-01'";
            obj.in_included_service_ids = "'{}'";
            obj.in_match_any_included_service = true;
            obj.in_match_any_excluded_service = true;
            obj.in_included_last_service = "null";
            obj.in_excluded_service_ids = "'{}'";
            obj.in_excluded_last_service = "null";
            DataTable dtExpected = new DataTable();
            DataTable dtResult = objBegin.Targeting(obj);
            DataTable expectedValue = objBegin.GetEmailTargetCountWithSpeciesBreedAgeAndLastVisitRange("2882", "'{3,7}'", "'{3531346,4994701,1647936,4016004,3019668,3266186,6797245}'", "'1 month'", "'200 months'", "'2010-01-01'", "'2018-01-01'");
            Assert.AreEqual(expectedValue.Rows.Count, dtResult.Rows.Count);
        }

        #endregion

        #region Inclusion list
        [TestMethod]
        public void email_target_return_true_if_species_Breed_age_last_visit_range_Inclusion_services_with_selected_any_services()
        {
            BeginTestCases objBegin = new BeginTestCases();
            CustomEmail3_Targeting obj = new CustomEmail3_Targeting();
            obj.in_hid = 2882;
            obj.in_editor_verion_id = 3;
            obj.in_marketing_msg_id = 82904;
            obj.in_species_ids = "'{3,7}'";
            obj.is_other_species = false;
            obj.is_all_breed = false;
            obj.in_breed_ids = "'{3531346,4994701,1647936,4016004,3019668,3266186,6797245}'";
            obj.in_is_age_in_range = true;
            obj.in_is_specific_age = false;
            obj.in_specific_age = "null";
            obj.in_age_range_from = "'1 month'";
            obj.in_age_range_to = "'200 months'";
            obj.in_last_service = "null";
            obj.in_last_service_from = "'2010-01-01'";
            obj.in_last_service_to = "'2018-01-01'";
            obj.in_included_service_ids = "'{39235137,77048018,63693452,25153625,25153576,25153579,25153578,67905913,120110531,77048018,25153625}'";
            obj.in_match_any_included_service = true;
            obj.in_match_any_excluded_service = true;
            obj.in_included_last_service = "null";
            obj.in_excluded_service_ids = "'{}'";
            obj.in_excluded_last_service = "null";
            DataTable dtExpected = new DataTable();
            DataTable dtResult = objBegin.Targeting(obj);
            DataTable expectedValue = objBegin.GetEmailTargetCountWithSpeciesBreedAgeAndLastVisitRangeIncludedService("2882", "'{3,7}'", "'{3531346,4994701,1647936,4016004,3019668,3266186,6797245}'", "'1 month'", "'200 months'", "'2010-01-01'", "'2018-01-01'", "'{39235137,77048018,63693452,25153625,25153576,25153579,25153578,67905913,120110531,77048018,25153625}'", null, true);
            Assert.AreEqual(expectedValue.Rows.Count, dtResult.Rows.Count);
        }
        [TestMethod]
        public void email_target_return_true_if_species_Breed_age_last_visit_range_Inclusion_services_with_selected_all_services()
        {
            BeginTestCases objBegin = new BeginTestCases();
            CustomEmail3_Targeting obj = new CustomEmail3_Targeting();
            obj.in_hid = 2882;
            obj.in_editor_verion_id = 3;
            obj.in_marketing_msg_id = 82904;
            obj.in_species_ids = "'{3,7}'";
            obj.is_other_species = false;
            obj.is_all_breed = false;
            obj.in_breed_ids = "'{3531346,4994701,1647936,4016004,3019668,3266186,6797245}'";
            obj.in_is_age_in_range = true;
            obj.in_is_specific_age = false;
            obj.in_specific_age = "null";
            obj.in_age_range_from = "'1 month'";
            obj.in_age_range_to = "'200 months'";
            obj.in_last_service = "null";
            obj.in_last_service_from = "'2010-01-01'";
            obj.in_last_service_to = "'2018-01-01'";
            obj.in_included_service_ids = "'{39235137,77048018,63693452,25153625,25153576,25153579,25153578,67905913,120110531,77048018,25153625}'";
            obj.in_match_any_included_service = false;
            obj.in_match_any_excluded_service = true;
            obj.in_included_last_service = "null";
            obj.in_excluded_service_ids = "'{}'";
            obj.in_excluded_last_service = "null";
            DataTable dtExpected = new DataTable();
            DataTable dtResult = objBegin.Targeting(obj);
            DataTable expectedValue = objBegin.GetEmailTargetCountWithSpeciesBreedAgeAndLastVisitRangeIncludedService("2882", "'{3,7}'", "'{3531346,4994701,1647936,4016004,3019668,3266186,6797245}'", "'1 month'", "'200 months'", "'2010-01-01'", "'2018-01-01'", "'{39235137,77048018,63693452,25153625,25153576,25153579,25153578,67905913,120110531,77048018,25153625}'", null, false);
            Assert.AreEqual(expectedValue.Rows.Count, dtResult.Rows.Count);
        }
        [TestMethod]
        public void email_target_return_true_if_species_Breed_age_last_visit_range_Inclusion_services_with_selected_any_services_and_last_used_services()
        {
            BeginTestCases objBegin = new BeginTestCases();
            CustomEmail3_Targeting obj = new CustomEmail3_Targeting();
            obj.in_hid = 2882;
            obj.in_editor_verion_id = 3;
            obj.in_marketing_msg_id = 82904;
            obj.in_species_ids = "'{3,7}'";
            obj.is_other_species = false;
            obj.is_all_breed = false;
            obj.in_breed_ids = "'{3531346,4994701,1647936,4016004,3019668,3266186,6797245}'";
            obj.in_is_age_in_range = true;
            obj.in_is_specific_age = false;
            obj.in_specific_age = "null";
            obj.in_age_range_from = "'1 month'";
            obj.in_age_range_to = "'200 months'";
            obj.in_last_service = "null";
            obj.in_last_service_from = "'2010-01-01'";
            obj.in_last_service_to = "'2018-01-01'";
            obj.in_included_service_ids = "'{39235137,77048018,63693452,25153625,25153576,25153579,25153578,67905913,120110531,77048018,25153625}'";
            obj.in_match_any_included_service = true;
            obj.in_match_any_excluded_service = true;
            obj.in_included_last_service = "'200 months'";
            obj.in_excluded_service_ids = "'{}'";
            obj.in_excluded_last_service = "null";
            DataTable dtExpected = new DataTable();
            DataTable dtResult = objBegin.Targeting(obj);
            DataTable expectedValue = objBegin.GetEmailTargetCountWithSpeciesBreedAgeAndLastVisitRangeIncludedService("2882", "'{3,7}'", "'{3531346,4994701,1647936,4016004,3019668,3266186,6797245}'", "'1 month'", "'200 months'", "'2010-01-01'", "'2018-01-01'", "'{39235137,77048018,63693452,25153625,25153576,25153579,25153578,67905913,120110531,77048018,25153625}'", "'200 months'", true);
            Assert.AreEqual(expectedValue.Rows.Count, dtResult.Rows.Count);
        }
        [TestMethod]
        public void email_target_return_true_if_species_Breed_age_last_visit_range_Inclusion_services_with_selected_all_services_and_last_used_services()
        {
            BeginTestCases objBegin = new BeginTestCases();
            CustomEmail3_Targeting obj = new CustomEmail3_Targeting();
            obj.in_hid = 2882;
            obj.in_editor_verion_id = 3;
            obj.in_marketing_msg_id = 82904;
            obj.in_species_ids = "'{3,7}'";
            obj.is_other_species = false;
            obj.is_all_breed = false;
            obj.in_breed_ids = "'{3531346,4994701,1647936,4016004,3019668,3266186,6797245}'";
            obj.in_is_age_in_range = true;
            obj.in_is_specific_age = false;
            obj.in_specific_age = "null";
            obj.in_age_range_from = "'1 month'";
            obj.in_age_range_to = "'200 months'";
            obj.in_last_service = "null";
            obj.in_last_service_from = "'2010-01-01'";
            obj.in_last_service_to = "'2018-01-01'";
            obj.in_included_service_ids = "'{39235137,77048018,63693452,25153625,25153576,25153579,25153578,67905913,120110531,77048018,25153625}'";
            obj.in_match_any_included_service = false;
            obj.in_match_any_excluded_service = true;
            obj.in_included_last_service = "'200 months'";
            obj.in_excluded_service_ids = "'{}'";
            obj.in_excluded_last_service = "null";
            DataTable dtExpected = new DataTable();
            DataTable dtResult = objBegin.Targeting(obj);
            DataTable expectedValue = objBegin.GetEmailTargetCountWithSpeciesBreedAgeAndLastVisitRangeIncludedService("2882", "'{3,7}'", "'{3531346,4994701,1647936,4016004,3019668,3266186,6797245}'", "'1 month'", "'200 months'", "'2010-01-01'", "'2018-01-01'", "'{39235137,77048018,63693452,25153625,25153576,25153579,25153578,67905913,120110531,77048018,25153625}'", "'200 months'", false);
            Assert.AreEqual(expectedValue.Rows.Count, dtResult.Rows.Count);
        }
        #endregion

        #region Exclusion List

        [TestMethod]
        public void email_target_return_true_if_species_Breed_age_last_visit_range_exclusion_services_with_selected_any_services()
        {
            BeginTestCases objBegin = new BeginTestCases();
            CustomEmail3_Targeting obj = new CustomEmail3_Targeting();
            obj.in_hid = 2882;
            obj.in_editor_verion_id = 3;
            obj.in_marketing_msg_id = 82904;
            obj.in_species_ids = "'{3,7}'";
            obj.is_other_species = false;
            obj.is_all_breed = false;
            obj.in_breed_ids = "'{3531346,4994701,1647936,4016004,3019668,3266186,6797245}'";
            obj.in_is_age_in_range = true;
            obj.in_is_specific_age = false;
            obj.in_specific_age = "null";
            obj.in_age_range_from = "'1 month'";
            obj.in_age_range_to = "'200 months'";
            obj.in_last_service = "null";
            obj.in_last_service_from = "'2010-01-01'";
            obj.in_last_service_to = "'2018-01-01'";
            obj.in_included_service_ids = "'{}'";
            obj.in_match_any_included_service = true;
            obj.in_match_any_excluded_service = true;
            obj.in_included_last_service = "null";
            obj.in_excluded_service_ids = "'{39235137,77048018,63693452,25153625,25153576,25153579,25153578,67905913,120110531,77048018,25153625}'";
            obj.in_excluded_last_service = "null";
            DataTable dtExpected = new DataTable();
            DataTable dtResult = objBegin.Targeting(obj);
            DataTable expectedValue = objBegin.GetEmailTargetCountWithSpeciesBreedAgeAndLastVisitRangeExcludedService("2882", "'{3,7}'", "'{3531346,4994701,1647936,4016004,3019668,3266186,6797245}'", "'1 month'", "'200 months'", "'2010-01-01'", "'2018-01-01'", "'{39235137,77048018,63693452,25153625,25153576,25153579,25153578,67905913,120110531,77048018,25153625}'", null, true);
            Assert.AreEqual(expectedValue.Rows.Count, dtResult.Rows.Count);
        }
        [TestMethod]
        public void email_target_return_true_if_species_Breed_age_last_visit_range_exclusion_services_with_selected_all_services()
        {
            BeginTestCases objBegin = new BeginTestCases();
            CustomEmail3_Targeting obj = new CustomEmail3_Targeting();
            obj.in_hid = 2882;
            obj.in_editor_verion_id = 3;
            obj.in_marketing_msg_id = 82904;
            obj.in_species_ids = "'{3,7}'";
            obj.is_other_species = false;
            obj.is_all_breed = false;
            obj.in_breed_ids = "'{3531346,4994701,1647936,4016004,3019668,3266186,6797245}'";
            obj.in_is_age_in_range = true;
            obj.in_is_specific_age = false;
            obj.in_specific_age = "null";
            obj.in_age_range_from = "'1 month'";
            obj.in_age_range_to = "'200 months'";
            obj.in_last_service = "null";
            obj.in_last_service_from = "'2010-01-01'";
            obj.in_last_service_to = "'2018-01-01'";
            obj.in_included_service_ids = "'{}'";
            obj.in_match_any_included_service = true;
            obj.in_match_any_excluded_service = false;
            obj.in_included_last_service = "null";
            obj.in_excluded_service_ids = "'{39235137,77048018,63693452,25153625,25153576,25153579,25153578,67905913,120110531,77048018,25153625}'";
            obj.in_excluded_last_service = "null";
            DataTable dtExpected = new DataTable();
            DataTable dtResult = objBegin.Targeting(obj);
            DataTable expectedValue = objBegin.GetEmailTargetCountWithSpeciesBreedAgeAndLastVisitRangeExcludedService("2882", "'{3,7}'", "'{3531346,4994701,1647936,4016004,3019668,3266186,6797245}'", "'1 month'", "'200 months'", "'2010-01-01'", "'2018-01-01'", "'{39235137,77048018,63693452,25153625,25153576,25153579,25153578,67905913,120110531,77048018,25153625}'", null, false);
            Assert.AreEqual(expectedValue.Rows.Count, dtResult.Rows.Count);
        }
        [TestMethod]
        public void email_target_return_true_if_species_Breed_age_last_visit_range_exclusion_services_with_selected_any_services_and_last_used_services()
        {
            BeginTestCases objBegin = new BeginTestCases();
            CustomEmail3_Targeting obj = new CustomEmail3_Targeting();
            obj.in_hid = 2882;
            obj.in_editor_verion_id = 3;
            obj.in_marketing_msg_id = 82904;
            obj.in_species_ids = "'{3,7}'";
            obj.is_other_species = false;
            obj.is_all_breed = false;
            obj.in_breed_ids = "'{3531346,4994701,1647936,4016004,3019668,3266186,6797245}'";
            obj.in_is_age_in_range = true;
            obj.in_is_specific_age = false;
            obj.in_specific_age = "null";
            obj.in_age_range_from = "'1 month'";
            obj.in_age_range_to = "'200 months'";
            obj.in_last_service = "null";
            obj.in_last_service_from = "'2010-01-01'";
            obj.in_last_service_to = "'2018-01-01'";
            obj.in_included_service_ids = "'{}'";
            obj.in_match_any_included_service = true;
            obj.in_match_any_excluded_service = true;
            obj.in_included_last_service = "null";
            obj.in_excluded_service_ids = "'{39235137,77048018,63693452,25153625,25153576,25153579,25153578,67905913,120110531,77048018,25153625}'";
            obj.in_excluded_last_service = "'200 months'";
            DataTable dtExpected = new DataTable();
            DataTable dtResult = objBegin.Targeting(obj);
            DataTable expectedValue = objBegin.GetEmailTargetCountWithSpeciesBreedAgeAndLastVisitRangeExcludedService("2882", "'{3,7}'", "'{3531346,4994701,1647936,4016004,3019668,3266186,6797245}'", "'1 month'", "'200 months'", "'2010-01-01'", "'2018-01-01'", "'{39235137,77048018,63693452,25153625,25153576,25153579,25153578,67905913,120110531,77048018,25153625}'", "'200 months'", true);
            Assert.AreEqual(expectedValue.Rows.Count, dtResult.Rows.Count);
        }
        [TestMethod]
        public void email_target_return_true_if_species_Breed_age_last_visit_range_exclusion_services_with_selected_all_services_and_last_used_services()
        {
            BeginTestCases objBegin = new BeginTestCases();
            CustomEmail3_Targeting obj = new CustomEmail3_Targeting();
            obj.in_hid = 2882;
            obj.in_editor_verion_id = 3;
            obj.in_marketing_msg_id = 82904;
            obj.in_species_ids = "'{3,7}'";
            obj.is_other_species = false;
            obj.is_all_breed = false;
            obj.in_breed_ids = "'{3531346,4994701,1647936,4016004,3019668,3266186,6797245}'";
            obj.in_is_age_in_range = true;
            obj.in_is_specific_age = false;
            obj.in_specific_age = "null";
            obj.in_age_range_from = "'1 month'";
            obj.in_age_range_to = "'200 months'";
            obj.in_last_service = "null";
            obj.in_last_service_from = "'2010-01-01'";
            obj.in_last_service_to = "'2018-01-01'";
            obj.in_included_service_ids = "'{}'";
            obj.in_match_any_included_service = true;
            obj.in_match_any_excluded_service = false;
            obj.in_included_last_service = "null";
            obj.in_excluded_service_ids = "'{39235137,77048018,63693452,25153625,25153576,25153579,25153578,67905913,120110531,77048018,25153625}'";
            obj.in_excluded_last_service = "'200 months'";
            DataTable dtExpected = new DataTable();
            DataTable dtResult = objBegin.Targeting(obj);
            DataTable expectedValue = objBegin.GetEmailTargetCountWithSpeciesBreedAgeAndLastVisitRangeExcludedService("2882", "'{3,7}'", "'{3531346,4994701,1647936,4016004,3019668,3266186,6797245}'", "'1 month'", "'200 months'", "'2010-01-01'", "'2018-01-01'", "'{39235137,77048018,63693452,25153625,25153576,25153579,25153578,67905913,120110531,77048018,25153625}'", "'200 months'", false);
            Assert.AreEqual(expectedValue.Rows.Count, dtResult.Rows.Count);
        }

        #endregion

        #endregion

        #region PATIENTS_DECEASED_CHECK_TESTS
        [TestMethod]
        public void check_patient_deceased_returns_false_if_patient_IS_ACTIVE()
        {
            BeginTestCases obj = new BeginTestCases();
            int hid = 2882;
            long patientId = 125063736;
            long clientId = 46127152;


            var result = obj.Patient_Deceased_Check(hid, patientId, clientId);
            Assert.AreEqual(0, result);
        }
        [TestMethod]
        public void check_patient_deceased_returns_false_if_patient_deceased_date_is_NULL()
        {

            BeginTestCases obj = new BeginTestCases();
            int hid = 2882;
            long patientId = 164445456;
            long clientId = 96772283;

            var result = obj.Patient_Deceased_Check(hid, patientId, clientId);
            Assert.AreEqual(0, result);
        }
        [TestMethod]
        public void check_patient_deceased_returns_true_if_patient_deceased_date_IS_NOT_NULL()
        {

            BeginTestCases obj = new BeginTestCases();
            int hid = 2882;
            long patientId = 42266190;
            long clientId = 25678699;

            var result = obj.Patient_Deceased_Check(hid, patientId, clientId);
            Assert.AreEqual(1, result);
        }
        [TestMethod]
        public void check_patient_deceased_returns_true_if_patient_is_NOT_ACTIVE()
        {

            BeginTestCases obj = new BeginTestCases();
            int hid = 2882;
            long patientId = 95417039;
            long clientId = 42686444;

            var result = obj.Patient_Deceased_Check(hid, patientId, clientId);
            Assert.AreEqual(1, result);
        }
        [TestMethod]
        public void check_patient_deceased_returns_true_if_patient_IS_ACTIVE_and_deceased_date_is_NOT_NULL()
        {

            BeginTestCases obj = new BeginTestCases();
            int hid = 2882;
            long patientId = 95417041;
            long clientId = 42686444;

            var result = obj.Patient_Deceased_Check(hid, patientId, clientId);
            Assert.AreEqual(1, result);
        }
        #endregion
    }
}
