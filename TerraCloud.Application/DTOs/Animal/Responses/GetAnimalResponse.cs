﻿namespace TerraCloud.Application.DTOs.Animal.Responses
{
    public class GetAnimalResponse
    {
        public Guid Id { get; set; }
        public string Species { get; set; } = null!;
        public int? DayHumidity { get; set; }
        public int? DayTemperature { get; set; }
        public int? NightHumidity { get; set; }
        public int? NightTemperature { get; set; }
        public int? AvarageHumidity => (DayHumidity + NightHumidity) / 2;
        public int? AvarageTemperature => (DayTemperature + NightTemperature) / 2;
        public bool IsPublic { get; set; }
    }
}
