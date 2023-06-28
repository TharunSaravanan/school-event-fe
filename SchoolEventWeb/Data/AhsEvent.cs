using System.ComponentModel.DataAnnotations;

namespace SchoolEventWeb.Data
{
    public class AhsEvent
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Requirement { get; set; }

        [Range(10, 50, ErrorMessage = "Attendance points should be between 10 and 50.")]
        public int AttendancePoints { get; set; }
        [Range(25, 100, ErrorMessage = "Participation points should be between 25 and 100.")]
        public int ParticipationPoints { get; set; }

        [DataType(DataType.Date)]
        public DateTime EventDate { get; set; } = DateTime.Today;

        public string Time
        {
            get {
                return EventDate.ToString("yyyy-MM-dd");
            }
            set {
                if (value != null)
                    EventDate = DateTime.Parse(value);
                else
                    EventDate = DateTime.Today;
            }
        }
        public String Type { get; set; } = "Non-Sport";
    }
}
