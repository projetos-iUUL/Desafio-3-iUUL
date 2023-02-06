using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda_Consultorio_Odontologico.view.appointment
{
    public class DeleteAppointmentForm
    {
        public string InputCPF { get; set; }
        public string InputDate { get; set; }
        public string InputStart { get; set; }
        public List<string> ErrorList { get; set; }

        public void Form()
        {
            Console.WriteLine("Insira o CPF do paciente que desejas cancelar o agendamento: ");
            InputCPF = Console.ReadLine();
            Console.WriteLine("Insira a data do agendamento que desejas cancelar: ");
            InputDate = Console.ReadLine();
            Console.WriteLine("Insira a hora inicial do agendamento que desejas cancelar: ");
            InputStart = Console.ReadLine();

        }
        public static void SuccessMessage()
        {
            Console.WriteLine("Agendamento removido com sucesso!\n");
        }
        public void ErrorMessages(int n)
        {
            this.ErrorList = new List<string>
            {
                $"Erro na data: {InputDate} -> Não é possível cancelar um agendamento passado.",
                $"Erro na data: {InputDate} -> Digite a data no formato válido (DD/MM/AAAA).",
                $"Erro na hora: {InputStart} -> Digite a hora no formato válido (HHMM).",
                $"Erro no CPF: {InputCPF} -> CPF não cadastrado ou incorreto.",
                "Não há agendamentos para o paciente/dia/hora informados!",
            };
            Console.WriteLine($"{ErrorList[n]}");
        }
    }
}
