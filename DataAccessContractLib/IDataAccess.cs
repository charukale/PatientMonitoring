//============================================================================
//
// COPYRIGHT KONINKLIJKE PHILIPS ELECTRONICS N.V. 2019
// All rights are reserved. Reproduction in whole or in part is
// prohibited without the written consent of the copyright owner.
//
//============================================================================ 
using System.Collections.Generic;
using VitalSignLib;

namespace DataAccessContractLib
{
    public interface IDataAccess
    {
        void EnableVitalSignForPatient(string m_patientId, List<VitalSign> m_vitalSigns);
        void StorePatientVitalSigns(string m_patientId, string m_jsonData);
        string ReadPatientVitalSigns(string m_patientId);
    }
}
