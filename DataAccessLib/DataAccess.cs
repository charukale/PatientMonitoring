//============================================================================
//
// COPYRIGHT KONINKLIJKE PHILIPS ELECTRONICS N.V. 2019
// All rights are reserved. Reproduction in whole or in part is
// prohibited without the written consent of the copyright owner.
//
//============================================================================ 
using System.Collections.Generic;
using DataAccessContractLib;
using VitalSignLib;
using EnableVitalSignLib;
using PatientVitalSignWriterLib;

namespace DataAccessLib
{
    //This is data access layer 
    //every operation related to dataStorage will go thru this layer.
    public class DataAccess : IDataAccess
    {
        public void EnableVitalSignForPatient(string m_patientId, List<VitalSign> m_vitalSigns)
        {
            EnableVitalSign m_enabler = new EnableVitalSign();
            m_enabler.EnableVitalSignForPatient(m_patientId, m_vitalSigns);
        }

        public string ReadPatientVitalSigns(string m_patientId)
        {
            PatientVitalSignReaderLib.PatientVitalSignReader m_reader = new PatientVitalSignReaderLib.PatientVitalSignReader();
            return m_reader.ReadPatientVitalSigns(m_patientId);
        }

        public void StorePatientVitalSigns(string m_patientId, string m_jsonData)
        {
            PatientVitalSignWriter m_writer = new PatientVitalSignWriter();
            m_writer.StorePatientVitalSigns(m_patientId, m_jsonData);
        }
    }
}
