using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.Models;
using RestaurantAPI.Services;

namespace RestaurantAPI.Controllers;

[Route("api/restaurant/{restaurantId}/dish")]
[ApiController]
public class DishController: ControllerBase
{
    private readonly IDishService _dishService;

    public DishController(IDishService dishService)
    {
        _dishService = dishService;
    }

    [HttpDelete("{dishId}")]
    public ActionResult DeleteById(int restaurantId, int dishId)
    {
        _dishService.DeleteById(restaurantId, dishId);
        return NoContent();
    }

    [HttpDelete]
    public ActionResult DeleteAll(int restaurantId)
    {
        _dishService.DeleteAll(restaurantId);
        return NoContent();
    }
    
    [HttpPost]
    public ActionResult Post([FromRoute] int restaurantId, [FromBody] CreateDishDto dto)
    {
        var newDishId = _dishService.Create(restaurantId, dto);
        return Created($"api/restaurant/{restaurantId}/dish/{newDishId}", newDishId);
    }

    [HttpGet("{dishId}")]
    public ActionResult<DishDto> Get([FromRoute] int restaurantId, [FromRoute] int dishId)
    {
        var dish = _dishService.GetById(restaurantId, dishId);
        return Ok(dish);
    }
    
    [HttpGet]
    public ActionResult<List<DishDto>> GetAll([FromRoute] int restaurantId)
    {
        var result = _dishService.GetAll(restaurantId);
        return Ok(result);
    }
}