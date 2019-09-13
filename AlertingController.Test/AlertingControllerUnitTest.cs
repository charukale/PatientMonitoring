//============================================================================
//
// COPYRIGHT KONINKLIJKE PHILIPS ELECTRONICS N.V. 2019
// All rights are reserved. Reproduction in whole or in part is
// prohibited without the written consent of the copyright owner.
//
//============================================================================ 
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PatientVitalSignWriterLib;

namespace AlertingController.Test
{
    [TestClass]
    //Test class for AlertingController
    // It checks readPatientVitalSign from storage.
    //It checks for validation of vitals signs
    public class AlertingControllerUnitTest
    {
        [TestMethod]
        public void Given_PatientId_When_ReadPatientVitalSigns_Invoke_Then_Valid_Result_Asserted()
        {
            PatientVitalSignWriter m_writer = new PatientVitalSignWriter();
            string m_expectedValue = "{patient id: Patient_123, SPO2: 99, Temp: 98, PulseRate: 94}";
            m_writer.StorePatientVitalSigns("Patient_123", m_expectedValue);

            AlertingSystemControllerLib.AlertingController m_alertControl = new AlertingSystemControllerLib.AlertingController();
            string m_actualValue = m_alertControl.ReadPatientVitalSigns("Patient_123");
            Assert.AreEqual(m_actualValue,m_expectedValue);
        }
        [TestMethod]
        public void Given_Valid_Argument_When_ValidatePulseRate_Invoke_Then_Valid_Result_Asserted()
        {
            AlertingSystemControllerLib.AlertingController m_validate = new AlertingSystemControllerLib.AlertingController();
            string m_actualValue = m_validate.ValidatePulseRate("Patient_123","10");
            string m_expectedValue = "Alert!!! Pulse Rate not in range Pulse Rate: 10 for patient: Patient_123";
            Assert.AreEqual(m_actualValue, m_expectedValue);
        }
        [TestMethod]
        public void Given_Valid_Argument_When_ValidateSpo2_Invoke_Then_Valid_Result_Asserted()
        {
            AlertingSystemControllerLib.AlertingController m_validate = new AlertingSystemControllerLib.AlertingController();
            string m_actualValue = m_validate.ValidateSpo2("Patient_123", "10");
            string m_expectedValue = "Alert!!! SPO2 not in range SPO2: 10 for patient: Patient_123";
            Assert.AreEqual(m_actualValue, m_expectedValue);
        }
        [TestMethod]
        public void Given_Valid_Argument_When_Temperature_Invoke_Then_Valid_Result_Asserted()
        {
            AlertingSystemControllerLib.AlertingController m_validate = new AlertingSystemControllerLib.AlertingController();
            string m_actualValue = m_validate.ValidateTemperature("Patient_123", "10");
            string m_expected = "Alert!!! Temperature not in range Temperature: 10 for patient Patient_123";
            Assert.AreEqual(m_actualValue, m_expected);
        }
    }
}
