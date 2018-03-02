using System;
using System.Data.SqlClient;
using System.Configuration;
using ynhrMemberManage.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;


namespace ynhrMemberManage.ORM
{
    /// <summary>
    /// 名称：数据库连接池。
    /// 版本：V1.0
    /// 创建：zhenghua
    /// 日期：2007-11-09
    /// 描述：使用单实例模式实现连接池管理。
    ///       借用连接调用：ConnectionPool.Instance.BConnection()。
    ///       归还连接调用：ConnectionPool.Instance.RConnection(SqlConnection conn)
    ///
    /// Log ：1
    /// 版本：V2.0
    /// 修改：zhenghua
    /// 日期：2007-11-09
    /// 描述：从业务外观层移到数据访问层，增加静态成员方法 BorrowConnection()
    ///                                                    ReturnConnection(SqlConnection conn)
    ///       公开原实例成员方法，并隐藏唯一实例，从而简化调用过程。
    ///       借用连接：ConnectionPool.BorrowConnection()
    ///       归还连接：ConnectionPool.ReturnConnection(SqlConnection conn)
    /// 20110203 修改     
    /// </summary>
    public sealed class ConnectionPool
    {
        #region 使用静态方法公开私有实例的私有成员方法
        /// <summary>
        /// 从连接池中借用一个连接
        /// </summary>
        /// <returns>连接对象</returns>
        public static SqlConnection BorrowConnection()
        {
            return Instance.BConnection();
        }

        /// <summary>
        /// 归还一个连接到连接池
        /// </summary>
        /// <param name="conn">连接对象</param>
        public static void ReturnConnection(SqlConnection conn)
        {
            Instance.RConnection(conn);
        }
        #endregion

        #region 私有成员变量
        // 唯一实例
        private static readonly ConnectionPool Instance = new ConnectionPool();
        private static SqlDatabase db = null;
        public static SqlDatabase Db
        {
            get { return db; }
        }
        #endregion

 
        #region 静态构造器使用ConnectionManager初始化连接字符串        
        static ConnectionPool()
        {            
            //db = DatabaseFactory.CreateDatabase() as SqlDatabase;

            string _connectionStringSet = ConfigAdapter.GetConfigNote("SetConnectionString").Trim();
            string _connectionString = _connectionStringSet;
            if (String.Empty != _connectionStringSet)
            {
                _connectionStringSet = DataSecurity.Encrypt(_connectionStringSet);
                ConfigAdapter.SetConfigNote("ConnectionString", _connectionStringSet);
                ConfigAdapter.SetConfigNote("SetConnectionString", String.Empty);
            }
            else
            {
                _connectionString = ConfigAdapter.GetConfigNote("ConnectionString");
                _connectionString = DataSecurity.Decrypt(_connectionString);
            }
            db = new SqlDatabase(_connectionString);
        }
        #endregion

        #region 私有构造器防止从外部生成对象实例
        private ConnectionPool() { }
        #endregion


        #region 借出、归还连接(适配基类已实现方法)
        // 借用一个连接
        private SqlConnection BConnection()
        {
            SqlConnection conn = db.CreateConnection() as SqlConnection;
            conn.Open();
            return conn;
        }

        /// <summary>
        /// 归还一个连接到连接池
        /// </summary>
        /// <param name="conn">连接对象</param>
        private void RConnection(SqlConnection conn)
        {
            conn.Close();
        
        }
        #endregion

    }
}
