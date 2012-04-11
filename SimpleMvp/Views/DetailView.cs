using System;
using Core.Common;
using SimpleMvp.Bases;
using SimpleMvp.ViewModels;

namespace SimpleMvp.Views
{
    public partial class DetailView : ViewBase<ArticleViewModel>, IDetailView
    {
        public DetailView()
        {
            InitializeComponent();
            if (!DesignMode)
            {
            }
        }

        public event EventHandler CloseClick;

        public void ShowDetails()
        {
            lblLabel.Text = Model.Name;
        }

        void btnClose_Click(object sender, EventArgs e)
        {
            Raise.Event(CloseClick, this, e);
        }
    }
}