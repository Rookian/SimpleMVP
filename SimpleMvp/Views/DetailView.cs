using System;
using System.Windows.Forms;
using Core;
using SimpleMvp.Base;

namespace SimpleMvp.Views
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

        public void ShowDetails(Article article)
        {
            lblLabel.Text = article.Name;
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