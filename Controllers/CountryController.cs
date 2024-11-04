using Microsoft.AspNetCore.Mvc;

[Route("/api/countries/")]
public class CountryController(ICountryService countryService) : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CountryCreateInfo entity)
    => (await countryService.CreateCountry(entity)).ToActionResult();

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] CountryUpdateInfo countryUpdate)
    => (await countryService.UpdateCountry(id, countryUpdate)).ToActionResult();

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    => (await countryService.DeleteCountry(id)).ToActionResult();

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery]BaseFilter filter)
    => (await countryService.GetAllCountries(filter)).ToActionResult();

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    => (await countryService.GetByIdCountry(id)).ToActionResult();

}