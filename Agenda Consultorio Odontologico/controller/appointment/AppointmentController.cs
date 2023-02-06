using Agenda_Consultorio_Odontologico.controller.appointment;
using Agenda_Consultorio_Odontologico.controller.appointmentControllers;
using Agenda_Consultorio_Odontologico.view.appointment;
using Agenda_Consultorio_Odontologico.view.appointmentInterface;

namespace Agenda_Consultorio_Odontologico.controller.appointmentController
{
    public class AppointmentController
    {
        public AppointmentController() { }


        public void CreateAppointment()
        {
            CreateAppointmentController createAppointmentController = new();
            AppointmentMenu appointmentMenu = new();

            if (createAppointmentController.ValidateAppointment())
            {
                createAppointmentController.CreateAppointment();
                AppointmentForm.SuccessMessage();
            }

            else
                appointmentMenu.Menu();
        }
        public void RemoveAppointment()
        {
            DeleteAppointmentController deleteAppointmentController = new();

            if (deleteAppointmentController.ValidateAppointment())
            {
                deleteAppointmentController.RemoveAppointment();
                DeleteAppointmentForm.SuccessMessage();
            }
        }

        public void PrintSchedule()
        {
            AppointmentsMenuController almc = new();
            almc.OpenInterface();
        }
    }
}
