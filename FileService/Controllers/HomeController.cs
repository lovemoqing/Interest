using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FileService.Common;
using FileService.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Options;

namespace FileService.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOptions<SiteConfig> _siteConfig;
        private readonly IHostingEnvironment _hostingEnvironment;
        public HomeController(IHostingEnvironment hostingEnvironment, IOptions<SiteConfig> siteConfig)
        {
            _hostingEnvironment = hostingEnvironment;
            _siteConfig = siteConfig;
        }
        public IActionResult Index()
        {
            ViewBag.FileList = FileSugar.List(_siteConfig.Value.RootPath);
            ViewBag.Host = _siteConfig.Value.Info;
            return View();
        }

        public JsonResult GetFileList(string currPath)
        {
            Tools tools = new Tools(_siteConfig);
            return Json(FileSugar.List(tools.GetPath(currPath)));
        }

        public JsonResult CreateFolder(string currPath)
        {
            Tools tools = new Tools(_siteConfig);
            FileSugar.CreateFolder(tools.GetPath(currPath));
            return Json("OK");
        }
        public JsonResult Del(string currPath)
        {
            Tools tools = new Tools(_siteConfig);
            FileSugar.DelFolder(tools.GetPath(currPath));
            return Json("OK");
        }
        
        public async Task<IActionResult> Post(List<IFormFile> files)
        {
            string currPath = Request.Form["currpath"];
            long size = files.Sum(f => f.Length);
            Tools tools = new Tools(_siteConfig);
            foreach (var formFile in files)
            {
                string filePath = tools.GetPath(currPath) + "\\" + formFile.FileName;
                if (formFile.Length > 0)
                {
                    //如果文件路径不存在则创建一个
                    if (!System.IO.File.Exists(tools.GetPath(currPath)))
                    {
                        Directory.CreateDirectory(tools.GetPath(currPath));
                    } 
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                }
            }
            return Ok(new { count = files.Count, size });
        }

        /// <summary>
        /// 文件流的方式输出        /// </summary>
        /// <returns></returns>
        public IActionResult DownLoad(string currPath)
        {
            Tools tools = new Tools(_siteConfig);
            var stream = System.IO.File.OpenRead(tools.GetPath(currPath));
            return File(stream, "application/octet-stream", Path.GetFileName(tools.GetPath(currPath)));
        }
    }
}