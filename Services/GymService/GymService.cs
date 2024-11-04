
using Microsoft.EntityFrameworkCore;

public class GymService(AppDbContext context) : IGymService
{
    public async Task<Result<bool>> CreateGym(GymCreateInfo gymCreate)
    {
        bool conflict = await context.Gyms.AnyAsync(
            x => x.GymName.ToLower() == gymCreate.GymBaseInfo.GymName.ToLower());

        if (conflict)
            return Result<bool>.Fail(Error.Conflict());

        await context.Gyms.AddAsync(gymCreate.GymCreatToGym());
        int res = await context.SaveChangesAsync();

        return res is 0
        ? Result<bool>.Fail(Error.InternalServerError("Failed to add ..."))
        : Result<bool>.Success(true);
    }

    public async Task<Result<bool>> DeleteGym(int id)
    {
        Gym? gym = await context.Gyms.Where(x => x.IsDeleted == false).FirstOrDefaultAsync(x => x.Id == id);
        if (gym is null)
            return Result<bool>.Fail(Error.NotFound());

        gym.ToDeleteGym();
        int res = await context.SaveChangesAsync();

        return res is 0
        ? Result<bool>.Fail(Error.InternalServerError("Failed to delete ..."))
        : Result<bool>.Success(true);
    }

    public async Task<Result<PagedResponse<IEnumerable<GymReadInfo>>>> GetAllGyms(BaseFilter filter)
    {
        IQueryable<Gym> gyms = context.Gyms;

        if (gyms is null)
            return Result<PagedResponse<IEnumerable<GymReadInfo>>>.Fail(Error.NotFound());

        IQueryable<GymReadInfo> result = gyms.Where(x => x.IsDeleted == false).Skip((filter.PageNumber - 1) * filter.PageSize)
        .Take(filter.PageSize).Select(x => x.GymToGymRead());

        int totalRecords = await result.CountAsync();

        PagedResponse<IEnumerable<GymReadInfo>> response = PagedResponse<IEnumerable<GymReadInfo>>
        .Create(filter.PageNumber, filter.PageSize, totalRecords, result);

        return Result<PagedResponse<IEnumerable<GymReadInfo>>>.Success(response);
    }

    public async Task<Result<GymReadInfo>> GetByIdGym(int id)
    {
        Gym? gym = await context.Gyms.Where(x => x.IsDeleted == false).FirstOrDefaultAsync(x => x.Id == id);

        return gym is null
        ? Result<GymReadInfo>.Fail(Error.NotFound())
        : Result<GymReadInfo>.Success(gym.GymToGymRead());
    }

    public async Task<Result<bool>> UpdateGym(int id, GymUpdateInfo gymUpdate)
    {
        Gym? gym = await context.Gyms.Where(x => x.IsDeleted == false).FirstOrDefaultAsync(x => x.Id == id);
        if (gym is null)
            return Result<bool>.Fail(Error.NotFound());

        bool conflict = await context.Gyms.AnyAsync(x =>
        x.GymName.ToLower() == gymUpdate.GymBaseInfo.GymName.ToLower());

        if (conflict)
            return Result<bool>.Fail(Error.Conflict());

        context.Gyms.Update(gym.GymUpdateTOGYm(gymUpdate));
        int res = await context.SaveChangesAsync();
        return res is 0
        ? Result<bool>.Fail(Error.InternalServerError(""))
        : Result<bool>.Success(true);
    }
}