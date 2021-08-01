using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using LayeredSkin.DirectUI;

namespace WeLink.UI
{
    public static class DuiBaseControlClass
    {
        public static Font Titlefont = new Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point,
            ((byte)(134)));
        public static Font Msgfont = new Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point,
          ((byte)(134)));
        /// <summary>
        /// 返回DuiLabel
        /// </summary>
        /// <param name="text">显示的信息</param>
        /// <param name="font">字体</param>
        /// <param name="size">大小</param>
        /// <param name="location">显示位置</param>
        /// <returns></returns>
        public static  DuiLabel AddDuiLabel(string text, Font font, Size size, Point location)
        {
            DuiLabel duiLabel = new DuiLabel();
            duiLabel.Size = size;
            duiLabel.Text = text;
            duiLabel.Font = font;
            duiLabel.TextRenderMode = TextRenderingHint.AntiAliasGridFit;
            duiLabel.Location = location;
            return duiLabel;
        }
        /// <summary>
        /// 返回DuiBaseControl
        /// </summary>
        /// <param name="bitmap">DuiBaseControl的背景图片</param>
        /// <param name="layout">DuiBaseControl的背景图片显示样式</param>
        /// <param name="cursor">鼠标样式</param>
        /// <param name="size">大小</param>
        /// <param name="location">显示位置</param>
        /// <param name="isEven">是否有鼠标事件</param>
        /// <returns>返回_baseControl</returns>
        public static DuiBaseControl AddDuiBaseControl(Bitmap bitmap, ImageLayout layout, Cursor cursor, Size size,
            Point location)
        {
            DuiBaseControl _baseControl = new DuiBaseControl();
            _baseControl.Size = size;
            _baseControl.Cursor = cursor;
            _baseControl.Location = location;
            _baseControl.BackColor = Color.Transparent;
            _baseControl.BackgroundImage = bitmap;
            _baseControl.BackgroundImageLayout = layout;
            return _baseControl;
        }
    }
}
