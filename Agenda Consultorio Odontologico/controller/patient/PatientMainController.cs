using Agenda_Consultorio_Odontologico.model;
using Agenda_Consultorio_Odontologico.view.patientInterface;

namespace Agenda_Consultorio_Odontologico.controller.patientControllers
{
    public class PatientMainController
    {
        PatientValidatorController pvc = new();
        PatientListInterface pli = new();
        PatientDeleteController pdc = new();
        
        public void AddPatient()
        {
            pvc.PatientValidator();
        }
        public void RemovePatient()
        {
            pdc.DeletePatient();                  
        }
        public void PrintPatientsListByCPF()
        {
            pli.Title();
            pli.Header();
            using var context = new ConsultorioContext();
            var patients = context.Patients.ToList();
            foreach (Patient patient in patients.OrderBy(x => x.CPF))
            {
                pli.ShowPatientsList(patient);
            }
            pli.Footer();
        }
        public void PrintPatientsListByName()
        {
            pli.Title();
            pli.Header();
            using var context = new ConsultorioContext();
            var patients = context.Patients.ToList();
            foreach (Patient patient in patients.OrderBy(x => x.Name))
            {
                pli.ShowPatientsList(patient);
            }
            pli.Footer();
        }
        
    }
}
