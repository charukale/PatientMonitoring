//============================================================================
//
// COPYRIGHT KONINKLIJKE PHILIPS ELECTRONICS N.V. 2019
// All rights are reserved. Reproduction in whole or in part is
// prohibited without the written consent of the copyright owner.
//
//============================================================================ 
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PatientVitalSignWriterLib;
using PatientVitalSignReaderLib;

namespace DataStoreController.Test
{
    [TestClass]
    //Test class for DataStore Controller
    //It Test StorePatientVitalSigns method and checks if valid data stored it dataStorage or not.
    public class DataController
    {
        [TestMethod]
        public void Given_Valid_Arguments_When_StorePatientVitalSigns_Invoke_Then_Valid_Result_Asserted()
        {
            PatientVitalSignWriter m_writer = new PatientVitalSignWriter();
            string m_expectedValue = "{patient id: Patient_123, SPO2: 99, Temp: 98, PulseRate: 94}";
            m_writer.StorePatientVitalSigns("Patient_123", m_expectedValue);

            PatientVitalSignReader m_reader = new PatientVitalSignReader();
            string m_actualValue = m_reader.ReadPatientVitalSigns("Patient_123");
            Assert.AreEqual(m_actualValue, m_expectedValue);


        }
    }
}
