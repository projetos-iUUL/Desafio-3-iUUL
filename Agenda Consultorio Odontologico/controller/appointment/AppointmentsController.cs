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
            ali.ShowAppointmentsList();
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
                ali.ShowAppointmentsListByPeriod(start, end);
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
