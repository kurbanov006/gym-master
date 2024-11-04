public readonly record struct UserTrainerBaseInfo(
    UserBaseInfo UserBaseInfo,
    string Specialization,
    DateTime CareerStart,
    int GymId
);

public readonly record struct UserTrainerCreateInfo(
    UserTrainerBaseInfo UserTrainerBaseInfo
);

public readonly record struct UserTrainerUpdateInfo(
    UserTrainerBaseInfo UserTrainerBaseInfo
);

public readonly record struct UserTrainerReadInfo(
    int Id,
    UserTrainerBaseInfo UserTrainerBaseInfo
);