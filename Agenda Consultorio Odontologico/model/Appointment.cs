using System.ComponentModel.DataAnnotations;

namespace Agenda_Consultorio_Odontologico.model
{
    public class Appointment
    {
        public int Id { get; internal set; }
        public DateTime Date { get; set; }
        public int Start { get; set; }
        public int End { get; set; }
        public int PatientId { get; set; }
        public int Time;
        [Required]
        public virtual Patient Patient { get; internal set; }
        public Appointment()
        {
            Time = End - Start ;
        }
    }
}
