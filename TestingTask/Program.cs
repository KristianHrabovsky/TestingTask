using Newtonsoft.Json.Linq;
using TestingTask.Data;
using TestingTask.Model;
using TestingTask.Util;

class Program
{
    private static string XML_URL_RAW = "https://pastebin.com/raw/PMQueqDV";

    static async Task Main(string[] args)
    {
        while (true)
        {
            await using var dbContext = new SqliteDbContext();

            try
            {
                Console.WriteLine($"[{DateTime.Now}] Starting XML fetch and database update...");

                string? json = await FileHelper.GetJsonFromXMLUrl(XML_URL_RAW);

                var downloadDate = DateTime.Now.ToString();

                if (json != null)
                {
                    var root = JObject.Parse(json);
                    var wario = root["wario"];

                    if (wario != null)
                    {

                        var sensorInputs = wario["input"]?["sensor"] as JArray;
                        var sensorOutputs = wario["output"]?["sensor"] as JArray;
                        var minMaxes = wario["minmax"]?["s"] as JArray;
                        var variableDatas = wario["variable"];

                        await dbContext.Database.EnsureCreatedAsync();

                        await DatabaseHelper.SaveToWarioDevicesTable(dbContext, wario);
                        await DatabaseHelper.SaveToSensorInputsTable(dbContext, sensorInputs);
                        await DatabaseHelper.SaveToSensorOutputsTable(dbContext, sensorOutputs);
                        await DatabaseHelper.SaveToMinMaxesTable(dbContext, minMaxes);
                        await DatabaseHelper.SaveToSensorVariableDatasTable(dbContext, variableDatas);

                        await dbContext.Forecasts.AddAsync(new Forecast("online", "All data saved in Database", downloadDate));

                        await dbContext.SaveChangesAsync();
                    }
                }
                else
                {
                    await dbContext.Forecasts.AddAsync(new Forecast("online", "Failed to convert XML to JSON.", downloadDate));
                    await dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[{DateTime.Now}] Error during processing: {ex.Message}");

                await dbContext.Forecasts.AddAsync(new Forecast("offline", "No data saved in Database.", ""));
                await dbContext.SaveChangesAsync();
            }

            Console.WriteLine($"[{DateTime.Now}] Waiting 1 Hour...\n");
            await Task.Delay(TimeSpan.FromHours(1));
        }
    }
}