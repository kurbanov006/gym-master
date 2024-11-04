public interface IUserClientService
{
    Task<Result<bool>> CreateUserClient(UserClientCreateInfo userClientCreate);
    Task<Result<bool>> UpdateUserClient(int id, UserClientUpdateInfo userClientCreate);
    Task<Result<bool>> DeleteUserClient(int id);
    Task<Result<UserClientReadInfo>> GetByIdUserClient(int id);
    Task<Result<PagedResponse<IEnumerable<UserClientReadInfo>>>> GetAllUserClient(BaseFilter filter);
}