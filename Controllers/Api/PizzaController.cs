using la_mia_pizzeria_model.Models;
using la_mia_pizzeria_model.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;


namespace la_mia_pizzeria_model.Controllers.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        IPizzaRepository _pizzaRepository;
        public PizzaController(IPizzaRepository pizzaRepository)
        {
            _pizzaRepository = pizzaRepository;
        }

        public IActionResult Get() 
        {
            List<Pizza> pizzas = _pizzaRepository.All();
            return Ok(pizzas);
        }


        public IActionResult Search(string? name)
        {

            List<Pizza> pizzas = _pizzaRepository.SearchByTitle(name);

            return Ok(pizzas);

        }
    }
}
