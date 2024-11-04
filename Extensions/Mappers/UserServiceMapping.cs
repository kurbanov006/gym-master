using System.Security.Cryptography.X509Certificates;

public static class UserServiceMapping
{
    public static UserService UserServiceCreatToUserService(this UserServiceCreateInfo userServiceCreateInfo)
    {
        return new UserService()
        {
            ServiceId = userServiceCreateInfo.UserServiceBaseInfo.ServiceId,
            UserClientId = userServiceCreateInfo.UserServiceBaseInfo.UserClientId,
            UserTrainerId = userServiceCreateInfo.UserServiceBaseInfo.UserTrainerId,
            LastPayMentDate = userServiceCreateInfo.UserServiceBaseInfo.LastPayMentDate
        };
    }

    public static UserService UpdateUserServiceToUserService(this UserService userService, UserServiceUpdateInfo userServiceUpdateInfo)
    {

        userService.ServiceId = userServiceUpdateInfo.UserServiceBaseInfo.ServiceId;
        userService.UserClientId = userServiceUpdateInfo.UserServiceBaseInfo.UserClientId;
        userService.UserTrainerId = userServiceUpdateInfo.UserServiceBaseInfo.UserTrainerId;
        userService.LastPayMentDate = userServiceUpdateInfo.UserServiceBaseInfo.LastPayMentDate;
        userService.UpdatedAt = DateTime.UtcNow;
        userService.Version = +1;
        return userService;


    }

    public static UserServiceReadInfo UserServiceToUserServiceRead(this UserService userService)
    {
        return new UserServiceReadInfo()
        {
            Id = userService.ServiceId,
            UserServiceBaseInfo = new UserServiceBaseInfo()
            {
                ServiceId = userService.ServiceId,
                UserClientId = userService.UserClientId,
                UserTrainerId = userService.UserTrainerId,
                LastPayMentDate = userService.LastPayMentDate
            }
        };
    }

    public static UserService ToDeleteUserService(this UserService userService)
    {
        userService.IsDeleted = true;
        userService.DeletedAt = DateTime.UtcNow;
        return userService;
    }
}