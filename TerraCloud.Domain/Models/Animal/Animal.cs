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
        /// <summary>
        /// Is animal published
        /// </summary>
        public bool IsPublic { get; set; } = false;

        /// <summary>
        /// Animal user creator
        /// </summary>
        public Guid UserId { get; set; }
        public virtual User.User User { get; set; }

        public virtual ICollection<AnimalUser>? AnimalUsers { get; }
    }
}
