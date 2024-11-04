public class Country : BaseEntity
{
    public string CountryName { get; set; } = string.Empty;
    public List<City> Cities { get; set; } = [];
}