public class City : BaseEntity
{
    public string CityName { get; set; } = string.Empty;
    public List<Gym> Gyms { get; set; } = [];
    public int CountryId { get; set; }
    public Country? Country { get; set; }
}