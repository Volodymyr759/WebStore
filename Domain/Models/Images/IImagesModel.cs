namespace Domain.Models.Images
{
    public interface IImagesModel
    {
        string FileName { get; set; }
        int Id { get; set; }
        string LinkWebStore { get; set; }
        string LinkSupplier { get; set; }
        string LocalPath { get; set; }
        int ProductId { get; set; }
    }
}