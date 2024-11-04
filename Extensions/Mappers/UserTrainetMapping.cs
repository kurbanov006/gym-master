public static class UserTrainerMapping
{
    public static UserTrainer UserTrainerToUserTrainer(this UserTrainerCreateInfo userTrainerCreate)
    {
        return new UserTrainer()
        {
            FirstName = userTrainerCreate.UserTrainerBaseInfo.UserBaseInfo.FirstName,
            LastName = userTrainerCreate.UserTrainerBaseInfo.UserBaseInfo.LastName,
            Email = userTrainerCreate.UserTrainerBaseInfo.UserBaseInfo.Email,
            PhoneNumber = userTrainerCreate.UserTrainerBaseInfo.UserBaseInfo.PhoneNumber,
            Address = userTrainerCreate.UserTrainerBaseInfo.UserBaseInfo.Address,
            DateOfBirth = userTrainerCreate.UserTrainerBaseInfo.UserBaseInfo.DateOfBirth,
            Specialization = userTrainerCreate.UserTrainerBaseInfo.Specialization,
            CareerStart = userTrainerCreate.UserTrainerBaseInfo.CareerStart,
            GymId = userTrainerCreate.UserTrainerBaseInfo.GymId
        };
    }

    public static UserTrainer UserTrainerUpdateToUserTrainer(this UserTrainer userTrainer, UserTrainerUpdateInfo userTrainerUpdateInfo)
    {
        userTrainer.FirstName = userTrainerUpdateInfo.UserTrainerBaseInfo.UserBaseInfo.FirstName;
        userTrainer.LastName = userTrainerUpdateInfo.UserTrainerBaseInfo.UserBaseInfo.LastName;
        userTrainer.Email = userTrainerUpdateInfo.UserTrainerBaseInfo.UserBaseInfo.Email;
        userTrainer.PhoneNumber = userTrainerUpdateInfo.UserTrainerBaseInfo.UserBaseInfo.PhoneNumber;
        userTrainer.Address = userTrainerUpdateInfo.UserTrainerBaseInfo.UserBaseInfo.Address;
        userTrainer.DateOfBirth = userTrainerUpdateInfo.UserTrainerBaseInfo.UserBaseInfo.DateOfBirth;
        userTrainer.Specialization = userTrainerUpdateInfo.UserTrainerBaseInfo.Specialization;
        userTrainer.CareerStart = userTrainerUpdateInfo.UserTrainerBaseInfo.CareerStart;
        userTrainer.GymId = userTrainerUpdateInfo.UserTrainerBaseInfo.GymId;
        userTrainer.UpdatedAt = DateTime.UtcNow;
        userTrainer.Version = +1;
        return userTrainer;
    }

    public static UserTrainerReadInfo UserToUserRead(this UserTrainer userTrainer)
    {
        return new UserTrainerReadInfo()
        {
            Id = userTrainer.Id,
            UserTrainerBaseInfo = new UserTrainerBaseInfo()
            {
                GymId = userTrainer.GymId,
                CareerStart = userTrainer.CareerStart,
                Specialization = userTrainer.Specialization,
                UserBaseInfo = new UserBaseInfo()
                {
                    FirstName = userTrainer.FirstName,
                    LastName = userTrainer.LastName,
                    Email = userTrainer.Email,
                    Address = userTrainer.Address,
                    PhoneNumber = userTrainer.PhoneNumber,
                    DateOfBirth = userTrainer.DateOfBirth
                }
            }
        };
    }

    public static UserTrainer ToDeleteUserTrainer(this UserTrainer userTrainer)
    {
        userTrainer.DeletedAt = DateTime.UtcNow;
        userTrainer.IsDeleted = true;
        return userTrainer;
    }
}