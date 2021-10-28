using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace MyCommonImagesLib
{
    public class MyRenderer
    {
        readonly Font boldFont = new Font("Arial", 6, FontStyle.Bold);
        readonly Font font = new Font("Arial", 6);
        int y = 10;
        readonly int x = 5;
        public Bitmap CreateBitmap()
        {
            Bitmap bmp = new Bitmap(650, 518);
            bmp.SetResolution(300.0F, 300.0F);

            string FirstName = "AbcdefghijklmnopqrstuvwxyzAbcdefghijklmnopqrstuvwx";
            string LastName = "AbcdefghijklmnopqrstuvwxyzAbcdefghijklmnopqrstuvwx";
            string DOB = "April 14, 1987";
            string OrderNumber = "MH-0001234";
            string Client = "Idaho Potatoes";
            string LocationCode = "NJ";

            using (Graphics graphics = Graphics.FromImage(bmp))
            {
                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.AssumeLinear;
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

                graphics.FillRectangle(new SolidBrush(Color.White), 0, 0, bmp.Width, bmp.Height);

                DrawStringSection(graphics, "First Name: ", FirstName);

                DrawStringSection(graphics, "First Name Length: ", FirstName.Length.ToString());

                DrawStringSection(graphics, "Last Name: ", LastName);

                DrawStringSection(graphics, "Last Name Length: ", LastName.Length.ToString());

                DrawStringSection(graphics, "Date of birth: ", DOB);

                DrawStringSection(graphics, "Lab Order Number: ", OrderNumber);

                DrawStringSection(graphics, "Company: ", Client);

                DrawStringSection(graphics, "Lab Acct: ", LocationCode);

                graphics.Flush();
                font.Dispose();
                boldFont.Dispose();
            }

            bmp.RotateFlip(RotateFlipType.Rotate90FlipNone);

            return bmp;
        }

        private void DrawStringSection(Graphics graphics, string header, string detail)
        {
            var titleSize = graphics.MeasureString(header, boldFont);
            var detailSize = graphics.MeasureString(detail, font);
            var size = titleSize.Height > detailSize.Height ? titleSize : detailSize;
            graphics.DrawString(header, boldFont, new SolidBrush(Color.Black), x, y);
            graphics.DrawString(detail, font, new SolidBrush(Color.Black), (int)titleSize.Width + 10, y);

            y = y + (int)size.Height + 5;
        }
    }
}
