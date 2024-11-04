public static class ServiceMapping
{
    public static Service ServiceCreateToService(this ServiceCreateInfo serviceCreateInfo)
    {
        return new Service()
        {
            ServiceName = serviceCreateInfo.ServiceBaseInfo.ServiceName,
            Description = serviceCreateInfo.ServiceBaseInfo.Description,
            Price = serviceCreateInfo.ServiceBaseInfo.Price,
            Duration = serviceCreateInfo.ServiceBaseInfo.Duration,
            ServiceType = serviceCreateInfo.ServiceBaseInfo.ServiceType,
            GymId = serviceCreateInfo.ServiceBaseInfo.GymId
        };
    }

    public static Service ServiceUpdateToService(this Service service, ServiceUpdateInfo serviceUpdateInfo)
    {
        service.ServiceName = serviceUpdateInfo.ServiceBaseInfo.ServiceName;
        service.Description = serviceUpdateInfo.ServiceBaseInfo.Description;
        service.Price = serviceUpdateInfo.ServiceBaseInfo.Price;
        service.Duration = serviceUpdateInfo.ServiceBaseInfo.Duration;
        service.ServiceType = serviceUpdateInfo.ServiceBaseInfo.ServiceType;
        service.GymId = serviceUpdateInfo.ServiceBaseInfo.GymId;
        service.UpdatedAt = DateTime.UtcNow;
        service.Version = +1;
        return service;
    }

    public static ServiceReadInfo ServiceToServiceRead(this Service service)
    {
        return new ServiceReadInfo()
        {
            Id = service.Id,
            ServiceBaseInfo = new ServiceBaseInfo()
            {
                ServiceName = service.ServiceName,
                Description = service.Description,
                Duration = service.Duration,
                GymId = service.GymId,
                ServiceType = service.ServiceType,
                Price = service.Price
            }
        };
    }

    public static Service ToDeleteService(this Service service)
    {
        service.IsDeleted = true;
        service.DeletedAt = DateTime.UtcNow;
        return service;
    }
}