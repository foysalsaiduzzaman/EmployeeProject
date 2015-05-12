namespace BookManagementApp.UI
{
    partial class MainUI
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
            this.categoryEntryButton = new System.Windows.Forms.Button();
            this.bookEntryButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // categoryEntryButton
            // 
            this.categoryEntryButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categoryEntryButton.Location = new System.Drawing.Point(43, 62);
            this.categoryEntryButton.Name = "categoryEntryButton";
            this.categoryEntryButton.Size = new System.Drawing.Size(179, 63);
            this.categoryEntryButton.TabIndex = 0;
            this.categoryEntryButton.Text = "Category Entry";
            this.categoryEntryButton.UseVisualStyleBackColor = true;
            this.categoryEntryButton.Click += new System.EventHandler(this.categoryEntryButton_Click);
            // 
            // bookEntryButton
            // 
            this.bookEntryButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bookEntryButton.Location = new System.Drawing.Point(255, 62);
            this.bookEntryButton.Name = "bookEntryButton";
            this.bookEntryButton.Size = new System.Drawing.Size(179, 63);
            this.bookEntryButton.TabIndex = 0;
            this.bookEntryButton.Text = "Book Entry";
            this.bookEntryButton.UseVisualStyleBackColor = true;
            this.bookEntryButton.Click += new System.EventHandler(this.bookEntryButton_Click);
            // 
            // MainUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 184);
            this.Controls.Add(this.bookEntryButton);
            this.Controls.Add(this.categoryEntryButton);
            this.Name = "MainUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainUI";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button categoryEntryButton;
        private System.Windows.Forms.Button bookEntryButton;
    }
}