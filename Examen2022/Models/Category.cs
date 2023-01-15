using System.ComponentModel.DataAnnotations;


namespace Examen2022.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }

        public ICollection<Article> Articles { get; set; }
    }
}
