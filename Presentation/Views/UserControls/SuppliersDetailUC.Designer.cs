namespace Presentation.Views.UserControls
{
    partial class SuppliersDetailUC
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
            this.textBoxId = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.labelLink = new System.Windows.Forms.Label();
            this.textBoxLink = new System.Windows.Forms.TextBox();
            this.labelCurrency = new System.Windows.Forms.Label();
            this.textBoxCurrency = new System.Windows.Forms.TextBox();
            this.labelNotes = new System.Windows.Forms.Label();
            this.richTextBoxNotes = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.Location = new System.Drawing.Point(100, 380);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 30);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Відмінити";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.Location = new System.Drawing.Point(19, 380);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 30);
            this.buttonSave.TabIndex = 3;
            this.buttonSave.Text = "Зберегти";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // textBoxId
            // 
            this.textBoxId.Location = new System.Drawing.Point(3, 349);
            this.textBoxId.Name = "textBoxId";
            this.textBoxId.Size = new System.Drawing.Size(78, 25);
            this.textBoxId.TabIndex = 4;
            this.textBoxId.Visible = false;
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(71, 21);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(115, 25);
            this.textBoxName.TabIndex = 6;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(11, 24);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(44, 17);
            this.labelName.TabIndex = 5;
            this.labelName.Text = "Назва";
            // 
            // labelLink
            // 
            this.labelLink.AutoSize = true;
            this.labelLink.Location = new System.Drawing.Point(11, 55);
            this.labelLink.Name = "labelLink";
            this.labelLink.Size = new System.Drawing.Size(35, 17);
            this.labelLink.TabIndex = 5;
            this.labelLink.Text = "Сайт";
            // 
            // textBoxLink
            // 
            this.textBoxLink.Location = new System.Drawing.Point(71, 52);
            this.textBoxLink.Name = "textBoxLink";
            this.textBoxLink.Size = new System.Drawing.Size(115, 25);
            this.textBoxLink.TabIndex = 6;
            // 
            // labelCurrency
            // 
            this.labelCurrency.AutoSize = true;
            this.labelCurrency.Location = new System.Drawing.Point(11, 86);
            this.labelCurrency.Name = "labelCurrency";
            this.labelCurrency.Size = new System.Drawing.Size(52, 17);
            this.labelCurrency.TabIndex = 5;
            this.labelCurrency.Text = "Валюта";
            // 
            // textBoxCurrency
            // 
            this.textBoxCurrency.Location = new System.Drawing.Point(71, 83);
            this.textBoxCurrency.Name = "textBoxCurrency";
            this.textBoxCurrency.Size = new System.Drawing.Size(115, 25);
            this.textBoxCurrency.TabIndex = 6;
            // 
            // labelNotes
            // 
            this.labelNotes.AutoSize = true;
            this.labelNotes.Location = new System.Drawing.Point(11, 117);
            this.labelNotes.Name = "labelNotes";
            this.labelNotes.Size = new System.Drawing.Size(38, 17);
            this.labelNotes.TabIndex = 5;
            this.labelNotes.Text = "Опис";
            // 
            // richTextBoxNotes
            // 
            this.richTextBoxNotes.Location = new System.Drawing.Point(73, 117);
            this.richTextBoxNotes.Name = "richTextBoxNotes";
            this.richTextBoxNotes.Size = new System.Drawing.Size(113, 137);
            this.richTextBoxNotes.TabIndex = 7;
            this.richTextBoxNotes.Text = "";
            // 
            // SuppliersDetailUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.richTextBoxNotes);
            this.Controls.Add(this.labelNotes);
            this.Controls.Add(this.textBoxCurrency);
            this.Controls.Add(this.labelCurrency);
            this.Controls.Add(this.textBoxLink);
            this.Controls.Add(this.labelLink);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.textBoxId);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SuppliersDetailUC";
            this.Size = new System.Drawing.Size(200, 422);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.TextBox textBoxId;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelLink;
        private System.Windows.Forms.TextBox textBoxLink;
        private System.Windows.Forms.Label labelCurrency;
        private System.Windows.Forms.TextBox textBoxCurrency;
        private System.Windows.Forms.Label labelNotes;
        private System.Windows.Forms.RichTextBox richTextBoxNotes;
    }
}
