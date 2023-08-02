namespace AlmuzainiCMS.Models
{
    public class FileUpload
    {
        public IFormFile ImgFile { get; set; }
        public IFormFile[] ImgFiles { get; set; }
        public int MyProperty { get; set; }
    }
}
