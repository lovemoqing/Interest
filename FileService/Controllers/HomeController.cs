using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FileService.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace FileService.Controllers
{
    public class HomeController : Controller
    {
        private readonly SiteConfig _siteConfig;
        private readonly IHostingEnvironment _hostingEnvironment;
        public HomeController(IHostingEnvironment hostingEnvironment, IOptions<SiteConfig> siteConfig)
        {
            _hostingEnvironment = hostingEnvironment;
            _siteConfig = siteConfig.Value;
        }
        public IActionResult Index()
        {
            ViewBag.Host = _siteConfig.Info;
            return View();
        }
    }
}