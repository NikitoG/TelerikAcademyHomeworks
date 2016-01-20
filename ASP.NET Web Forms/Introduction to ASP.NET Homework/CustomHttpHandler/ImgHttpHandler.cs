using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;

namespace CustomHttpHandler
{
    public class ImgHttpHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            int width = 600;
            int height = 400;
            var imageAsText = context.Request.Url.ToString();

            using (Bitmap bitmap = new Bitmap(width, height))
            {
                Graphics graphics = Graphics.FromImage(bitmap);
                graphics.FillRectangle(Brushes.Red, 0f, 0f, bitmap.Width, bitmap.Height);
                graphics.DrawString(imageAsText, 
                    new Font("Consolas", 20, FontStyle.Underline), 
                    SystemBrushes.WindowText,
                    new PointF(10, 40));

                using (MemoryStream mem = new MemoryStream())
                {
                    bitmap.Save(mem, ImageFormat.Png);
                    mem.Seek(0, SeekOrigin.Begin);

                    context.Response.ContentType = "image/png";

                    mem.CopyTo(context.Response.OutputStream, 4096);
                    context.Response.Flush();
                }
            }
        }

        public bool IsReusable
        {
            // Return true to keep the handler in memory (pooling).
            get { return false; }
        }
    }
}