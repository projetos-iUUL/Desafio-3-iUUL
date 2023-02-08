namespace Agenda_Consultorio_Odontologico.view.patientInterface
{
    public class DeletePatientForm
    {
        public string InputCPF { get; set; }
        public List<string> ErrorList { get; set; }

        public DeletePatientForm() { }


        public void Form()
        {
            Console.WriteLine("Insira o CPF do paciente que deseja remover: ");
            InputCPF = Console.ReadLine();

        }
        public void SuccessMessage()
        {
            Console.WriteLine("Paciente removido com sucesso!\n");
        }
        public void ErrorMessages(int n)
        {
            this.ErrorList = new List<string>
            {
                $"Erro no CPF: {InputCPF} -> Favor insira um CPF válido (11 caracteres, apenas números).",
                $"Erro no CPF: {InputCPF} -> O CPF inserido não está cadastrado!",
                $"Erro no CPF: {InputCPF} -> Você não pode excluir um paciente que possui agendamento programado!",
            };
            Console.WriteLine($"{ErrorList[n]}");
        }
    }
}
