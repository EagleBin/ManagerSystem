using SqlSugar;
using System.ComponentModel.DataAnnotations;

namespace ManagerSystem.Data
{
    public class MySqlHelper<T> where T : class, new()
    {

        public SqlSugarClient Db;
        public SimpleClient<T> CurrentDb { get { return new SimpleClient<T>(Db); } }

        private static MySqlHelper<T> mySingle = null;
        /// <summary>
        /// 单例模式，初始化
        /// </summary>
        /// <returns></returns>
        public static MySqlHelper<T> GetInstance()
        {
            if (mySingle == null)
            {
                lock(typeof(MySqlHelper<T>))
                {
                    if (mySingle == null)
                    {
                        mySingle = new MySqlHelper<T>();
                    }
                }
            }

            return mySingle;
        }

        /// <summary>
        /// 构造函数，初始化，连接数据库
        /// </summary>
        public MySqlHelper()
        {
            Db = new SqlSugarClient(new ConnectionConfig()
            {
                //ConnectionString = "server=.;uid=sa;pwd=123456;database=DailyApp_DeepLearn",
                //DbType = SqlSugar.DbType.SqlServer,
                //IsAutoCloseConnection = true,
                //InitKeyType = InitKeyType.Attribute

                ConnectionString = "database=managersystem;Data Source=127.0.0.1;User Id=root;pwd=123456;charset=utf8;pooling=true",
                DbType = SqlSugar.DbType.MySql,
                IsAutoCloseConnection = true,
                InitKeyType = InitKeyType.Attribute
            });

            //调式代码 用来打印SQL
            Db.Aop.OnLogExecuting = (sql, pars) =>
            {
                Console.WriteLine(sql + "\r\n" +
                    Db.Utilities.SerializeObject(pars.ToDictionary(it => it.ParameterName, it => it.Value)));
                Console.WriteLine();
            };

        }

        /// <summary>
        /// 关闭
        /// </summary>
        public void Dispose()
        {
            if (Db != null)
            {
                Db.Dispose();
            }
        }




    }
}
