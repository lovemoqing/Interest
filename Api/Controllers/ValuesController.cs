using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace api
{
    [EnableCors("AllowSameDomain")] //启用跨域
    [Route("api/[controller]/[Action]")]
    public class ValuesController : Controller
    {
        [HttpGet]
        [HttpPost]
        public JsonResult Get(int pageIndex = 1, int pageSize = 10)
        {
            List<TB_Person> list = new List<TB_Person>() {
                new TB_Person() { Name="1叶秀兰",Address= "河南省 漯河市 临颍县",date=DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd")) },
                new TB_Person() { Name="2叶秀兰",Address= "吉林省 通化市 通化县",date=DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd")) },
                new TB_Person() { Name="3叶秀兰",Address= "河南省 漯河市 临颍县",date=DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd")) },
                new TB_Person() { Name="4叶秀兰",Address= "吉林省 通化市 通化县",date=DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd")) },
                new TB_Person() { Name="5叶秀兰",Address= "河南省 漯河市 临颍县",date=DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd")) },
                new TB_Person() { Name="6叶秀兰",Address= "吉林省 通化市 通化县",date=DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd")) },
                new TB_Person() { Name="7叶秀兰",Address= "河南省 漯河市 临颍县",date=DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd")) },
                new TB_Person() { Name="8叶秀兰",Address= "吉林省 通化市 通化县",date=DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd")) },
                new TB_Person() { Name="9叶秀兰",Address= "河南省 漯河市 临颍县",date=DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd")) },
                new TB_Person() { Name="10叶秀兰",Address= "河南省 漯河市 临颍县",date=DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd")) },
                new TB_Person() { Name="11叶秀兰",Address= "河南省 漯河市 临颍县",date=DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd")) },
                new TB_Person() { Name="12叶秀兰",Address= "吉林省 通化市 通化县",date=DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd")) },
                new TB_Person() { Name="13叶秀兰",Address= "河南省 漯河市 临颍县",date=DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd")) },
                new TB_Person() { Name="1413叶秀兰",Address= "吉林省 通化市 通化县",date=DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd")) },
                new TB_Person() { Name="15叶秀兰",Address= "吉林省 通化市 通化县",date=DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd")) },
                new TB_Person() { Name="16叶秀兰",Address= "吉林省 通化市 通化县",date=DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd")) },
                new TB_Person() { Name="17叶秀兰",Address= "吉林省 通化市 通化县",date=DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd")) },
                new TB_Person() { Name="18叶秀兰",Address= "吉林省 通化市 通化县",date=DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd")) },
                new TB_Person() { Name="19叶秀兰",Address= "吉林省 通化市 通化县",date=DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd")) },
                new TB_Person() { Name="20姚明",Address= "宁夏回族自治区 吴忠市 同心县",date=DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd")) }
            };
            ResponseModel<List<TB_Person>> response = new ResponseModel<List<TB_Person>>()
            {
                Code = 200,
                Result = list.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList(),
                Msg = "测试数据！",
                TotalCount = list.Count
            };
            return Json(response);
        }

        [HttpGet]
        [HttpPost]
        public JsonResult Add(string name, string region, string start, string end, bool delivery, string type, string resource, string desc, string options)
        {
            return Json("ok");
        }
    }
}
