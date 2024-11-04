public static class GymMapping
{
    public static Gym GymCreatToGym(this GymCreateInfo gymCreate)
    {
        return new Gym()
        {
            GymName = gymCreate.GymBaseInfo.GymName,
            Address = gymCreate.GymBaseInfo.Address,
            PhoneNumber = gymCreate.GymBaseInfo.PhoneNumber,
            Email = gymCreate.GymBaseInfo.Email,
            WorkingHours = gymCreate.GymBaseInfo.WorkingHours,
            CityId = gymCreate.GymBaseInfo.CityId
        };
    }

    public static Gym GymUpdateTOGYm(this Gym gym, GymUpdateInfo gymUpdate)
    {
        gym.GymName = gymUpdate.GymBaseInfo.GymName;
        gym.Address = gymUpdate.GymBaseInfo.Address;
        gym.PhoneNumber = gymUpdate.GymBaseInfo.PhoneNumber;
        gym.Email = gymUpdate.GymBaseInfo.Email;
        gym.WorkingHours = gymUpdate.GymBaseInfo.WorkingHours;
        gym.CityId = gymUpdate.GymBaseInfo.CityId;
        gym.Version = +1;

        gym.UpdatedAt = DateTime.UtcNow;
        return gym;
    }

    public static GymReadInfo GymToGymRead(this Gym gym)
    {
        return new GymReadInfo()
        {
            Id = gym.Id,
            GymBaseInfo = new GymBaseInfo()
            {
                GymName = gym.GymName,
                Address = gym.Address,
                PhoneNumber = gym.PhoneNumber,
                Email = gym.Email,
                WorkingHours = gym.WorkingHours,
                CityId = gym.CityId
            }
        };
    }

    public static Gym ToDeleteGym(this Gym gym)
    {
        gym.IsDeleted = true;
        gym.DeletedAt = DateTime.UtcNow;
        return gym;
    }
}