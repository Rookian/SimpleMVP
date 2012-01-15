using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SimpleMvp
{
    public partial class MainView : Form, IMainView
    {
        public MainView()
        {
            InitializeComponent();
        }

        public void ShowArticles(IEnumerable<string> articles)
        {
            lbxArticles.Items.Clear();
            lbxArticles.Items.AddRange(articles.ToArray());
        }

        public event EventHandler DetailsClick;
        public event EventHandler CloseClick;

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
            if (CloseClick != null)
            {
                CloseClick(this, e);
            }
        }

        private void lbxArticles_DoubleClick(object sender, EventArgs e)
        {
            btnDetails_Click(sender, e);
        }
    }
}