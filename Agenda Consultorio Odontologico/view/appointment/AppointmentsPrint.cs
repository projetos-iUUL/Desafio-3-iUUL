using Agenda_Consultorio_Odontologico.model;
using Agenda_Consultorio_Odontologico.data;

namespace Agenda_Consultorio_Odontologico.view.appointmentInterface
{
    public class AppointmentsPrint
    {
        public void Header()
        {
            Console.WriteLine("Lista de agendamentos \n");
            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine("   Data      H.Ini  H.Fim  Tempo   Nome             Dt.Nac     ");
            Console.WriteLine("---------------------------------------------------------------");
        }
        public void ShowAppointmentsList(string date, string start, string end, string time, string name, string birth)
        {
            Console.WriteLine(date.PadLeft(7) + start.PadLeft(7) + end.PadLeft(7) + time.PadLeft(5) + " min  " + name.PadRight(15) + birth);
        }
        public void Footer()
        {
            Console.WriteLine("---------------------------------------------------------------");
        }

    }
}
