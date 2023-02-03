using Agenda_Consultorio_Odontologico.controller.appointment;
using Agenda_Consultorio_Odontologico.controller.appointmentControllers;

namespace Agenda_Consultorio_Odontologico.controller.appointmentController
{
    public class AppointmentMainController
    {
        AppointmentValidatorController avc = new();        
        AppointmentDeleteController adc = new();
        AppointmentListMenuController almc = new();
        public void AddAppointment()
        {
            avc.AppointmentValidator();
        }
        public void RemoveAppointment()
        {
            adc.DeleteAppointment();
        }
        public void PrintFullAppointmentList()
        {
            almc.OpenInterface();
        }
    }
}
