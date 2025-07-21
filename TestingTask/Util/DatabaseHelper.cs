using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using TestingTask.Data;
using TestingTask.Model;

namespace TestingTask.Util
{
    public static class DatabaseHelper
    {
        public static async Task SaveToWarioDevicesTable(SqliteDbContext? dbContext, JToken? wario)
        {
            if (wario != null && dbContext != null)
            {
                var degree = wario["@degree"]?.ToString() ?? string.Empty;
                var pressure = wario["@pressure"]?.ToString() ?? string.Empty;
                var serialNumber = wario["@serial_number"]?.ToString() ?? string.Empty;
                var model = wario["@model"]?.ToString() ?? string.Empty;
                var firmware = wario["@firmware"]?.ToString() ?? string.Empty;
                var runtime = wario["@runtime"]?.ToString() ?? string.Empty;
                var freeMemory = wario["@freemem"]?.ToString() ?? string.Empty;
                var date = wario["@date"]?.ToString() ?? string.Empty;
                var time = wario["@time"]?.ToString() ?? string.Empty;
                var language = wario["@language"]?.ToString() ?? string.Empty;
                var pressureType = wario["@pressure_type"]?.ToString() ?? string.Empty;
                var r = wario["@r"]?.ToString() ?? string.Empty;
                var bip = wario["@bip"]?.ToString() ?? string.Empty;

                await dbContext.WarioDevices.AddAsync(new WarioDevice(degree, pressure, serialNumber, model, firmware, runtime, freeMemory, date, time, language, pressureType, r, bip));
            }
        }

        public static async Task SaveToMinMaxesTable(SqliteDbContext? dbContext, JArray? minMaxes)
        {
            if (minMaxes != null && dbContext != null)
            {
                foreach (var value in minMaxes)
                {
                    var id = value["@id"]?.ToString() ?? string.Empty;
                    var min = value["@min"]?.ToString() ?? string.Empty;
                    var max = value["@max"]?.ToString() ?? string.Empty;

                    await dbContext.MinMaxes.AddAsync(new MinMax(id, min, max));
                }
            }
        }

        public static async Task SaveToSensorInputsTable(SqliteDbContext? dbContext, JArray? sensorInputs)
        {
            if (sensorInputs != null && dbContext != null)
            {
                foreach (var sensor in sensorInputs)
                {
                    var type = sensor["type"]?.ToString() ?? string.Empty;
                    var id = sensor["id"]?.ToString() ?? string.Empty;
                    var name = sensor["name"]?.ToString() ?? string.Empty;
                    var place = sensor["place"]?.ToString() ?? string.Empty;
                    var value = sensor["value"]?.ToString() ?? string.Empty;

                    await dbContext.SensorInputs.AddAsync(new SensorInput(type, id, name, place, value));
                }
            }
        }

        public static async Task SaveToSensorOutputsTable(SqliteDbContext? dbContext, JArray? sensorOutputs)
        {
            if (sensorOutputs != null && dbContext != null)
            {
                foreach (var sensor in sensorOutputs)
                {
                    var type = sensor["type"]?.ToString() ?? string.Empty;
                    var id = sensor["id"]?.ToString() ?? string.Empty;
                    var name = sensor["name"]?.ToString() ?? string.Empty;
                    var place = sensor["place"]?.ToString() ?? string.Empty;
                    var value = sensor["value"]?.ToString() ?? string.Empty;

                    await dbContext.SensorOutputs.AddAsync(new SensorOutput(type, id, name, place, value));
                }
            }
        }

        public static async Task SaveToSensorVariableDatasTable(SqliteDbContext? dbContext, JToken? variableDatas)
        {
            if (variableDatas != null && dbContext != null)
            {
                var sunrise = variableDatas["sunrise"]?.ToString() ?? string.Empty;
                var sunset = variableDatas["sunset"]?.ToString() ?? string.Empty;
                var civstart = variableDatas["civstart"]?.ToString() ?? string.Empty;
                var civend = variableDatas["civend"]?.ToString() ?? string.Empty;
                var nautstart = variableDatas["nautstart"]?.ToString() ?? string.Empty;
                var nautend = variableDatas["nautend"]?.ToString() ?? string.Empty;
                var astrostart = variableDatas["astrostart"]?.ToString() ?? string.Empty;
                var astroend = variableDatas["astroend"]?.ToString() ?? string.Empty;
                var daylen = variableDatas["daylen"]?.ToString() ?? string.Empty;
                var civlen = variableDatas["civlen"]?.ToString() ?? string.Empty; ;
                var nautlen = variableDatas["nautlen"]?.ToString() ?? string.Empty;
                var astrolen = variableDatas["astrolen"]?.ToString() ?? string.Empty;
                var moonphase = variableDatas["moonphase"]?.ToString() ?? string.Empty;
                var isday = variableDatas["isday"]?.ToString() ?? string.Empty;
                var bio = variableDatas["bio"]?.ToString() ?? string.Empty;
                var pressureOld = variableDatas["pressure_old"]?.ToString() ?? string.Empty;
                var temperature_avg = variableDatas["temperature_avg"]?.ToString() ?? string.Empty;
                var agl = variableDatas["agl"]?.ToString() ?? string.Empty;
                var fog = variableDatas["fog"]?.ToString() ?? string.Empty;
                var lsp = variableDatas["lsp"]?.ToString() ?? string.Empty;

                await dbContext.VariableDatas.AddAsync(new VariableData(sunrise, sunset, civstart, civend, nautstart, nautend, astrostart, astroend, daylen, civlen, nautlen, astrolen, moonphase, isday, bio, pressureOld, temperature_avg, agl, fog, lsp));
            }
        }

