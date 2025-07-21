namespace TestingTask.Model
{
    public class MinMax
    {
        public int Id { get; set; }
        public string SensorId { get; set; }
        public string Min { get; set; }
        public string Max { get; set; }

        public MinMax(string sensorId, string min, string max)
        {
            SensorId = sensorId;
            Min = min;
            Max = max;
        }
    }
}
