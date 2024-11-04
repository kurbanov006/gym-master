using Microsoft.EntityFrameworkCore;

public class UserTrainerService(AppDbContext context) : IUserTrainerService
{
    public async Task<Result<bool>> CreateUserTrainer(UserTrainerCreateInfo userTrainer)
    {
        bool conflict = await context.UserTrainers.AnyAsync(x =>
        x.Email.ToLower() == userTrainer.UserTrainerBaseInfo.UserBaseInfo.Email.ToLower());

        if (conflict)
            return Result<bool>.Fail(Error.Conflict());

        await context.UserTrainers.AddAsync(userTrainer.UserTrainerToUserTrainer());
        int res = await context.SaveChangesAsync();

        return res is 0
        ? Result<bool>.Fail(Error.InternalServerError("Failed to add ..."))
        : Result<bool>.Success(true);
    }

    public async Task<Result<bool>> DeleteUserTrainer(int id)
    {
        UserTrainer? userTrainer = await context.UserTrainers.Where(
            x => x.IsDeleted == false).FirstOrDefaultAsync(x => x.Id == id);
        if (userTrainer is null)
            return Result<bool>.Fail(Error.NotFound());

        userTrainer.ToDeleteUserTrainer();
        int res = await context.SaveChangesAsync();

        return res is 0
        ? Result<bool>.Fail(Error.InternalServerError("Failed to deleted"))
        : Result<bool>.Success(true);
    }

    public async Task<Result<PagedResponse<IEnumerable<UserTrainerReadInfo>>>> GetAllUserTrainer(BaseFilter filter)
    {
        IQueryable<UserTrainer> userTrainers = context.UserTrainers;

        if (userTrainers is null)
            return Result<PagedResponse<IEnumerable<UserTrainerReadInfo>>>.Fail(Error.NotFound());

        IQueryable<UserTrainerReadInfo> result = userTrainers.Where(x => x.IsDeleted == false)
        .Skip((filter.PageNumber - 1) * filter.PageSize)
        .Take(filter.PageSize)
        .Select(x => x.UserToUserRead());

        int totalRecords = await result.CountAsync();
        PagedResponse<IEnumerable<UserTrainerReadInfo>> response =
        PagedResponse<IEnumerable<UserTrainerReadInfo>>.Create(filter.PageNumber, filter.PageSize, totalRecords, result);

        return Result<PagedResponse<IEnumerable<UserTrainerReadInfo>>>.Success(response);
    }

    public async Task<Result<UserTrainerReadInfo>> GetByIdUserTrainer(int id)
    {
        UserTrainer? userTrainer = await context.UserTrainers.Where(x => x.IsDeleted == false).FirstOrDefaultAsync(x => x.Id == id);

        return userTrainer is null
        ? Result<UserTrainerReadInfo>.Fail(Error.NotFound())
        : Result<UserTrainerReadInfo>.Success(userTrainer.UserToUserRead());
    }

    public async Task<Result<bool>> UpdateUserTrainer(int id, UserTrainerUpdateInfo updateInfo)
    {
        UserTrainer? userTrainer = await context.UserTrainers.Where(x => x.IsDeleted == false).FirstOrDefaultAsync(x => x.Id == id);
        if (userTrainer is null)
            return Result<bool>.Fail(Error.NotFound());

        bool conflict = await context.UserTrainers.AnyAsync(x =>
        x.Email.ToLower() == updateInfo.UserTrainerBaseInfo.UserBaseInfo.Email.ToLower());

        context.UserTrainers.Update(userTrainer.UserTrainerUpdateToUserTrainer(updateInfo));
        int res = await context.SaveChangesAsync();
        return res is 0
        ? Result<bool>.Fail(Error.InternalServerError(""))
        : Result<bool>.Success(true);
    }
}