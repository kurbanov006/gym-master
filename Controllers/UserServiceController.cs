using Microsoft.AspNetCore.Mvc;

[Route("/api/userservice/")]
public class UserServiceController(IUserServiceService userService) : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] UserServiceCreateInfo userServiceCreate)
    => (await userService.CreateUserService(userServiceCreate)).ToActionResult();

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UserServiceUpdateInfo userServiceUpdate)
    => (await userService.UpdateUserService(id, userServiceUpdate)).ToActionResult();

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    => (await userService.DeleteUserServrice(id)).ToActionResult();

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] BaseFilter filter)
    => (await userService.GetAllUserServices(filter)).ToActionResult();

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    => (await userService.GetByIdUserService(id)).ToActionResult();

    [HttpGet("checkPayment{id}")]
    public async Task<IActionResult> GetUserService(int id)
    => (await userService.CheckUser(id)).ToActionResult();
}