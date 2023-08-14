namespace AlmuzainiCMS.Models
{
    public class NewsVM
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile Image { get; set; }

        public string UpdatedAt { get; set; }

    }
}
