namespace SchoolEventWeb.Data
{
    public class Winner
    {
        public int Id { get; set; }
        public string QuarterName { get; set; }
        public int StudentId { get; set; }
        public string StudentName { get; set;}
        public int StudentGrade { get; set; }
        public string WinnerType { get; set; }
        public string PrizeType { get; set; }
        public string Prize { get; set; }

    }
}
