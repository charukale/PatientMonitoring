@echo off
echo Building PatientMonitoring solution.
"C:\Program Files (x86)\Microsoft Visual Studio 14.0\Common7\IDE\devenv.exe" D:\MyExamples\PatientMonitoring\PatientMonitoring.sln /build "Debug|x86"
echo Build succeeded.
echo Running application
start D:\MyExamples\PatientMonitoring\PatientAlertingSystemHost\bin\Debug\PatientAlertingSystemHost.exe
echo Starting Unit test case execution.
"C:\Program Files (x86)\Microsoft Visual Studio 14.0\Common7\IDE\CommonExtensions\Microsoft\TestWindow\vstest.console.exe" D:\MyExamples\PatientMonitoring\AlertingController.Test\bin\Debug\AlertingController.Test.dll
"C:\Program Files (x86)\Microsoft Visual Studio 14.0\Common7\IDE\CommonExtensions\Microsoft\TestWindow\vstest.console.exe" D:\MyExamples\PatientMonitoring\AlertingSystem.Test\bin\Debug\AlertingSystem.Test.dll
"C:\Program Files (x86)\Microsoft Visual Studio 14.0\Common7\IDE\CommonExtensions\Microsoft\TestWindow\vstest.console.exe" D:\MyExamples\PatientMonitoring\DataStoreController.Test\bin\Debug\DataStoreController.Test.dll
"C:\Program Files (x86)\Microsoft Visual Studio 14.0\Common7\IDE\CommonExtensions\Microsoft\TestWindow\vstest.console.exe" D:\MyExamples\PatientMonitoring\PatientMonitoring.Test\bin\Debug\PatientMonitoring.Test.dll
"C:\Program Files (x86)\Microsoft Visual Studio 14.0\Common7\IDE\CommonExtensions\Microsoft\TestWindow\vstest.console.exe" D:\MyExamples\PatientMonitoring\PatientVitalSignWriter.Test\bin\Debug\PatientVitalSignWriter.Test.dll
"C:\Program Files (x86)\Microsoft Visual Studio 14.0\Common7\IDE\CommonExtensions\Microsoft\TestWindow\vstest.console.exe" D:\MyExamples\PatientMonitoring\PatientDbQuery.Test\bin\Debug\PatientDbQuery.Test.dll
pause