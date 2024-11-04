public class Gym : BaseEntity
{
    public string GymName { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string WorkingHours { get; set; } = string.Empty;
    public int CityId { get; set; }
    public City? City { get; set; }
    public List<Service> Services { get; set; } = [];
}