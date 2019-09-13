//============================================================================
//
// COPYRIGHT KONINKLIJKE PHILIPS ELECTRONICS N.V. 2019
// All rights are reserved. Reproduction in whole or in part is
// prohibited without the written consent of the copyright owner.
//
//============================================================================ 
using System.Collections.Generic;
using PatientVitalSignWriterContractLib;
using DataStoreLib;

namespace PatientVitalSignWriterLib
{
    //This writer class will write patient vital sign in storage 
    public class PatientVitalSignWriter : IPatientVitalSignWriter
    {
        public void StorePatientVitalSigns(string m_patientId, string m_jsonData)
        {
            if (DataStore.DictPatientDataMap != null)
            {
                Queue<string> m_queuePatientData = null;
                //Checks if patient already exist 
                //If new patient and create a new queue and enqueue vitalsigns in it.
                //Then push to storage in Dictionary. 
                if (!DataStore.DictPatientDataMap.ContainsKey(m_patientId))
                {
                    m_queuePatientData = new Queue<string>();
                    DataStore.DictPatientDataMap.Add(m_patientId, m_queuePatientData);
                }
                m_queuePatientData = DataStore.DictPatientDataMap[m_patientId];

                m_queuePatientData.Enqueue(m_jsonData);
            }
        }
    }
}
