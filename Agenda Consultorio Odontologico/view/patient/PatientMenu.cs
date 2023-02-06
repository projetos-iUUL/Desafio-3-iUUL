using Agenda_Consultorio_Odontologico.model;

namespace Agenda_Consultorio_Odontologico.view.patientInterface
{
    public class PatientMenu
    {
        public string InputOption { get; set; }

        public void Menu()
        {
            Console.WriteLine("Menu de Cadastro de Pacientes");
            Console.WriteLine("1- Cadastrar novo paciente");
            Console.WriteLine("2- Excluir paciente");
            Console.WriteLine("3- Listar pacientes (ordenados por CPF)");
            Console.WriteLine("4- Listar pacientes (ordenados por nome)");
            Console.WriteLine("5- Voltar p/ o menu principal");
            InputOption = Console.ReadLine();
        }
    }
}
