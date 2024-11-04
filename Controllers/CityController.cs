
using Microsoft.AspNetCore.Mvc;

[Route("/api/cities/")]
public class CityController(ICityService cityService) : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CityCreateInfo cityCreate)
    => (await cityService.CreateCity(cityCreate)).ToActionResult();

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] CityUpdateInfo cityUpdate)
    => (await cityService.UpdateCity(id, cityUpdate)).ToActionResult();

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    => (await cityService.DeleteCity(id)).ToActionResult();

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] BaseFilter filter)
    => (await cityService.GetAllCities(filter)).ToActionResult();

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    => (await cityService.GetByIdCity(id)).ToActionResult();
}