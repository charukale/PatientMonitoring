//============================================================================
//
// COPYRIGHT KONINKLIJKE PHILIPS ELECTRONICS N.V. 2019
// All rights are reserved. Reproduction in whole or in part is
// prohibited without the written consent of the copyright owner.
//
//============================================================================ 
using PatientMonitorContractLib;
using System.Collections.Generic;
using System.Text;
using DataStoreLib;
using VitalSignLib;
using GeneratePatientVitalSignContractLib;
using FactoryLib;

namespace PatientMonitorLib
{
    //This will generate patient vital sign and will provide in Json Format...
    //It will take list of enabled/diabled vital signs from DataStore and will generate data 
    //according to enabled vital sign.
    public class PatientMonitor : IPatientMonitor
    {
        public string GenerateVitalSignAsJson(string m_patientId)
        {
            StringBuilder m_stringBuilder = new StringBuilder();
            double m_vitalSignValue = 0;

            //By default all vitals sign will be checked (enabled).
            //LstDefaultSign this property will give default list of vital sign 
            List<VitalSign> lstVitalSign = GetEnabledVitalSignForPatient(m_patientId);

            m_stringBuilder.Append("{patientId: " + m_patientId);

            foreach (VitalSign vitalSign in lstVitalSign)
            {
                if (vitalSign.IsPatientVitalSignEnabled)
                {
                    //It will take typeObj i.e spo2obj/pulserateObj/TemperatureObj
                    //on the basis of object type patientVitalSignGenerator will be called.
                    //vitalSignValue will take values of vital sign and append to stringBuilder.
                    IVitalSignGenerator typeObj = Factory.GetDataGenerator(vitalSign.VitalSignType);
                    m_vitalSignValue = typeObj.PatientVitalSignGenerator(m_patientId);
                }
                m_stringBuilder.Append(", " + vitalSign.VitalSignType.ToString() + ": " + m_vitalSignValue.ToString());
            }
            m_stringBuilder.Append("}");

            return m_stringBuilder.ToString();
        }
        private List<VitalSign> GetEnabledVitalSignForPatient(string m_patientId)
        {
            List<VitalSign> lstVitalSign = DataStore.dictPatientVitalSignEnabledMap.ContainsKey(m_patientId)
                ? DataStore.dictPatientVitalSignEnabledMap[m_patientId]
                : DataStore.LstDefaultVitalSign;

            return lstVitalSign;
        }
    }
}
