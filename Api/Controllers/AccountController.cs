using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace Api.Controllers
{
    [EnableCors("AllowSameDomain")] //启用跨域
    [Route("api/[controller]/[Action]")]
    public class AccountController : Controller
    {
        public JsonResult Single(TB_UserInfo user)
        {
            return Json(user);
        }
    }
}