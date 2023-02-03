using Agenda_Consultorio_Odontologico.model;
using Agenda_Consultorio_Odontologico.view.appointment;
using Agenda_Consultorio_Odontologico.view.appointmentInterface;
using System;

namespace Agenda_Consultorio_Odontologico.controller.appointment
{
    public class AppointmentDeleteController
    {
        AppointmentDeleteInterface adi = new();
        Appointment? appointment;
        bool hasConflit = false;
        public void DeleteAppointment()
        {
            adi.GetInformation();
            CheckDate();        
            CheckCPF();
            CheckAppointmentDateAndHour();
            if (!hasConflit)
            {
                using var context = new ConsultorioContext();
                context.Appointments.Remove(appointment);
                context.SaveChanges();
                adi.SuccessMessage();
            }
        }
        public void CheckDate()
        {
            bool parseSuccess = DateTime.TryParse(adi.InputDate, out DateTime outputDate);
            if (parseSuccess)
            {
                if (outputDate < DateTime.Today)
                {
                    adi.ErrorMessages(0);
                    hasConflit = true;
                }
                else if (outputDate == DateTime.Today) CheckHour(); 
            }
            else
            {
                adi.ErrorMessages(1);
                hasConflit = true;
            }
        }
        public void CheckHour()
        {
            bool parseSuccess = int.TryParse(adi.InputStart, out int outputStart);
            if (parseSuccess)
            {
                if(outputStart < DateTime.Today.Hour) 
                { 
                    adi.ErrorMessages(0);
                    hasConflit = true;
                }
            }
            else
            {
                adi.ErrorMessages(2);
                hasConflit = true;
            }
        }
        public void CheckCPF()
        {
            List<Appointment> list = new();
            bool parseSuccess = long.TryParse(adi.InputCPF, out long outputCPF);
            if (parseSuccess)
            {
                using var context = new ConsultorioContext();
                var appointments = context.Appointments.ToList();
                for (int i = 0; i < appointments.Count; i++)
                {
                    Appointment appointment = appointments[i];
                    if (appointment.Patient.CPF.Equals(outputCPF))
                    {
                        list.Add(appointment);
                    }
                }
                if (list.Count == 0)
                {
                    adi.ErrorMessages(3);
                    hasConflit = true;
                }
            }
        }
        public void CheckAppointmentDateAndHour()
        {
            bool parseSuccess = DateTime.TryParse(adi.InputDate, out DateTime outputDate);
            List<Appointment> list = new();
            if (parseSuccess)
            {
                using var context = new ConsultorioContext();
                var appointments = context.Appointments.ToList();
                for (int i = 0; i < appointments.Count; i++)
                {
                    Appointment a = appointments[i];
                    if (a.Date.Day == outputDate.Day)
                    {
                        if (a.Start.ToString("0000") == adi.InputStart)
                        {
                            list.Add(a);
                            appointment = a;
                        }
                    }
                }
                if (list.Count == 0)
                    {
                        adi.ErrorMessages(4);
                        hasConflit = true;
                    }    
            }
        }
    }
}
