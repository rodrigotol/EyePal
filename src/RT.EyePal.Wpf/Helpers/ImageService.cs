using System.Drawing;
using System.IO;
using System.Windows.Media.Imaging;

namespace RT.EyePal.Wpf.Helpers
{
    public class ImageService
    {
        public static BitmapImage GenerateImageSource(Bitmap bitmap)
        {
            var memoryStream = new MemoryStream();
            bitmap.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
            memoryStream.Position = 0;

            var bitmapImage = new BitmapImage();            
            bitmapImage.BeginInit();
            bitmapImage.StreamSource = memoryStream;
            bitmapImage.EndInit();

            return bitmapImage;
        }
    }
}