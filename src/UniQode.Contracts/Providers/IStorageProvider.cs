namespace UniQode.Contracts.Providers
{
    public interface IStorageProvider
    {
        void Upload(byte[] imageBytes, string fileName, string containerName);
        byte[] Download(string fileName, string containerName);
    }
}