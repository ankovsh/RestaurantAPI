using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.Models;
using RestaurantAPI.Services;

namespace RestaurantAPI.Controllers;

[Route("api/restaurant")]
[ApiController]
[Authorize]
public class RestaurantController : ControllerBase
{
    private readonly IRestaurantService _restaurantService;

    public RestaurantController(IRestaurantService  restaurantService)
    {
        _restaurantService = restaurantService;
    }

    [HttpPut("{id}")]
    public ActionResult UpdateRestaurant([FromRoute] int id, [FromBody]UpdateRestaurantDto dto)
    {
        _restaurantService.Update(id, dto);
        return Ok();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete([FromRoute] int id)
    {
        _restaurantService.Delete(id);
        return NoContent();
    }

    [HttpPost]
    [Authorize(Roles = "Admin,Manager")]
    public ActionResult CreateRestaurant([FromBody]CreateRestaurantDto dto)
    {
        var id = _restaurantService.Create(dto);
        
        return Created($"api/restaurant/{id}", null);
    }
    
    [HttpGet]
    [Authorize(Policy = "HasNationality")]
    public ActionResult<IEnumerable<RestaurantDto>> GetAll()
    {
        var restaurantDtos = _restaurantService.GetAll();
        return Ok(restaurantDtos);
    }

    [HttpGet("{id}")]
    public ActionResult<RestaurantDto> Get([FromRoute]int id)
    {
        var restaurantDto = _restaurantService.GetById(id);
        
        return Ok(restaurantDto);
    }
}