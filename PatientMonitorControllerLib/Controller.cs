//============================================================================
//
// COPYRIGHT KONINKLIJKE PHILIPS ELECTRONICS N.V. 2019
// All rights are reserved. Reproduction in whole or in part is
// prohibited without the written consent of the copyright owner.
//
//============================================================================ 
using System.Collections.Generic;
using PatientMonitorLib;
using EnableVitalSignLib;
using PatientMonitorControllerContractLib;
using VitalSignLib;
using PatientVitalSignWriterContractLib;
using PatientVitalSignWriterLib;

namespace ControllerLib
{
    //This is Patient Monitor service 
    //This exposes GenerateVitalSignAsJson.
    //It Generate vital sign for patient in json format
    public class Controller : IController
    {
        readonly PatientMonitor m_patientMonitor = new PatientMonitor();
        readonly EnableVitalSign m_vitalSignEnabler = new EnableVitalSign();
        readonly IPatientVitalSignWriter m_vitalSignWriter = new PatientVitalSignWriter();
        #region PatientMonitor Public Methods
        public string GenerateVitalSignAsJson(string m_patientId)
        {
            return m_patientMonitor.GenerateVitalSignAsJson(m_patientId);
        }
        public void EnableVitalSignForPatient(string m_patientId, List<VitalSign> m_vitalSigns)
        {
            m_vitalSignEnabler.EnableVitalSignForPatient(m_patientId, m_vitalSigns);
        }
        public void StorePatientVitalSignsInDB(string m_patientId, string m_jsonData)
        {
            m_vitalSignWriter.StorePatientVitalSigns(m_patientId, m_jsonData);
        }
        #endregion
    }
}
