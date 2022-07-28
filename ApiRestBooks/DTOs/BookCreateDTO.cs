using System.ComponentModel.DataAnnotations;

namespace ApiRestBooks.DTOs
{
    public class BookCreateDTO
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int PageCount { get; set; }
        [Required]
        public string Excerpt { get; set; }
        [Required]
        public DateTime PublishDate { get; set; }
    }
}
