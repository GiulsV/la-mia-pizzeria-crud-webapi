using la_mia_pizzeria_model.Models;
using la_mia_pizzeria_model.Models.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;


namespace la_mia_pizzeria_model.Controllers.Api
{

    [Route("api/[controller]", Order = 1)]
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

        [HttpGet]
        public IActionResult Get(string? title)
        {
            List<Pizza> pizzas = _pizzaRepository.SearchByTitle(title);

            return Ok(pizzas);

        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Pizza pizzas = _pizzaRepository.GetById(id);

            return Ok(pizzas);
        }


        ////SEARCH
        //public IActionResult Search(string? name)
        //{

        //    List<Pizza> pizzas = _pizzaRepository.SearchByTitle(name);

        //    return Ok(pizzas);

        //}

        ////DETAIL
        //[HttpGet("{id}")]
        //public IActionResult Detail(int id)
        //{
        //    Pizza pizza = _pizzaRepository.GetById(id);

        //    return Ok(pizza);
        //}

        //UPDATE
        [HttpPost]
        public IActionResult Update(Pizza pizza)
        {
            return Ok("ok");
        }
    }
}
