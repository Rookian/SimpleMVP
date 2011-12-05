namespace SimpleMvp
{
  partial class MainForm
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
      this.lbxArticles = new System.Windows.Forms.ListBox();
      this.btnClose = new System.Windows.Forms.Button();
      this.btnDetails = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // lbxArticles
      // 
      this.lbxArticles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lbxArticles.FormattingEnabled = true;
      this.lbxArticles.Location = new System.Drawing.Point(12, 12);
      this.lbxArticles.Name = "lbxArticles";
      this.lbxArticles.Size = new System.Drawing.Size(423, 290);
      this.lbxArticles.TabIndex = 0;
      this.lbxArticles.DoubleClick += new System.EventHandler(this.lbxArticles_DoubleClick);
      // 
      // btnClose
      // 
      this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnClose.Location = new System.Drawing.Point(360, 308);
      this.btnClose.Name = "btnClose";
      this.btnClose.Size = new System.Drawing.Size(75, 23);
      this.btnClose.TabIndex = 1;
      this.btnClose.Text = "Close";
      this.btnClose.UseVisualStyleBackColor = true;
      this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
      // 
      // btnDetails
      // 
      this.btnDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnDetails.Location = new System.Drawing.Point(279, 308);
      this.btnDetails.Name = "btnDetails";
      this.btnDetails.Size = new System.Drawing.Size(75, 23);
      this.btnDetails.TabIndex = 2;
      this.btnDetails.Text = "Details";
      this.btnDetails.UseVisualStyleBackColor = true;
      this.btnDetails.Click += new System.EventHandler(this.btnDetails_Click);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(447, 342);
      this.Controls.Add(this.btnDetails);
      this.Controls.Add(this.btnClose);
      this.Controls.Add(this.lbxArticles);
      this.Name = "MainForm";
      this.Text = "Form1";
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ListBox lbxArticles;
    private System.Windows.Forms.Button btnClose;
    private System.Windows.Forms.Button btnDetails;
  }
}

