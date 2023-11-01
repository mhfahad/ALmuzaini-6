namespace AlMuzainiCMS.API.Models
{
    public class HomeContentModel
    {
        public string[]? SliderFileNames { get; set; }
        public string[]? RateCalculatorFileNames { get; set; }  
        public string[]? MiddleSliderFileNames { get; set; }  
        public string[]? RoundButtonsFileNames { get; set; }
        public string[]? LastSliderFileNames { get; set; }  
        public string[]? VideosFileNames { get; set; }  
        public List<LatestNews>? LatestNews { get; set; }     
    }
}
