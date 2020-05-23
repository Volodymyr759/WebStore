namespace Services.ImagesServices
{
    /// <summary>
    /// Модель Dto зображень
    /// </summary>
    public class ImagesDtoModel
    {
        /// <summary>
        /// Ідентифікатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Назва файлу зображення
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Ідетифікатор товару зображення
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Назва товару зображення
        /// </summary>
        public string ProductName { get; set; }

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
