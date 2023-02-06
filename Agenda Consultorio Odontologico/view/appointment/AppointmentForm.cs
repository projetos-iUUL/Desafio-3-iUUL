namespace Agenda_Consultorio_Odontologico.view.appointmentInterface
{
    public class AppointmentForm
    {
        public string InputCPF { get; set; }
        public string InputDate { get; set; }
        public string InputStart { get; set; }
        public string InputEnd { get; set; }
        public List<string> ErrorList { get; set; }


        public void Form()
        {
            Console.WriteLine("Insira o CPF do paciente: ");
            InputCPF = Console.ReadLine();
            Console.WriteLine("Insira a data da consulta (dd/mm/aaaa): ");
            InputDate = Console.ReadLine();
            Console.WriteLine("Insira o horário de início da consulta (HHMM): ");
            InputStart = Console.ReadLine();
            Console.WriteLine("Insira o horário de término da consulta (HHMM): ");
            InputEnd = Console.ReadLine();
        }

        public void GetPatientCPF()
        {
            Console.WriteLine("Insira o CPF do paciente: ");
            InputCPF = Console.ReadLine();
        }
        public void GetDate()
        {
            Console.WriteLine("Insira a data da consulta (dd/mm/aaaa): ");
            InputDate = Console.ReadLine();
        }
        public void GetStart()
        {
            Console.WriteLine("Insira o horário de início da consulta (HHMM): ");
            InputStart = Console.ReadLine();
        }
        public void GetEnd()
        {
            Console.WriteLine("Insira o horário de término da consulta (HHMM): ");
            InputEnd = Console.ReadLine();
        }
        public void ShowData()
        {
            Console.WriteLine($"--------------------------------------------");
            Console.WriteLine($"CPF: {InputCPF}");
            Console.WriteLine($"Data da consulta: {InputDate}");
            Console.WriteLine($"Hora inicial: {InputStart}");
            Console.WriteLine($"Hora final: {InputEnd} \n");
        }
        public static void SuccessMessage()
        {
            Console.WriteLine("Agendamento realizado com sucesso!\n");
        }
        public void ErrorMessages(int n)
        {
            this.ErrorList = new List<string>
            {
                $"Erro no CPF: {InputCPF} -> CPF não cadastrado!" ,
                $"Erro no CPF: {InputCPF} -> Favor insira um CPF válido (11 caracteres, apenas números).",
                $"Erro na data: {InputDate} -> A data não pode ser anterior à hoje!",
                $"Erro na data: { InputDate} -> Favor insira uma data no formato DD,MM,AAAA. ",
                $"Erro no horário de início: {InputStart} -> Hora inválida ou fora do horário de atendimento (horário de atendimento é das 8h até 19h)",
                $"Erro no horário de início: {InputStart} -> Favor digite um horário no formato 0900, 1345, 1730." ,
                $"Erro no horário de término: {InputEnd} -> Hora inválida ou fora do horário de atendimento (horário de atendimento é das 8h até 19h)",
                $"Erro no horário de término: {InputEnd} -> A hora final não pode ser menor que a hora inicial!)",
                $"Erro no horário de término: {InputEnd} -> Favor digite um horário no formato 0900, 1345, 1730." ,
                $"Conflito de agendamento: Não pode haver dois agendamentos futuros para um mesmo paciente!" ,
                $"Conflito de agendamento: Já existe uma consulta marcada para este horário!" ,
            };
            Console.WriteLine($"{ErrorList[n]}");
        }
    }
}
