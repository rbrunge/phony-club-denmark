using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Web;

namespace PhonyClubDenmark.Website.Helpers
{
    /// <summary>
    /// Work in progress
    /// </summary>
    public static class ImageHelper
    {
        public static void MergeImages(Image background, Image foreground, HttpContext context)
        {
            if (background == null)
                throw new ArgumentNullException("background");

            if (foreground == null)
                throw new ArgumentNullException("foreground");

            // if ratio is > 120/90
            //  define by width
            // else
            // define by height
            double ratioForeGround = foreground.Width/(float)foreground.Height;

            int foreGroundWidth = background.Width; 
            int foreGroundHeight = background.Height;
            if (ratioForeGround > 1)
            {
                foreGroundHeight = (int)(background.Height * (background.Height/foreground.Height));
            }
            else
            {
                foreGroundWidth = (int)(background.Height * (foreground.Width / (float)foreground.Height));
            }

            using (background)
            {
                using (var bitmap = new Bitmap(background.Width, background.Height))
                {
                    using (var canvas = Graphics.FromImage(bitmap))
                    {
                        canvas.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        canvas.DrawImage(background, new Rectangle(0, 0, background.Width, background.Height), new Rectangle(0, 0, background.Width, background.Height), GraphicsUnit.Pixel);
                        // canvas.DrawImage(foreground, (bitmap.Width / 2) - (foreGroundWidth / 2 + 5), (bitmap.Height / 2) - (foreGroundWidth / 2 + 5));
                        canvas.DrawImage(foreground, (bitmap.Width / 2) - (foreGroundWidth / 2 + 5), (bitmap.Height / 2) - (foreGroundHeight / 2 + 5), foreGroundWidth, foreGroundHeight);
                        canvas.Save();
                    }
                    try
                    {
                        context.Response.ContentType = "image/png";
                        bitmap.Save(context.Response.OutputStream, ImageFormat.Png);
                    }
                    catch (Exception)
                    {
                        // no action
                    }
                    finally
                    {
                        background.Dispose();
                        foreground.Dispose();

                    }
                }
            }
        }

        public static void ImageWithText(string text, int width, int height, HttpContext context)
        {
            using (var rectangleFont = new Font("Arial", 8, FontStyle.Bold))
            using (var bitmap = new Bitmap(width, height, PixelFormat.Format24bppRgb))
            using (var g = Graphics.FromImage(bitmap))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                var backgroundColor = Color.Bisque;
                g.Clear(backgroundColor);
                g.DrawString(text, rectangleFont, SystemBrushes.WindowText, new PointF(10, 40));
                context.Response.ContentType = "image/png";
                bitmap.Save(context.Response.OutputStream, ImageFormat.Png);
            }
        }
    }
}