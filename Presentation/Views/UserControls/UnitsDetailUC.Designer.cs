namespace Presentation.Views.UserControls
{
    partial class UnitsDetailUC
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
            this.labelName = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxId = new System.Windows.Forms.TextBox();
            this.labelNotes = new System.Windows.Forms.Label();
            this.textBoxNotes = new System.Windows.Forms.TextBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(11, 24);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(44, 17);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Назва";
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.Location = new System.Drawing.Point(19, 380);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 30);
            this.buttonSave.TabIndex = 1;
            this.buttonSave.Text = "Зберегти";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(71, 21);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(115, 25);
            this.textBoxName.TabIndex = 2;
            // 
            // textBoxId
            // 
            this.textBoxId.Location = new System.Drawing.Point(3, 337);
            this.textBoxId.Name = "textBoxId";
            this.textBoxId.Size = new System.Drawing.Size(78, 25);
            this.textBoxId.TabIndex = 2;
            this.textBoxId.Visible = false;
            // 
            // labelNotes
            // 
            this.labelNotes.AutoSize = true;
            this.labelNotes.Location = new System.Drawing.Point(11, 55);
            this.labelNotes.Name = "labelNotes";
            this.labelNotes.Size = new System.Drawing.Size(38, 17);
            this.labelNotes.TabIndex = 0;
            this.labelNotes.Text = "Опис";
            // 
            // textBoxNotes
            // 
            this.textBoxNotes.Location = new System.Drawing.Point(71, 52);
            this.textBoxNotes.Name = "textBoxNotes";
            this.textBoxNotes.Size = new System.Drawing.Size(115, 25);
            this.textBoxNotes.TabIndex = 2;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.Location = new System.Drawing.Point(100, 380);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 30);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Відмінити";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // UnitsDetailUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBoxId);
            this.Controls.Add(this.textBoxNotes);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelNotes);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.labelName);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "UnitsDetailUC";
            this.Size = new System.Drawing.Size(200, 422);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxId;
        private System.Windows.Forms.Label labelNotes;
        private System.Windows.Forms.TextBox textBoxNotes;
        private System.Windows.Forms.Button buttonCancel;
    }
}
