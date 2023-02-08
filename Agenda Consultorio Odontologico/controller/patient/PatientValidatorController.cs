using Agenda_Consultorio_Odontologico.data;
using Agenda_Consultorio_Odontologico.model;
using Agenda_Consultorio_Odontologico.view.patientInterface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Globalization;

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
            var cpfLong = long.Parse(cpf);
            using var context = new ConsultorioContext();
            var p = context.Patients.First(p => p.CPF == cpfLong);
            
            return p != null;
        }
        // Data de Nascimento
        private bool IsBirthDate(string birthDate)
        {
            string format = "dd/MM/yyyy";
            DateTime DataFormatada;
            int AnoAtual, AnoNascimento;

            try
            {
                DataFormatada = DateTime.ParseExact(birthDate, format, CultureInfo.InvariantCulture);

            }
            catch (Exception) { return false; }

            DateTime now = DateTime.Now;
            AnoAtual = now.Year;
            AnoNascimento = DataFormatada.Year;

            if (AnoAtual - AnoNascimento <= 12) return false;

            return true;
        }
    }
}
