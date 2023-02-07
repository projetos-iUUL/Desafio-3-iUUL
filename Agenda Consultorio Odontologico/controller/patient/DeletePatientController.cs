using Agenda_Consultorio_Odontologico.data;
using Agenda_Consultorio_Odontologico.model;
using Agenda_Consultorio_Odontologico.view.patientInterface;

namespace Agenda_Consultorio_Odontologico.controller.patientControllers
{
    public class DeletePatientController
    {
        DeletePatientForm pdi = new();
        public void DeletePatient()
        {
            List<Patient> list = new List<Patient>();
            pdi.GetInformation();
            bool parseSuccess = long.TryParse(pdi.InputCPF, out long outputCPF);
            if (parseSuccess)
            {
                using var context = new ConsultorioContext();
                var patients = context.Patients.ToList();
                for (int i = 0; i < patients.Count; i++)
                {
                    Patient patient = patients[i];
                    if (patient.CPF == outputCPF)
                    {
                        list.Add(patient);
                    }
                }
                if (list.Count == 0)
                {
                    pdi.ErrorMessages(1);
                }
                else
                {
                    foreach (Patient patient in list)
                    {
                        CheckAppointments(patient);
                    }
                }
            }
            else pdi.ErrorMessages(0);
        }
        public void CheckAppointments(Patient patient)
        {
            List<Appointment> list = new();
            using var context = new ConsultorioContext();
            var appointments = context.Appointments.ToList();
            for (int i = 0; i < appointments.Count; i++)
            {
                Appointment appointment = appointments[i];
                if (appointment.Patient == patient)
                {
                    list.Add(appointment);
                }
            }
            if (list.Count > 0)
            {
                foreach (Appointment appointment in list)
                {
                    CheckAppointmentTime(appointment, patient);
                }
            }
            else
            {
                context.Patients.Remove(patient);
                context.SaveChanges();
                pdi.SuccessMessage();
            }
        }
        public void CheckAppointmentTime(Appointment appointment, Patient patient)
        {
            if(appointment.Date < DateTime.Today) 
            {
                using var context = new ConsultorioContext();
                context.Appointments.Remove(appointment);
                context.Patients.Remove(patient);
                context.SaveChanges();
                pdi.SuccessMessage();
            }
            else pdi.ErrorMessages(2);
        }
    }
}
