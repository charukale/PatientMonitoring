//============================================================================
//
// COPYRIGHT KONINKLIJKE PHILIPS ELECTRONICS N.V. 2019
// All rights are reserved. Reproduction in whole or in part is
// prohibited without the written consent of the copyright owner.
//
//============================================================================ 
using GeneratePatientVitalSignContractLib;
using PatientSpo2GeneratorLib;
using PatientTemperatureGeneratorLib;
using PatientPulserateGeneratorLib;
using System;
using System.Reflection;

namespace FactoryLib
{
    //Factory will create object and gives.
    public static class Factory
    {
        static IVitalSignGenerator spo2Generator = new Spo2Generator();
        static IVitalSignGenerator pulserateGenerator = new PulserateGenerator();
        static IVitalSignGenerator temperatureGenerator = new TemperatureGenerator();
        //static object syncObject = new object();

        public static IVitalSignGenerator GetDataGenerator(VitalSignContractLib.VitalSignType type)
        {
            IVitalSignGenerator vitalSignGenerator = null;
            //lock (syncObject)
            //{
            switch (type)
            {
                case VitalSignContractLib.VitalSignType.SPO2:
                    {
                    //if (spo2Generator == null)
                    //{
                    //    spo2Generator = new Spo2Generator();
                    //}
                    vitalSignGenerator = spo2Generator;
                    }
                break;
                case VitalSignContractLib.VitalSignType.PulseRate:
                    {
                    //if (pulserateGenerator == null)
                    //{
                    //    pulserateGenerator = new PulserateGenerator();
                    //}
                    vitalSignGenerator = pulserateGenerator;
                    }
                break;
                case VitalSignContractLib.VitalSignType.Temp:
                    {
                    //if (temperatureGenerator == null)
                    //{
                    //    temperatureGenerator = new TemperatureGenerator();
                    //}
                    vitalSignGenerator = temperatureGenerator;
                    }
                break;
            }

            return vitalSignGenerator;

            //string assemblyName = "Patient" + type.ToString() + "GeneratorLib";
            //string className = type.ToString() + "Generator";

            //Assembly assembly = Assembly.Load(assemblyName);
            //Type generatorType = assembly.GetType(className);
            //object vitalSignGenerator = Activator.CreateInstance(generatorType);

            //return vitalSignGenerator as IVitalSignGenerator;
        }
    }
}
