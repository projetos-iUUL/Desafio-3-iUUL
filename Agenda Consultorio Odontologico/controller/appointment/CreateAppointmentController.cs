using Agenda_Consultorio_Odontologico.model;
using Agenda_Consultorio_Odontologico.view.appointmentInterface;
using Agenda_Consultorio_Odontologico.data;
using System;
using System.Collections.Generic;

namespace Agenda_Consultorio_Odontologico.controller.appointmentControllers
{
    public class CreateAppointmentController
    {
        public DateTime date { get; set; }
        public int start { get; set; }
        public int end { get; set; }
        public Patient patient { get; set; }
        private bool hasConflit { get; set; }

        public CreateAppointmentController()
        {
            hasConflit = false;
        }


        public bool ValidateAppointment()
        {
            AppointmentForm appointmentForm = new();

            appointmentForm.Form();

            appointmentForm.ShowData();

            IsPatientCPF(appointmentForm);
            IsDate(appointmentForm);
            IsStart(appointmentForm);
            IsEnd(appointmentForm);
            IsFutureAppointment(appointmentForm);
            IsOverlappingAppointment(appointmentForm);

            return hasConflit;
        }
        internal void CreateAppointment()
        {
            using var context = new ConsultorioContext();
            Appointment appointment = new();
            appointment.Start = start; appointment.End = end; appointment.Date = date; appointment.Patient = patient;
            context.Appointments.Add(appointment);
            context.SaveChanges();
        }





        /************************
         * FUNÇÕES DE VALIDAÇÃO *
         ***********************/
        private void IsPatientCPF(AppointmentForm appointmentForm)
        {
            List<Patient> list = new();
            bool parseSuccess = long.TryParse(appointmentForm.InputCPF, out long outputCPF);
            if (parseSuccess)
            {
                using var context = new ConsultorioContext();
                var patients = context.Patients.ToList();
                for (int i = 0; i < patients.Count; i++)
                {
                    Patient p = patients[i];
                    if (p.CPF == outputCPF)
                    {
                        list.Add(p);
                        patient = p;
                    }
                }
                if (list.Count == 0)
                {
                    appointmentForm.ErrorMessages(0);
                    appointmentForm.GetPatientCPF();
                    IsPatientCPF(appointmentForm);
                }
            }
            else
            {
                appointmentForm.ErrorMessages(1);
                appointmentForm.GetPatientCPF();
                IsPatientCPF(appointmentForm);
            }
        }
        private void IsDate(AppointmentForm appointmentForm)
        {
            DateTime today = DateTime.Today;
            bool parseSuccess = DateTime.TryParse(appointmentForm.InputDate, out DateTime outputDate);
            if (parseSuccess)
            {
                if (outputDate >= today)
                {
                    date = outputDate;
                }
                else
                {
                    appointmentForm.ErrorMessages(2);
                    appointmentForm.GetDate();
                    IsDate(appointmentForm);
                }
            }
            else
            {
                appointmentForm.ErrorMessages(3);
                appointmentForm.GetDate();
                IsDate(appointmentForm);
            }
        }
        private void IsStart(AppointmentForm appointmentForm)
        {
            if (appointmentForm.InputStart.Length > 0 && appointmentForm.InputStart.Length < 5)
            {
                IsStartHourFormat(appointmentForm);
                bool parseSuccess = int.TryParse(appointmentForm.InputStart, out int outputStart);
                if (parseSuccess)
                {
                    if (outputStart > 0800 && outputStart < 1846)
                    {
                        start = outputStart;
                    }
                    else
                    {
                        appointmentForm.ErrorMessages(4);
                        appointmentForm.GetStart();
                        IsStart(appointmentForm);
                    }
                }
            }
            else
            {
                appointmentForm.ErrorMessages(5);
                appointmentForm.GetStart();
                IsStart(appointmentForm);
            }
        }
        private void IsEnd(AppointmentForm appointmentForm)
        {
            if (appointmentForm.InputEnd.Length > 0 && appointmentForm.InputEnd.Length < 5)
            {
                IsEndHourFormat(appointmentForm);
                bool parseSuccess = int.TryParse(appointmentForm.InputEnd, out int outputEnd);
                if (parseSuccess)
                {
                    if (outputEnd > start)
                    {
                        if (outputEnd > 0815 && outputEnd < 1901)
                        {
                            end = outputEnd;
                        }
                        else
                        {
                            appointmentForm.ErrorMessages(6);
                            appointmentForm.GetEnd();
                            IsEnd(appointmentForm);
                        }
                    }
                    else
                    {
                        appointmentForm.ErrorMessages(7);
                        appointmentForm.GetEnd();
                        IsEnd(appointmentForm);
                    }
                }
            }
            else
            {
                appointmentForm.ErrorMessages(8);
                appointmentForm.GetEnd();
                IsEnd(appointmentForm);
            }
        }
        private void IsFutureAppointment(AppointmentForm appointmentForm)
        {
            using var context = new ConsultorioContext();
            var appointments = context.Appointments.ToList();
            for (int i = 0; i < appointments.Count; i++)
            {
                Appointment appointment = appointments[i];
                if (DateTime.Today.Day < appointment.Date.Day)
                {
                    if (appointment.Patient == patient)
                    {
                        appointmentForm.ErrorMessages(9);
                        hasConflit = true;
                        break;
                    }
                }
            }
        }
        private void IsOverlappingAppointment(AppointmentForm appointmentForm)
        {
            using var context = new ConsultorioContext();
            var appointments = context.Appointments.ToList();
            for (int i = 0; i < appointments.Count; i++)
            {
                Appointment appointment = appointments[i];
                if (appointment.Date.Year == date.Year && appointment.Date.Month == date.Month && appointment.Date.Day == date.Day)
                {
                    if ((start >= appointment.Start && start < appointment.End) || (end > appointment.Start && end <= appointment.End))
                    {
                        appointmentForm.ErrorMessages(10);
                        hasConflit = true;
                        break;
                    }
                }
            }
        }
        private void IsStartHourFormat(AppointmentForm appointmentForm)
        {
            char a = appointmentForm.InputStart[2];
            char b = appointmentForm.InputStart[3];
            if (int.TryParse(a.ToString(), out int n))
            {
                if (n > 5)
                {
                    appointmentForm.ErrorMessages(5);
                    appointmentForm.GetStart();
                    IsStart(appointmentForm);
                }
                else
                {
                    if (int.TryParse(b.ToString(), out int m))
                    {
                        if (!(m == 0 || m == 5))
                        {
                            appointmentForm.ErrorMessages(5);
                            appointmentForm.GetStart();
                            IsStart(appointmentForm);
                        }
                    }
                }
            }
        }
        private void IsEndHourFormat(AppointmentForm appointmentForm)
        {
            char a = appointmentForm.InputEnd[2];
            char b = appointmentForm.InputEnd[3];
            if (int.TryParse(a.ToString(), out int n))
            {
                if (n > 5)
                {
                    appointmentForm.ErrorMessages(8);
                    appointmentForm.GetEnd();
                    IsEnd(appointmentForm);
                }
                else
                {
                    if (int.TryParse(b.ToString(), out int m))
                    {
                        if (!(m == 0 || m == 5))
                        {
                            appointmentForm.ErrorMessages(8);
                            appointmentForm.GetEnd();
                            IsEnd(appointmentForm);
                        }
                    }
                }
            }
        }
        //$end
    }
}
