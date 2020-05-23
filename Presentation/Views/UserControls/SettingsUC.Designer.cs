namespace Presentation.Views.UserControls
{
    partial class SettingsUC
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
            this.labelFolderImages1 = new System.Windows.Forms.Label();
            this.textBoxFolderImagesOdesa = new System.Windows.Forms.TextBox();
            this.buttonSetFolderImagesOdesa = new System.Windows.Forms.Button();
            this.buttonSetFolderImagesKyiv = new System.Windows.Forms.Button();
            this.textBoxFolderImagesKyiv = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxSetShedule = new System.Windows.Forms.GroupBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.checkBoxLoadNewProducts = new System.Windows.Forms.CheckBox();
            this.checkBoxCheckPrices = new System.Windows.Forms.CheckBox();
            this.checkBoxCheckAvailability = new System.Windows.Forms.CheckBox();
            this.labelInterval = new System.Windows.Forms.Label();
            this.labelStart = new System.Windows.Forms.Label();
            this.checkBoxRunShedule = new System.Windows.Forms.CheckBox();
            this.textBoxStart = new System.Windows.Forms.MaskedTextBox();
            this.textBoxInterval = new System.Windows.Forms.NumericUpDown();
            this.groupBoxSetShedule.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxInterval)).BeginInit();
            this.SuspendLayout();
            // 
            // labelFolderImages1
            // 
            this.labelFolderImages1.AutoSize = true;
            this.labelFolderImages1.Location = new System.Drawing.Point(18, 35);
            this.labelFolderImages1.Name = "labelFolderImages1";
            this.labelFolderImages1.Size = new System.Drawing.Size(170, 17);
            this.labelFolderImages1.TabIndex = 0;
            this.labelFolderImages1.Text = "Каталог зображень Одеса:";
            // 
            // textBoxFolderImagesOdesa
            // 
            this.textBoxFolderImagesOdesa.Location = new System.Drawing.Point(194, 32);
            this.textBoxFolderImagesOdesa.Name = "textBoxFolderImagesOdesa";
            this.textBoxFolderImagesOdesa.Size = new System.Drawing.Size(334, 25);
            this.textBoxFolderImagesOdesa.TabIndex = 1;
            // 
            // buttonSetFolderImagesOdesa
            // 
            this.buttonSetFolderImagesOdesa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSetFolderImagesOdesa.Location = new System.Drawing.Point(534, 32);
            this.buttonSetFolderImagesOdesa.Name = "buttonSetFolderImagesOdesa";
            this.buttonSetFolderImagesOdesa.Size = new System.Drawing.Size(40, 27);
            this.buttonSetFolderImagesOdesa.TabIndex = 2;
            this.buttonSetFolderImagesOdesa.Text = "...";
            this.buttonSetFolderImagesOdesa.UseVisualStyleBackColor = true;
            this.buttonSetFolderImagesOdesa.Click += new System.EventHandler(this.ButtonSetFolderImagesOdesa_Click);
            // 
            // buttonSetFolderImagesKyiv
            // 
            this.buttonSetFolderImagesKyiv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSetFolderImagesKyiv.Location = new System.Drawing.Point(534, 74);
            this.buttonSetFolderImagesKyiv.Name = "buttonSetFolderImagesKyiv";
            this.buttonSetFolderImagesKyiv.Size = new System.Drawing.Size(40, 27);
            this.buttonSetFolderImagesKyiv.TabIndex = 5;
            this.buttonSetFolderImagesKyiv.Text = "...";
            this.buttonSetFolderImagesKyiv.UseVisualStyleBackColor = true;
            this.buttonSetFolderImagesKyiv.Click += new System.EventHandler(this.ButtonSetFolderImagesKyiv_Click);
            // 
            // textBoxFolderImagesKyiv
            // 
            this.textBoxFolderImagesKyiv.Location = new System.Drawing.Point(194, 74);
            this.textBoxFolderImagesKyiv.Name = "textBoxFolderImagesKyiv";
            this.textBoxFolderImagesKyiv.Size = new System.Drawing.Size(334, 25);
            this.textBoxFolderImagesKyiv.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Каталог зображень Київ:";
            // 
            // groupBoxSetShedule
            // 
            this.groupBoxSetShedule.Controls.Add(this.textBoxInterval);
            this.groupBoxSetShedule.Controls.Add(this.textBoxStart);
            this.groupBoxSetShedule.Controls.Add(this.buttonSave);
            this.groupBoxSetShedule.Controls.Add(this.checkBoxLoadNewProducts);
            this.groupBoxSetShedule.Controls.Add(this.checkBoxCheckPrices);
            this.groupBoxSetShedule.Controls.Add(this.checkBoxCheckAvailability);
            this.groupBoxSetShedule.Controls.Add(this.labelInterval);
            this.groupBoxSetShedule.Controls.Add(this.labelStart);
            this.groupBoxSetShedule.Controls.Add(this.checkBoxRunShedule);
            this.groupBoxSetShedule.Location = new System.Drawing.Point(21, 116);
            this.groupBoxSetShedule.Name = "groupBoxSetShedule";
            this.groupBoxSetShedule.Size = new System.Drawing.Size(553, 278);
            this.groupBoxSetShedule.TabIndex = 6;
            this.groupBoxSetShedule.TabStop = false;
            this.groupBoxSetShedule.Text = "Виконання завдань по встановленому графіку";
            // 
            // buttonSave
            // 
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.Location = new System.Drawing.Point(431, 232);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(97, 30);
            this.buttonSave.TabIndex = 4;
            this.buttonSave.Text = "Зберегти";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // checkBoxLoadNewProducts
            // 
            this.checkBoxLoadNewProducts.AutoSize = true;
            this.checkBoxLoadNewProducts.Location = new System.Drawing.Point(27, 201);
            this.checkBoxLoadNewProducts.Name = "checkBoxLoadNewProducts";
            this.checkBoxLoadNewProducts.Size = new System.Drawing.Size(365, 21);
            this.checkBoxLoadNewProducts.TabIndex = 3;
            this.checkBoxLoadNewProducts.Text = "Завантажувати в базу даних нові товари постачальників";
            this.checkBoxLoadNewProducts.UseVisualStyleBackColor = true;
            // 
            // checkBoxCheckPrices
            // 
            this.checkBoxCheckPrices.AutoSize = true;
            this.checkBoxCheckPrices.Location = new System.Drawing.Point(27, 174);
            this.checkBoxCheckPrices.Name = "checkBoxCheckPrices";
            this.checkBoxCheckPrices.Size = new System.Drawing.Size(264, 21);
            this.checkBoxCheckPrices.TabIndex = 3;
            this.checkBoxCheckPrices.Text = "Перевірка цін товарів у постачальників";
            this.checkBoxCheckPrices.UseVisualStyleBackColor = true;
            // 
            // checkBoxCheckAvailability
            // 
            this.checkBoxCheckAvailability.AutoSize = true;
            this.checkBoxCheckAvailability.Location = new System.Drawing.Point(27, 147);
            this.checkBoxCheckAvailability.Name = "checkBoxCheckAvailability";
            this.checkBoxCheckAvailability.Size = new System.Drawing.Size(304, 21);
            this.checkBoxCheckAvailability.TabIndex = 3;
            this.checkBoxCheckAvailability.Text = "Перевірка наявності товарів у постачальників";
            this.checkBoxCheckAvailability.UseVisualStyleBackColor = true;
            // 
            // labelInterval
            // 
            this.labelInterval.AutoSize = true;
            this.labelInterval.Location = new System.Drawing.Point(27, 107);
            this.labelInterval.Name = "labelInterval";
            this.labelInterval.Size = new System.Drawing.Size(89, 17);
            this.labelInterval.TabIndex = 1;
            this.labelInterval.Text = "Інтервал, год.";
            // 
            // labelStart
            // 
            this.labelStart.AutoSize = true;
            this.labelStart.Location = new System.Drawing.Point(27, 76);
            this.labelStart.Name = "labelStart";
            this.labelStart.Size = new System.Drawing.Size(85, 17);
            this.labelStart.TabIndex = 1;
            this.labelStart.Text = "Початок, час";
            // 
            // checkBoxRunShedule
            // 
            this.checkBoxRunShedule.AutoSize = true;
            this.checkBoxRunShedule.Location = new System.Drawing.Point(27, 41);
            this.checkBoxRunShedule.Name = "checkBoxRunShedule";
            this.checkBoxRunShedule.Size = new System.Drawing.Size(161, 21);
            this.checkBoxRunShedule.TabIndex = 0;
            this.checkBoxRunShedule.Text = "Виконувати по графіку";
            this.checkBoxRunShedule.UseVisualStyleBackColor = true;
            // 
            // textBoxStart
            // 
            this.textBoxStart.Location = new System.Drawing.Point(131, 73);
            this.textBoxStart.Mask = "00:00";
            this.textBoxStart.Name = "textBoxStart";
            this.textBoxStart.Size = new System.Drawing.Size(57, 25);
            this.textBoxStart.TabIndex = 5;
            this.textBoxStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxStart.ValidatingType = typeof(System.DateTime);
            // 
            // textBoxInterval
            // 
            this.textBoxInterval.Location = new System.Drawing.Point(131, 104);
            this.textBoxInterval.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.textBoxInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.textBoxInterval.Name = "textBoxInterval";
            this.textBoxInterval.Size = new System.Drawing.Size(57, 25);
            this.textBoxInterval.TabIndex = 6;
            this.textBoxInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxInterval.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // SettingsUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxSetShedule);
            this.Controls.Add(this.buttonSetFolderImagesKyiv);
            this.Controls.Add(this.textBoxFolderImagesKyiv);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonSetFolderImagesOdesa);
            this.Controls.Add(this.textBoxFolderImagesOdesa);
            this.Controls.Add(this.labelFolderImages1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "SettingsUC";
            this.Size = new System.Drawing.Size(900, 469);
            this.groupBoxSetShedule.ResumeLayout(false);
            this.groupBoxSetShedule.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxInterval)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelFolderImages1;
        private System.Windows.Forms.TextBox textBoxFolderImagesOdesa;
        private System.Windows.Forms.Button buttonSetFolderImagesOdesa;
        private System.Windows.Forms.Button buttonSetFolderImagesKyiv;
        private System.Windows.Forms.TextBox textBoxFolderImagesKyiv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBoxSetShedule;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.CheckBox checkBoxLoadNewProducts;
        private System.Windows.Forms.CheckBox checkBoxCheckPrices;
        private System.Windows.Forms.CheckBox checkBoxCheckAvailability;
        private System.Windows.Forms.Label labelInterval;
        private System.Windows.Forms.Label labelStart;
        private System.Windows.Forms.CheckBox checkBoxRunShedule;
        private System.Windows.Forms.NumericUpDown textBoxInterval;
        private System.Windows.Forms.MaskedTextBox textBoxStart;
    }
}
