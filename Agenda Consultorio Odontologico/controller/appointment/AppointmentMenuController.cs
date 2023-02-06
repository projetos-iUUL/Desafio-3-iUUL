using Agenda_Consultorio_Odontologico.view;
using Agenda_Consultorio_Odontologico.view.appointmentInterface;

namespace Agenda_Consultorio_Odontologico.controller.appointmentController
{
    public class AppointmentMenuController
    {
        public void Menu()
        {
            AppointmentMenu appointmentMenu = new();
            appointmentMenu.Menu();
            Options(appointmentMenu);
        }

        private void Options(AppointmentMenu appointmentMenu)
        {
            AppointmentController appointmentMainController = new();
            MainMenuController mainMenuController = new();

            string inputOption = appointmentMenu.InputOption;
            bool parseSuccess = int.TryParse(inputOption, out int value);
            if (parseSuccess)
            {
                switch (value)
                {
                    case 1:
                        appointmentMainController.CreateAppointment();
                        mainMenuController.OpenMenu();
                        break;
                    case 2:
                        appointmentMainController.RemoveAppointment();
                        mainMenuController.OpenMenu();
                        break;
                    case 3:
                        appointmentMainController.PrintSchedule();
                        mainMenuController.OpenMenu();
                        break;
                    case 4:
                        mainMenuController.OpenMenu();
                        break;
                    default:
                        MainMenuView.InvalidOptionMessage();
                        appointmentMenu.Menu();
                        break;
                }
            }
            else
            {
                MainMenuView.InvalidOptionMessage();
                appointmentMenu.Menu();
            }
        }
    }
}
