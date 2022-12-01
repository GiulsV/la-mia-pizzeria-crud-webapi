using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Server;
using la_mia_pizzeria_model.Data;
using Azure;
using Microsoft.Extensions.Hosting;

namespace la_mia_pizzeria_model.Models.Repositories
{
    public class DbPizzaRepository : IPizzaRepository
    {
        private PizzeriaDbContext db;

        public DbPizzaRepository(PizzeriaDbContext _db)
        {
            db = _db;
        }

        public DbPizzaRepository()
        {
        }

        public List<Pizza> All()
        {
            return AllWithRelations();
        }

        public List<Pizza> AllWithRelations()
        {
            return db.Pizze.Include(pizza => pizza.Category).Include(pizza => pizza.Ingredients).ToList();
        }

        public Pizza GetById(int id)
        {
            return db.Pizze.Where(p => p.Id == id).Include("Category").Include("Ingredients").Include("Comments").FirstOrDefault();
        }

        public void Create(Pizza pizza, List<int> selectedIngredients)
        {
            //associazione dei tag selezionato dall'utente al modello

            pizza.Ingredients = new List<Ingredient>();
            foreach (int tagId in selectedIngredients)
            {
                //todo: implementare repository tag?
                Ingredient tag = db.Ingredients.Where(t => t.Id == tagId).FirstOrDefault();
                pizza.Ingredients.Add(tag);
            }

            db.Pizze.Add(pizza);
            db.SaveChanges();
        }


        public List<Pizza> SearchByTitle(string? name)
        {

            IQueryable<Pizza> query = db.Pizze.Include("Category").Include("Ingredients");

            if (name == null)
                return query.ToList();

            return query.Where(post => post.Name.ToLower().Contains(name.ToLower())).ToList();
        }

        public void Update(Pizza pizza, Pizza formData, List<int>? selectedIngredients)
        {

            if (selectedIngredients == null)
            {
                selectedIngredients = new List<int>();
            }


            pizza.Name = formData.Name;
            pizza.Description = formData.Description;
            pizza.Image = formData.Image;
            pizza.CategoryId = formData.CategoryId;

            pizza.Ingredients.Clear();


            foreach (int tagId in selectedIngredients)
            {
                Ingredient ingredient = db.Ingredients.Where(t => t.Id == tagId).FirstOrDefault();
                pizza.Ingredients.Add(ingredient);
            }

            //db.Update(pizza);
            db.SaveChanges();
        }

        public void Delete(Pizza pizza)
        {
            db.Pizze.Remove(pizza);
            db.SaveChanges();
        }
    }
}
