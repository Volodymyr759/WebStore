namespace Presentation.Views.UserControls
{
    partial class ProductsDetailUC
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
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.textBoxNameWebStore = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxNameSupplier = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxCodeWebStore = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxCodeSupplier = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxPriceWebStore = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxPriceSupplier = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxCurrency = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxAvailable = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBoxLinkWebStore = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textBoxLinkSupplier = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.comboBoxSupplierName = new System.Windows.Forms.ComboBox();
            this.comboBoxCategoryName = new System.Windows.Forms.ComboBox();
            this.comboBoxGroupName = new System.Windows.Forms.ComboBox();
            this.comboBoxUnitName = new System.Windows.Forms.ComboBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.Location = new System.Drawing.Point(157, 424);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(77, 30);
            this.buttonCancel.TabIndex = 3;
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
            this.buttonSave.TabIndex = 4;
            this.buttonSave.Text = "Зберегти";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // textBoxNameWebStore
            // 
            this.textBoxNameWebStore.Location = new System.Drawing.Point(94, 21);
            this.textBoxNameWebStore.Name = "textBoxNameWebStore";
            this.textBoxNameWebStore.Size = new System.Drawing.Size(204, 25);
            this.textBoxNameWebStore.TabIndex = 7;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(11, 24);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(44, 17);
            this.labelName.TabIndex = 6;
            this.labelName.Text = "Назва";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Назва пост.";
            // 
            // textBoxNameSupplier
            // 
            this.textBoxNameSupplier.Location = new System.Drawing.Point(94, 52);
            this.textBoxNameSupplier.Name = "textBoxNameSupplier";
            this.textBoxNameSupplier.Size = new System.Drawing.Size(204, 25);
            this.textBoxNameSupplier.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Постачальник";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Категорія";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Група";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 179);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 17);
            this.label5.TabIndex = 6;
            this.label5.Text = "Од. вим.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 239);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 17);
            this.label6.TabIndex = 6;
            this.label6.Text = "Код";
            // 
            // textBoxCodeWebStore
            // 
            this.textBoxCodeWebStore.Location = new System.Drawing.Point(61, 236);
            this.textBoxCodeWebStore.Name = "textBoxCodeWebStore";
            this.textBoxCodeWebStore.Size = new System.Drawing.Size(70, 25);
            this.textBoxCodeWebStore.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(137, 239);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 17);
            this.label7.TabIndex = 6;
            this.label7.Text = "Код постач.";
            // 
            // textBoxCodeSupplier
            // 
            this.textBoxCodeSupplier.Location = new System.Drawing.Point(222, 236);
            this.textBoxCodeSupplier.Name = "textBoxCodeSupplier";
            this.textBoxCodeSupplier.Size = new System.Drawing.Size(76, 25);
            this.textBoxCodeSupplier.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(137, 179);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 17);
            this.label8.TabIndex = 6;
            this.label8.Text = "Ціна";
            // 
            // textBoxPriceWebStore
            // 
            this.textBoxPriceWebStore.AcceptsReturn = true;
            this.textBoxPriceWebStore.Location = new System.Drawing.Point(222, 176);
            this.textBoxPriceWebStore.Name = "textBoxPriceWebStore";
            this.textBoxPriceWebStore.Size = new System.Drawing.Size(76, 25);
            this.textBoxPriceWebStore.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(137, 210);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 17);
            this.label9.TabIndex = 6;
            this.label9.Text = "Ціна пост.";
            // 
            // textBoxPriceSupplier
            // 
            this.textBoxPriceSupplier.Location = new System.Drawing.Point(222, 207);
            this.textBoxPriceSupplier.Name = "textBoxPriceSupplier";
            this.textBoxPriceSupplier.Size = new System.Drawing.Size(76, 25);
            this.textBoxPriceSupplier.TabIndex = 7;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(11, 210);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 17);
            this.label10.TabIndex = 6;
            this.label10.Text = "Валюта";
            // 
            // textBoxCurrency
            // 
            this.textBoxCurrency.Enabled = false;
            this.textBoxCurrency.Location = new System.Drawing.Point(82, 207);
            this.textBoxCurrency.Name = "textBoxCurrency";
            this.textBoxCurrency.Size = new System.Drawing.Size(49, 25);
            this.textBoxCurrency.TabIndex = 7;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(11, 270);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 17);
            this.label11.TabIndex = 6;
            this.label11.Text = "Наявно";
            // 
            // textBoxAvailable
            // 
            this.textBoxAvailable.Location = new System.Drawing.Point(108, 267);
            this.textBoxAvailable.Name = "textBoxAvailable";
            this.textBoxAvailable.Size = new System.Drawing.Size(190, 25);
            this.textBoxAvailable.TabIndex = 7;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(11, 301);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(33, 17);
            this.label12.TabIndex = 6;
            this.label12.Text = "Лінк";
            // 
            // textBoxLinkWebStore
            // 
            this.textBoxLinkWebStore.Location = new System.Drawing.Point(108, 298);
            this.textBoxLinkWebStore.Name = "textBoxLinkWebStore";
            this.textBoxLinkWebStore.Size = new System.Drawing.Size(190, 25);
            this.textBoxLinkWebStore.TabIndex = 7;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(11, 332);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(80, 17);
            this.label13.TabIndex = 6;
            this.label13.Text = "Лінк постач.";
            // 
            // textBoxLinkSupplier
            // 
            this.textBoxLinkSupplier.Location = new System.Drawing.Point(108, 329);
            this.textBoxLinkSupplier.Name = "textBoxLinkSupplier";
            this.textBoxLinkSupplier.Size = new System.Drawing.Size(190, 25);
            this.textBoxLinkSupplier.TabIndex = 7;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(11, 360);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(38, 17);
            this.label14.TabIndex = 6;
            this.label14.Text = "Опис";
            // 
            // comboBoxSupplierName
            // 
            this.comboBoxSupplierName.FormattingEnabled = true;
            this.comboBoxSupplierName.Location = new System.Drawing.Point(108, 83);
            this.comboBoxSupplierName.Name = "comboBoxSupplierName";
            this.comboBoxSupplierName.Size = new System.Drawing.Size(190, 25);
            this.comboBoxSupplierName.TabIndex = 8;
            // 
            // comboBoxCategoryName
            // 
            this.comboBoxCategoryName.FormattingEnabled = true;
            this.comboBoxCategoryName.Location = new System.Drawing.Point(108, 114);
            this.comboBoxCategoryName.Name = "comboBoxCategoryName";
            this.comboBoxCategoryName.Size = new System.Drawing.Size(190, 25);
            this.comboBoxCategoryName.TabIndex = 8;
            // 
            // comboBoxGroupName
            // 
            this.comboBoxGroupName.FormattingEnabled = true;
            this.comboBoxGroupName.Location = new System.Drawing.Point(108, 145);
            this.comboBoxGroupName.Name = "comboBoxGroupName";
            this.comboBoxGroupName.Size = new System.Drawing.Size(190, 25);
            this.comboBoxGroupName.TabIndex = 8;
            // 
            // comboBoxUnitName
            // 
            this.comboBoxUnitName.FormattingEnabled = true;
            this.comboBoxUnitName.Location = new System.Drawing.Point(82, 176);
            this.comboBoxUnitName.Name = "comboBoxUnitName";
            this.comboBoxUnitName.Size = new System.Drawing.Size(49, 25);
            this.comboBoxUnitName.TabIndex = 8;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(105, 358);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(193, 61);
            this.richTextBox1.TabIndex = 9;
            this.richTextBox1.Text = "";
            // 
            // ProductsDetailUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.comboBoxUnitName);
            this.Controls.Add(this.comboBoxGroupName);
            this.Controls.Add(this.comboBoxCategoryName);
            this.Controls.Add(this.comboBoxSupplierName);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.textBoxLinkSupplier);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.textBoxLinkWebStore);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.textBoxAvailable);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBoxCurrency);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBoxPriceSupplier);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBoxPriceWebStore);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBoxCodeSupplier);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxCodeWebStore);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxNameSupplier);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxNameWebStore);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MaximumSize = new System.Drawing.Size(310, 469);
            this.MinimumSize = new System.Drawing.Size(310, 469);
            this.Name = "ProductsDetailUC";
            this.Size = new System.Drawing.Size(310, 469);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.TextBox textBoxNameWebStore;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxNameSupplier;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxCodeWebStore;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxCodeSupplier;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxPriceWebStore;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxPriceSupplier;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxCurrency;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBoxAvailable;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBoxLinkWebStore;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBoxLinkSupplier;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox comboBoxSupplierName;
        private System.Windows.Forms.ComboBox comboBoxCategoryName;
        private System.Windows.Forms.ComboBox comboBoxGroupName;
        private System.Windows.Forms.ComboBox comboBoxUnitName;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}
