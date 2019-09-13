//============================================================================
//
// COPYRIGHT KONINKLIJKE PHILIPS ELECTRONICS N.V. 2019
// All rights are reserved. Reproduction in whole or in part is
// prohibited without the written consent of the copyright owner.
//
//============================================================================ 

using System.Collections.Generic;
using PatientVitalSignReaderContractLib;
using DataStoreLib;

namespace PatientVitalSignReaderLib
{
    //This class will Read the patient vital signs from DataStorage
    public class PatientVitalSignReader : IReader
    {
        public string ReadPatientVitalSigns(string m_patientId)
        {
            string m_jsonData = string.Empty;
            if (DataStore.DictPatientDataMap != null && DataStore.DictPatientDataMap.Count > 0)
            {
                //Queue<string> queuePatientData = GetQueueForPatient(m_patientId);
                ////If new patient comes a new queue will be created to store its vital signs
                ////If not then, old patient's queue will be fetched from data storage and new vitals will be store.
                //if (!DataStore.DictPatientDataMap.ContainsKey(m_patientId))
                //{
                //    queuePatientData = new Queue<string>();
                //    DataStore.DictPatientDataMap.Add(m_patientId, queuePatientData);
                //}
                //queuePatientData = DataStore.DictPatientDataMap[m_patientId];

                m_jsonData = GetPatientDataFromQueue(m_patientId);
            }
            return m_jsonData;
        }

        private Queue<string> GetQueueForPatient(string m_patientId)
        {
            Queue<string> queuePatientData = null;

            //If new patient comes a new queue will be created to store its vital signs
            //If not then, old patient's queue will be fetched from data storage and new vitals will be store.
            if (!DataStore.DictPatientDataMap.ContainsKey(m_patientId))
            {
                queuePatientData = new Queue<string>();
                DataStore.DictPatientDataMap.Add(m_patientId, queuePatientData);
            }
            queuePatientData = DataStore.DictPatientDataMap[m_patientId];

            return queuePatientData;
        }
        private string GetPatientDataFromQueue(string m_patientId)
        {
            string patientData = string.Empty;

            Queue<string> queuePatientData = GetQueueForPatient(m_patientId);

            patientData = (queuePatientData.Count > 0) ? queuePatientData.Dequeue() : string.Empty;

            return patientData;
        }
    }
}
