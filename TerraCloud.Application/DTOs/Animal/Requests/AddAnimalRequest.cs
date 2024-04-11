namespace TerraCloud.Application.DTOs.Animal.Requests
{
    public class AddAnimalRequest
    {
        public string Species { get; set; } = null!;
        public int? DayHumidity { get; set; }
        public int? DayTemperature { get; set; }
        public int? NightHumidity { get; set; }
        public int? NightTemperature { get; set; }
    }
}
