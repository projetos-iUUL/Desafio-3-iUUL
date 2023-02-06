using Agenda_Consultorio_Odontologico.model;

namespace Agenda_Consultorio_Odontologico.view.appointmentInterface
{
    public class AppointmentsPrint
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
        public void ShowAppointmentsList(Appointment appointment)
        {
            string date = appointment.Date.ToString("dd/MM/yyyy");
            string start = appointment.Start.ToString("0000");
            string end = appointment.End.ToString("0000");
            string time = appointment.Time.ToString();
            string name = appointment.Patient.Name;
            string birth = appointment.Patient.BirthDate.ToString("dd/MM/yyyy");
            Console.WriteLine(date.PadLeft(7) + start.PadLeft(7) + end.PadLeft(7) + time.PadLeft(5) + " min  " + name.PadRight(15) + birth);
        }
        public void Footer()
        {
            Console.WriteLine("---------------------------------------------------------------");
        }

    }
}
