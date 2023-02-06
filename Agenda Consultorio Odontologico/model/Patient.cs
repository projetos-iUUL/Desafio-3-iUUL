using System.ComponentModel.DataAnnotations;

namespace Agenda_Consultorio_Odontologico.model
{
    public class Patient
    {
        public int Id { get; internal set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public long CPF { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        public virtual List<Appointment> Appointments { get; set; }  
        public int Age;
        public Patient()
        {
            Age = DateTime.Today.Year - BirthDate.Year;
        }
    }
}
