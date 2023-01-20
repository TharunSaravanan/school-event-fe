﻿using System.ComponentModel.DataAnnotations;

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
        public DateTime Time { get; set; } = DateTime.Now;
        public String Category { get; set; } = "Non-Sport";
    }
}
