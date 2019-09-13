//============================================================================
//
// COPYRIGHT KONINKLIJKE PHILIPS ELECTRONICS N.V. 2019
// All rights are reserved. Reproduction in whole or in part is
// prohibited without the written consent of the copyright owner.
//
//============================================================================ 

using System.Collections.Generic;
using EnableVitalSignContractLib;
using DataStoreLib;
using VitalSignLib;

namespace EnableVitalSignLib
{
    //This class will have information of enabled of disable vitals sign.
    public class EnableVitalSign : IEnableVitalSign
    {
        public void EnableVitalSignForPatient(string m_patientId, List<VitalSign> m_vitalSigns)
        {
            if (DataStore.dictPatientVitalSignEnabledMap.ContainsKey(m_patientId))
            {
                DataStore.dictPatientVitalSignEnabledMap.Remove(m_patientId);
            }
            //Store the list of enabled/disabled vital sign for m_patientId in dataStorage.
            DataStore.dictPatientVitalSignEnabledMap.Add(m_patientId, m_vitalSigns);
        }
    }
}
