using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Core;

namespace SimpleMvp
{
    public partial class MainView : Form, IMainView
    {
        public MainView()
        {
            InitializeComponent();
        }

        public event EventHandler DetailsClick;
        public event EventHandler CloseClick;

        public void ShowArticles(IEnumerable<Article> articles)
        {
            lbxArticles.Items.Clear();
            lbxArticles.Items.AddRange(articles.Select(x => x.Name).ToArray());
        }

        public string GetSelectedArticle()
        {
            return lbxArticles.SelectedItem as string;
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