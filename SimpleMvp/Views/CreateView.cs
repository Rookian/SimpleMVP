using System;
using System.Windows.Forms;
using Core.Common;
using SimpleMvp.Bases;

namespace SimpleMvp.Views
{
    public partial class CreateView : Form, ICreateView
    {
        public CreateView()
        {
            InitializeComponent();
        }

        public event EventHandler CloseClick;

        public string GetArticleName()
        {
            return tbName.Text;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Raise.Event(CloseClick, this, e);
        }
    }
}
