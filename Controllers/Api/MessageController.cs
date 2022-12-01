using la_mia_pizzeria_model.Data;
using la_mia_pizzeria_model.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace la_mia_pizzeria_model.Controllers.Api
{

    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private PizzeriaDbContext db;

        public MessageController(PizzeriaDbContext _db)
        {
            db = _db;
        }
        
        
        [HttpPost]
        public IActionResult Create([FromBody] Message message)
        {

            try
            {
                db.Messages.Add(message);
                db.SaveChanges();

            }
            catch (Exception e)
            {
                return UnprocessableEntity(e.Message);
            }

            return Ok(message);
        }
    }
}
