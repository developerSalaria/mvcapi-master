using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TPA.Common.Core.Constants;
using TPA.Common.Core.Helpers;
using TPA.Common.Core.Model;
using TPA.Common.Core.Services;

namespace TPA.Presentation.ApiServices
{
    public class FileService : HttpClientService
    {
        static FileService _instance;

        public static FileService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new FileService();
                }
                return _instance;
            }
        }

        public FileData GetFile(int fileId)
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.FileApiURL.GET_FILE + $"?fileId={fileId}");
            var Content = Get<FileData>(URL);
            if (Content.IsSuccessful)
            {
                return Content.Model;
            }
            else
            {
                return null;
            }
        }

        public int SaveFile(HttpPostedFileBase file)
        {
            if (file == null)
                return 0;

            byte[] uploadedFile = new byte[file.InputStream.Length];
            file.InputStream.Read(uploadedFile, 0, uploadedFile.Length);
            FileData data = new FileData();
            // Initialization.  
            data.Contents = Convert.ToBase64String(uploadedFile);
            data.ContentType = file.ContentType;
            data.FileName = file.FileName;
            return SaveFile(data);
        }

        public int SaveFile(FileData file)
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.FileApiURL.SAVE_FILE);
            var Content = Post<int>(URL, file);
            if (Content.IsSuccessful)
            {
                return Content.Model;
            }
            else
            {
                return -1;
            }
        }
    }
}