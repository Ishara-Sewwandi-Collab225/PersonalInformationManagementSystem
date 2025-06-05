using System;
using System.Drawing;
using System.Windows.Forms;

namespace Personal_Information
{
    public partial class ImageViewerForm : Form

    {
        public ImageViewerForm(Image image)
        {
            this.Text = "Image Viewer";
            this.Size = new Size(600, 600);
            this.StartPosition = FormStartPosition.CenterScreen;

            PictureBox pictureBox = new PictureBox
            {
                Dock = DockStyle.Fill,
                Image = image,
                SizeMode = PictureBoxSizeMode.Zoom
            };

            this.Controls.Add(pictureBox);
        }
    }
}
