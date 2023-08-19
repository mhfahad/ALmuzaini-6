namespace AlmuzainiCMS.Models
{
    public class VideoFileUploadVM
    {
        public IFormFile[] VideoFile { get; set; }
        public IFormFile[]  VideoThumbFile  { get; set; }

        public string Position { get; set; }   
    }
}
