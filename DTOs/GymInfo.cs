public readonly record struct GymBaseInfo(
    string GymName,
    string Address,
    string PhoneNumber,
    string Email,
    string WorkingHours,
    int CityId
);

public readonly record struct GymCreateInfo(
    GymBaseInfo GymBaseInfo
);

public readonly record struct GymUpdateInfo(
    GymBaseInfo GymBaseInfo
);

public readonly record struct GymReadInfo(
    int Id,
    GymBaseInfo GymBaseInfo
);