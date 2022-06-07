using Azure.Storage.Blobs;

namespace ElectronicsAPI.Helpers
{
    public static class FileHelper
    {
        public static async Task<string> UploadPhoneImage(IFormFile Image)
        {
            string connectionString = @"DefaultEndpointsProtocol=https;AccountName=electronicstorageacc;AccountKey=7xcb0OnUwPa0owb4ce4W3EIFflGk13YS/GT3eZjuMlzVaw+UX1l1hXPnZnt+v03D1X3x7MWayDKC+AStkBhG7A==;EndpointSuffix=core.windows.net";
            string containerName = "phonesimage";
            BlobContainerClient blobContainerClient = new BlobContainerClient(connectionString, containerName);
            BlobClient blobClient = blobContainerClient.GetBlobClient(Image.FileName);
            var memoryStream = new MemoryStream();
            await Image.CopyToAsync(memoryStream);
            memoryStream.Position = 0;
            await blobClient.UploadAsync(memoryStream);
            return blobClient.Uri.AbsoluteUri;
        }

        public static async Task<string> UploadLaptopImage(IFormFile Image)
        {
            string connectionString = @"DefaultEndpointsProtocol=https;AccountName=electronicstorageacc;AccountKey=7xcb0OnUwPa0owb4ce4W3EIFflGk13YS/GT3eZjuMlzVaw+UX1l1hXPnZnt+v03D1X3x7MWayDKC+AStkBhG7A==;EndpointSuffix=core.windows.net";
            string containerName = "laptopsimage";
            BlobContainerClient blobContainerClient = new BlobContainerClient(connectionString, containerName);
            BlobClient blobClient = blobContainerClient.GetBlobClient(Image.FileName);
            var memoryStream = new MemoryStream();
            await Image.CopyToAsync(memoryStream);
            memoryStream.Position = 0;
            await blobClient.UploadAsync(memoryStream);
            return blobClient.Uri.AbsoluteUri;
        }

        public static async Task<string> UploadKeyboardImage(IFormFile Image)
        {
            string connectionString = @"DefaultEndpointsProtocol=https;AccountName=electronicstorageacc;AccountKey=7xcb0OnUwPa0owb4ce4W3EIFflGk13YS/GT3eZjuMlzVaw+UX1l1hXPnZnt+v03D1X3x7MWayDKC+AStkBhG7A==;EndpointSuffix=core.windows.net";
            string containerName = "keyboardsimage";
            BlobContainerClient blobContainerClient = new BlobContainerClient(connectionString, containerName);
            BlobClient blobClient = blobContainerClient.GetBlobClient(Image.FileName);
            var memoryStream = new MemoryStream();
            await Image.CopyToAsync(memoryStream);
            memoryStream.Position = 0;
            await blobClient.UploadAsync(memoryStream);
            return blobClient.Uri.AbsoluteUri;
        }

        public static async Task<string> UploadHeadphoneImage(IFormFile Image)
        {
            string connectionString = @"DefaultEndpointsProtocol=https;AccountName=electronicstorageacc;AccountKey=7xcb0OnUwPa0owb4ce4W3EIFflGk13YS/GT3eZjuMlzVaw+UX1l1hXPnZnt+v03D1X3x7MWayDKC+AStkBhG7A==;EndpointSuffix=core.windows.net";
            string containerName = "headphonesimage";
            BlobContainerClient blobContainerClient = new BlobContainerClient(connectionString, containerName);
            BlobClient blobClient = blobContainerClient.GetBlobClient(Image.FileName);
            var memoryStream = new MemoryStream();
            await Image.CopyToAsync(memoryStream);
            memoryStream.Position = 0;
            await blobClient.UploadAsync(memoryStream);
            return blobClient.Uri.AbsoluteUri;
        }
    }
}
