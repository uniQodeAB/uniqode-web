using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using UniQode.Contracts.Providers;

namespace UniQode.Services.Providers
{
    public class AzureBlobStorageProvider : IStorageProvider
    {
        private readonly CloudStorageAccount _storageAccount;
        private readonly CloudBlobClient _blobClient;

        public AzureBlobStorageProvider(string connectionString)
        {
            _storageAccount = CloudStorageAccount.Parse(connectionString);
            _blobClient = _storageAccount.CreateCloudBlobClient();
        }

        public void Upload(byte[] imageBytes, string fileName, string containerName)
        {
            var container = _blobClient.GetContainerReference(containerName);

            container.CreateIfNotExists(BlobContainerPublicAccessType.Blob);

            var blockBlob = container.GetBlockBlobReference(fileName);

            blockBlob.UploadFromByteArray(imageBytes, 0, imageBytes.Length);
        }

        public byte[] Download(string fileName, string containerName)
        {
            throw new System.NotImplementedException();
        }
    }
}