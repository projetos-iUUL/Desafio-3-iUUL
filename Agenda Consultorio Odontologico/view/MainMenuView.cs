namespace Agenda_Consultorio_Odontologico.view
{
    public class MainMenuView
    {
        public string InputOption { get; set; }

        public MainMenuView() { }

        public void Menu()
        {
            Console.WriteLine("Menu Principal");
            Console.WriteLine("1- Cadastro de pacientes");
            Console.WriteLine("2- Agenda");
            Console.WriteLine("3- Fim");
            InputOption = Console.ReadLine();
        }
        public static void InvalidOptionMessage()
        {
            Console.WriteLine("Favor insira uma opção válida. \n");
        }
    }
}
