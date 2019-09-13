//============================================================================
//
// COPYRIGHT KONINKLIJKE PHILIPS ELECTRONICS N.V. 2019
// All rights are reserved. Reproduction in whole or in part is
// prohibited without the written consent of the copyright owner.
//
//============================================================================ 
using System.ServiceModel;

namespace ValidatePatientVitalSignContractLib
{
    [ServiceContract]
    public interface IValidateVitalSign
    {
        [OperationContract]
        string ValidateVitalSign(string m_patientId, string m_vitalSignValue);
        [OperationContract]
        bool IsVitalSignInRange(int m_value);


    }
}
