using SqlSugar;
using System;
using System.Collections.Generic;

namespace Service
{
    /// <summary>
    /// 数据库连接上下文
    /// </summary>
    public class SqlContext
    {
        private const string conn = "server=47.93.243.75;database=MyStudy;uid=sa;pwd=love520..;";
        //单例模式变量
        private static SqlSugarClient _db = null;
        //解决多线程下单例失效问题,对对象进行为空判断时加上锁机制
        private static object _db_lock = new object();
        //定义私有的构造函数禁止对上下文实例化
        private SqlContext() { }
        //创建单例对象
        public static SqlSugarClient CreateInstance(DbType dbType = DbType.SqlServer, string conn = conn)
        {
            lock (_db_lock)
            {
                if (_db == null)
                {
                    _db = new SqlSugarClient(new ConnectionConfig()
                    {
                        ConnectionString = conn,
                        DbType = dbType,
                        IsAutoCloseConnection = true
                    });
                }
            }
            return _db;
        }
    }

    public class SqlHelper
    {
        private static SqlSugarClient _SqlSugarClient = SqlContext.CreateInstance();

        public static List<T> GetList<T>()
        {
            return _SqlSugarClient.Queryable<T>().ToList();
        }

    }
}
