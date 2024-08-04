namespace TerraCloud.Application.DTOs.Animal.Requests
{
    public class UpdateAnimalRequest
    {
        /// <summary>
        /// Animal ID
        /// </summary>
        public Guid Id { get; set; }
        public string Species { get; set; } = null!;
        public int? DayHumidity { get; set; }
        public int? DayTemperature { get; set; }
        public int? NightHumidity { get; set; }
        public int? NightTemperature { get; set; }
        public bool IsPublic { get; set; }
    }
}
