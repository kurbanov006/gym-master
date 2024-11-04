public static class CountryMapping
{
    public static Country CreatCountryToCountry(this CountryCreateInfo country)
    {
        return new Country()
        {
            CountryName = country.countryBaseInfo.CountryName,
        };
    }

    public static Country UpdateCountryToCountry(this Country country, CountryUpdateInfo countryUpdate)
    {
        country.CountryName = countryUpdate.countryBaseInfo.CountryName;
        country.UpdatedAt = DateTime.UtcNow;
        country.Version = +1;
        return country;
    }

    public static CountryReadInfo CountryToCountryRead(this Country country)
    {
        return new CountryReadInfo()
        {
            Id = country.Id,
            countryBaseInfo = new CountryBaseInfo()
            {
                CountryName = country.CountryName
            }
        };
    }

    public static Country ToDeleteCountry(this Country country)
    {
        country.IsDeleted = true;
        country.DeletedAt = DateTime.UtcNow;
        return country;
    }
}