namespace Domain.Models.Groups
{
    /// <summary>
    /// Інтерфейс групи товарів власного каталогу
    /// </summary>
    public interface IGroupsModel
    {
        /// <summary>
        /// Ідентифікатор
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Назва групи
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Тип товару
        /// </summary>
        string ProductType { get; set; }

        /// <summary>
        /// Ідентифікатор групи на власному сайті
        /// </summary>
        string Identifier { get; set; }

        /// <summary>
        /// Номер групи на власному сайті
        /// </summary>
        string Number { get; set; }

        /// <summary>
        /// Посилання на сторінку групи
        /// </summary>
        string Link { get; set; }

        /// <summary>
        /// Ідентифікатор групи-предка
        /// </summary>
        string AncestorIdentifier { get; set; }

        /// <summary>
        /// Номер групи-предка
        /// </summary>
        string AncestorNumber { get; set; }

        /// <summary>
        /// Примітки / опис групи
        /// </summary>
        string Notes { get; set; }
    }
}