namespace TerraCloud.Domain.Models.Animal
{
    public class Animal
    {
        public Guid Id { get; set; }
        public string Species { get; set; } = null!;
        public int? DayHumidity { get; set; }
        public int? DayTemperature { get; set; }
        public int? NightHumidity { get; set; }
        public int? NightTemperature { get; set; }
    }
}
