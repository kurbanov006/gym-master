using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

[Route("/api/usertrainer/")]
public class UserTrainerController(IUserTrainerService trainerService) : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] UserTrainerCreateInfo userTrainerCreate)
   => (await trainerService.CreateUserTrainer(userTrainerCreate)).ToActionResult();

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UserTrainerUpdateInfo userTrainer)
    => (await trainerService.UpdateUserTrainer(id, userTrainer)).ToActionResult();

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    => (await trainerService.DeleteUserTrainer(id)).ToActionResult();

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] BaseFilter filter)
    => (await trainerService.GetAllUserTrainer(filter)).ToActionResult();

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    => (await trainerService.GetByIdUserTrainer(id)).ToActionResult();
}