public interface ICityService
{
    Task<Result<bool>> CreateCity(CityCreateInfo cityCreate);
    Task<Result<bool>> UpdateCity(int id, CityUpdateInfo cityUpdate);
    Task<Result<bool>> DeleteCity(int id);
    Task<Result<CityReadInfo>> GetByIdCity(int id);
    Task<Result<PagedResponse<IEnumerable<CityReadInfo>>>> GetAllCities(BaseFilter filter);
}