namespace Presentation.Views.UserControls
{
    partial class ProductsUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.contextMenuOptions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.contextMenuOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvProducts
            // 
            this.dgvProducts.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProducts.Location = new System.Drawing.Point(0, 0);
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducts.Size = new System.Drawing.Size(884, 422);
            this.dgvProducts.TabIndex = 0;
            this.dgvProducts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvProducts_CellClick);
            this.dgvProducts.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvProducts_CellMouseLeave);
            this.dgvProducts.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvProducts_CellMouseMove);
            // 
            // contextMenuOptions
            // 
            this.contextMenuOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addMenuItem,
            this.editMenuItem,
            this.deleteMenuItem});
            this.contextMenuOptions.Name = "contextMenuOptions";
            this.contextMenuOptions.Size = new System.Drawing.Size(135, 70);
            // 
            // addMenuItem
            // 
            this.addMenuItem.Image = global::Presentation.Properties.Resources.AddBlack24x24;
            this.addMenuItem.Name = "addMenuItem";
            this.addMenuItem.Size = new System.Drawing.Size(134, 22);
            this.addMenuItem.Text = "Додати";
            this.addMenuItem.Click += new System.EventHandler(this.AddMenuItem_Click);
            // 
            // editMenuItem
            // 
            this.editMenuItem.Image = global::Presentation.Properties.Resources.EditBlack24x24;
            this.editMenuItem.Name = "editMenuItem";
            this.editMenuItem.Size = new System.Drawing.Size(134, 22);
            this.editMenuItem.Text = "Редагувати";
            this.editMenuItem.Click += new System.EventHandler(this.EditMenuItem_Click);
            // 
            // deleteMenuItem
            // 
            this.deleteMenuItem.Image = global::Presentation.Properties.Resources.DeleteBlack24x24;
            this.deleteMenuItem.Name = "deleteMenuItem";
            this.deleteMenuItem.Size = new System.Drawing.Size(134, 22);
            this.deleteMenuItem.Text = "Видалити";
            this.deleteMenuItem.Click += new System.EventHandler(this.DeleteMenuItem_Click);
            // 
            // ProductsUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvProducts);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ProductsUC";
            this.Size = new System.Drawing.Size(884, 422);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.contextMenuOptions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.ContextMenuStrip contextMenuOptions;
        private System.Windows.Forms.ToolStripMenuItem addMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteMenuItem;
    }
}
