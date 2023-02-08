using Agenda_Consultorio_Odontologico.data;
using Agenda_Consultorio_Odontologico.model;
using Agenda_Consultorio_Odontologico.view.appointment;
using Agenda_Consultorio_Odontologico.view.appointmentInterface;

namespace Agenda_Consultorio_Odontologico.controller.appointment
{
    public class AppointmentsController
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public bool HasConflit { get; set; }

        public AppointmentsController()
        {
            HasConflit = false;
        }


        public void PrintSchedule()
        {
            AppointmentsPrint appointmentsPrint = new();
            appointmentsPrint.Header();

            using var context = new ConsultorioContext();
            var query = from app in context.Appointments
                        join pac in context.Patients
                        on app.PatientId equals pac.Id
                        orderby app.Date
                        select new { app, pac };

            foreach (var item in query)
            {
                string date = item.app.Date.ToString("dd/MM/yyyy");
                string itemStart = item.app.Start.ToString("0000");
                string itemEnd = item.app.End.ToString("0000");
                string time = item.app.Time.ToString();
                string name = item.app.Patient.Name;
                string birth = item.app.Patient.BirthDate.ToString("dd/MM/yyyy");
                appointmentsPrint.ShowAppointmentsList(date, itemStart, itemEnd, time, name, birth);                
            }

            appointmentsPrint.Footer();
        }
        public void PrintScheduleByPeriod()
        {
            AppointmentsMenu appointmentsMenu = new();
            AppointmentsPrint appointmentsPrint = new();
            appointmentsMenu.GetDates();
            CheckDates();
            CheckDatesOrder();
            if (!HasConflit)
            {
                appointmentsPrint.Header();
                using var context = new ConsultorioContext();
                var query = from app in context.Appointments
                            join pac in context.Patients
                            on app.PatientId equals pac.Id
                            where app.Date >= Start && app.Date >= End
                            orderby app.Date
                            select new { app, pac };
                foreach (var item in query)
                {
                    string date = item.app.Date.ToString("dd/MM/yyyy");
                    string start = item.app.Start.ToString("0000");
                    string end = item.app.End.ToString("0000");
                    string time = item.app.Time.ToString();
                    string name = item.app.Patient.Name;
                    string birth = item.app.Patient.BirthDate.ToString("dd/MM/yyyy");
                    appointmentsPrint.ShowAppointmentsList(date, start, end, time, name, birth);
                }
                appointmentsPrint.Footer();
            }
        }
        public void CheckDates()
        {
            AppointmentsMenu appointmentsMenu = new();
            bool parseSuccessStart = DateTime.TryParse(appointmentsMenu.InputStartDate, out DateTime outputStartDate);
            bool parseSuccessEnd = DateTime.TryParse(appointmentsMenu.InputEndDate, out DateTime outputEndDate);
            if (!parseSuccessStart)
            {
                appointmentsMenu.ErrorMessages(1);
                HasConflit = true;
            }
            else Start = outputStartDate;
            if (!parseSuccessEnd)
            {
                appointmentsMenu.ErrorMessages(2);
                HasConflit = true;
            }
            else End = outputEndDate;
        }
        public void CheckDatesOrder()
        {
            AppointmentsMenu appointmentsMenu = new();
            if (Start > End)
            {
                appointmentsMenu.ErrorMessages(3);
                HasConflit = true;
            }
        }
    }
}
