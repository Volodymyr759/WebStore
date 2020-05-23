namespace Domain.Models.Images
{
    /// <summary>
    /// Модель зображення
    /// </summary>
    public class ImagesModel : IImagesModel
    {
        /// <summary>
        /// Ідентифікатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Ідетифікатор товару зображення
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Назва файлу зображення
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Посилання на сторінку зображення на власному сайті
        /// </summary>
        public string LinkWebStore { get; set; }

        /// <summary>
        /// Посилання на сторінку зображення на сайті постачальника
        /// </summary>
        public string LinkSupplier { get; set; }

        /// <summary>
        /// Локальний шлях зберігання зображення
        /// </summary>
        public string LocalPath { get; set; }
    }
}
