using Microsoft.AspNetCore.Mvc;

[Route("/api/gyms/")]
public class GymController(IGymService gymService) : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] GymCreateInfo entity)
    => (await gymService.CreateGym(entity)).ToActionResult();

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] GymUpdateInfo countryUpdate)
    => (await gymService.UpdateGym(id, countryUpdate)).ToActionResult();

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    => (await gymService.DeleteGym(id)).ToActionResult();

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] BaseFilter filter)
    => (await gymService.GetAllGyms(filter)).ToActionResult();

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    => (await gymService.GetByIdGym(id)).ToActionResult();

}