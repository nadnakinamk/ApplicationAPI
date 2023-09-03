
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;


namespace ApplicationCore.Extensions
{
    public static class ImageConvertion
    {

        //public static void GenerateThumbnails(double scaleFactor, Stream sourcePath,
        //    string targetPath, int Height, int Width)
        //{
        //    using (var image = Image.FromStream(sourcePath))
        //    {
        //        var newWidth = (int)(Width * scaleFactor);

        //        var newHeight = (int)(Height * scaleFactor);


        //        var thumbnailImg = new Bitmap(newWidth, newHeight);
        //        var thumbGraph = Graphics.FromImage(thumbnailImg);
        //        thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
        //        thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
        //        thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
        //        var imageRectangle = new Rectangle(0, 0, newWidth, newHeight);
        //        thumbGraph.DrawImage(image, imageRectangle);
        //        thumbnailImg.Save(targetPath, image.RawFormat);
        //    }
        //}
    }
}
