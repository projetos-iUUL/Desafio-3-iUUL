using Agenda_Consultorio_Odontologico.model;
using Agenda_Consultorio_Odontologico.view.appointment;
using Agenda_Consultorio_Odontologico.view.appointmentInterface;

namespace Agenda_Consultorio_Odontologico.controller.appointment
{
    public class AppointmentsController
    {
        AppointmentsPrint ali = new();
        AppointmentsMenu almi = new();
        DateTime start;
        DateTime end;
        bool hasConflit = false;
        public void PrintFullAppointmentList()
        {
            ali.Title();
            ali.Header();
            using var context = new ConsultorioContext();
            var appointments = context.Appointments.ToList();
            foreach (Appointment appointment in appointments.OrderBy(x => x.Date))
            {
                ali.ShowAppointmentsList(appointment);
            }
            ali.Footer();
        }
        public void PrintAppointmentListByPeriod()
        {
            almi.GetDates();
            CheckDates();
            CheckDatesOrder();
            if(!hasConflit)
            {
                ali.Title();
                ali.Header();
                using var context = new ConsultorioContext();
                var appointments = context.Appointments.ToList();
                foreach (Appointment appointment in appointments.OrderBy(x => x.Date))
                {
                    if (appointment.Date >= start && appointment.Date <= end)
                    {
                        ali.ShowAppointmentsList(appointment); 
                    }
                }
                ali.Footer();
            }
        }
        public void CheckDates()
        {
            bool parseSuccessStart = DateTime.TryParse(almi.InputStartDate, out DateTime outputStartDate);
            bool parseSuccessEnd = DateTime.TryParse(almi.InputEndDate, out DateTime outputEndDate);
            if (!parseSuccessStart)
            {
                almi.ErrorMessages(1);
                hasConflit = true;
            }
            else start = outputStartDate ;
            if (!parseSuccessEnd)
            {
                almi.ErrorMessages(2);
                hasConflit = true;
            }
            else end = outputEndDate;
        }
        public void CheckDatesOrder()
        {
            if (start > end)
            {
                almi.ErrorMessages(3);
                hasConflit = true;
            }
        }
    }
}
