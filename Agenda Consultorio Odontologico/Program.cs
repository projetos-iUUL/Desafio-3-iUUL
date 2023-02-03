using Agenda_Consultorio_Odontologico.controller;
using Agenda_Consultorio_Odontologico.model;

namespace Agenda_Consultorio_Odontologico
{
    class Program
    {        
        static public void Main()
        {
            MainMenuController mc = new MainMenuController();
            //SaveUsingEntity();
            mc.OpenInterface();
        }

        private static void SaveUsingEntity()
        {
            var date1 = new DateTime(1992, 9, 13, 0, 0, 0);
            Patient a = new();
            a.Name= "Teste A";
            a.BirthDate = date1;
            a.CPF = 12312312311;           
            var date2 = new DateTime(1997, 11, 29, 0, 0, 0);
            Patient b = new();

            var date3 = new DateTime(1990, 9, 19, 0, 0, 0);
            Patient c = new();

            var date4 = new DateTime(2022, 8, 26, 0, 0, 0);
            var date5 = new DateTime(2023, 3, 1, 0, 0, 0);

            Appointment appointment1 = new();
            appointment1.Date = date4;
            appointment1.Patient = a;
            appointment1.End = 1100;
            appointment1.Start = 1030;
            Appointment appointment2 = new();
            Appointment appointment3 = new();

            using var context = new ConsultorioContext();
            context.Patients.Add(a);
            context.Appointments.Add(appointment1);
            context.SaveChanges();
        }
    }
}
