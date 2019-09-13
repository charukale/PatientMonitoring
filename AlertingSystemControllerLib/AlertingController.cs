//============================================================================
//
// COPYRIGHT KONINKLIJKE PHILIPS ELECTRONICS N.V. 2019
// All rights are reserved. Reproduction in whole or in part is
// prohibited without the written consent of the copyright owner.
//
//============================================================================ 
using AlertingSystemControllerContractLib;
using PatientVitalSignReaderLib;

namespace AlertingSystemControllerLib
{
    //This is Alerting Service 
    //It exposes ReadVitalSigns: It will read data from Datastorage
    //It exposes ValidatePulseRate,validateSpo2,ValidateTemperature
    // : It will validate Vital signs. is it in range, not ?
    public class AlertingController : IAlertingController
    {
        readonly PatientVitalSignReader reader = new PatientVitalSignReader();
        readonly ValidatePatientPulseRateLib.ValidatePatientPulseRate pulserateValidator = new ValidatePatientPulseRateLib.ValidatePatientPulseRate();
        readonly ValidatePatientSpo2Lib.ValidatePatientSpo2 spo2Validator = new ValidatePatientSpo2Lib.ValidatePatientSpo2();
        readonly ValidatePatientTemperatureLib.ValidatePatientTemperature temperatureValidator = new ValidatePatientTemperatureLib.ValidatePatientTemperature();
        public string ReadPatientVitalSigns(string m_patientId)
        {
            return reader.ReadPatientVitalSigns(m_patientId);
        }

        public string ValidatePulseRate(string m_patientId, string m_pulseRate)
        {
           return pulserateValidator.ValidateVitalSign(m_patientId,m_pulseRate);
        }

        public string ValidateSpo2(string m_patientId, string m_spo2)
        {
            return spo2Validator.ValidateVitalSign(m_patientId,m_spo2);
        }

        public string ValidateTemperature(string m_patientId, string m_temperature)
        {
            return temperatureValidator.ValidateVitalSign(m_patientId, m_temperature);
        }
    }
}
