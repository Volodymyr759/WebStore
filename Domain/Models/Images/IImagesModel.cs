namespace Domain.Models.Images
{
    /// <summary>
    /// Інтерфейс моделі зображень
    /// </summary>
    public interface IImagesModel
    {
        /// <summary>
        /// Ідентифікатор
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Ідетифікатор товару зображення
        /// </summary>
        int ProductId { get; set; }

        /// <summary>
        /// Назва файлу зображення
        /// </summary>
        string FileName { get; set; }

        /// <summary>
        /// Посилання на сторінку зображення на власному сайті
        /// </summary>
        string LinkWebStore { get; set; }

        /// <summary>
        /// Посилання на сторінку зображення на сайті постачальника
        /// </summary>
        string LinkSupplier { get; set; }

        /// <summary>
        /// Локальний шлях зберігання зображення
        /// </summary>
        string LocalPath { get; set; }
    }
}