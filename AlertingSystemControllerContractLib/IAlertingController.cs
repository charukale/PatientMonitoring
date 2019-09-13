//============================================================================
//
// COPYRIGHT KONINKLIJKE PHILIPS ELECTRONICS N.V. 2019
// All rights are reserved. Reproduction in whole or in part is
// prohibited without the written consent of the copyright owner.
//
//============================================================================ 
using System.ServiceModel;

namespace AlertingSystemControllerContractLib
{
    [ServiceContract]
    public interface IAlertingController
    {
        [OperationContract]
        string ReadPatientVitalSigns(string m_patientId);
        [OperationContract]
        string ValidateSpo2(string m_patientId, string m_spo2);
        [OperationContract]
        string ValidatePulseRate(string m_patientId, string m_pulseRate);
        [OperationContract]
        string ValidateTemperature(string m_patientId, string m_temperature);
    }
}
