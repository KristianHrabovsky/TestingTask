namespace TestingTask.Model
{
    public class Forecast
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public string DownloadDate { get; set; }

        public Forecast(string status, string description, string downloadDate)
        {
            Status = status;
            Description = description;
            DownloadDate = downloadDate;
        }
    }
}
