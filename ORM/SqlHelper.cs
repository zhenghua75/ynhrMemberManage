using System;
using System.Data;
using System.Xml;
using System.Data.SqlClient;
using System.Collections;


namespace ynhrMemberManage.ORM
{
    /// <summary>
    /// The SqlHelper class is intended to encapsulate high performance, scalable best practices for 
    /// common uses of SqlClient.
    /// 
    /// zhenghua modify edition v2.0
    /// </summary>
    public sealed class SqlHelper
    {
        #region private utility methods & constructors
        private SqlHelper() { }
        private static void AttachParameters(SqlCommand command, SqlParameter[] commandParameters)
        {
            foreach (SqlParameter p in commandParameters)
            {
                //check for derived output value with no value assigned
                if ((p.Direction == ParameterDirection.InputOutput || p.Direction == ParameterDirection.Input) && (p.Value == null))
                {
                    p.Value = DBNull.Value;
                }
                else if ((p.Direction == ParameterDirection.InputOutput || p.Direction == ParameterDirection.Input) && (p.Value.ToString().Trim() == ""))
                {
                    p.Value = DBNull.Value;
                }
                else if ((p.Direction == ParameterDirection.InputOutput || p.Direction == ParameterDirection.Input) && (p.Value.ToString().Trim() == String.Empty))
                {
                    p.Value = DBNull.Value;
                }
                else if ((p.Direction == ParameterDirection.InputOutput || p.Direction == ParameterDirection.Input) && (p.Value is DateTime) && ((DateTime)p.Value).Equals(DateTime.MinValue))
                {
                    p.Value = DBNull.Value;
                }

                command.Parameters.Add(p);
            }
        }       
        private static void PrepareCommand(SqlCommand command, SqlParameter[] commandParameters)
        {
            if (commandParameters != null)
            {
                AttachParameters(command, commandParameters);
            }

            return;
        }
        #endregion private utility methods & constructors

        #region ExecuteNonQuery
        public static int ExecuteNonQuery(CommandType commandType,string commandText)
        {
            return ConnectionPool.Db.ExecuteNonQuery(commandType, commandText);
        }
        public static int ExecuteNonQuery(string commandText, params SqlParameter[] commandParameters)
        {
            using (SqlCommand cmd = ConnectionPool.Db.GetSqlStringCommand(commandText) as SqlCommand)
            {
                PrepareCommand(cmd, commandParameters);
                return ConnectionPool.Db.ExecuteNonQuery(cmd);                
            }
            
        }
        public static int ExecuteNonQuery(string spName, params object[] parameterValues)
        {
            return ConnectionPool.Db.ExecuteNonQuery(spName, parameterValues);
        }
        public static int ExecuteNonQuery(SqlTransaction transaction, CommandType commandType, string commandText)
        {
            return ConnectionPool.Db.ExecuteNonQuery(transaction, commandType, commandText);
        }
        public static int ExecuteNonQuery(SqlTransaction transaction, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            using (SqlCommand cmd = ConnectionPool.Db.GetSqlStringCommand(commandText) as SqlCommand)
            {
                PrepareCommand(cmd, commandParameters);

                return ConnectionPool.Db.ExecuteNonQuery(cmd, transaction);
            }
        }
        public static int ExecuteNonQuery(SqlTransaction transaction, string spName, params object[] parameterValues)
        {
            return ConnectionPool.Db.ExecuteNonQuery(transaction, spName, parameterValues);
        }

        #endregion ExecuteNonQuery

        #region ExecuteDataSet
        public static DataSet ExecuteDataset(CommandType commandType, string commandText)
        {
            return ConnectionPool.Db.ExecuteDataSet(commandType, commandText);
        }        
        public static DataSet ExecuteDataset(string commandText, params SqlParameter[] commandParameters)
        {
            using (SqlCommand cmd = ConnectionPool.Db.GetSqlStringCommand(commandText) as SqlCommand)
            {
                PrepareCommand(cmd, commandParameters);
                return ConnectionPool.Db.ExecuteDataSet(cmd);
            }
        }
        public static DataSet ExecuteDataset(string spName, params object[] parameterValues)
        {
            return ConnectionPool.Db.ExecuteDataSet(spName, parameterValues);
        }
        public static DataSet ExecuteDataset(SqlTransaction transaction, CommandType commandType, string commandText)
        {
            return ConnectionPool.Db.ExecuteDataSet(transaction, commandType, commandText);
        }
        public static DataSet ExecuteDataset(SqlTransaction transaction, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            using (SqlCommand cmd = ConnectionPool.Db.GetSqlStringCommand(commandText) as SqlCommand)
            {
                PrepareCommand(cmd,commandParameters);
                return ConnectionPool.Db.ExecuteDataSet(cmd);
            }
        }
        public static DataSet ExecuteDataset(SqlTransaction transaction, string spName, params object[] parameterValues)
        {
            return ConnectionPool.Db.ExecuteDataSet(transaction, spName, parameterValues);
        }

