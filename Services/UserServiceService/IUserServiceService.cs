public interface IUserServiceService
{
    Task<Result<bool>> CreateUserService(UserServiceCreateInfo userService);
    Task<Result<bool>> UpdateUserService(int id, UserServiceUpdateInfo serviceUpdateInfo);
    Task<Result<bool>> DeleteUserServrice(int id);
    Task<Result<UserServiceReadInfo>> GetByIdUserService(int id);
    Task<Result<PagedResponse<IEnumerable<UserServiceReadInfo>>>> GetAllUserServices(BaseFilter filter);
    Task<Result<string>> CheckUser(int id);
}