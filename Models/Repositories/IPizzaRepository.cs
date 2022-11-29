
using Microsoft.Extensions.Hosting;

namespace la_mia_pizzeria_model.Models.Repositories
{
    public interface IPizzaRepository
    {
        List<Pizza> All();
        List<Pizza> AllWithRelations();
        List<Pizza> SearchByTitle(string? name);
        void Create(Pizza pizza, List<int> selectedPizze);
        void Delete(Pizza pizza);
        Pizza GetById(int id);
        void Update(Pizza pizza, Pizza formData, List<int>? selectedPizze);
    }
}
