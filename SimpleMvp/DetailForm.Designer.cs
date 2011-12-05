namespace SimpleMvp
{
  partial class DetailForm
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
      this.btnClose = new System.Windows.Forms.Button();
      this.lblLabel = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // btnClose
      // 
      this.btnClose.Location = new System.Drawing.Point(197, 227);
      this.btnClose.Name = "btnClose";
      this.btnClose.Size = new System.Drawing.Size(75, 23);
      this.btnClose.TabIndex = 0;
      this.btnClose.Text = "Close";
      this.btnClose.UseVisualStyleBackColor = true;
      this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
      // 
      // lblLabel
      // 
      this.lblLabel.AutoSize = true;
      this.lblLabel.Location = new System.Drawing.Point(12, 9);
      this.lblLabel.Name = "lblLabel";
      this.lblLabel.Size = new System.Drawing.Size(35, 13);
      this.lblLabel.TabIndex = 1;
      this.lblLabel.Text = "label1";
      // 
      // DetailForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(284, 262);
      this.Controls.Add(this.lblLabel);
      this.Controls.Add(this.btnClose);
      this.Name = "DetailForm";
      this.Text = "DetailForm";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btnClose;
    private System.Windows.Forms.Label lblLabel;
  }
}