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
    /// ���ƣ����ݿ����ӳء�
    /// �汾��V1.0
    /// ������zhenghua
    /// ���ڣ�2007-11-09
    /// ������ʹ�õ�ʵ��ģʽʵ�����ӳع���
    ///       �������ӵ��ã�ConnectionPool.Instance.BConnection()��
    ///       �黹���ӵ��ã�ConnectionPool.Instance.RConnection(SqlConnection conn)
    ///
    /// Log ��1
    /// �汾��V2.0
    /// �޸ģ�zhenghua
    /// ���ڣ�2007-11-09
    /// ��������ҵ����۲��Ƶ����ݷ��ʲ㣬���Ӿ�̬��Ա���� BorrowConnection()
    ///                                                    ReturnConnection(SqlConnection conn)
    ///       ����ԭʵ����Ա������������Ψһʵ�����Ӷ��򻯵��ù��̡�
    ///       �������ӣ�ConnectionPool.BorrowConnection()
    ///       �黹���ӣ�ConnectionPool.ReturnConnection(SqlConnection conn)
    /// 20110203 �޸�     
    /// </summary>
    public sealed class ConnectionPool
    {
        #region ʹ�þ�̬��������˽��ʵ����˽�г�Ա����
        /// <summary>
        /// �����ӳ��н���һ������
        /// </summary>
        /// <returns>���Ӷ���</returns>
        public static SqlConnection BorrowConnection()
        {
            return Instance.BConnection();
        }

        /// <summary>
        /// �黹һ�����ӵ����ӳ�
        /// </summary>
        /// <param name="conn">���Ӷ���</param>
        public static void ReturnConnection(SqlConnection conn)
        {
            Instance.RConnection(conn);
        }
        #endregion

        #region ˽�г�Ա����
        // Ψһʵ��
        private static readonly ConnectionPool Instance = new ConnectionPool();
        private static SqlDatabase db = null;
        public static SqlDatabase Db
        {
            get { return db; }
        }
        #endregion

 
        #region ��̬������ʹ��ConnectionManager��ʼ�������ַ���        
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

        #region ˽�й�������ֹ���ⲿ���ɶ���ʵ��
        private ConnectionPool() { }
        #endregion


        #region ������黹����(���������ʵ�ַ���)
        // ����һ������
        private SqlConnection BConnection()
        {
            SqlConnection conn = db.CreateConnection() as SqlConnection;
            conn.Open();
            return conn;
        }

        /// <summary>
        /// �黹һ�����ӵ����ӳ�
        /// </summary>
        /// <param name="conn">���Ӷ���</param>
        private void RConnection(SqlConnection conn)
        {
            conn.Close();
        
        }
        #endregion

    }
}
