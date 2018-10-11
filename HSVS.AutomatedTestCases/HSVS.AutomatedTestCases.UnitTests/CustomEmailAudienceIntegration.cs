using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HSVS.AutomatedTestCases.BusinessLogic;

namespace HSVS.AutomatedTestCases.UnitTests
{
    [TestClass]
    public class CustomEmailAudienceIntegration
    {
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

        [TestMethod]
        public void patient_age_check_returns_true_if_patient_age_meets_the_targeting_criteria()
        {
            //select * from campaign_targeting.patient_age_criteria_check(2882,287240615,'1 year','13 month')
            BeginTestCases obj = new BeginTestCases();
            int hid = 2882;
            long patientId = 287240615;
            string startInterval = "1 year";
            string endInterval = "13 month";
            var result = obj.Patient_Age_Criteria_Check(hid, patientId, startInterval, endInterval);
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void patient_age_check_returns_false_if_patient_age_does_not_meet_targeting_criteria()
        {
            
            BeginTestCases obj = new BeginTestCases();
            int hid = 2882;
            long patientId = 287240615;
            string startInterval = "2 month";
            string endInterval = "3 month";
            var result = obj.Patient_Age_Criteria_Check(hid, patientId, startInterval, endInterval);
            Assert.AreEqual(0, result);
        }
    }
}
