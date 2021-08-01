using LayeredSkin.Forms;

namespace WeLink.UI
{
    public partial class LayeredBaseForm : LayeredForm
    {
        public LayeredBaseForm()
        {
            InitializeComponent();
            //显示阴影
            this.BackgroundRender = new ShadowBackgroundRender();
        }

        private void LayeredBaseForm_Load(object sender, System.EventArgs e)
        {

        }
    }
}
