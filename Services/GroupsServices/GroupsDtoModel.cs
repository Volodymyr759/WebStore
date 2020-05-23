namespace Services.GroupsServices
{
    /// <summary>
    /// Модель Dto груп
    /// </summary>
    public class GroupsDtoModel
    {
        /// <summary>
        /// Ідентифікатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Назва групи
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Тип товару
        /// </summary>
        public string ProductType { get; set; }

        /// <summary>
        /// Номер групи на власному сайті
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Ідентифікатор групи на власному сайті
        /// </summary>
        public string Identifier { get; set; }

        /// <summary>
        /// Номер групи-предка
        /// </summary>
        public string AncestorNumber { get; set; }

        /// <summary>
        /// Ідентифікатор групи-предка
        /// </summary>
        public string AncestorIdentifier { get; set; }

        /// <summary>
        /// Посилання на сторінку групи
        /// </summary>
        public string Link { get; set; }

        /// <summary>
        /// Примітки / опис групи
        /// </summary>
        public string Notes { get; set; }
    }
}
