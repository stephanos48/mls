using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Auth;
using System.Web.Hosting;

namespace mls.Controllers
{
    public class UploadController : Controller
    {

        UploadService uploadService = new UploadService();

        private StorageCredentials storageCredentials;
        private CloudStorageAccount cloudStorageAccount;
        private CloudBlobClient cloudBlobClient;
        private CloudBlobContainer cloudBlobContainer;
        private HostingEnvironment hostingEnvironment;

        private UploadController(HostingEnvironment env)
        {
            this.hostingEnvironment = env;
            storageCredentials = new StorageCredentials("mlsdatablob", "opnUlCANJa43SqVtiQ7hSx3Eh6kQDc8iL6ohtw0DWNnuVkgeZcH3jspFL/KH2R1bCJtFkzMRHMPNnfXNWbQUSw==");
            cloudStorageAccount = new CloudStorageAccount(storageCredentials, true);
            cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
            cloudBlobContainer = cloudBlobClient.GetContainerReference("mlsdata-pics");
        }

        // GET: Upload
        public ActionResult Upload()
        {
            ViewBag.ContainerName = "Name : " + cloudBlobContainer.Name;
            GetAllBlobs();
            return View();
        }

        private void GetAllBlobs()
        {
            ViewBag.Blobs = cloudBlobContainer.ListBlobs().ToList();
        }

        /*[HttpPost]
        public async Task<ActionResult> UploadFiles(IList<> files)
        {
            long size = 0;
            try
            {
                foreach (var file in files)
                {
                    var fileName = ContentDispositionHeaderValue
                                   .Parse(file.ContentDisposition)
                                   .FileName
                                   .Trim('');
                }
            }
            catch (Exception)
            {

            }
        }*/

        [HttpPost]
        public async Task<ActionResult> Upload(HttpPostedFileBase photo)
        {
            var imageUrl = await uploadService.UploadImageAsync(photo);
            TempData["LatestImage"] = imageUrl.ToString();
            return RedirectToAction("LatestImage");
        }

        public ActionResult LatestImage()
        {
            var latestImage = string.Empty;
            if (TempData["LatestImage"] != null)
            {
                ViewBag.LatestImage = Convert.ToString(TempData["LatestImage"]);
            }

            return View();
        }

    }
}