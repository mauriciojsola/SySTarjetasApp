using System;
using System.Drawing;
using System.Windows.Forms;

namespace SySTarjetas.Desktop.Controls
{
    public class CustomTextBox : TextBox
    {
        protected override void OnGotFocus(EventArgs e)
        {
            SelectionStart = 0;
            SelectionLength = Text.Length;
            var color = Color.FromArgb(255, 255, 128);
            base.BackColor = color;
            base.OnGotFocus(e);
        }

        protected override void OnLostFocus(EventArgs e)
        {
            var color = Color.FromArgb(255, 255, 255);
            base.BackColor = color;
            base.OnLostFocus(e);
        }

    }
}
