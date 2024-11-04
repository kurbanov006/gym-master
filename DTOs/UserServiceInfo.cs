public readonly record struct UserServiceBaseInfo(
    int UserClientId,
    int UserTrainerId,
    int ServiceId,
    DateTime LastPayMentDate
);

public readonly record struct UserServiceCreateInfo(
    UserServiceBaseInfo UserServiceBaseInfo
);

public readonly record struct UserServiceUpdateInfo(
    UserServiceBaseInfo UserServiceBaseInfo
);

public readonly record struct UserServiceReadInfo(
    int Id,
    UserServiceBaseInfo UserServiceBaseInfo
);