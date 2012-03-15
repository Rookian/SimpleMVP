using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Core.Common;
using SimpleMvp.Base;
using SimpleMvp.Common;
using SimpleMvp.Model;

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

        public void BindModel(IEnumerable<ArticleViewModel> articles)
        {
            lbxArticles.SetDisplayAndValueMember(articles.ToList(), x => x.Name, x => x.Id);
        }

        public ArticleViewModel GetSelectedArticle()
        {
            return lbxArticles.SelectedItem as ArticleViewModel;
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            Raise.Event(DetailsClick, this, e);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Raise.Event(CloseClick, this, e);
        }

        private void lbxArticles_DoubleClick(object sender, EventArgs e)
        {
            btnDetails_Click(sender, e);
        }
    }
}