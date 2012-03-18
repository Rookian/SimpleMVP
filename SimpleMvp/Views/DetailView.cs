using System;
using System.Windows.Forms;
using Core.Common;
using SimpleMvp.Bases;
using SimpleMvp.ViewModels;

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

        public void ShowDetails(ArticleViewModel article)
        {
            lblLabel.Text = article.Name;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Raise.Event(CloseClick, this, e);
        }
    }
}