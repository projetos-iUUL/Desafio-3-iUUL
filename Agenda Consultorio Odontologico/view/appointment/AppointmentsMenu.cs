namespace Agenda_Consultorio_Odontologico.view.appointment
{
    public class AppointmentsMenu
    {
        public string InputOption;
        public string InputStartDate;
        public string InputEndDate;
        public List<string> ErrorList;

        public AppointmentsMenu() { }

        public void Menu()
        {
            Console.WriteLine("Lista dos agendamentos");
            Console.WriteLine("1- Mostrar lista completa.");
            Console.WriteLine("2- Mostrar lista por período.");
            InputOption = Console.ReadLine();
        }
        public void ErrorMessages(int n)
        {
            this.ErrorList = new List<string>
            {
                "Favor insira uma opção válida",
                $"Erro na data: {InputStartDate} -> Digite a data no formato válido (DD/MM/AAAA).",
                $"Erro na hora: {InputEndDate} -> Digite a data no formato válido (DD/MM/AAAA).",
                "A data inicial não pode ser posterior à data final!",
            };
            Console.WriteLine($"{ErrorList[n]}");
        }
        public void GetDates()
        {
            Console.WriteLine("Insira a data de início do período: ");
            InputStartDate = Console.ReadLine();
            Console.WriteLine("Insira a data final do período: ");
            InputEndDate = Console.ReadLine();
        }
    }
}
