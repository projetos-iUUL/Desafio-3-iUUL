﻿using Agenda_Consultorio_Odontologico.model;
using Agenda_Consultorio_Odontologico.view.patientInterface;
using System;

namespace Agenda_Consultorio_Odontologico.controller.patientControllers
{
    public class PatientValidatorController
    {
        PatientRegistrationInterface pri = new();

        string name;
        long cpf;
        DateTime birthDate;
        public void PatientValidator()
        {
            pri.GetInformation();
            pri.ShowData();
            NameValidate();
        }
        public void NameValidate()
        {
            switch (pri.InputName.Length)
            {
                case 0:
                    pri.FailureMessage();
                    break;
                case < 5:
                    pri.FailureMessage();
                    break;
                case >= 5:
                    name = pri.InputName;
                    CPFValidate();
                    break;
            }
        }
        public void CPFValidate()
        {
            string inputCPF = pri.InputCPF;
            switch (inputCPF.Length)
            {
                case 11:
                    bool parseSuccess = long.TryParse(inputCPF, out long outputCPF);
                    if (parseSuccess)
                    {
                        CPFValidateAllSameNumber(outputCPF);
                    }
                    else
                    {
                        pri.FailureMessage();
                    }
                    break;
                default:
                    pri.FailureMessage();
                    break;
            }
        }
        public void CPFValidateAllSameNumber(long outputCPF)
        {
            switch (outputCPF)
            {
                case 11111111111:
                    pri.FailureMessage();
                    break;
                case 22222222222:
                    pri.FailureMessage();
                    break;
                case 33333333333:
                    pri.FailureMessage();
                    break;
                case 44444444444:
                    pri.FailureMessage();
                    break;
                case 55555555555:
                    pri.FailureMessage();
                    break;
                case 66666666666:
                    pri.FailureMessage();
                    break;
                case 77777777777:
                    pri.FailureMessage();
                    break;
                case 88888888888:
                    pri.FailureMessage();
                    break;
                case 99999999999:
                    pri.FailureMessage();
                    break;
                default:
                    CPFAlreadyInTheListValidate(outputCPF);
                    break;
            }
        }
        public void CPFAlreadyInTheListValidate(long outputCPF)
        {
            int count = Patient.PatientList.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    Patient patient = Patient.PatientList[i];
                    if (patient.CPF == outputCPF)
                    {
                        pri.FailureMessage();
                    }
                    else
                    {
                        cpf = outputCPF;
                        BirthDateValidate();
                    }
                }
            }
            else 
            {
                cpf = outputCPF;
                BirthDateValidate();
            }                      
        }
        public void BirthDateValidate()
        {
            DateTime now = DateTime.Now;
            TimeSpan fourteenYears = new TimeSpan(4748, 0, 0, 0);
            bool parseSuccess = DateTime.TryParse(pri.InputDate, out DateTime outputDate);
            if (parseSuccess)
            {
                TimeIntervalController timeInterval = new(outputDate, now);
                if (timeInterval.Duration > fourteenYears)
                {
                    birthDate = outputDate;
                    Patient patient = new(name, cpf, birthDate);
                    pri.SuccessMessage();
                }
                else
                {
                    pri.FailureMessage(); ;
                }
            }
            else
            {
                pri.FailureMessage();
            }
        }
    }
}
