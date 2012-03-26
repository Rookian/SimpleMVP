using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Core.Common;
using SimpleMvp.Bases;
using SimpleMvp.Infrastructure;
using SimpleMvp.ViewModels;

namespace SimpleMvp.Views
{
    public partial class MainView : Form, IMainView
    {
        public MainView()
        {
            InitializeComponent();
        }

        public event EventHandler DetailsClick;
        public event EventHandler CloseClick;
        public event EventHandler CreateClick;
        public event EventHandler DeleteClick;

        public void BindModel(IEnumerable<ArticleViewModel> articles)
        {
            lbxArticles.SetDisplayAndValueMember(articles.ToList(), x => x.Name, x => x.Id);
        }

        public ArticleViewModel GetSelectedArticle()
        {
            return lbxArticles.SelectedItem as ArticleViewModel;
        }

        void btnDetails_Click(object sender, EventArgs e)
        {
            Raise.Event(DetailsClick, this, e);
        }

        void btnClose_Click(object sender, EventArgs e)
        {
            Raise.Event(CloseClick, this, e);
        }

        void lbxArticles_DoubleClick(object sender, EventArgs e)
        {
            Raise.Event(DetailsClick, this, e);
        }

        void btnCreate_Click(object sender, EventArgs e)
        {
            Raise.Event(CreateClick, sender, e);
        }

        void btnDelete_Click(object sender, EventArgs e)
        {
            Raise.Event(DeleteClick, sender, e);
        }
    }
}