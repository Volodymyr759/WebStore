using Common;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Presentation
{
    public partial class MainView : Form, IMainView
    {
        public event EventHandler UnitsMenuClickEventRaised;
        public event EventHandler ImagesMenuClickEventRaised;
        public event EventHandler ParametersMenuClickEventRaised;
        public event EventHandler SuppliersMenuClickEventRaised;
        public event EventHandler GroupsMenuClickEventRaised;
        public event EventHandler CategoriesMenuClickEventRaised;
        public event EventHandler ProductsMenuClickEventRaised;

        private BasePresenter basePresenter;

        public MainView()
        {
            InitializeComponent();
            basePresenter = new BasePresenter();
        }

        public void NewfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("notepad.exe");
            }
            catch
            {
                basePresenter.ShowErrorMessage("Управління товарами", "Помилка запуску текстового файлу");
            }
        }

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
                basePresenter.ShowErrorMessage("Управління товарами", "Помилка при відкритті файлу");
            }
        }

        public void ExportcsvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void ExportxmlToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void ProductsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                EventHelper.RaiseEvent(this, ProductsMenuClickEventRaised, e);
            }
            catch (Exception)
            {
                basePresenter.ShowErrorMessage("Управління товарами", "Помилка завантаження списку товарів");
            }
        }

        public void CategoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                EventHelper.RaiseEvent(this, CategoriesMenuClickEventRaised, e);
            }
            catch (Exception)
            {
                basePresenter.ShowErrorMessage("Управління товарами", "Помилка завантаження списку категорій товарів постачальників");
            }
        }

        public void GroupspromuaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                EventHelper.RaiseEvent(this, GroupsMenuClickEventRaised, e);
            }
            catch (Exception)
            {
                basePresenter.ShowErrorMessage("Управління товарами", "Помилка завантаження списку груп prom.ua");
            }
        }

        public void SuppliersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                EventHelper.RaiseEvent(this, SuppliersMenuClickEventRaised, e);
            }
            catch (Exception)
            {
                basePresenter.ShowErrorMessage("Управління товарами", "Помилка завантаження списку постачальників");
            }
        }

        public void ParametersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                EventHelper.RaiseEvent(this, ParametersMenuClickEventRaised, e);
            }
            catch (Exception)
            {
                basePresenter.ShowErrorMessage("Управління товарами", "Помилка завантаження списку характеристик");
            }
        }

        public void ImagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                EventHelper.RaiseEvent(this, ImagesMenuClickEventRaised, e);
            }
            catch (Exception)
            {
                basePresenter.ShowErrorMessage("Управління товарами", "Помилка завантаження списку зображень");
            }
        }

        public void UnitsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                EventHelper.RaiseEvent(this, UnitsMenuClickEventRaised, e);
            }
            catch (Exception)
            {
                basePresenter.ShowErrorMessage("Управління товарами", "Помилка завантаження одиниць виміру");
            }
        }

        public void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void SearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void HelpinfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void ShowMainView()
        {
            Show();
        }

        public Panel GetMainPanel()
        {
            return panelMain;
        }

        public Panel GetRightPanel()
        {
            return panelRight;
        }
    }
}
