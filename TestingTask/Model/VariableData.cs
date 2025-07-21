namespace TestingTask.Model
{
    public class VariableData
    {
        public int Id { get; set; }
        public string Sunrise { get; set; }
        public string Sunset { get; set; }
        public string CivStart { get; set; }
        public string CivEnd { get; set; }
        public string NautStart { get; set; }
        public string NautEnd { get; set; }
        public string AstroStart { get; set; }
        public string AstroEnd { get; set; }
        public string DayLength { get; set; }
        public string CivLength { get; set; }
        public string NautLength { get; set; }
        public string AstroLength { get; set; }
        public string MoonPhase { get; set; }
        public string IsDay { get; set; }
        public string Bio { get; set; }
        public string PressureOld { get; set; }
        public string TemperatureAvg { get; set; }
        public string AGL { get; set; }
        public string Fog { get; set; }
        public string LSP { get; set; }
        public VariableData(string sunrise, string sunset, string civStart, string civEnd, string nautStart, string nautEnd, string astroStart, string astroEnd, string dayLength, string civLength, string nautLength, string astroLength, string moonPhase, string isDay, string bio, string pressureOld, string temperatureAvg, string aGL, string fog, string lSP)
        {
            Sunrise = sunrise;
            Sunset = sunset;
            CivStart = civStart;
            CivEnd = civEnd;
            NautStart = nautStart;
            NautEnd = nautEnd;
            AstroStart = astroStart;
            AstroEnd = astroEnd;
            DayLength = dayLength;
            CivLength = civLength;
            NautLength = nautLength;
            AstroLength = astroLength;
            MoonPhase = moonPhase;
            IsDay = isDay;
            Bio = bio;
            PressureOld = pressureOld;
            TemperatureAvg = temperatureAvg;
            AGL = aGL;
            Fog = fog;
            LSP = lSP;
        }
    }
}
