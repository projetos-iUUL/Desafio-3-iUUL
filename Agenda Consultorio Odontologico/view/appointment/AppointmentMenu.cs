namespace Agenda_Consultorio_Odontologico.view.appointmentInterface
{
    public class AppointmentMenu
    {
        public string InputOption { get; set; }

        public AppointmentMenu() { }

        public void Menu()
        {
            Console.WriteLine("Agenda");
            Console.WriteLine("1- Agendar consulta");
            Console.WriteLine("2- Cancelar agendamento");
            Console.WriteLine("3- Listar agenda");
            Console.WriteLine("4- Voltar p/ menu principal");
            InputOption = Console.ReadLine();
        }
    }
}
