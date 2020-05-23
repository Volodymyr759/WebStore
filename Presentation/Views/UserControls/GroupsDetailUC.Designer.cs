namespace Presentation.Views.UserControls
{
    partial class GroupsDetailUC
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
            this.textBoxNotes = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelNotes = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.labelNumber = new System.Windows.Forms.Label();
            this.textBoxNumber = new System.Windows.Forms.TextBox();
            this.labelIdentifier = new System.Windows.Forms.Label();
            this.textBoxIdentifier = new System.Windows.Forms.TextBox();
            this.labelAncestorNumber = new System.Windows.Forms.Label();
            this.textBoxAncestorNumber = new System.Windows.Forms.TextBox();
            this.labelAncestorIdentifier = new System.Windows.Forms.Label();
            this.textBoxAncestorIdentifier = new System.Windows.Forms.TextBox();
            this.labelProductType = new System.Windows.Forms.Label();
            this.textBoxProductType = new System.Windows.Forms.TextBox();
            this.labelLink = new System.Windows.Forms.Label();
            this.textBoxLink = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
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
            // textBoxNotes
            // 
            this.textBoxNotes.Location = new System.Drawing.Point(71, 238);
            this.textBoxNotes.Name = "textBoxNotes";
            this.textBoxNotes.Size = new System.Drawing.Size(225, 25);
            this.textBoxNotes.TabIndex = 8;
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(71, 21);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(225, 25);
            this.textBoxName.TabIndex = 9;
            // 
            // labelNotes
            // 
            this.labelNotes.AutoSize = true;
            this.labelNotes.Location = new System.Drawing.Point(11, 241);
            this.labelNotes.Name = "labelNotes";
            this.labelNotes.Size = new System.Drawing.Size(38, 17);
            this.labelNotes.TabIndex = 6;
            this.labelNotes.Text = "Опис";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(11, 24);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(44, 17);
            this.labelName.TabIndex = 7;
            this.labelName.Text = "Назва";
            // 
            // labelNumber
            // 
            this.labelNumber.AutoSize = true;
            this.labelNumber.Location = new System.Drawing.Point(11, 55);
            this.labelNumber.Name = "labelNumber";
            this.labelNumber.Size = new System.Drawing.Size(49, 17);
            this.labelNumber.TabIndex = 7;
            this.labelNumber.Text = "Номер";
            // 
            // textBoxNumber
            // 
            this.textBoxNumber.Location = new System.Drawing.Point(71, 52);
            this.textBoxNumber.Name = "textBoxNumber";
            this.textBoxNumber.Size = new System.Drawing.Size(225, 25);
            this.textBoxNumber.TabIndex = 9;
            // 
            // labelIdentifier
            // 
            this.labelIdentifier.AutoSize = true;
            this.labelIdentifier.Location = new System.Drawing.Point(11, 86);
            this.labelIdentifier.Name = "labelIdentifier";
            this.labelIdentifier.Size = new System.Drawing.Size(90, 17);
            this.labelIdentifier.TabIndex = 7;
            this.labelIdentifier.Text = "Ідентифікатор";
            // 
            // textBoxIdentifier
            // 
            this.textBoxIdentifier.Location = new System.Drawing.Point(113, 83);
            this.textBoxIdentifier.Name = "textBoxIdentifier";
            this.textBoxIdentifier.Size = new System.Drawing.Size(183, 25);
            this.textBoxIdentifier.TabIndex = 9;
            // 
            // labelAncestorNumber
            // 
            this.labelAncestorNumber.AutoSize = true;
            this.labelAncestorNumber.Location = new System.Drawing.Point(11, 117);
            this.labelAncestorNumber.Name = "labelAncestorNumber";
            this.labelAncestorNumber.Size = new System.Drawing.Size(96, 17);
            this.labelAncestorNumber.TabIndex = 7;
            this.labelAncestorNumber.Text = "Предок номер";
            // 
            // textBoxAncestorNumber
            // 
            this.textBoxAncestorNumber.Location = new System.Drawing.Point(113, 114);
            this.textBoxAncestorNumber.Name = "textBoxAncestorNumber";
            this.textBoxAncestorNumber.Size = new System.Drawing.Size(183, 25);
            this.textBoxAncestorNumber.TabIndex = 9;
            // 
            // labelAncestorIdentifier
            // 
            this.labelAncestorIdentifier.AutoSize = true;
            this.labelAncestorIdentifier.Location = new System.Drawing.Point(11, 148);
            this.labelAncestorIdentifier.Name = "labelAncestorIdentifier";
            this.labelAncestorIdentifier.Size = new System.Drawing.Size(89, 17);
            this.labelAncestorIdentifier.TabIndex = 7;
            this.labelAncestorIdentifier.Text = "Предок ідент.";
            // 
            // textBoxAncestorIdentifier
            // 
            this.textBoxAncestorIdentifier.Location = new System.Drawing.Point(113, 145);
            this.textBoxAncestorIdentifier.Name = "textBoxAncestorIdentifier";
            this.textBoxAncestorIdentifier.Size = new System.Drawing.Size(183, 25);
            this.textBoxAncestorIdentifier.TabIndex = 9;
            // 
            // labelProductType
            // 
            this.labelProductType.AutoSize = true;
            this.labelProductType.Location = new System.Drawing.Point(11, 179);
            this.labelProductType.Name = "labelProductType";
            this.labelProductType.Size = new System.Drawing.Size(74, 17);
            this.labelProductType.TabIndex = 7;
            this.labelProductType.Text = "Тип товару";
            // 
            // textBoxProductType
            // 
            this.textBoxProductType.Location = new System.Drawing.Point(113, 176);
            this.textBoxProductType.Name = "textBoxProductType";
            this.textBoxProductType.Size = new System.Drawing.Size(183, 25);
            this.textBoxProductType.TabIndex = 9;
            // 
            // labelLink
            // 
            this.labelLink.AutoSize = true;
            this.labelLink.Location = new System.Drawing.Point(11, 210);
            this.labelLink.Name = "labelLink";
            this.labelLink.Size = new System.Drawing.Size(33, 17);
            this.labelLink.TabIndex = 7;
            this.labelLink.Text = "Лінк";
            // 
            // textBoxLink
            // 
            this.textBoxLink.Location = new System.Drawing.Point(71, 207);
            this.textBoxLink.Name = "textBoxLink";
            this.textBoxLink.Size = new System.Drawing.Size(225, 25);
            this.textBoxLink.TabIndex = 9;
            // 
            // GroupsDetailUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBoxNotes);
            this.Controls.Add(this.textBoxLink);
            this.Controls.Add(this.textBoxProductType);
            this.Controls.Add(this.labelLink);
            this.Controls.Add(this.textBoxAncestorIdentifier);
            this.Controls.Add(this.labelProductType);
            this.Controls.Add(this.textBoxAncestorNumber);
            this.Controls.Add(this.labelAncestorIdentifier);
            this.Controls.Add(this.textBoxIdentifier);
            this.Controls.Add(this.labelAncestorNumber);
            this.Controls.Add(this.textBoxNumber);
            this.Controls.Add(this.labelIdentifier);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelNumber);
            this.Controls.Add(this.labelNotes);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "GroupsDetailUC";
            this.Size = new System.Drawing.Size(310, 469);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.TextBox textBoxNotes;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelNotes;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelNumber;
        private System.Windows.Forms.TextBox textBoxNumber;
        private System.Windows.Forms.Label labelIdentifier;
        private System.Windows.Forms.TextBox textBoxIdentifier;
        private System.Windows.Forms.Label labelAncestorNumber;
        private System.Windows.Forms.TextBox textBoxAncestorNumber;
        private System.Windows.Forms.Label labelAncestorIdentifier;
        private System.Windows.Forms.TextBox textBoxAncestorIdentifier;
        private System.Windows.Forms.Label labelProductType;
        private System.Windows.Forms.TextBox textBoxProductType;
        private System.Windows.Forms.Label labelLink;
        private System.Windows.Forms.TextBox textBoxLink;
    }
}
