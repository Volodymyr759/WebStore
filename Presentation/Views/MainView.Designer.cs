namespace Presentation
{
    partial class MainView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportcsvToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportxmlToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.handbooksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.categoriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupspromuaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.suppliersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parametersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unitsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serviceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpinfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonNew = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonOpen = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripTextBoxSearch = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButtonSearch = new System.Windows.Forms.ToolStripButton();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelRight = new System.Windows.Forms.Panel();
            this.menuStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.handbooksToolStripMenuItem,
            this.serviceToolStripMenuItem,
            this.windowToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(7, 3, 0, 3);
            this.menuStrip.Size = new System.Drawing.Size(884, 25);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newfileToolStripMenuItem,
            this.openToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(48, 19);
            this.fileToolStripMenuItem.Text = "Файл";
            // 
            // newfileToolStripMenuItem
            // 
            this.newfileToolStripMenuItem.Name = "newfileToolStripMenuItem";
            this.newfileToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.newfileToolStripMenuItem.Text = "Новий";
            this.newfileToolStripMenuItem.Click += new System.EventHandler(this.NewfileToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.openToolStripMenuItem.Text = "Відкрити";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportcsvToolStripMenuItem,
            this.exportxmlToolStripMenuItem1});
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.exportToolStripMenuItem.Text = "Експорт";
            // 
            // exportcsvToolStripMenuItem
            // 
            this.exportcsvToolStripMenuItem.Name = "exportcsvToolStripMenuItem";
            this.exportcsvToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            this.exportcsvToolStripMenuItem.Text = "csv";
            this.exportcsvToolStripMenuItem.Click += new System.EventHandler(this.ExportcsvToolStripMenuItem_Click);
            // 
            // exportxmlToolStripMenuItem1
            // 
            this.exportxmlToolStripMenuItem1.Name = "exportxmlToolStripMenuItem1";
            this.exportxmlToolStripMenuItem1.Size = new System.Drawing.Size(93, 22);
            this.exportxmlToolStripMenuItem1.Text = "xml";
            this.exportxmlToolStripMenuItem1.Click += new System.EventHandler(this.ExportxmlToolStripMenuItem1_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.exitToolStripMenuItem.Text = "Вихід";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // handbooksToolStripMenuItem
            // 
            this.handbooksToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.productsToolStripMenuItem,
            this.categoriesToolStripMenuItem,
            this.groupspromuaToolStripMenuItem,
            this.suppliersToolStripMenuItem,
            this.parametersToolStripMenuItem,
            this.imagesToolStripMenuItem,
            this.unitsToolStripMenuItem});
            this.handbooksToolStripMenuItem.Name = "handbooksToolStripMenuItem";
            this.handbooksToolStripMenuItem.Size = new System.Drawing.Size(76, 19);
            this.handbooksToolStripMenuItem.Text = "Довідники";
            // 
            // productsToolStripMenuItem
            // 
            this.productsToolStripMenuItem.Name = "productsToolStripMenuItem";
            this.productsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.productsToolStripMenuItem.Text = "Товари";
            this.productsToolStripMenuItem.Click += new System.EventHandler(this.ProductsToolStripMenuItem_Click);
            // 
            // categoriesToolStripMenuItem
            // 
            this.categoriesToolStripMenuItem.Name = "categoriesToolStripMenuItem";
            this.categoriesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.categoriesToolStripMenuItem.Text = "Категорії";
            this.categoriesToolStripMenuItem.Click += new System.EventHandler(this.CategoriesToolStripMenuItem_Click);
            // 
            // groupspromuaToolStripMenuItem
            // 
            this.groupspromuaToolStripMenuItem.Name = "groupspromuaToolStripMenuItem";
            this.groupspromuaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.groupspromuaToolStripMenuItem.Text = "Групи prom.ua";
            this.groupspromuaToolStripMenuItem.Click += new System.EventHandler(this.GroupspromuaToolStripMenuItem_Click);
            // 
            // suppliersToolStripMenuItem
            // 
            this.suppliersToolStripMenuItem.Name = "suppliersToolStripMenuItem";
            this.suppliersToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.suppliersToolStripMenuItem.Text = "Постачальники";
            this.suppliersToolStripMenuItem.Click += new System.EventHandler(this.SuppliersToolStripMenuItem_Click);
            // 
            // parametersToolStripMenuItem
            // 
            this.parametersToolStripMenuItem.Name = "parametersToolStripMenuItem";
            this.parametersToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.parametersToolStripMenuItem.Text = "Характеристики";
            this.parametersToolStripMenuItem.Click += new System.EventHandler(this.ParametersToolStripMenuItem_Click);
            // 
            // imagesToolStripMenuItem
            // 
            this.imagesToolStripMenuItem.Name = "imagesToolStripMenuItem";
            this.imagesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.imagesToolStripMenuItem.Text = "Зображення";
            this.imagesToolStripMenuItem.Click += new System.EventHandler(this.ImagesToolStripMenuItem_Click);
            // 
            // unitsToolStripMenuItem
            // 
            this.unitsToolStripMenuItem.Name = "unitsToolStripMenuItem";
            this.unitsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.unitsToolStripMenuItem.Text = "Одиниці виміру";
            this.unitsToolStripMenuItem.Click += new System.EventHandler(this.UnitsToolStripMenuItem_Click);
            // 
            // serviceToolStripMenuItem
            // 
            this.serviceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.searchToolStripMenuItem});
            this.serviceToolStripMenuItem.Name = "serviceToolStripMenuItem";
            this.serviceToolStripMenuItem.Size = new System.Drawing.Size(55, 19);
            this.serviceToolStripMenuItem.Text = "Сервіс";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.settingsToolStripMenuItem.Text = "Налаштування";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.SettingsToolStripMenuItem_Click);
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.searchToolStripMenuItem.Text = "Пошук";
            this.searchToolStripMenuItem.Click += new System.EventHandler(this.SearchToolStripMenuItem_Click);
            // 
            // windowToolStripMenuItem
            // 
            this.windowToolStripMenuItem.Name = "windowToolStripMenuItem";
            this.windowToolStripMenuItem.Size = new System.Drawing.Size(49, 19);
            this.windowToolStripMenuItem.Text = "Вікно";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpinfoToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(75, 19);
            this.helpToolStripMenuItem.Text = "Допомога";
            // 
            // helpinfoToolStripMenuItem
            // 
            this.helpinfoToolStripMenuItem.Name = "helpinfoToolStripMenuItem";
            this.helpinfoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.helpinfoToolStripMenuItem.Text = "Довідка";
            this.helpinfoToolStripMenuItem.Click += new System.EventHandler(this.HelpinfoToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aboutToolStripMenuItem.Text = "Про програму";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonNew,
            this.toolStripButtonOpen,
            this.toolStripSeparator1,
            this.toolStripTextBoxSearch,
            this.toolStripButtonSearch});
            this.toolStrip.Location = new System.Drawing.Point(0, 25);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(884, 25);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "toolStrip1";
            // 
            // toolStripButtonNew
            // 
            this.toolStripButtonNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonNew.Image = global::Presentation.Properties.Resources._new;
            this.toolStripButtonNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonNew.Name = "toolStripButtonNew";
            this.toolStripButtonNew.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonNew.Text = "toolStripButton1";
            // 
            // toolStripButtonOpen
            // 
            this.toolStripButtonOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonOpen.Image = global::Presentation.Properties.Resources.OpenFolder;
            this.toolStripButtonOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonOpen.Name = "toolStripButtonOpen";
            this.toolStripButtonOpen.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonOpen.Text = "toolStripButton2";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripTextBoxSearch
            // 
            this.toolStripTextBoxSearch.Name = "toolStripTextBoxSearch";
            this.toolStripTextBoxSearch.Size = new System.Drawing.Size(250, 25);
            // 
            // toolStripButtonSearch
            // 
            this.toolStripButtonSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSearch.Image = global::Presentation.Properties.Resources.Search;
            this.toolStripButtonSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSearch.Name = "toolStripButtonSearch";
            this.toolStripButtonSearch.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonSearch.Text = "toolStripButton3";
            // 
            // panelMain
            // 
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 50);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(884, 422);
            this.panelMain.TabIndex = 2;
            // 
            // panelRight
            // 
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(684, 50);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(200, 422);
            this.panelRight.TabIndex = 3;
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 472);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.menuStrip);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainView";
            this.Text = "Управління товарами";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newfileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportcsvToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportxmlToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem handbooksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem categoriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem groupspromuaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem suppliersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem parametersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serviceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpinfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton toolStripButtonNew;
        private System.Windows.Forms.ToolStripButton toolStripButtonOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxSearch;
        private System.Windows.Forms.ToolStripButton toolStripButtonSearch;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.ToolStripMenuItem unitsToolStripMenuItem;
    }
}

