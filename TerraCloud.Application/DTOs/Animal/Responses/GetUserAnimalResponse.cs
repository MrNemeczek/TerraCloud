namespace TerraCloud.Application.DTOs.Animal.Responses
{
    public class GetUserAnimalResponse
    {
        public Guid Id { get; set; }
        public Guid AnimalId { get; set; }
        public string Species { get; set; } = null!;
        public int? DayHumidity { get; set; }
        public int? DayTemperature { get; set; }
        public int? NightHumidity { get; set; }
        public int? NightTemperature { get; set; }
        public int? AvarageHumidity => (DayHumidity + NightHumidity) / 2;
        public int? AvarageTemperature => (DayTemperature + NightTemperature) / 2;
        /// <summary>
        /// Is user owner of that animal?
        /// </summary>
        public bool IsOwner { get; set; }
    }
}
