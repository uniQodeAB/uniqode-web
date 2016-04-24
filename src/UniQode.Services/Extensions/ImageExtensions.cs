using System.Drawing;
using System.IO;

namespace UniQode.Services.Extensions
{
    public static class ImageExtensions
    {
        public static byte[] ToBytes(this Image img)
        {
            byte[] bytes;
            using (var stream = new MemoryStream())
            {
                img.Save(stream, img.RawFormat);
                stream.Close();
                bytes = stream.ToArray();
            }
            return bytes;
        }

        public static Bitmap ToBitmap(this byte[] imageBytes)
        {
            using (var memoryStream = new MemoryStream(imageBytes))
            using (var newImage = Image.FromStream(memoryStream))
                return new Bitmap(newImage);
        }
    }
}