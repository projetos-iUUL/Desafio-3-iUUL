using Agenda_Consultorio_Odontologico.model;

namespace Agenda_Consultorio_Odontologico.view.appointmentInterface
{
    public class AppointmentListInterface
    {       
        public void Title()
        {
            Console.WriteLine("Lista de agendamentos \n");
        }
        public void Header()
        {
            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine("   Data      H.Ini  H.Fim  Tempo   Nome             Dt.Nac     ");
            Console.WriteLine("---------------------------------------------------------------");
        }
        public void ShowAppointmentsList()
        {
            using var context = new ConsultorioContext();
            var query = from app in context.Appointments
                        join pac in context.Patients
                        on app.PatientId equals pac.Id
                        select new { app, pac };
            foreach (var item in query)
            {               
                string date = item.app.Date.ToString("dd/MM/yyyy");
                string start = item.app.Start.ToString("0000");
                string end = item.app.End.ToString("0000");
                string time = item.app.Time.ToString();
                string name = item.app.Patient.Name;
                string birth = item.app.Patient.BirthDate.ToString("dd/MM/yyyy");
                Console.WriteLine(date.PadLeft(7) + start.PadLeft(7) + end.PadLeft(7) + time.PadLeft(5) + " min  " + name.PadRight(15) + birth);               
            }
        }
        public void ShowAppointmentsListByPeriod(DateTime i, DateTime e)
        {
            using var context = new ConsultorioContext();
            var query = from app in context.Appointments
                        join pac in context.Patients
                        on app.PatientId equals pac.Id
                        where app.Date >= i && app.Date >= e
                        select new { app, pac };
            foreach (var item in query)
            {
                string date = item.app.Date.ToString("dd/MM/yyyy");
                string start = item.app.Start.ToString("0000");
                string end = item.app.End.ToString("0000");
                string time = item.app.Time.ToString();
                string name = item.app.Patient.Name;
                string birth = item.app.Patient.BirthDate.ToString("dd/MM/yyyy");
                Console.WriteLine(date.PadLeft(7) + start.PadLeft(7) + end.PadLeft(7) + time.PadLeft(5) + " min  " + name.PadRight(15) + birth);
            }
        }
        public void Footer()
        {
            Console.WriteLine("---------------------------------------------------------------");
        }

    }
}
