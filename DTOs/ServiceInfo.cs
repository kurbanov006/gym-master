public readonly record struct ServiceBaseInfo(
    string ServiceName,
    string Description,
    decimal Price,
    int Duration,
    string ServiceType,
    int GymId
);

public readonly record struct ServiceCreateInfo(
    ServiceBaseInfo ServiceBaseInfo
);

public readonly record struct ServiceUpdateInfo(
    ServiceBaseInfo ServiceBaseInfo
);

public readonly record struct ServiceReadInfo(
    int Id,
    ServiceBaseInfo ServiceBaseInfo
);