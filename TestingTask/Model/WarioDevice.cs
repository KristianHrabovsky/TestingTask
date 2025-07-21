namespace TestingTask.Model
{
    public class WarioDevice
    {
        public int Id { get; set; }
        public string Degree { get; set; }
        public string Pressure { get; set; }
        public string SerialNumber { get; set; }
        public string Model { get; set; }
        public string Firmware { get; set; }
        public string Runtime { get; set; }
        public string FreeMemory { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Language { get; set; }
        public string PressureType { get; set; }
        public string R { get; set; }
        public string Bip { get; set; }
        public WarioDevice(string degree, string pressure, string serialNumber, string model, string firmware, string runtime, string freeMemory, string date, string time, string language, string pressureType, string r, string bip)
        {
            Degree = degree;
            Pressure = pressure;
            SerialNumber = serialNumber;
            Model = model;
            Firmware = firmware;
            Runtime = runtime;
            FreeMemory = freeMemory;
            Date = date;
            Time = time;
            Language = language;
            PressureType = pressureType;
            R = r;
            Bip = bip;
        }
    }
}
