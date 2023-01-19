namespace SchoolEventWeb.Data
{
    public class AhsEvent
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public string Description { get; set; }
        public int AttendancePoints { get; set; }
        public int ParticipationPoints { get; set; }
        public DateTime Time { get; set; }
    }
}
