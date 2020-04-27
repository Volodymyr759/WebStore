namespace Presentation
{
    partial class ErrorMessageView
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
            this.messageTextBox = new System.Windows.Forms.TextBox();
            this.copyBtn = new System.Windows.Forms.Button();
            this.closeBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // messageTextBox
            // 
            this.messageTextBox.Location = new System.Drawing.Point(14, 33);
            this.messageTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.messageTextBox.Multiline = true;
            this.messageTextBox.Name = "messageTextBox";
            this.messageTextBox.ReadOnly = true;
            this.messageTextBox.Size = new System.Drawing.Size(314, 196);
            this.messageTextBox.TabIndex = 0;
            // 
            // copyBtn
            // 
            this.copyBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.copyBtn.Location = new System.Drawing.Point(146, 238);
            this.copyBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.copyBtn.Name = "copyBtn";
            this.copyBtn.Size = new System.Drawing.Size(87, 30);
            this.copyBtn.TabIndex = 1;
            this.copyBtn.Text = "Копіювати";
            this.copyBtn.UseVisualStyleBackColor = true;
            this.copyBtn.Click += new System.EventHandler(this.CopyBtn_Click);
            // 
            // closeBtn
            // 
            this.closeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeBtn.Location = new System.Drawing.Point(241, 238);
            this.closeBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(87, 30);
            this.closeBtn.TabIndex = 2;
            this.closeBtn.Text = "OK";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // ErrorMessageView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 277);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.copyBtn);
            this.Controls.Add(this.messageTextBox);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ErrorMessageView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Error Message";
            this.Load += new System.EventHandler(this.ErrorMessageView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox messageTextBox;
        private System.Windows.Forms.Button copyBtn;
        private System.Windows.Forms.Button closeBtn;
    }
}