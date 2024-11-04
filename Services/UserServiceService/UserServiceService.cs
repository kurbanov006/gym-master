
using Microsoft.AspNetCore.SignalR.Protocol;
using Microsoft.EntityFrameworkCore;

public class UserServiceService(AppDbContext context) : IUserServiceService
{

    public async Task<Result<bool>> CreateUserService(UserServiceCreateInfo userService)
    {
        await context.UserServices.AddAsync(userService.UserServiceCreatToUserService());
        int res = await context.SaveChangesAsync();

        return res is 0
        ? Result<bool>.Fail(Error.InternalServerError("Failed to add ..."))
        : Result<bool>.Success(true);
    }

    public async Task<Result<bool>> DeleteUserServrice(int id)
    {
        UserService? userService = await context.UserServices
        .Where(x => x.IsDeleted == false).FirstOrDefaultAsync(x => x.Id == id);
        if (userService is null)
            return Result<bool>.Fail(Error.NotFound());

        userService.ToDeleteUserService();
        int res = await context.SaveChangesAsync();

        return res is 0
        ? Result<bool>.Fail(Error.InternalServerError("Failed to deleted ..."))
        : Result<bool>.Success(true);
    }

    public async Task<Result<PagedResponse<IEnumerable<UserServiceReadInfo>>>> GetAllUserServices(BaseFilter filter)
    {
        IQueryable<UserService> userServices = context.UserServices;

        if (userServices is null)
            return Result<PagedResponse<IEnumerable<UserServiceReadInfo>>>.Fail(Error.NotFound());

        IQueryable<UserServiceReadInfo> result = userServices.Where(x => x.IsDeleted == false)
        .Skip((filter.PageNumber - 1) * filter.PageSize)
        .Take(filter.PageSize)
        .Select(x => x.UserServiceToUserServiceRead());

        int totalRecords = await result.CountAsync();
        PagedResponse<IEnumerable<UserServiceReadInfo>> response =
        PagedResponse<IEnumerable<UserServiceReadInfo>>.Create(filter.PageNumber, filter.PageSize, totalRecords, result);

        return Result<PagedResponse<IEnumerable<UserServiceReadInfo>>>.Success(response);
    }

    public async Task<Result<UserServiceReadInfo>> GetByIdUserService(int id)
    {
        UserService? userService = await context.UserServices.Where(x => x.IsDeleted == false).FirstOrDefaultAsync(x => x.Id == id);

        return userService is null
        ? Result<UserServiceReadInfo>.Fail(Error.NotFound())
        : Result<UserServiceReadInfo>.Success(userService.UserServiceToUserServiceRead());
    }

    public async Task<Result<bool>> UpdateUserService(int id, UserServiceUpdateInfo serviceUpdateInfo)
    {
        UserService? userService = await context.UserServices.Where(x => x.IsDeleted == false).FirstOrDefaultAsync(x => x.Id == id);
        if (userService is null)
            return Result<bool>.Fail(Error.NotFound());

        context.UserServices.Update(userService.UpdateUserServiceToUserService(serviceUpdateInfo));
        int res = await context.SaveChangesAsync();
        return res is 0
        ? Result<bool>.Fail(Error.InternalServerError(""))
        : Result<bool>.Success(true);
    }
    public async Task<Result<string>> CheckUser(int id)
    {
        UserService? user = await context.UserServices
        .Where(x => !x.IsDeleted)
        .FirstOrDefaultAsync(x => x.Id == id);

        if (user is null)
            return Result<string>.Fail(Error.NotFound());

        string paymentMessage = user.CheckPaymentDue(user.LastPayMentDate);
        return Result<string>.Success(paymentMessage);

    }
}