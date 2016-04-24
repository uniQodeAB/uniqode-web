using System.Drawing;
using UniQode.Contracts.Services;
using UniQode.Services.Extensions;

namespace UniQode.Services
{
    public class ImageService : IImageService
    {
        private byte[] CropImage(Image src, Rectangle crop)
        {
            var target = new Bitmap(crop.Width, crop.Height);
            using (var g = Graphics.FromImage(target))
                g.DrawImage(src, new Rectangle(0, 0, target.Width, target.Height), crop, GraphicsUnit.Pixel);

            return target.ToBytes();
        }

        public byte[] CropImage(byte[] imagesBytes)
        {
            var bmap = imagesBytes.ToBitmap();
            return CropImage(bmap, new Rectangle(0, 0, bmap.Width, bmap.Width));
        }

        public byte[] ScaleImage(byte[] imagesBytes, int maxWidth)
        {
            //todo
            throw new System.NotImplementedException();
        }
    }
}