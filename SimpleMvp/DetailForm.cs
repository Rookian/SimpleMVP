using System;
using System.Windows.Forms;

namespace SimpleMvp
{
    public partial class DetailForm : Form, IDetailView
    {
        public DetailForm()
        {
            InitializeComponent();
            if (!DesignMode)
            {
            }
        }

        public event EventHandler CloseClick;

        public void ShowDetails(string article)
        {
            lblLabel.Text = article;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (CloseClick != null)
            {
                CloseClick(this, e);
            }
        }
    }
}