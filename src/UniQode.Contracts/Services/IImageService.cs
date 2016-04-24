namespace UniQode.Contracts.Services
{
    public interface IImageService
    {
        byte[] CropImage(byte[] imagesBytes);

        byte[] ScaleImage(byte[] imagesBytes, int maxWidth);
    }
}