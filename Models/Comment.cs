using System.ComponentModel.DataAnnotations;

namespace la_mia_pizzeria_model.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        
        [EmailAddress]
        public string UserEmail { get; set; }
        public string CommentTxt { get; set; }

        [Range(1, 10)]
        public int Rate { get; set; }
        public int PizzaId { get; set; }
        public Pizza Pizza { get; set;}
    }
}
