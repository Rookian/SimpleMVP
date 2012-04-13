using System;
using Core.Common;
using SimpleMvp.Bases;
using SimpleMvp.ViewModels;
using System.Windows.Forms;

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

        public void ShowDetails(ArticleViewModel model)
        {
            lblLabel.Text = model.Name;
        }

        void btnClose_Click(object sender, EventArgs e)
        {
            Raise.Event(CloseClick, this, e);
        }
    }
}