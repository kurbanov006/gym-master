public readonly record struct UserClientBaseInfo(
    UserBaseInfo UserBaseInfo
);

public readonly record struct UserClientCreateInfo(
    UserClientBaseInfo UserClientBaseInfo
);

public readonly record struct UserClientUpdateInfo(
    UserClientBaseInfo UserClientBaseInfo
);

public readonly record struct UserClientReadInfo(
    int Id,
    UserClientBaseInfo UserClientBaseInfo
);