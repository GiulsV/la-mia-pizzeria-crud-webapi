using la_mia_pizzeria_model.Data;
using la_mia_pizzeria_model.Models;
using la_mia_pizzeria_model.Models.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace la_mia_pizzeria_model.Controllers
{
    [Route("api/[controller][action]")]
    [ApiController]
    public class CommentController : ControllerBase
    {

        public PizzeriaDbContext db;
        public CommentController(PizzeriaDbContext _db)
        {
            db = _db;
        }

        [HttpPost]
        public IActionResult Create([FromBody] Comment comment)
        {
            try
            {
                db.Comments.Add(comment);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                return UnprocessableEntity(e.Message);
            }
            return Ok(comment);
        }
    }
}
