using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace SchoolEventWeb.Data
{
    public class EventService
    {
        private HttpClient httpClient;

        public EventService()
        {
            httpClient = new HttpClient();
            //httpClient.BaseAddress = new Uri("https://school-event-app.herokuapp.com/");
            httpClient.BaseAddress = new Uri("http://localhost:8080/");
        }


        public List<AhsEvent> GetUpcomingEvents()
        {
            var result = httpClient.GetFromJsonAsync<List<AhsEvent>>("event/upcomingEvents").Result;
            return result.OrderByDescending(k => k.Time).ToList();
        }

        public List<AhsEvent> GetCompletedEvents()
        {
            var result = httpClient.GetFromJsonAsync<List<AhsEvent>>("event/completedEvents").Result;
            return result.OrderByDescending(k => k.Time).ToList();
        }

        public List<AhsEvent> GetAllEvents()
        {
            var result = httpClient.GetFromJsonAsync<List<AhsEvent>>("event/allEvents").Result;
            return result.OrderByDescending(k => k.Time).ToList();
        }

        public void InsertEvent(AhsEvent ahsevent)
        {
            var result = httpClient.PostAsJsonAsync("/event/add", ahsevent).Result;
        }

        public void InsertPoint(Point point)
        {
            var result = httpClient.PostAsJsonAsync("/point/add", point).Result;
        }


        public void InsertStudent(Student student)
        {
            var result = httpClient.PostAsJsonAsync("/student/add", student).Result ;
        }

        public List<EventPoint> GetPointsForEvent(int eventId, int grade)
        {
            var points = httpClient.GetFromJsonAsync<List<Point>>("point/pointsForEvent?eventId=" + eventId + "&grade=" + grade ).Result;
            var students = GetAllStudents();

            List<EventPoint> result = new List<EventPoint>();
            foreach (var p in points)
            { 
                var r = new EventPoint();
                r.Points = p.Points;
                if (p.IsParticipant)
                    r.ParticipationType = "Participant";
                else
                    r.ParticipationType = "Attendant";

                r.StudentName = students.First(k => k.Id == p.StudentId).Name;
                result.Add(r);
            }

            return result;
        }

        public List<Student> GetAllStudents()
        {
            var result = httpClient.GetFromJsonAsync<List<Student>>("student/getAll").Result;
            return result;
        }

        public List<LeaderBoardPoint> GetLeaderBoardPoints(string quarterName)
        {
            var result = httpClient.GetFromJsonAsync<List<LeaderBoardPoint>>("point/leaderBoard?quarterName=" + quarterName).Result;
            result = result.OrderByDescending(x => x.TotalPoints).ToList();
            return result;
        }

        public List<Winner> GetWinners(string quarterName)
        {
            var result = httpClient.GetFromJsonAsync<List<Winner>>("point/winner?quarterName=" + quarterName).Result;
            return result;
        }

        public List<Quarter> GetQuarters()
        {
            var result = httpClient.GetFromJsonAsync<List<Quarter>>("point/quarters").Result;
            return result;
        }

        public List<Winner> LuckyDraw(string quarterName)
        {
            var result = httpClient.GetFromJsonAsync<List<Winner>>("point/draw?quarterName=" + quarterName).Result;
            return result;
        }
    }
}