namespace Domain.Models.Images
{
    public class ImagesDtoModel
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string ProductName { get; set; }
        public string LinkWebStore { get; set; }
        public string LinkSupplier { get; set; }
        public string LocalPath { get; set; }
    }
}
