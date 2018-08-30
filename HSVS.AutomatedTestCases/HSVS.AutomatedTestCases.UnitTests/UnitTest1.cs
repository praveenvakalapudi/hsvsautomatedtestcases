using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HSVS.AutomatedTestCases.BusinessLogic;

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
    }
}
