//============================================================================
//
// COPYRIGHT KONINKLIJKE PHILIPS ELECTRONICS N.V. 2019
// All rights are reserved. Reproduction in whole or in part is
// prohibited without the written consent of the copyright owner.
//
//============================================================================ 
namespace GeneratePatientVitalSignContractLib
{
    public interface IVitalSignGenerator
    {
        double PatientVitalSignGenerator(string m_patientId);
    }
}
