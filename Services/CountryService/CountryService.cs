
using Microsoft.EntityFrameworkCore;

public class CountryService(AppDbContext context) : ICountryService
{
    public async Task<Result<bool>> CreateCountry(CountryCreateInfo countryCreate)
    {
        bool conflict = await context.Countries.AnyAsync(x =>
        x.CountryName.ToLower() == countryCreate.countryBaseInfo.CountryName.ToLower());

        if (conflict)
            return Result<bool>.Fail(Error.Conflict());

        await context.Countries.AddAsync(countryCreate.CreatCountryToCountry());
        int res = await context.SaveChangesAsync();

        return res is 0
        ? Result<bool>.Fail(Error.InternalServerError("Failed to add ..."))
        : Result<bool>.Success(true);
    }

    public async Task<Result<bool>> DeleteCountry(int id)
    {
        Country? country = await context.Countries.Where(x => x.IsDeleted == false).FirstOrDefaultAsync(x => x.Id == id);
        if (country is null)
            return Result<bool>.Fail(Error.NotFound());

        country.ToDeleteCountry();
        int res = await context.SaveChangesAsync();

        return res is 0
        ? Result<bool>.Fail(Error.InternalServerError("Failed to delete ..."))
        : Result<bool>.Success(true);
    }

    public async Task<Result<PagedResponse<IEnumerable<CountryReadInfo>>>> GetAllCountries(BaseFilter filter)
    {
        IQueryable<Country> countries = context.Countries;

        if (countries is null)
            return Result<PagedResponse<IEnumerable<CountryReadInfo>>>.Fail(Error.NotFound());

        IQueryable<CountryReadInfo> result = countries.Where(x => x.IsDeleted == false).Skip((filter.PageNumber - 1) * filter.PageSize)
        .Take(filter.PageSize).Select(x => x.CountryToCountryRead());

        int totalRecords = await result.CountAsync();

        PagedResponse<IEnumerable<CountryReadInfo>> response = PagedResponse<IEnumerable<CountryReadInfo>>
        .Create(filter.PageNumber, filter.PageSize, totalRecords, result);

        return Result<PagedResponse<IEnumerable<CountryReadInfo>>>.Success(response);
    }

    public async Task<Result<CountryReadInfo>> GetByIdCountry(int id)
    {
        Country? country = await context.Countries.Where(x => x.IsDeleted == false).FirstOrDefaultAsync(x => x.Id == id);

        return country is null
        ? Result<CountryReadInfo>.Fail(Error.NotFound())
        : Result<CountryReadInfo>.Success(country.CountryToCountryRead());
    }

    public async Task<Result<bool>> UpdateCountry(int id, CountryUpdateInfo countryUpdate)
    {
        Country? country = await context.Countries.Where(x => x.IsDeleted == false).FirstOrDefaultAsync(x => x.Id == id);
        if (country is null)
            return Result<bool>.Fail(Error.NotFound());

        bool conflict = await context.Countries.AnyAsync(x =>
        x.CountryName.ToLower() == countryUpdate.countryBaseInfo.CountryName.ToLower());

        if (conflict)
            return Result<bool>.Fail(Error.Conflict());

        context.Countries.Update(country.UpdateCountryToCountry(countryUpdate));
        int res = await context.SaveChangesAsync();
        return res is 0
        ? Result<bool>.Fail(Error.InternalServerError(""))
        : Result<bool>.Success(true);
    }
}