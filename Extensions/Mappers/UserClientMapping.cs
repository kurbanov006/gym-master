public static class UserClientMapping
{
    public static UserClient UserClientCreateToUserClient(this UserClientCreateInfo userClientCreate)
    {
        return new UserClient()
        {
            FirstName = userClientCreate.UserClientBaseInfo.UserBaseInfo.FirstName,
            LastName = userClientCreate.UserClientBaseInfo.UserBaseInfo.LastName,
            Email = userClientCreate.UserClientBaseInfo.UserBaseInfo.Email,
            PhoneNumber = userClientCreate.UserClientBaseInfo.UserBaseInfo.PhoneNumber,
            Address = userClientCreate.UserClientBaseInfo.UserBaseInfo.Address,
            DateOfBirth = userClientCreate.UserClientBaseInfo.UserBaseInfo.DateOfBirth
        };
    }

    public static UserClient UserUpdateToUser(this UserClient userClient, UserClientUpdateInfo userClientUpdate)
    {
        userClient.FirstName = userClientUpdate.UserClientBaseInfo.UserBaseInfo.FirstName;
        userClient.LastName = userClientUpdate.UserClientBaseInfo.UserBaseInfo.LastName;
        userClient.Email = userClientUpdate.UserClientBaseInfo.UserBaseInfo.Email;
        userClient.PhoneNumber = userClientUpdate.UserClientBaseInfo.UserBaseInfo.PhoneNumber;
        userClient.Address = userClientUpdate.UserClientBaseInfo.UserBaseInfo.Address;
        userClient.DateOfBirth = userClientUpdate.UserClientBaseInfo.UserBaseInfo.DateOfBirth;
        userClient.UpdatedAt = DateTime.UtcNow;
        userClient.Version = +1;
        return userClient;
    }

    public static UserClientReadInfo UserToUserRead(this UserClient userClient)
    {
        return new UserClientReadInfo()
        {
            Id = userClient.Id,
            UserClientBaseInfo = new UserClientBaseInfo()
            {
                UserBaseInfo = new UserBaseInfo()
                {
                    FirstName = userClient.FirstName,
                    LastName = userClient.LastName,
                    Email = userClient.Email,
                    PhoneNumber = userClient.PhoneNumber,
                    Address = userClient.Address,
                    DateOfBirth = userClient.DateOfBirth,
                }
            }
        };
    }

    public static UserClient ToDeleteUserClient(this UserClient userClient)
    {
        userClient.IsDeleted = true;
        userClient.DeletedAt = DateTime.UtcNow;
        return userClient;
    }
}