using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Core;
using SimpleMvp.Base;

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

        public void BindModel(IEnumerable<Article> articles)
        {
            lbxArticles.SetDisplayAndValueMember(articles, x => x.Name, x => x.Id);
        }

        public Article GetSelectedArticle()
        {
            return lbxArticles.SelectedItem as Article;
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