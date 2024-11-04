public interface ICountryService
{
    Task<Result<bool>> CreateCountry(CountryCreateInfo countryCreate);
    Task<Result<bool>> UpdateCountry(int id, CountryUpdateInfo countryUpdate);
    Task<Result<bool>> DeleteCountry(int id);
    Task<Result<CountryReadInfo>> GetByIdCountry(int id);
    Task<Result<PagedResponse<IEnumerable<CountryReadInfo>>>> GetAllCountries(BaseFilter filter);
}