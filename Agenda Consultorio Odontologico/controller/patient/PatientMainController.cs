using Agenda_Consultorio_Odontologico.model;
using Agenda_Consultorio_Odontologico.data;
using Agenda_Consultorio_Odontologico.view.patientInterface;

namespace Agenda_Consultorio_Odontologico.controller.patientControllers
{
    public class PatientMainController
    {
        public PatientMainController() { }

        public void AddPatient()
        {
            PatientValidatorController patientValidatorController = new();
            patientValidatorController.PatientValidator();
        }
        public void RemovePatient()
        {
            DeletePatientController deletePatientController = new();
            deletePatientController.DeletePatient();
        }

        public void PrintPatientsListByCPF()
        {
            PatientsPrint patientsPrint = new();
            patientsPrint.Header();

            using var context = new ConsultorioContext();
            var query = from pac in context.Patients
                        join app in context.Appointments
                        on pac.Id equals app.PatientId
                        orderby pac.CPF
                        select new {pac, app};
            foreach(var item in query)
            {
                string cpf = item.pac.CPF.ToString("00000000000");
                string name = item.pac.Name;
                string birth = item.pac.BirthDate.ToString("dd/MM/yyyy");
                string age = item.pac.Age.ToString();
                patientsPrint.ShowPatientsList(cpf, name, birth, age);
                if (item.pac.Appointments != null)
                {
                string date = item.app.Date.ToString("dd/MM/yyyy");
                string start = item.app.Start.ToString("0000");
                string end = item.app.End.ToString("0000");
                patientsPrint.ShowPatientAppointment(date, start, end);              
                }
            }
            patientsPrint.Footer();
        }
        public void PrintPatientsListByName()
        {
            PatientsPrint patientsPrint = new();
            patientsPrint.Header();

            using var context = new ConsultorioContext();
            var query = from pac in context.Patients
                        join app in context.Appointments
                        on pac.Id equals app.PatientId
                        orderby pac.Name
                        select new { pac, app };
            foreach (var item in query)
            {
                string cpf = item.pac.CPF.ToString("00000000000");
                string name = item.pac.Name;
                string birth = item.pac.BirthDate.ToString("dd/MM/yyyy");
                string age = item.pac.Age.ToString();
                patientsPrint.ShowPatientsList(cpf, name, birth, age);
                if (item.pac.Appointments != null)
                {
                    string date = item.app.Date.ToString("dd/MM/yyyy");
                    string start = item.app.Start.ToString("0000");
                    string end = item.app.End.ToString("0000");
                    patientsPrint.ShowPatientAppointment(date, start, end);
                }
            }
            patientsPrint.Footer();
        }

    }
}
