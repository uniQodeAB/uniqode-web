using System;
using UniQode.Contracts.Providers;
using UniQode.Services.Providers;
using UniQode.Testing;
using Xunit;

namespace UniQode.Services.Tests
{
    public class AzureBlobStorageProviderTests
    {
        private readonly IStorageProvider _target;

        public AzureBlobStorageProviderTests()
        {
            _target = new AzureBlobStorageProvider(CommonResources.ConnectionStrings.AzureBlobStorage);
        }

        [Fact]
        public void Upload_GivenABase64Image_ShouldBeAbleToUploadToAzure()
        {
            var base64String = "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";

            var bytes = Convert.FromBase64String(base64String);

            _target.Upload(bytes, "test_img.png", "tests");
        }
    }
}