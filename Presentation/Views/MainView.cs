using Common;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Presentation
{
    /// <summary>
    /// Головна форма
    /// </summary>
    public partial class MainView : Form, IMainView
    {
        #region Меню Файл

        /// <summary>
        /// Подія вибору експорту товарів у файл Сsv
        /// </summary>
        public event EventHandler ExportСsvMenuClickEventRaised;

        /// <summary>
        /// Подія вибору експорту товарів у файл Xml
        /// </summary>
        public event EventHandler ExportXmlMenuClickEventRaised;

        #endregion

        #region Меню Довідники

        /// <summary>
        /// Подія вибору довідника одиниць виміру
        /// </summary>
        public event EventHandler UnitsMenuClickEventRaised;

        /// <summary>
        /// Подія вибору довідника зображень товарів
        /// </summary>
        public event EventHandler ImagesMenuClickEventRaised;

        /// <summary>
        /// Подія вибору довідника характеристик товарів
        /// </summary>
        public event EventHandler ParametersMenuClickEventRaised;

        /// <summary>
        /// Подія вибору довідника постачальників
        /// </summary>
        public event EventHandler SuppliersMenuClickEventRaised;

        /// <summary>
        /// Подія вибору довідника груп власного каталогу
        /// </summary>
        public event EventHandler GroupsMenuClickEventRaised;

        /// <summary>
        /// Подія вибору довідника категорій постачальників
        /// </summary>
        public event EventHandler CategoriesMenuClickEventRaised;

        /// <summary>
        /// Подія вибору довідника товарів
        /// </summary>
        public event EventHandler ProductsMenuClickEventRaised;

        #endregion

        #region Меню Сервіс

        /// <summary>
        /// Подія вибору меню налаштувань
        /// </summary>
        public event EventHandler SettingsMenuClickEventRaised;

        /// <summary>
        /// Подія вибору меню завантаження нових товарів
        /// </summary>
        public event EventHandler FindNewProductsMenuClickEventRaised;

        /// <summary>
        /// Подія вибору меню завантаження застарілих товарів
        /// </summary>
        public event EventHandler FindOldProductsMenuClickEventRaised;

        /// <summary>
        /// Подія вибору меню перевірки наявності товарів у постачальників
        /// </summary>
        public event EventHandler CheckAvailabilityMenuClickEventRaised;

        /// <summary>
        /// Подія вибору меню перевірки цін товарів постачальників
        /// </summary>
        public event EventHandler CheckPricesMenuClickEventRaised;

        /// <summary>
        /// Подія вибору меню завантаження зображень товарів
        /// </summary>
        public event EventHandler GetImagesMenuClickEventRaised;

        /// <summary>
        /// Подія вибору меню завантаження характеристик товарів
        /// </summary>
        public event EventHandler GetParametersMenuClickEventRaised;

        #endregion

        #region Helpers

        /// <summary>
        /// Подія завантаження головної форми
        /// </summary>
        public event EventHandler MainViewLoadedEventRaised;

        #endregion

        private IErrorMessageView errorMessageView;

        /// <summary>
        /// Конструктор головної форми
        /// </summary>
        /// <param name="errorMessageView">Екземпляр універсальної форми повідомлення про помилку</param>
        public MainView(IErrorMessageView errorMessageView)
        {
            InitializeComponent();
            this.errorMessageView = errorMessageView;
        }

        private void MainView_Load(object sender, EventArgs e)
        {
            EventHelper.RaiseEvent(this, MainViewLoadedEventRaised, e);
        }

        /// <summary>
        /// Відкриває новий файл Блокнот
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void NewfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("notepad.exe");
            }
            catch
            {
                errorMessageView.ShowErrorMessageView("Управління товарами", "Помилка запуску текстового файлу.");
            }
        }

        /// <summary>
        /// Відкриває вікно пошуку файлів
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var fileContent = string.Empty;
                var filePath = string.Empty;
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    InitialDirectory = "c:\\",
                    //openFileDialog.Filter = "txt files (*.txt)|*.txt";
                    FilterIndex = 2,
                    RestoreDirectory = true
                };

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                    Process.Start(filePath);
                }
            }
            catch
            {
                errorMessageView.ShowErrorMessageView("Управління товарами", "Помилка при відкритті файлу.");
            }
        }

        /// <summary>
        /// Генерує подію експорту товарів у файл Сsv
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ExportcsvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                EventHelper.RaiseEvent(this, ExportСsvMenuClickEventRaised, e);
            }
            catch (Exception ex)
            {
                errorMessageView.ShowErrorMessageView("Управління товарами", ex.Message);
            }
        }

        /// <summary>
        /// Генерує подію експорту товарів у файл Xml
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ExportxmlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                EventHelper.RaiseEvent(this, ExportXmlMenuClickEventRaised, e);
            }
            catch (Exception ex)
            {
                errorMessageView.ShowErrorMessageView("Управління товарами", ex.Message);
            }
        }

        /// <summary>
        /// Закриває програму
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Генерує подію для відображення довідника товарів
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ProductsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                EventHelper.RaiseEvent(this, ProductsMenuClickEventRaised, e);
            }
            catch (Exception ex)
            {
                errorMessageView.ShowErrorMessageView("Управління товарами", ex.Message);
            }
        }

        /// <summary>
        /// Генерує подію для відображення довідника категорій постачальників
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void CategoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                EventHelper.RaiseEvent(this, CategoriesMenuClickEventRaised, e);
            }
            catch (Exception ex)
            {
                errorMessageView.ShowErrorMessageView("Управління товарами", ex.Message);
            }
        }

        /// <summary>
        /// Генерує подію для відображення груп власного каталогу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void GroupsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                EventHelper.RaiseEvent(this, GroupsMenuClickEventRaised, e);
            }
            catch (Exception ex)
            {
                errorMessageView.ShowErrorMessageView("Управління товарами", ex.Message);
            }
        }

        /// <summary>
        /// Генерує подію для відображення довідника постачальників
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void SuppliersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                EventHelper.RaiseEvent(this, SuppliersMenuClickEventRaised, e);
            }
            catch (Exception ex)
            {
                errorMessageView.ShowErrorMessageView("Управління товарами", ex.Message);
            }
        }

        /// <summary>
        /// Генерує подію для відображення довідника характеристик товарів
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ParametersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                EventHelper.RaiseEvent(this, ParametersMenuClickEventRaised, e);
            }
            catch (Exception ex)
            {
                errorMessageView.ShowErrorMessageView("Управління товарами", ex.Message);
            }
        }

        /// <summary>
        /// Генерує подію для відображення довідника зображень товарів
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ImagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                EventHelper.RaiseEvent(this, ImagesMenuClickEventRaised, e);
            }
            catch (Exception ex)
            {
                errorMessageView.ShowErrorMessageView("Управління товарами", ex.Message);
            }
        }

        /// <summary>
        /// Генерує подію для відображення довідника одиниць виміру
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void UnitsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                EventHelper.RaiseEvent(this, UnitsMenuClickEventRaised, e);
            }
            catch (Exception ex)
            {
                errorMessageView.ShowErrorMessageView("Управління товарами", ex.Message);
            }
        }

        /// <summary>
        /// Генерує подію для відображення налаштувань
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                EventHelper.RaiseEvent(this, SettingsMenuClickEventRaised, e);
            }
            catch (Exception ex)
            {
                errorMessageView.ShowErrorMessageView("Управління товарами", ex.Message);
            }
        }

        /// <summary>
        /// Перехід на веб-сторінку довідкового файлу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void HelpinfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {// TODO - змінити посилання на актуальну сторінку довідки
                Process.Start("https://earth.nullschool.net/#current/wind/surface/level/overlay=temp/orthographic=-336.53,50.54,2286/loc=24.008,49.545");

            }
            catch (Exception ex)
            {
                errorMessageView.ShowErrorMessageView("Управління товарами", ex.Message);
            }
        }

        /// <summary>
        /// Відкриває форму "Про програму"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox about = new AboutBox();
            about.Show();
        }

        /// <summary>
        /// Завантаження головної форми
        /// </summary>
        public void ShowMainView()
        {
            Show();
        }

        /// <summary>
        /// Повертає основну панель головної форми
        /// </summary>
        /// <returns></returns>
        public Panel GetMainPanel() => panelMain;

        /// <summary>
        /// Повертає праву панель головної форми
        /// </summary>
        public Panel GetRightPanel() => panelRight;

        /// <summary>
        /// Повертає елемент для переходу на сторінку за посиланням
        /// </summary>
        public ToolStripTextBox GetToolStripSearchBox() => toolStripTextBoxSearch;

        /// <summary>
        /// Генерує подію для завантаження нових товарів з джерел постачальників
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void FindNewProductsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                EventHelper.RaiseEvent(this, FindNewProductsMenuClickEventRaised, new EventArgs());
            }
            catch (Exception ex)
            {
                errorMessageView.ShowErrorMessageView("Управління товарами", ex.Message);
            }
        }

        /// <summary>
        /// Генерує подію для визначення застарілих товарів власного каталогу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void FindOldProductsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                EventHelper.RaiseEvent(this, FindOldProductsMenuClickEventRaised, new EventArgs());
            }
            catch (Exception ex)
            {
                errorMessageView.ShowErrorMessageView("Управління товарами", ex.Message);
            }
        }

        /// <summary>
        /// Генерує подію для перевірки наявності товарів у постачальників
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void CheckAvailabilityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                EventHelper.RaiseEvent(this, CheckAvailabilityMenuClickEventRaised, new EventArgs());
            }
            catch (Exception ex)
            {
                errorMessageView.ShowErrorMessageView("Управління товарами", ex.Message);
            }
        }

        /// <summary>
        /// Генерує подію для перевірки цін товарів у постачальників
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void CheckPricesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                EventHelper.RaiseEvent(this, CheckPricesMenuClickEventRaised, new EventArgs());
            }
            catch (Exception ex)
            {
                errorMessageView.ShowErrorMessageView("Управління товарами", ex.Message);
            }
        }

        private void GetImagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                EventHelper.RaiseEvent(this, GetImagesMenuClickEventRaised, new EventArgs());
            }
            catch (Exception ex)
            {
                errorMessageView.ShowErrorMessageView("Управління товарами", ex.Message);
            }
        }

        private void GetParametersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                EventHelper.RaiseEvent(this, GetParametersMenuClickEventRaised, new EventArgs());
            }
            catch (Exception ex)
            {
                errorMessageView.ShowErrorMessageView("Управління товарами", ex.Message);
            }
        }

        private void ToolStripButtonSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (toolStripTextBoxSearch.Text.Length > 0) Process.Start(toolStripTextBoxSearch.Text);
            }
            catch
            {
                errorMessageView.ShowErrorMessageView("Управління товарами", "Помилка відображення посилання.");
            }
        }
    }
}
