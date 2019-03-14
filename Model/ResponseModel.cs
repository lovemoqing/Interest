using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 返回模型
    /// </summary>
    public class ResponseModel<T>
    {
        /// <summary>
        /// 状态码
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// 总数
        /// </summary>
        public int TotalCount { get; set; }
        /// <summary>
        /// 提示
        /// </summary>
        public string Msg { get; set; }
        /// <summary>
        /// 返回的结果集
        /// </summary>
        public T Result { get; set; }
    }
}
