using System;
using System.Windows.Forms;

namespace SimpleMvp
{
    public partial class DetailView : Form, IDetailView
    {
        public DetailView()
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