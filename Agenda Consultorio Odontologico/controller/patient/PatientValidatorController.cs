using Agenda_Consultorio_Odontologico.model;
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
            pri.GetName();
            pri.GetCPF();
            pri.GetDate(); 
            pri.ShowData();
            NameValidate();
            CPFValidate(); 
            BirthDateValidate();
        }
        public void NameValidate()
        {
            switch (pri.InputName.Length)
            {
                case 0:
                    pri.ErrorMessages(0);
                    pri.GetName();
                    NameValidate();
                    break;
                case < 5:
                    pri.ErrorMessages(1);
                    pri.GetName();
                    NameValidate();
                    break;
                case >= 5:
                    name = pri.InputName;
                    break;
            }
        }
        public void CPFValidate()
        {
            switch (pri.InputCPF.Length) 
            {
                case 11:
                    bool parseSuccess = long.TryParse(pri.InputCPF, out long outputCPF);
                    if (parseSuccess)
                    {
                        CPFValidateAllSameNumber(outputCPF);
                    }
                    else
                    {
                        pri.ErrorMessages(2);
                        pri.GetCPF();
                        CPFValidate();
                    }
                    break;
                default:
                    pri.ErrorMessages(2);
                    pri.GetCPF();
                    CPFValidate();
                    break;
            }
        }
        public void CPFValidateAllSameNumber(long outputCPF) 
        {
            long[] list = { 11111111111, 22222222222, 33333333333, 44444444444, 55555555555, 66666666666, 77777777777, 88888888888, 99999999999 };
            if(list.Contains(outputCPF))
            {
                pri.ErrorMessages(2);
                pri.GetCPF();
                CPFValidate();
            }                          
            else CPFAlreadyInTheListValidate(outputCPF);
        }
        public void CPFAlreadyInTheListValidate(long outputCPF)
        {
            using var context = new ConsultorioContext();
            var patients = context.Patients.ToList();
            int count = patients.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    Patient patient = patients[i];
                    if (patient.CPF == outputCPF)
                    {
                        pri.ErrorMessages(3);
                        pri.GetCPF();
                        CPFValidate();
                    }
                    else
                    {
                        cpf = outputCPF;
                    }
                }
            }
            else
            {
                cpf = outputCPF;
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
                    using var context = new ConsultorioContext();
                    Patient patient = new();
                    patient.Name = name; patient.CPF = cpf; patient.BirthDate = birthDate;
                    context.Patients.Add(patient);
                    context.SaveChanges();
                    pri.SuccessMessage();
                }
                else
                {
                    pri.ErrorMessages(4);
                    pri.GetDate();
                    BirthDateValidate();
                }
            }
            else
            {
                pri.ErrorMessages(5);
                pri.GetDate();
                BirthDateValidate();
            }
        }
    }
}
