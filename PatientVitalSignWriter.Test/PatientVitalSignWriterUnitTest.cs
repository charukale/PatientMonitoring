//============================================================================
//
// COPYRIGHT KONINKLIJKE PHILIPS ELECTRONICS N.V. 2019
// All rights are reserved. Reproduction in whole or in part is
// prohibited without the written consent of the copyright owner.
//
//============================================================================ 
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PatientVitalSignReaderLib;

namespace PatientVitalSignWriter.Test
{
    [TestClass]
    public class PatientVitalSignWriterUnitTest
    {
        [TestMethod]
        public void Given_PatientId_Along_With_Json_Data_When_Invoke_StorePatientVitalSignsInDB_Valid_Json_Stores_In_Queue()
        {
            PatientVitalSignWriterLib.PatientVitalSignWriter m_writer = new PatientVitalSignWriterLib.PatientVitalSignWriter();
            string m_expected = "{patient id: Patient_123, SPO2: 99, Temp: 98, PulseRate: 94}";
            m_writer.StorePatientVitalSigns("Patient_123", m_expected);

            PatientVitalSignReader reader = new PatientVitalSignReader();
            string ActualValue = reader.ReadPatientVitalSigns("Patient_123");
            Assert.AreEqual(ActualValue, m_expected);
        }
    }
}
