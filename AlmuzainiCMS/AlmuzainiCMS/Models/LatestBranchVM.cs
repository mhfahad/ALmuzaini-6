namespace AlmuzainiCMS.Models
{
    public class LatestBranchVM
    {
        public Guid Id { get; set; }

        public string SelectedDropdownValue { get; set; }
        public string BusinessType { get; set; }
        public string Area { get; set; }
        public string Adress { get; set; }
        public string Time { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Map { get; set; }


        public string UpdatedAt { get; set; }
    }
}
