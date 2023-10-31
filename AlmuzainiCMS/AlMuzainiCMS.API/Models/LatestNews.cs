namespace AlMuzainiCMS.API.Models
{
    public class LatestNews
    {
        
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public string ImagePath { get; set; }
        public string UpdatedAt { get; set; }
       
    }
}
