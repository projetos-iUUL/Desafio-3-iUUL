using Agenda_Consultorio_Odontologico.model;

namespace Agenda_Consultorio_Odontologico.view.patientInterface
{
    public class PatientForm
    {
        public string InputName { get; set; }
        public string InputCPF { get; set; }
        public string InputDate { get; set; }
        public List<string> ErrorList { get; set; }

        public PatientForm() { }


        public void Form()
        {
            Console.WriteLine("Insira o nome do cliente: ");
            this.InputName = Console.ReadLine();
            Console.WriteLine("Insira o CPF: ");
            this.InputCPF = Console.ReadLine();
            Console.WriteLine("Insira da data de nascimento (dd/mm/aaaa): ");
            this.InputDate = Console.ReadLine();
        }
        public void GetName()
        {
            Console.WriteLine("Insira o nome do cliente: ");
            this.InputName = Console.ReadLine();
        }
        public void GetCPF()
        {
            Console.WriteLine("Insira o CPF: ");
            this.InputCPF = Console.ReadLine();
        }
        public void GetDate()
        {
            Console.WriteLine("Insira da data de nascimento (dd/mm/aaaa): ");
            this.InputDate = Console.ReadLine();
        }

        public void ShowData()
        {
            Console.WriteLine($"--------------------------------------------");
            Console.WriteLine($"CPF: {this.InputCPF}");
            Console.WriteLine($"Nome: {this.InputName}");
            Console.WriteLine($"Data de nascimento: {this.InputDate} \n");

        }
        public void SuccessMessage()
        {
            Console.WriteLine("Paciente cadastrado com sucesso!\n");
        }

        public void ErrorMessages(int n)
        {
            this.ErrorList = new List<string>
            {
                $"Erro no nome: {this.InputName} -> O nome deve possuir pelo menos 5 caracteres",
                $"Erro no CPF: {this.InputCPF} -> Favor inserir um CPF válido (11 caracteres, apenas números).",
                $"Erro no CPF: {this.InputCPF} -> O CPF inserido já está cadastrado em outro paciente! Verifique os dados e insira novamente.",
                $"Erro na data de nascimento: {this.InputDate} -> Favor inserir uma data válida no formato DD/MM/AAAA.",
                $"Erro na data de nascimento: {this.InputDate} -> O cliente deve ter pelo menos 13 anos!",
            };
            Console.WriteLine($"{ErrorList[n]}");
        }
    }
}
