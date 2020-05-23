namespace Presentation.Views.UserControls
{
    partial class ImagesDetailUC
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
            this.textBoxFileName = new System.Windows.Forms.TextBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.labelFileName = new System.Windows.Forms.Label();
            this.labelProductName = new System.Windows.Forms.Label();
            this.labelLinkWebStore = new System.Windows.Forms.Label();
            this.textBoxLinkWebStore = new System.Windows.Forms.TextBox();
            this.labelLinkSupplier = new System.Windows.Forms.Label();
            this.textBoxLinkSupplier = new System.Windows.Forms.TextBox();
            this.labelLocalPath = new System.Windows.Forms.Label();
            this.textBoxLocalPath = new System.Windows.Forms.TextBox();
            this.comboBoxProductName = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // textBoxFileName
            // 
            this.textBoxFileName.Location = new System.Drawing.Point(79, 17);
            this.textBoxFileName.Name = "textBoxFileName";
            this.textBoxFileName.Size = new System.Drawing.Size(212, 25);
            this.textBoxFileName.TabIndex = 9;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.Location = new System.Drawing.Point(157, 424);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(77, 30);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Відмінити";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.Location = new System.Drawing.Point(76, 424);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(77, 30);
            this.buttonSave.TabIndex = 6;
            this.buttonSave.Text = "Зберегти";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // labelFileName
            // 
            this.labelFileName.AutoSize = true;
            this.labelFileName.Location = new System.Drawing.Point(17, 20);
            this.labelFileName.Name = "labelFileName";
            this.labelFileName.Size = new System.Drawing.Size(38, 17);
            this.labelFileName.TabIndex = 4;
            this.labelFileName.Text = "Файл";
            // 
            // labelProductName
            // 
            this.labelProductName.AutoSize = true;
            this.labelProductName.Location = new System.Drawing.Point(17, 51);
            this.labelProductName.Name = "labelProductName";
            this.labelProductName.Size = new System.Drawing.Size(45, 17);
            this.labelProductName.TabIndex = 4;
            this.labelProductName.Text = "Товар";
            // 
            // labelLinkWebStore
            // 
            this.labelLinkWebStore.AutoSize = true;
            this.labelLinkWebStore.Location = new System.Drawing.Point(17, 82);
            this.labelLinkWebStore.Name = "labelLinkWebStore";
            this.labelLinkWebStore.Size = new System.Drawing.Size(33, 17);
            this.labelLinkWebStore.TabIndex = 4;
            this.labelLinkWebStore.Text = "Лінк";
            // 
            // textBoxLinkWebStore
            // 
            this.textBoxLinkWebStore.Location = new System.Drawing.Point(77, 79);
            this.textBoxLinkWebStore.Name = "textBoxLinkWebStore";
            this.textBoxLinkWebStore.Size = new System.Drawing.Size(214, 25);
            this.textBoxLinkWebStore.TabIndex = 9;
            // 
            // labelLinkSupplier
            // 
            this.labelLinkSupplier.AutoSize = true;
            this.labelLinkSupplier.Location = new System.Drawing.Point(17, 113);
            this.labelLinkSupplier.Name = "labelLinkSupplier";
            this.labelLinkSupplier.Size = new System.Drawing.Size(125, 17);
            this.labelLinkSupplier.TabIndex = 4;
            this.labelLinkSupplier.Text = "Лінк постачальника";
            // 
            // textBoxLinkSupplier
            // 
            this.textBoxLinkSupplier.Location = new System.Drawing.Point(77, 133);
            this.textBoxLinkSupplier.Name = "textBoxLinkSupplier";
            this.textBoxLinkSupplier.Size = new System.Drawing.Size(214, 25);
            this.textBoxLinkSupplier.TabIndex = 9;
            // 
            // labelLocalPath
            // 
            this.labelLocalPath.AutoSize = true;
            this.labelLocalPath.Location = new System.Drawing.Point(17, 167);
            this.labelLocalPath.Name = "labelLocalPath";
            this.labelLocalPath.Size = new System.Drawing.Size(44, 17);
            this.labelLocalPath.TabIndex = 4;
            this.labelLocalPath.Text = "Папка";
            // 
            // textBoxLocalPath
            // 
            this.textBoxLocalPath.Location = new System.Drawing.Point(77, 164);
            this.textBoxLocalPath.Name = "textBoxLocalPath";
            this.textBoxLocalPath.Size = new System.Drawing.Size(214, 25);
            this.textBoxLocalPath.TabIndex = 9;
            // 
            // comboBoxProductName
            // 
            this.comboBoxProductName.FormattingEnabled = true;
            this.comboBoxProductName.Location = new System.Drawing.Point(79, 48);
            this.comboBoxProductName.Name = "comboBoxProductName";
            this.comboBoxProductName.Size = new System.Drawing.Size(212, 25);
            this.comboBoxProductName.TabIndex = 10;
            // 
            // ImagesDetailUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.comboBoxProductName);
            this.Controls.Add(this.textBoxLocalPath);
            this.Controls.Add(this.textBoxLinkSupplier);
            this.Controls.Add(this.textBoxLinkWebStore);
            this.Controls.Add(this.labelLocalPath);
            this.Controls.Add(this.labelLinkSupplier);
            this.Controls.Add(this.textBoxFileName);
            this.Controls.Add(this.labelLinkWebStore);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.labelProductName);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.labelFileName);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ImagesDetailUC";
            this.Size = new System.Drawing.Size(310, 469);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxFileName;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label labelFileName;
        private System.Windows.Forms.Label labelProductName;
        private System.Windows.Forms.Label labelLinkWebStore;
        private System.Windows.Forms.TextBox textBoxLinkWebStore;
        private System.Windows.Forms.Label labelLinkSupplier;
        private System.Windows.Forms.TextBox textBoxLinkSupplier;
        private System.Windows.Forms.Label labelLocalPath;
        private System.Windows.Forms.TextBox textBoxLocalPath;
        private System.Windows.Forms.ComboBox comboBoxProductName;
    }
}
