
using Microsoft.EntityFrameworkCore;

public class ServiceService(AppDbContext context) : IServiceService
{
    public async Task<Result<bool>> CreateService(ServiceCreateInfo serviceCreate)
    {
        bool conflict = await context.Services.AnyAsync(x =>
        x.ServiceName.ToLower() == serviceCreate.ServiceBaseInfo.ServiceName.ToLower());

        if (conflict)
            return Result<bool>.Fail(Error.Conflict());

        await context.Services.AddAsync(serviceCreate.ServiceCreateToService());
        int res = await context.SaveChangesAsync();

        return res is 0
        ? Result<bool>.Fail(Error.InternalServerError("Failed to add ..."))
        : Result<bool>.Success(true);
    }

    public async Task<Result<bool>> DeleteService(int id)
    {
        Service? service = await context.Services.Where(x => x.IsDeleted == false).FirstOrDefaultAsync(x => x.Id == id);
        if (service is null)
            return Result<bool>.Fail(Error.NotFound());

        service.ToDeleteService();
        int res = await context.SaveChangesAsync();

        return res is 0
        ? Result<bool>.Fail(Error.InternalServerError("Failed to delete ..."))
        : Result<bool>.Success(true);
    }

    public async Task<Result<PagedResponse<IEnumerable<ServiceReadInfo>>>> GetAllServices(BaseFilter filter)
    {
        IQueryable<Service> services = context.Services;

        if (services is null)
            return Result<PagedResponse<IEnumerable<ServiceReadInfo>>>.Fail(Error.NotFound());

        IQueryable<ServiceReadInfo> result = services.Where(x => x.IsDeleted == false).Skip((filter.PageNumber - 1) * filter.PageSize)
        .Take(filter.PageSize).Select(x => x.ServiceToServiceRead());

        int totalRecords = await result.CountAsync();

        PagedResponse<IEnumerable<ServiceReadInfo>> response = PagedResponse<IEnumerable<ServiceReadInfo>>
        .Create(filter.PageNumber, filter.PageSize, totalRecords, result);

        return Result<PagedResponse<IEnumerable<ServiceReadInfo>>>.Success(response);
    }

    public async Task<Result<ServiceReadInfo>> GetByIdService(int id)
    {
        Service? service = await context.Services.Where(x => x.IsDeleted == false).FirstOrDefaultAsync(x => x.Id == id);

        return service is null
        ? Result<ServiceReadInfo>.Fail(Error.NotFound())
        : Result<ServiceReadInfo>.Success(service.ServiceToServiceRead());
    }

    public async Task<Result<bool>> UpdateService(int id, ServiceUpdateInfo serviceUpdate)
    {
        Service? service = await context.Services.Where(x => x.IsDeleted == false).FirstOrDefaultAsync(x => x.Id == id);
        if (service is null)
            return Result<bool>.Fail(Error.NotFound());

        bool conflict = await context.Services.AnyAsync(x =>
        x.ServiceName.ToLower() == serviceUpdate.ServiceBaseInfo.ServiceName.ToLower());

        if (conflict)
            return Result<bool>.Fail(Error.Conflict());

        context.Services.Update(service.ServiceUpdateToService(serviceUpdate));
        int res = await context.SaveChangesAsync();
        return res is 0
        ? Result<bool>.Fail(Error.InternalServerError(""))
        : Result<bool>.Success(true);
    }
}