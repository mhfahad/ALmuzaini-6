namespace AlmuzainiCMS.Models
{
    public class LatestNewsVM
    {
        public Guid Id { get; set; }
        public string Title { get; set; }   
        public string Description { get; set; }

        public string ImagePath { get; set; }
        public string UpdatedAt { get; set; }

        public string FullDescription { get; set; }
        public string TruncatedDescription { get; set; }

    }
}