        public static void PrintSensorInputsTable(SqliteDbContext? dbContext)
        {
            if (dbContext != null)
            {
                Console.WriteLine("SENSOR INPUTS");
                dbContext.SensorInputs?.ToList().ForEach(p =>
                {
                    Console.WriteLine($"{p.Type}, {p.SensorId}, {p.Name}, {p.Place}");
                });
                Console.WriteLine();
            }
        }

        public static void PrintSensorOtputsTable(SqliteDbContext? dbContext)
        {
            if (dbContext != null)
            {
                Console.WriteLine("SENSOR OUTPUTS");
                dbContext.SensorOutputs?.ToList().ForEach(p =>
                {
                    Console.WriteLine($"{p.Type}, {p.SensorId}, {p.Name}, {p.Place}");
                });
                Console.WriteLine();
            }
        }

        public static void PrintMinMaxesTable(SqliteDbContext? dbContext)
        {
            if (dbContext != null)
            {
                Console.WriteLine("MIN MAXES");
                dbContext.MinMaxes?.ToList().ForEach(p =>
                {
                    Console.WriteLine($"{p.SensorId}, {p.Min}, {p.Max}");
                });
                Console.WriteLine();
            }
        }

        public static void PrintForecastsTable(SqliteDbContext? dbContext)
        {
            if (dbContext != null)
            {
                Console.WriteLine("FORECASTS");
                dbContext.Forecasts?.ToList().ForEach(p =>
                {
                    Console.WriteLine($"{p.Status}, {p.Description}, {p.DownloadDate}");
                });
                Console.WriteLine();
            }
        }

        public static void PrintVariableDatasTable(SqliteDbContext? dbContext)
        {
            if (dbContext != null)
            {
                Console.WriteLine("VARIABLE DATAS");
                dbContext.VariableDatas?.ToList().ForEach(p =>
                {
                    Console.WriteLine(p.Sunrise);
                    Console.WriteLine(p.Sunset);
                    Console.WriteLine(p.CivStart);
                    Console.WriteLine(p.CivEnd);
                    Console.WriteLine(p.NautStart);
                    Console.WriteLine(p.NautEnd);
                    Console.WriteLine(p.AstroStart);
                    Console.WriteLine(p.AstroEnd);
                    Console.WriteLine(p.DayLength);
                    Console.WriteLine(p.CivLength);
                    Console.WriteLine(p.NautLength);
                    Console.WriteLine(p.AstroLength);
                    Console.WriteLine(p.MoonPhase);
                    Console.WriteLine(p.IsDay);
                    Console.WriteLine(p.Bio);
                    Console.WriteLine(p.PressureOld);
                    Console.WriteLine(p.TemperatureAvg);
                    Console.WriteLine(p.AGL);
                    Console.WriteLine(p.Fog);
                    Console.WriteLine(p.LSP);
                });
                Console.WriteLine();
            }
        }

        public static void PrintWarioDevicesTable(SqliteDbContext? dbContext)
        {
            if (dbContext != null)
            {
                Console.WriteLine("WARIO DEVICES");
                dbContext.WarioDevices?.ToList().ForEach(p =>
                {
                    Console.WriteLine(p.Degree);
                    Console.WriteLine(p.Pressure);
                    Console.WriteLine(p.SerialNumber);
                    Console.WriteLine(p.Model);
                    Console.WriteLine(p.Firmware);
                    Console.WriteLine(p.Runtime);
                    Console.WriteLine(p.FreeMemory);
                    Console.WriteLine(p.Date);
                    Console.WriteLine(p.Time);
                    Console.WriteLine(p.Language);
                    Console.WriteLine(p.PressureType);
                    Console.WriteLine(p.R);
                    Console.WriteLine(p.Bip);
                });
                Console.WriteLine();
            }
        }

        public static void PrintAllTablesInDatabase(SqliteDbContext? dbContext)
        {
            if (dbContext != null)
            {
                var tables = dbContext.Model.GetEntityTypes();
                foreach (var t in tables)
                {
                    Console.WriteLine("Table: " + t.GetTableName());
                }
            }
        }
    }
}
