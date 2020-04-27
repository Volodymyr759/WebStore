namespace Domain.Models.Images
{
    public class ImagesModel : IImagesModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string FileName { get; set; }
        public string LinkWebStore { get; set; }
        public string LinkSupplier { get; set; }
        public string LocalPath { get; set; }
    }
}
