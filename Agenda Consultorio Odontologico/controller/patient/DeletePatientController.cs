using Agenda_Consultorio_Odontologico.data;
using Agenda_Consultorio_Odontologico.model;
using Agenda_Consultorio_Odontologico.view.patientInterface;

namespace Agenda_Consultorio_Odontologico.controller.patientControllers
{
    public class DeletePatientController
    {
        public DeletePatientController() { }

        public void DeletePatient()
        {
            DeletePatientForm pdi = new();
            pdi.Form();

            if (long.TryParse(pdi.InputCPF, out long outputCPF))
            {
                using var context = new ConsultorioContext();
                var patients = context.Patients.ToList();

                foreach(var pat in patients )
                {
                    if(pat.CPF == outputCPF)
                    {
                        if (HasFutureAppointment(pat))
                        {
                            pdi.ErrorMessages(2);
                        }
                        else
                        {
                            context.Patients.Remove(pat);
                            pdi.SuccessMessage();
                        }
                    }
                }
            }
            else
            {
                pdi.ErrorMessages(0);
            }
        }
        public bool HasFutureAppointment(Patient patient)
        {
            foreach(var appointment in patient.Appointments)
            {
                if (appointment.Date > DateTime.Now)
                    return true;
            }
            return false;
        }
    }
}
