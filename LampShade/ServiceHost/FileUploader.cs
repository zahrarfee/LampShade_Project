﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using _0_Framework.Application;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace ServiceHost
{
    public class FileUploader:IFileUploader
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileUploader(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public string Upload(IFormFile file,string path)
        {
            if (file == null)
                return "";
              var pathDirectory = $"{_webHostEnvironment.WebRootPath}//ProductPictures//{path}";
              if (!Directory.Exists(pathDirectory))
              {
                  Directory.CreateDirectory(pathDirectory);

              }

              var fileName = $"{DateTime.Now.ToFileName()}-{file.FileName}"; 
              var filepath = $"{pathDirectory}//{fileName}";
            using var output=System.IO.File.Create(filepath );
            file.CopyTo(output);
            return $"{path}/{fileName}";
        }
    }
}
