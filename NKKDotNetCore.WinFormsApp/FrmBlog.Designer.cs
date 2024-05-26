namespace NKKDotNetCore.WinFormsApp
{
    partial class FrmBlog
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblContent = new Label();
            lblAuthor = new Label();
            txtTitle = new TextBox();
            txtAuthor = new TextBox();
            txtContent = new RichTextBox();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(226, 31);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(45, 20);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Title :";
            // 
            // lblContent
            // 
            lblContent.AutoSize = true;
            lblContent.Location = new Point(226, 137);
            lblContent.Name = "lblContent";
            lblContent.Size = new Size(68, 20);
            lblContent.TabIndex = 1;
            lblContent.Text = "Content :";
            // 
            // lblAuthor
            // 
            lblAuthor.AutoSize = true;
            lblAuthor.Location = new Point(226, 84);
            lblAuthor.Name = "lblAuthor";
            lblAuthor.Size = new Size(61, 20);
            lblAuthor.TabIndex = 2;
            lblAuthor.Text = "Author :";
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(226, 54);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(351, 27);
            txtTitle.TabIndex = 3;
            // 
            // txtAuthor
            // 
            txtAuthor.Location = new Point(226, 107);
            txtAuthor.Name = "txtAuthor";
            txtAuthor.Size = new Size(351, 27);
            txtAuthor.TabIndex = 4;
            // 
            // txtContent
            // 
            txtContent.Location = new Point(226, 160);
            txtContent.Name = "txtContent";
            txtContent.Size = new Size(351, 94);
            txtContent.TabIndex = 5;
            txtContent.Text = "";
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(6, 140, 8);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(349, 267);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(97, 41);
            btnSave.TabIndex = 6;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(237, 9, 104);
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(226, 267);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(99, 41);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // FrmBlog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtContent);
            Controls.Add(txtAuthor);
            Controls.Add(txtTitle);
            Controls.Add(lblAuthor);
            Controls.Add(lblContent);
            Controls.Add(lblTitle);
            Name = "FrmBlog";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Blog";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblContent;
        private Label lblAuthor;
        private TextBox txtTitle;
        private TextBox txtAuthor;
        private RichTextBox txtContent;
        private Button btnSave;
        private Button btnCancel;
    }
}
