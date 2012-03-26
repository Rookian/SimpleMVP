using System;
using System.Windows.Forms;
using Core.Common;
using SimpleMvp.Bases;
using SimpleMvp.Infrastructure;
using SimpleMvp.ViewModels;

namespace SimpleMvp.Views
{
    public partial class CreateView : Form, ICreateView
    {
        public CreateView()
        {
            InitializeComponent();
        }

        public event EventHandler CloseClick;

        public void BindModel(ArticleViewModel viewModel)
        {
            tbName.Bind(viewModel, x => x.Name, x => x.Id);
        }

        public ArticleViewModel GetArticle()
        {
            return tbName.Model<ArticleViewModel>();
        }

        void btnSave_Click(object sender, EventArgs e)
        {
            Raise.Event(CloseClick, this, e);
        }
    }
}