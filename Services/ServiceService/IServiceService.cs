public interface IServiceService
{
    Task<Result<bool>> CreateService(ServiceCreateInfo serviceCreate);
    Task<Result<bool>> UpdateService(int id, ServiceUpdateInfo serviceUpdate);
    Task<Result<bool>> DeleteService(int id);
    Task<Result<ServiceReadInfo>> GetByIdService(int id);
    Task<Result<PagedResponse<IEnumerable<ServiceReadInfo>>>> GetAllServices(BaseFilter filter);
}