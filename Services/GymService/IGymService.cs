public interface IGymService
{
    Task<Result<bool>> CreateGym(GymCreateInfo gymCreate);
    Task<Result<bool>> UpdateGym(int id, GymUpdateInfo gymUpdate);
    Task<Result<bool>> DeleteGym(int id);
    Task<Result<GymReadInfo>> GetByIdGym(int id);
    Task<Result<PagedResponse<IEnumerable<GymReadInfo>>>> GetAllGyms(BaseFilter filter);
}