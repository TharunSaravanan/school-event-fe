using System.ComponentModel.DataAnnotations;

namespace SchoolEventWeb.Data
{
    public class AhsEvent
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Range(10, 50, ErrorMessage = "Attendance points should be between 10 and 50.")]
        public int AttendancePoints { get; set; }
        [Range(25, 100, ErrorMessage = "Participation points should be between 10 and 50.")]
        public int ParticipationPoints { get; set; }

        private DateTime _time;
        public DateTime Time { 
            get
            {
                return _time.Date;
            }

            set
            {
                _time = value;
            }
        } 
        public String Type { get; set; } = "Non-Sport";

        public AhsEvent()
        {
            _time = DateTime.Today;
        }
    }
}
