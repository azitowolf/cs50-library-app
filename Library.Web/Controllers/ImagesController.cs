using Library.Utils;
using Library.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using Azure.Storage.Blobs.Models;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Library.Web.Controllers
{
    public class ImagesController : Controller
    {
        // make sure that appsettings.json is filled with the necessary details of the azure storage
        private readonly AzureStorageConfig storageConfig = null;
        private readonly ILogger _logger;


        public ImagesController(AzureStorageConfig config, ILogger logger)
        {
            storageConfig = config;
            _logger = logger;
        }

        public async Task<BlobContentInfo> Upload(ICollection<FormFile> files)
        {
            bool isUploaded = false;
            BlobContentInfo uploadedFile = null;

            try
            {
                if (files.Count == 0)
                    throw new ArgumentException("No files received from the upload");

                if (storageConfig.AccountKey == string.Empty || storageConfig.AccountName == string.Empty)
                    throw new ArgumentException("sorry, can't retrieve your azure storage details from appsettings.js, make sure that you add azure storage details there");

                if (storageConfig.ImageContainer == string.Empty)
                    throw new ArgumentException("Please provide a name for your image container in the azure blob storage");

                foreach (var formFile in files)
                {
                    if (StorageHelper.IsImage(formFile))
                    {
                        if (formFile.Length > 0)
                        {
                            using (Stream stream = formFile.OpenReadStream())
                            {
                                isUploaded = true;
                                uploadedFile = await StorageHelper.UploadFileToStorage(stream, formFile.FileName, storageConfig);; 
                            }
                        }
                    }
                    else
                    {
                        return uploadedFile;
                    }
                }

                return uploadedFile;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        // GET /api/images/thumbnails
        [HttpGet("thumbnails")]
        public async Task<List<string>> GetThumbNails(AzureStorageConfig storageConfig)
        {
            try
            {
                //if (storageConfig.AccountKey == string.Empty || storageConfig.AccountName == string.Empty)
                //    return BadRequest("Sorry, can't retrieve your Azure storage details from appsettings.js, make sure that you add Azure storage details there.");

                //if (storageConfig.ImageContainer == string.Empty)
                //    return BadRequest("Please provide a name for your image container in Azure blob storage.");

                List<string> thumbnailUrls = await StorageHelper.GetThumbNailUrls(storageConfig);
                return thumbnailUrls;            
            }
            catch (Exception ex)
            {
                // TODO add logger here
                return new List<string>();
            }
        }

        public Uri GetSingleImageUri(string fileName)
        {
            // Create a URI to the storage account
            string accountUri = "https://" + storageConfig.AccountName + ".blob.core.windows.net/";
            string uploadedFileUri = accountUri + "images/" + fileName;
            return new Uri(uploadedFileUri);
        }

        // GET /api/images/thumbnails
        [HttpGet("allimages")]
        public async Task<List<string>> GetAllImageUris(AzureStorageConfig config)
        {
            try
            {
                List<string> imageUris = await StorageHelper.GetImageUris(storageConfig);
                return imageUris;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new List<string>();
            }
            

        }
    }
}