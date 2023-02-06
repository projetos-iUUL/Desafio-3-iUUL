using Agenda_Consultorio_Odontologico.model;
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
            var patients = context.Patients.ToList();

            foreach (Patient patient in patients.OrderBy(x => x.CPF))
            {
                patientsPrint.ShowPatientsList(patient);
            }

            patientsPrint.Footer();
        }
        public void PrintPatientsListByName()
        {
            PatientsPrint patientsPrint = new();
            patientsPrint.Header();

            using var context = new ConsultorioContext();
            var patients = context.Patients.ToList();

            foreach (Patient patient in patients.OrderBy(x => x.Name))
            {
                patientsPrint.ShowPatientsList(patient);
            }

            patientsPrint.Footer();
        }

    }
}
