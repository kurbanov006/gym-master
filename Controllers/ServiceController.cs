using Microsoft.AspNetCore.Mvc;

[Route("/api/servicess/")]
public class ServiceController(IServiceService serviceService) : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ServiceCreateInfo entity)
   => (await serviceService.CreateService(entity)).ToActionResult();

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] ServiceUpdateInfo countryUpdate)
    => (await serviceService.UpdateService(id, countryUpdate)).ToActionResult();

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    => (await serviceService.DeleteService(id)).ToActionResult();

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] BaseFilter filter)
    => (await serviceService.GetAllServices(filter)).ToActionResult();

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    => (await serviceService.GetByIdService(id)).ToActionResult();
}