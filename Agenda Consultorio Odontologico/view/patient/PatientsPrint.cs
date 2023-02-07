using Agenda_Consultorio_Odontologico.model;
using Agenda_Consultorio_Odontologico.data;

namespace Agenda_Consultorio_Odontologico.view.patientInterface
{
    public class PatientsPrint
    {
        public void Header()
        {
            Console.WriteLine("Lista de paciente");
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("CPF          Nome                       Dt.Nasc.     Idade");
            Console.WriteLine("----------------------------------------------------------");
        }
        public void ShowPatientsList(string cpf, string name, string birth, string age)
        {           
            Console.WriteLine(cpf.PadRight(13) + name.PadRight(27) + birth + age.PadLeft(6));
        }
        public void Footer()
        {
            Console.WriteLine("----------------------------------------------------------");
        }

        internal void ShowPatientAppointment(string date, string start, string end)
        {
            Console.WriteLine("             Agendado para: " + date);
            Console.WriteLine("             " + start + " às " + end);
        }
    }
}
