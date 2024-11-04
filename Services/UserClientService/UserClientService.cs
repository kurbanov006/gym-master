
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

public class UserClientService(AppDbContext context) : IUserClientService
{
    public async Task<Result<bool>> CreateUserClient(UserClientCreateInfo userClientCreate)
    {
        bool conflict = await context.UserClients.AnyAsync(x =>
        x.Email.ToLower() == userClientCreate.UserClientBaseInfo.UserBaseInfo.Email.ToLower());

        if (conflict)
            return Result<bool>.Fail(Error.Conflict());

        await context.UserClients.AddAsync(userClientCreate.UserClientCreateToUserClient());
        int res = await context.SaveChangesAsync();

        return res is 0
        ? Result<bool>.Fail(Error.InternalServerError("Failed to add ..."))
        : Result<bool>.Success(true);
    }

    public async Task<Result<bool>> DeleteUserClient(int id)
    {
        UserClient? userClient = await context.UserClients.Where(
            x => x.IsDeleted == false).FirstOrDefaultAsync(x => x.Id == id);
        if (userClient is null)
            return Result<bool>.Fail(Error.NotFound());

        userClient.ToDeleteUserClient();
        int res = await context.SaveChangesAsync();

        return res is 0
        ? Result<bool>.Fail(Error.InternalServerError("Failed to deleted"))
        : Result<bool>.Success(true);
    }

    public async Task<Result<PagedResponse<IEnumerable<UserClientReadInfo>>>> GetAllUserClient(BaseFilter filter)
    {
        IQueryable<UserClient> userClients = context.UserClients;

        if (userClients is null)
            return Result<PagedResponse<IEnumerable<UserClientReadInfo>>>.Fail(Error.NotFound());

        IQueryable<UserClientReadInfo> result = userClients.Where(x => x.IsDeleted == false)
        .Skip((filter.PageNumber - 1) * filter.PageSize)
        .Take(filter.PageSize)
        .Select(x => x.UserToUserRead());

        int totalRecords = await result.CountAsync();
        PagedResponse<IEnumerable<UserClientReadInfo>> response =
        PagedResponse<IEnumerable<UserClientReadInfo>>.Create(filter.PageNumber, filter.PageSize, totalRecords, result);

        return Result<PagedResponse<IEnumerable<UserClientReadInfo>>>.Success(response);
    }

    public async Task<Result<UserClientReadInfo>> GetByIdUserClient(int id)
    {
        UserClient? userClient = await context.UserClients.Where(x => x.IsDeleted == false).FirstOrDefaultAsync(x => x.Id == id);

        return userClient is null
        ? Result<UserClientReadInfo>.Fail(Error.NotFound())
        : Result<UserClientReadInfo>.Success(userClient.UserToUserRead());
    }

    public async Task<Result<bool>> UpdateUserClient(int id, UserClientUpdateInfo userClientUpdate)
    {
        UserClient? userClient = await context.UserClients.Where(x => x.IsDeleted == false).FirstOrDefaultAsync(x => x.Id == id);
        if (userClient is null)
            return Result<bool>.Fail(Error.NotFound());

        bool conflict = await context.UserClients.AnyAsync(x =>
        x.Email.ToLower() == userClientUpdate.UserClientBaseInfo.UserBaseInfo.Email.ToLower());

        context.UserClients.Update(userClient.UserUpdateToUser(userClientUpdate));
        int res = await context.SaveChangesAsync();
        return res is 0
        ? Result<bool>.Fail(Error.InternalServerError(""))
        : Result<bool>.Success(true);
    }
}