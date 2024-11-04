public static class CityMapping
{
    public static City CityCreatToCity(this CityCreateInfo cityCreateInfo)
    {
        return new City()
        {
            CityName = cityCreateInfo.CityBaseInfo.CityName,
            CountryId = cityCreateInfo.CountryId
        };
    }

    public static City CityUpdateToCity(this City city, CityUpdateInfo cityUpdateInfo)
    {
        city.CityName = cityUpdateInfo.CityBaseInfo.CityName;
        city.CountryId = cityUpdateInfo.CountryId;
        city.UpdatedAt = DateTime.UtcNow;
        city.Version = +1;
        return city;
    }

    public static CityReadInfo CityToCityRead(this City city)
    {
        return new CityReadInfo()
        {
            Id = city.Id,
            CityBaseInfo = new CityBaseInfo()
            {
                CityName = city.CityName
            },
            CountryId = city.CountryId
        };
    }

    public static City ToDeleteCity(this City city)
    {
        city.IsDeleted = true;
        city.DeletedAt = DateTime.UtcNow;
        return city;
    }
}