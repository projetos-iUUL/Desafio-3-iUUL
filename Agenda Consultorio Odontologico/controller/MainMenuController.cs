using Agenda_Consultorio_Odontologico.controller.appointmentController;
using Agenda_Consultorio_Odontologico.controller.patientControllers;
using Agenda_Consultorio_Odontologico.view;

namespace Agenda_Consultorio_Odontologico.controller
{
    public class MainMenuController
    {
        public void OpenMenu()
        {
            MainMenuView menu = new();
            menu.Menu();
            Options(menu);
        }

        private void Options(MainMenuView menu)
        {
            PatientMenuController patientMenuController = new();
            AppointmentMenuController appointmentMenuController = new();

            bool parseSuccess = int.TryParse(menu.InputOption, out int value);

            if (parseSuccess)
            {
                switch (value)
                {
                    case 1:
                        patientMenuController.Menu();
                        break;
                    case 2:
                        appointmentMenuController.Menu();
                        break;
                    case 3:
                        System.Environment.Exit(0);
                        break;
                    default:
                        {
                            MainMenuView.InvalidOptionMessage();
                            menu.Menu();
                        }
                        break;
                }
            }
            else
            {
                MainMenuView.InvalidOptionMessage();
                menu.Menu();
            }
        }

    }
}
