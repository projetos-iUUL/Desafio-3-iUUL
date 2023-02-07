using Agenda_Consultorio_Odontologico.view.appointment;

namespace Agenda_Consultorio_Odontologico.controller.appointment
{
    public class AppointmentsMenuController
    {
        public AppointmentsMenuController() { }


        public void OpenInterface()
        {
            AppointmentsMenu appointmentsMenu = new();
            appointmentsMenu.Menu();
            Options(appointmentsMenu);
        }
        private void Options(AppointmentsMenu appointmentsMenu)
        {
            AppointmentsController appointmentsController = new();
            MainMenuController mainMenuController = new();

            bool parseSuccess = int.TryParse(appointmentsMenu.InputOption, out int value);

            if (parseSuccess)
            {
                switch (value)
                {
                    case 1:
                        appointmentsController.PrintSchedule();
                        mainMenuController.OpenMenu();
                        break;
                    case 2:
                        appointmentsController.PrintScheduleByPeriod();
                        mainMenuController.OpenMenu();
                        break;
                    default:
                        appointmentsMenu.ErrorMessages(0);
                        appointmentsMenu.Menu();
                        break;
                }
            }
            else
            {
                appointmentsMenu.ErrorMessages(0);
                appointmentsMenu.Menu();
            }
        }

    }
}
