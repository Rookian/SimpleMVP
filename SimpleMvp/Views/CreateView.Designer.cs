namespace SimpleMvp.Views
{
    partial class CreateView
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
            this.btnSave = new System.Windows.Forms.Button();
            this.tbName = new System.Windows.Forms.TextBox();
            this.gbArticle = new System.Windows.Forms.GroupBox();
            this.lblName = new System.Windows.Forms.Label();
            this.gbArticle.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(197, 109);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(50, 39);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(160, 20);
            this.tbName.TabIndex = 1;
            // 
            // gbArticle
            // 
            this.gbArticle.Controls.Add(this.lblName);
            this.gbArticle.Controls.Add(this.tbName);
            this.gbArticle.Location = new System.Drawing.Point(12, 12);
            this.gbArticle.Name = "gbArticle";
            this.gbArticle.Size = new System.Drawing.Size(260, 87);
            this.gbArticle.TabIndex = 2;
            this.gbArticle.TabStop = false;
            this.gbArticle.Text = "Article";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(6, 42);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Name:";
            // 
            // CreateView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 144);
            this.Controls.Add(this.gbArticle);
            this.Controls.Add(this.btnSave);
            this.Name = "CreateView";
            this.Text = "CreateView";
            this.gbArticle.ResumeLayout(false);
            this.gbArticle.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.GroupBox gbArticle;
        private System.Windows.Forms.Label lblName;
    }
}