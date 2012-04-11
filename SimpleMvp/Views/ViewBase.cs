using System.Windows.Forms;

namespace SimpleMvp.Views
{
    public abstract class ViewBase<TModel> : Form where TModel : class
    {
        public TModel Model { get; set; }
    }
}