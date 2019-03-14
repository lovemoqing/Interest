using Model;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public class DalNotice
    {
        public static List<TB_Notice> GetAll()
        {
            SqlSugarClient db = SqlContext.CreateInstance();
            return db.Queryable<TB_Notice>().ToList();
        }
    }
}
