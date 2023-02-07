using Agenda_Consultorio_Odontologico.data;
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

        public AppointmentsController() { }


        public void PrintSchedule()
        {
            ali.Title();
            ali.Header();
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
                ali.ShowAppointmentsList(date, itemStart, itemEnd, time, name, birth);                
            }
            ali.Footer();
        }
        public void PrintScheduleByPeriod()
        {
            almi.GetDates();
            CheckDates();
            CheckDatesOrder();
            if (!hasConflit)
            {
                ali.Title();
                ali.Header();
                using var context = new ConsultorioContext();
                var query = from app in context.Appointments
                            join pac in context.Patients
                            on app.PatientId equals pac.Id
                            where app.Date >= start && app.Date >= end
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
                    ali.ShowAppointmentsList(date, start, end, time, name, birth);
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
            else start = outputStartDate;
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
