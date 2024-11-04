public readonly record struct CityBaseInfo(string CityName);

public readonly record struct CityCreateInfo(
    CityBaseInfo CityBaseInfo,
    int CountryId
);

public readonly record struct CityUpdateInfo(
    CityBaseInfo CityBaseInfo,
    int CountryId
);

public readonly record struct CityReadInfo(
    int Id,
    CityBaseInfo CityBaseInfo,
    int CountryId
);