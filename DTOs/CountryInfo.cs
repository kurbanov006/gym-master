public readonly record struct CountryBaseInfo(string CountryName);

public readonly record struct CountryCreateInfo(
    CountryBaseInfo countryBaseInfo
);

public readonly record struct CountryUpdateInfo(
    CountryBaseInfo countryBaseInfo
);

public readonly record struct CountryReadInfo(
    int Id,
    CountryBaseInfo countryBaseInfo
);