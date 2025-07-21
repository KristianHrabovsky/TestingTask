namespace TestingTask.Model
{
    public class SensorInput
    {
        public int Id { get; set; }
        public string SensorId { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Place { get; set; }
        public string Value { get; set; }

        public SensorInput(string sensorId, string type, string name, string place, string value)
        {
            SensorId = sensorId;
            Type = type;
            Name = name;
            Place = place;
            Value = value;
        }
    }
}
