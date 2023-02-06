using Agenda_Consultorio_Odontologico.model;
using Agenda_Consultorio_Odontologico.view.patientInterface;
using System;

namespace Agenda_Consultorio_Odontologico.controller.patientControllers
{
    public class PatientValidatorController
    {
        private bool IsValid { get; set; }

        public PatientValidatorController()
        {
            IsValid = false;
        }


        public void PatientValidator()
        {
            PatientForm pri = new();
            pri.Form();

            pri.ShowData();

            while (!IsValid)
            {
                pri.GetName();
                IsValid = IsName(pri.InputName);
                if (!IsValid)
                {
                    pri.ErrorMessages(0);
                }
            }
            IsValid = false;

            while (!IsValid)
            {
                pri.GetCPF();
                IsValid = IsCPF(pri.InputCPF);
                if (!IsValid)
                {
                    pri.ErrorMessages(1);
                }
            }
            IsValid = false;

            while (!IsValid)
            {
                pri.GetCPF();
                IsValid = IsCPFAlreadyExistent(pri.InputCPF);
                if (!IsValid)
                {
                    pri.ErrorMessages(2);
                }
            }
            IsValid = false;

            while (!IsValid)
            {
                pri.GetDate();
                IsValid = IsBirthDate(pri.InputDate);
                if (!IsValid)
                {
                    pri.ErrorMessages(3);
                }
            }
            IsValid = false;

            pri.SuccessMessage();
        }




        /************************************
         * MÉTODOS DE VALIDAÇÃO DE ENTRADAS *
         ***********************************/
        // Nome
        private bool IsName(string name)
        {
            return name.Length < 5;
        }
        // CPF
        // Fonte: https://macoratti.net/11/09/c_val1.htm
        private bool IsCPF(string cpf)
        {
            if (!long.TryParse(cpf, out long cpfLong))
                return false;
            else
                cpf = cpfLong.ToString();

            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf += digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito += resto.ToString();
            return cpf.EndsWith(digito);
        }
        // CPF existente
        private bool IsCPFAlreadyExistent(string cpf)
        {
            //...
        }
        // Data de Nascimento
        private bool IsBirthDate(string birthDate)
        {
            //...
        }
    }
}
