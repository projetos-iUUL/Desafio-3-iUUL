using Agenda_Consultorio_Odontologico.view;
using Agenda_Consultorio_Odontologico.view.patientInterface;

namespace Agenda_Consultorio_Odontologico.controller.patientControllers
{
    public class PatientMenuController
    {
        public void Menu()
        {
            PatientMenu patientMenu = new();
            patientMenu.Menu();
            Options(patientMenu);
        }
        private void Options(PatientMenu patientMenu)
        {
            PatientMainController patientMainController = new();
            MainMenuController mainMenuController = new();

            bool parseSuccess = int.TryParse(patientMenu.InputOption, out int value);

            if (parseSuccess)
            {
                switch (value)
                {
                    case 1:
                        patientMainController.AddPatient();
                        mainMenuController.OpenMenu();
                        break;
                    case 2:
                        patientMainController.RemovePatient();
                        mainMenuController.OpenMenu();
                        break;
                    case 3:
                        patientMainController.PrintPatientsListByCPF();
                        mainMenuController.OpenMenu();
                        break;
                    case 4:
                        patientMainController.PrintPatientsListByName();
                        mainMenuController.OpenMenu();
                        break;
                    case 5:
                        mainMenuController.OpenMenu();
                        break;
                    default:
                        MainMenuView.InvalidOptionMessage();
                        patientMenu.Menu();
                        break;
                }
            }
            else
            {
                MainMenuView.InvalidOptionMessage();
                patientMenu.Menu();
            }

        }
    }
}
