//============================================================================
//
// COPYRIGHT KONINKLIJKE PHILIPS ELECTRONICS N.V. 2019
// All rights are reserved. Reproduction in whole or in part is
// prohibited without the written consent of the copyright owner.
//
//============================================================================ 
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PatientMonitorLib;

namespace PatientMonitoring.Test
{
    [TestClass]
    //Test class for patientMonitoring
    public class PatientMonitoringUnitTest
    {
        [TestMethod]
        //It checks if there is any null in generated json
        
        public void Given_Patient_Id_When_GenerateVitalSignAsJson_Invoke_Then_Valid_Result_Asserted()
        {
            PatientMonitor m_patientMonitor = new PatientMonitor();
            string m_actualValue = m_patientMonitor.GenerateVitalSignAsJson("PatientId_23");
            string[] m_values = m_actualValue.Split(' ');
            //It checks there should be 8 entity in the json string
            Assert.AreEqual(8, m_values.Length);

            foreach (string value in m_values)
            {
                if(string.IsNullOrEmpty(value))
                {
                    Assert.Fail("Failed");
                }
            }
        }
        //[TestMethod]
        //public void Given_Patient_Id_When_GenerateVitalSignAsJson_Invoke_Then_InValid_Result_Asserted()
        //{
        //    PatientMonitor m_patientMonitor = new PatientMonitor();
        //    string m_actualValue = m_patientMonitor.GenerateVitalSignAsJson("PatientId_23");
        //    string[] m_values = m_actualValue.Split(':');
        //    //It checks there should be 8 entity in the json string
        //    Assert.AreEqual(6, m_values.Length);

        //    foreach (string value in m_values)
        //    {
        //        if (string.IsNullOrEmpty(value))
        //        {
        //            Assert.Fail("Failed");
        //        }
        //    }
       // }
    }
}
