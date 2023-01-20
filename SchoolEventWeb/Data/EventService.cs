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
            httpClient.BaseAddress = new Uri("https://school-event-app.herokuapp.com/");
        }

        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warmer", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public Task<WeatherForecast[]> GetForecastAsync(DateTime startDate)
        {
            return Task.FromResult(Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = startDate.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            }).ToArray());
        }

        public List<AhsEvent> GetUpcomingEvents()
        {
            var result = httpClient.GetFromJsonAsync<List<AhsEvent>>("event/upcomingEvents").Result;
            return result;
        }

        public List<AhsEvent> GetCompletedEvents()
        {
            var result = httpClient.GetFromJsonAsync<List<AhsEvent>>("event/completedEvents").Result;
            return result;
        }

        public void InsertEvent(AhsEvent ahsevent)
        {
            var result = httpClient.PostAsJsonAsync("/event/add", ahsevent).Result;
        }


        public void InsertStudent(Student student)
        {
            var result = httpClient.PostAsJsonAsync("/student/add", student).Result ;
        }

        public List<Student> GetAllStudents()
        {
            var result = httpClient.GetFromJsonAsync<List<Student>>("student/getAll").Result;
            return result;
        }
    }
}