using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FileService.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace FileService.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class InterfaceController : ControllerBase
    {
        private readonly SiteConfig _siteConfig;
        private readonly IHostingEnvironment _hostingEnvironment;
        public InterfaceController(IHostingEnvironment hostingEnvironment, IOptions<SiteConfig> siteConfig)
        {
            _hostingEnvironment = hostingEnvironment;
            _siteConfig = siteConfig.Value;
        }
        /// <summary>
        /// 图片上传
        /// </summary>
        /// <param name="id">标识，暂时没用</param>
        /// <param name="filename">图片名称，带后缀名</param>
        /// <param name="img">图片base64编码</param>
        /// <returns></returns>
        public IActionResult Upload(int id, string filename, string img)
        {
            string res = string.Empty;
            try
            {
                string filePath = _hostingEnvironment.WebRootPath + "/images/" + filename;
                //将Base64String转为图片并保存
                byte[] arr2 = Convert.FromBase64String(img);
                using (MemoryStream ms2 = new MemoryStream(arr2))
                {
                    System.Drawing.Bitmap bmp2 = new System.Drawing.Bitmap(ms2);
                    bmp2.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);
                }
                res = _siteConfig.Info + "/images/" + filename;
            }
            catch (Exception ex)
            {
                res = ex.ToString();
            }
            return Content(res);
        }



        [HttpPost]
        public async Task<IActionResult> Post(List<IFormFile> files)
        {
            long size = files.Sum(f => f.Length);

            foreach (var formFile in files)
            {
                string filePath = _hostingEnvironment.WebRootPath + "/images/" + formFile.FileName;
                if (formFile.Length > 0)
                {
                    //如果文件路径不存在则创建一个
                    //if (!System.IO.File.Exists(folderPath))
                    //{
                    //    Directory.CreateDirectory(folderPath);
                    //} 
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                }
            }
            return Ok(new { count = files.Count, size });
        }
    }
}