using Microsoft.AspNetCore.Mvc;

[Route("/api/userclients/")]
public class UserClientController(IUserClientService clientService) : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] UserClientCreateInfo userClientCreate)
    => (await clientService.CreateUserClient(userClientCreate)).ToActionResult();

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UserClientUpdateInfo userClient)
    => (await clientService.UpdateUserClient(id, userClient)).ToActionResult();

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    => (await clientService.DeleteUserClient(id)).ToActionResult();

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] BaseFilter filter)
    => (await clientService.GetAllUserClient(filter)).ToActionResult();

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    => (await clientService.GetByIdUserClient(id)).ToActionResult();
}