public interface IUserTrainerService
{
    Task<Result<bool>> CreateUserTrainer(UserTrainerCreateInfo userTrainer);
    Task<Result<bool>> UpdateUserTrainer(int id, UserTrainerUpdateInfo updateInfo);
    Task<Result<bool>> DeleteUserTrainer(int id);
    Task<Result<UserTrainerReadInfo>> GetByIdUserTrainer(int id);
    Task<Result<PagedResponse<IEnumerable<UserTrainerReadInfo>>>> GetAllUserTrainer(BaseFilter filter);
}