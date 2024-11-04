
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

public class CityService(AppDbContext context) : ICityService
{
    public async Task<Result<bool>> CreateCity(CityCreateInfo cityCreate)
    {
        bool conflict = await context.Cities.AnyAsync(
            x => x.CityName.ToLower() == cityCreate.CityBaseInfo.CityName.ToLower());

        if (conflict)
            return Result<bool>.Fail(Error.Conflict());

        await context.Cities.AddAsync(cityCreate.CityCreatToCity());
        int res = await context.SaveChangesAsync();

        return res is 0
        ? Result<bool>.Fail(Error.InternalServerError("Failed to add ..."))
        : Result<bool>.Success(true);
    }

    public async Task<Result<bool>> DeleteCity(int id)
    {
        City? city = await context.Cities.Where(x => x.IsDeleted == false).FirstOrDefaultAsync(x => x.Id == id);
        if (city is null)
            return Result<bool>.Fail(Error.NotFound());

        city.ToDeleteCity();
        int res = await context.SaveChangesAsync();

        return res is 0
        ? Result<bool>.Fail(Error.InternalServerError("Failed to delete ..."))
        : Result<bool>.Success(true);
    }

    public async Task<Result<PagedResponse<IEnumerable<CityReadInfo>>>> GetAllCities(BaseFilter filter)
    {
        IQueryable<City> cities = context.Cities;

        if (cities is null)
            return Result<PagedResponse<IEnumerable<CityReadInfo>>>.Fail(Error.NotFound());

        IQueryable<CityReadInfo> result = cities.Where(x => x.IsDeleted == false).Skip((filter.PageNumber - 1) * filter.PageSize)
        .Take(filter.PageSize).Select(x => x.CityToCityRead());

        int totalRecords = await result.CountAsync();

        PagedResponse<IEnumerable<CityReadInfo>> response = PagedResponse<IEnumerable<CityReadInfo>>
        .Create(filter.PageNumber, filter.PageSize, totalRecords, result);

        return Result<PagedResponse<IEnumerable<CityReadInfo>>>.Success(response);
    }

    public async Task<Result<CityReadInfo>> GetByIdCity(int id)
    {
        City? city = await context.Cities.Where(x => x.IsDeleted == false).FirstOrDefaultAsync(x => x.Id == id);

        return city is null
        ? Result<CityReadInfo>.Fail(Error.NotFound())
        : Result<CityReadInfo>.Success(city.CityToCityRead());
    }

    public async Task<Result<bool>> UpdateCity(int id, CityUpdateInfo cityUpdate)
    {
        City? city = await context.Cities.Where(x => x.IsDeleted == false).FirstOrDefaultAsync(x => x.Id == id);
        if (city is null)
            return Result<bool>.Fail(Error.NotFound());

        bool conflict = await context.Cities.AnyAsync(x =>
        x.CityName.ToLower() == cityUpdate.CityBaseInfo.CityName.ToLower());

        if (conflict)
            return Result<bool>.Fail(Error.Conflict());

        context.Cities.Update(city.CityUpdateToCity(cityUpdate));
        int res = await context.SaveChangesAsync();
        return res is 0
        ? Result<bool>.Fail(Error.InternalServerError(""))
        : Result<bool>.Success(true);
    }
}