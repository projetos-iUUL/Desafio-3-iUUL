using Agenda_Consultorio_Odontologico.data;
using Agenda_Consultorio_Odontologico.model;
using Agenda_Consultorio_Odontologico.view.appointment;
using Agenda_Consultorio_Odontologico.view.appointmentInterface;
using System;

namespace Agenda_Consultorio_Odontologico.controller.appointment
{
    public class DeleteAppointmentController
    {
        public Appointment appointment { get; set; }
        private bool hasConflit { get; set; }

        public DeleteAppointmentController()
        {
            hasConflit = false;
        }


        public bool ValidateAppointment()
        {
            DeleteAppointmentForm deletionForm = new();

            deletionForm.Form();
            IsDate(deletionForm);
            IsCPF(deletionForm);
            IsAppointmentDateAndHour(deletionForm);

            return hasConflit;
        }
        internal void RemoveAppointment()
        {
            using var context = new ConsultorioContext();
            context.Appointments.Remove(appointment);
            context.SaveChanges();
        }





        /*********************************
         * FUNÇÕES DE VALIDAÇÃO DE DADOS *
         ********************************/
        // DATA
        private void IsDate(DeleteAppointmentForm deletionForm)
        {
            bool parseSuccess = DateTime.TryParse(deletionForm.InputDate, out DateTime outputDate);
            if (parseSuccess)
            {
                if (outputDate < DateTime.Today)
                {
                    deletionForm.ErrorMessages(0);
                    hasConflit = true;
                }
                else if (outputDate == DateTime.Today)
                    IsHour(deletionForm);
            }
            else
            {
                deletionForm.ErrorMessages(1);
                hasConflit = true;
            }
        }
        // HORA
        private void IsHour(DeleteAppointmentForm deletionForm)
        {
            bool parseSuccess = int.TryParse(deletionForm.InputStart, out int outputStart);
            if (parseSuccess)
            {
                if (outputStart < DateTime.Today.Hour)
                {
                    deletionForm.ErrorMessages(0);
                    hasConflit = true;
                }
            }
            else
            {
                deletionForm.ErrorMessages(2);
                hasConflit = true;
            }
        }
        // CPF
        private void IsCPF(DeleteAppointmentForm deletionForm)
        {
            List<Appointment> list = new();
            bool parseSuccess = long.TryParse(deletionForm.InputCPF, out long outputCPF);
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
                    deletionForm.ErrorMessages(3);
                    hasConflit = true;
                }
            }
        }
        // DATA E HORA
        private void IsAppointmentDateAndHour(DeleteAppointmentForm deletionForm)
        {
            bool parseSuccess = DateTime.TryParse(deletionForm.InputDate, out DateTime outputDate);
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
                        if (a.Start.ToString("0000") == deletionForm.InputStart)
                        {
                            list.Add(a);
                            appointment = a;
                        }
                    }
                }
                if (list.Count == 0)
                {
                    deletionForm.ErrorMessages(4);
                    hasConflit = true;
                }
            }
        }
        //$end
    }
}
