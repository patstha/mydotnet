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
            int canvasWidth = 6000;
            int canvasHeight = 5180;
            int margin = 10;
            Bitmap bmp = new Bitmap(canvasWidth, canvasHeight);
            bmp.SetResolution(3000.0F, 3000.0F);

            string FirstName = "AbcdefghijklmnopqrstuvwxyzAbcdefghijklmnopqrstuv";
            string LastName = "AbcdefghijklmnopqrstuvwxyzAbcdefghijklmnopqrstuv";
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

                RectangleF rectF1 = new RectangleF(0, 0, bmp.Width - margin, bmp.Height - margin);

                RectangleF rectF2 = DrawStringSection(graphics, "First Name: ", FirstName, rectF1);
                
                RectangleF rectF3 =  DrawStringSection(graphics, "First Name Length: ", FirstName.Length.ToString(), rectF2);
                
                RectangleF rectF4 = DrawStringSection(graphics, "Last Name: ", LastName, rectF3);

                RectangleF rectF5 = DrawStringSection(graphics, "Last Name Length: ", LastName.Length.ToString(), rectF4);

                RectangleF rectF6 = DrawStringSection(graphics, "Date of birth: ", DOB, rectF5);

                RectangleF rectF7 = DrawStringSection(graphics, "Lab Order Number: ", OrderNumber, rectF6);

                RectangleF rectF8 = DrawStringSection(graphics, "Company: ", Client, rectF7);

                _ = DrawStringSection(graphics, "Lab Acct: ", LocationCode, rectF8);

                graphics.Flush();
                font.Dispose();
                boldFont.Dispose();
            }

            bmp.RotateFlip(RotateFlipType.Rotate90FlipNone);

            return bmp;
        }

        private RectangleF DrawStringSection(Graphics graphics, string header, string detail, RectangleF rectangleF)
        {
            var stringSize = graphics.MeasureString(header, boldFont);
            //graphics.DrawString(header, boldFont, new SolidBrush(Color.Black));
            graphics.DrawString(detail, font, new SolidBrush(Color.Black), rectangleF);

            return new RectangleF(rectangleF.X, rectangleF.Y + (int)stringSize.Height, rectangleF.Width, rectangleF.Height);
        }
    }
}
