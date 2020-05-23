namespace Domain.Models.Categories
{
    /// <summary>
    /// Модель Категорій
    /// </summary>
    public class CategoriesModel : ICategoriesModel
    {
        /// <summary>
        /// Ідентифікатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Назва категорії
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Ідентифікатор постачальника
        /// </summary>
        public int SupplierId { get; set; }

        /// <summary>
        /// Посилання на сторінку категорії
        /// </summary>
        public string Link { get; set; }

        /// <summary>
        /// Курс - множник для переводу між валютами і створення націнки для товарів, які належатимуть категорії
        /// </summary>
        public decimal Rate { get; set; }

        /// <summary>
        /// Примітки / опис категорії
        /// </summary>
        public string Notes { get; set; }
    }
}
