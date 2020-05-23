namespace Domain.Models.Categories
{
    /// <summary>
    /// Інтерфейс моделі Категорій
    /// </summary>
    public interface ICategoriesModel
    {
        /// <summary>
        /// Ідентифікатор
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Посилання на сторінку категорії
        /// </summary>
        string Link { get; set; }

        /// <summary>
        /// Назва категорії
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Примітки / опис категорії
        /// </summary>
        string Notes { get; set; }

        /// <summary>
        /// Курс - множник для переводу між валютами і створення націнки для товарів, які належатимуть категорії
        /// </summary>
        decimal Rate { get; set; }

        /// <summary>
        /// Ідентифікатор постачальника
        /// </summary>
        int SupplierId { get; set; }
    }
}