        #endregion ExecuteDataSet

        #region ExecuteDataTable
        public static DataTable ExecuteDataTable(CommandType commandType, string commandText)
        {
            return ConnectionPool.Db.ExecuteDataSet(commandType, commandText).Tables[0].Copy();
        }
        public static DataTable ExecuteDataTable(string commandText, params SqlParameter[] commandParameters)
        {
            using (SqlCommand cmd = ConnectionPool.Db.GetSqlStringCommand(commandText) as SqlCommand)
            {
                PrepareCommand(cmd,commandParameters);
                return ConnectionPool.Db.ExecuteDataSet(cmd).Tables[0].Copy();
            }
        }
        public static DataTable ExecuteDataTable(string spName, params object[] parameterValues)
        {
            return ConnectionPool.Db.ExecuteDataSet(spName, parameterValues).Tables[0].Copy();
        }
        public static DataTable ExecuteDataTable(SqlTransaction transaction, CommandType commandType, string commandText)
        {
            return ConnectionPool.Db.ExecuteDataSet(transaction, commandType, commandText).Tables[0].Copy();
        }
        public static DataTable ExecuteDataTable(SqlTransaction transaction, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            using (SqlCommand cmd = ConnectionPool.Db.GetSqlStringCommand(commandText) as SqlCommand)
            {
                PrepareCommand(cmd,commandParameters);
                return ConnectionPool.Db.ExecuteDataSet(cmd, transaction).Tables[0].Copy();
            }
        }
        public static DataTable ExecuteDataTable(SqlTransaction transaction, string spName, params object[] parameterValues)
        {
            return ConnectionPool.Db.ExecuteDataSet(transaction, spName, parameterValues).Tables[0].Copy();
        }

        #endregion ExecuteDataTable

        #region ExecuteReader

        public static SqlDataReader ExecuteReader(CommandType commandType, string commandText)
        {
            return (SqlDataReader)ConnectionPool.Db.ExecuteReader(commandType, commandText);
        }
        public static SqlDataReader ExecuteReader(string commandText, params SqlParameter[] commandParameters)
        {
            using (SqlCommand cmd = ConnectionPool.Db.GetSqlStringCommand(commandText) as SqlCommand)
            {
                PrepareCommand(cmd,commandParameters);
                return (SqlDataReader)ConnectionPool.Db.ExecuteReader(cmd);
            }
        }
        public static SqlDataReader ExecuteReader(string spName, params object[] parameterValues)
        {
            return (SqlDataReader)ConnectionPool.Db.ExecuteReader(spName, parameterValues);
        }
        public static SqlDataReader ExecuteReader(SqlTransaction transaction, CommandType commandType, string commandText)
        {
            return (SqlDataReader)ConnectionPool.Db.ExecuteReader(transaction, commandType, commandText);
        }
        public static SqlDataReader ExecuteReader(SqlTransaction transaction, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            using (SqlCommand cmd = ConnectionPool.Db.GetSqlStringCommand(commandText) as SqlCommand)
            {
                PrepareCommand(cmd,commandParameters);
                return (SqlDataReader)ConnectionPool.Db.ExecuteReader(cmd, transaction);
            }
        }
        public static SqlDataReader ExecuteReader(SqlTransaction transaction, string spName, params object[] parameterValues)
        {
            return (SqlDataReader)ConnectionPool.Db.ExecuteReader(transaction, spName, parameterValues);
        }

        #endregion ExecuteReader

        #region ExecuteScalar
        public static object ExecuteScalar(CommandType commandType, string commandText)
        {
            return ConnectionPool.Db.ExecuteScalar(commandType, commandText);
        }
        public static object ExecuteScalar(string commandText, params SqlParameter[] commandParameters)
        {
            using (SqlCommand cmd = ConnectionPool.Db.GetSqlStringCommand(commandText) as SqlCommand)
            {
                PrepareCommand(cmd,commandParameters);
                return ConnectionPool.Db.ExecuteScalar(cmd);                
            }

        }
        public static object ExecuteScalar(string spName, params object[] parameterValues)
        {
            return ConnectionPool.Db.ExecuteScalar(spName, parameterValues);
        }
        public static object ExecuteScalar(SqlTransaction transaction, CommandType commandType, string commandText)
        {
            return ConnectionPool.Db.ExecuteScalar(transaction, commandType, commandText);
        }
        public static object ExecuteScalar(SqlTransaction transaction, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            using (SqlCommand cmd = ConnectionPool.Db.GetSqlStringCommand(commandText) as SqlCommand)
            {
                PrepareCommand(cmd, commandParameters);
                return ConnectionPool.Db.ExecuteScalar(cmd);
            }
        }
        public static object ExecuteScalar(SqlTransaction transaction, string spName, params object[] parameterValues)
        {
            return ConnectionPool.Db.ExecuteScalar(transaction, spName, parameterValues);
        }

        #endregion ExecuteScalar
    }

}
