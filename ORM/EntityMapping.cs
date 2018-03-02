#region Import NameSpace

using System;
using System.Collections;
using System.Reflection;
using System.Diagnostics;
using System.Data;
using System.Data.SqlClient;
using ynhrMemberManage.Common;
using System.Collections.Generic;
using System.Data.Common;

#endregion

namespace ynhrMemberManage.ORM
{
    /// <summary>
    /// ���ƣ�ʵ�����ӳ���ࡣ
    /// �汾��V1.0
    /// ������zhenghua
    /// ���ڣ�2007-11-09
    /// �������ṩCreate() Update() Delete() Get()������ʵ�����ӳ�䵽���ݿ�
    ///
    /// Log ��1
    /// �汾��v 2.0
    /// �޸ģ�zhenghua
    /// ���ڣ�2007-11-09
    /// ���������Ӳ������¡���ɾ���ķ�����
    ///
    /// Log ��2
    /// �汾��v 2.1
    /// �޸ģ�zhenghua
    /// ���ڣ�20110204
    /// ������
    /// 
    /// </summary>
    public class EntityMapping
    {
        #region ��ȡ��¼ӳ��

        /// <summary>
        /// ��ȡ��¼ӳ��
        /// </summary>
        /// <param name="objEntity">ʵ��</param>
        /// <param name="conn">���ݿ�����</param>
        /// <returns>ʵ��</returns>
        public static EntityObjectBase Get(EntityObjectBase objEntity)
        {
            return Get(objEntity, null);
        }


        /// <summary>
        /// ��ȡ��¼ӳ��
        /// </summary>
        /// <param name="objEntity">ʵ��</param>
        /// <param name="tran">���ݿ��������</param>
        /// <returns>ʵ��</returns>
        //public static EntityObjectBase Get(EntityObjectBase objEntity, SqlTransaction tran)
        //{
        //    return Get(objEntity, null, tran);
        //}


        /// <summary>
        /// ��ȡ��¼ӳ��
        /// </summary>
        /// <param name="objEntity">ʵ��</param>        
        /// <param name="tran">���ݿ��������</param>
        /// <returns>ʵ��</returns>
        public static EntityObjectBase Get(EntityObjectBase objEntity, SqlTransaction tran)        
        {
            TableAttributes taEntity = objEntity.GetEntityColumns();

            string strKeyColumns = "";

            List<SqlParameter> lstPara = new List<SqlParameter>();            
            for (int i = 0; i < taEntity.Columns.Count; i++)
            {// ��װ����
                ColumnAttributes caCurrent = taEntity.Columns[i] as ColumnAttributes;
                if (caCurrent.IsPrimaryKey)
                {
                    strKeyColumns += caCurrent.ColumnName + "=@" + caCurrent.ColumnName + " AND ";
                    SqlParameter paraCurrent = new SqlParameter("@" + caCurrent.ColumnName, caCurrent.Value);    
                    
                    lstPara.Add(paraCurrent);
                }
            }
			SqlParameter[] objPara = new SqlParameter[lstPara.Count];
			for(int i=0; i < lstPara.Count; i++)
			{
				objPara[i] = lstPara[i] as SqlParameter;
			}

            string strSql = "SELECT * FROM [TableName] with(nolock) WHERE [Key]";
            // �滻��ǰ������
            strSql = strSql.Replace("[TableName]", taEntity.TableName);
            strSql = strSql.Replace("[Key]", strKeyColumns.Substring(0, strKeyColumns.Length - 5));

            DataTable tbResult = null;
            if (null == tran)
            {
                tbResult = SqlHelper.ExecuteDataset(strSql, objPara).Tables[0];
            }
            else
            {
                tbResult = SqlHelper.ExecuteDataset(tran, CommandType.Text, strSql, objPara).Tables[0];
            }

            if (tbResult.Rows.Count > 0)
            {
                Type type = objEntity.GetType();
                EntityObjectBase objResult = Activator.CreateInstance(type) as EntityObjectBase;

                objResult.FromTable(tbResult);

                return objResult;
            }
            else
            {
                return null;
            }
        }

        #endregion

        #region �½���¼ӳ��

        /// <summary>
        /// �½���¼ӳ��
        /// </summary>
        /// <param name="objEntity">ʵ��</param>
        /// <param name="conn">���ݿ�����</param>
        /// <returns>�����ֶ�ֵ��Ӱ������</returns>
        //public static long Create(EntityObjectBase objEntity,SqlConnection conn)
        //{
        //    return Create(objEntity,conn,null);
        //}

        /// <summary>
        /// �½���¼ӳ��
        /// </summary>
        /// <param name="objEntity">ʵ��</param>
        /// <param name="tran">���ݿ��������</param>
        /// <returns>�����ֶ�ֵ��Ӱ������</returns>
        public static long Create(EntityObjectBase objEntity)
        {
            return Create(objEntity, null);
        }

        /// <summary>
        /// �½���¼ӳ��
        /// </summary>
        /// <param name="objEntity">ʵ��</param>
        /// <param name="tran">���ݿ�����</param>
        /// <returns>�����ֶ�ֵ��Ӱ������</returns>
        public static long Create(EntityObjectBase objEntity, SqlTransaction tran)
        {
            TableAttributes taEntity = objEntity.GetEntityColumns();

            string strColumns = "";
            string strParaColumns = "";
            bool bIsIdentity = false;

            List<SqlParameter> lstPara = new List<SqlParameter>();            
            for(int i = 0; i < taEntity.Columns.Count; i++)
            {// ��װ����
                ColumnAttributes caCurrent = taEntity.Columns[i] as ColumnAttributes;
                if(caCurrent.IsIdentity)
                {
                    bIsIdentity = true;
                    continue;
                }

                strColumns += caCurrent.ColumnName + ",";
                strParaColumns += "@" + caCurrent.ColumnName + ",";

                SqlParameter paraCurrent = null;
                if (caCurrent.IsVersionNumber)
                {
                    paraCurrent = new SqlParameter("@" + caCurrent.ColumnName, 1);
                }
                else
                {
                    //��������
                    paraCurrent = new SqlParameter("@" + caCurrent.ColumnName, caCurrent.Value);
                }

                lstPara.Add(paraCurrent);
            }
			SqlParameter[] objPara = new SqlParameter[lstPara.Count];
			for(int i=0; i < lstPara.Count; i++)
			{
				objPara[i] = lstPara[i] as SqlParameter;
			}
            
            string strSql = "INSERT INTO [TableName]([Columns]) VALUES([ParaColumns])";
            // �滻��ǰ������
            strSql = strSql.Replace("[TableName]",  taEntity.TableName);
            strSql = strSql.Replace("[Columns]",    strColumns.Substring(0,strColumns.Length-1));
            strSql = strSql.Replace("[ParaColumns]",strParaColumns.Substring(0,strParaColumns.Length-1));

            if(bIsIdentity)
            {
                // �������ֶεĲ���
                strSql += "  SELECT @@IDENTITY";
                if (null == tran)
                {
                    return long.Parse(SqlHelper.ExecuteScalar(strSql, objPara).ToString());
                }
                else
                {
                    return long.Parse(SqlHelper.ExecuteScalar(tran,CommandType.Text,strSql,objPara).ToString());
                }
            }
            else
            {
                // ���������ֶεĲ���
                if ( null == tran)
                {
                    return SqlHelper.ExecuteNonQuery(strSql,objPara);
                }
                else
                {
                    return SqlHelper.ExecuteNonQuery(tran,CommandType.Text,strSql,objPara);
                }
            }
        }

        #endregion

        #region ���¼�¼ӳ��

        /// <summary>
        /// ���¼�¼ӳ��
        /// </summary>
        /// <param name="objEntity">ʵ��</param>
        /// <param name="conn">���ݿ�����</param>
        /// <returns>Ӱ�������</returns>
        public static int Update(EntityObjectBase objEntity)
        {
            return Update(objEntity, null);
        }

        /// <summary>
        /// ���¼�¼ӳ��
        /// </summary>
        /// <param name="objEntity">ʵ��</param>
        /// <param name="tran">���ݿ��������</param>
        /// <returns>Ӱ�������</returns>
        //public static int Update(EntityObjectBase objEntity, SqlTransaction tran)
        //{
        //    return Update(objEntity, null, tran);
        //}

        /// <summary>
        /// ���¼�¼ӳ��
        /// </summary>
        /// <param name="objEntity">ʵ��</param>
        /// <param name="conn">���ݿ�����</param>
        /// <param name="tran">���ݿ��������</param>
        /// <returns>Ӱ�������</returns>
        public static int Update(EntityObjectBase objEntity, SqlTransaction tran)
        {
            TableAttributes taEntity = objEntity.GetEntityColumns();

            string strUpColumns = String.Empty;
            string strKeyColumns = String.Empty;

            List<SqlParameter> lstPara = new List<SqlParameter>();            
            for (int i = 0; i < taEntity.Columns.Count; i++)
            {// ��װ����
                ColumnAttributes caCurrent = taEntity.Columns[i] as ColumnAttributes;
                if (caCurrent.IsPrimaryKey)
                {
                    strKeyColumns += caCurrent.ColumnName + "=@" + caCurrent.ColumnName + " AND ";
                }
                else if (caCurrent.IsVersionNumber)
                {
                    strUpColumns += caCurrent.ColumnName + "=" + caCurrent.ColumnName + " + 1,";

                    continue;
                }
                else if (caCurrent.IsModify)
                {                    
                    strUpColumns += caCurrent.ColumnName + "=@" + caCurrent.ColumnName + ",";
                }
                else
                {
                    continue;
                }

                //��������
                SqlParameter paraCurrent = new SqlParameter("@" + caCurrent.ColumnName, caCurrent.Value);
                lstPara.Add(paraCurrent);
            }

			if(String.Empty == strUpColumns.Trim())
			{
				return 0;
			}

			SqlParameter[] objPara = new SqlParameter[lstPara.Count];
			for(int i=0; i < lstPara.Count; i++)
			{
				objPara[i] = lstPara[i] as SqlParameter;
			}

            string strCondition = strKeyColumns;
            string strSql = "UPDATE [TableName] SET [Columns] WHERE [Condition]";
            // �滻��ǰ������
            strSql = strSql.Replace("[TableName]", taEntity.TableName);
            strSql = strSql.Replace("[Columns]", strUpColumns.Substring(0, strUpColumns.Length - 1));
            strSql = strSql.Replace("[Condition]", strCondition.Substring(0, strCondition.Length - 5));

            int upCount = 0;
            if (null == tran)
            {
                upCount = SqlHelper.ExecuteNonQuery(strSql, objPara);
            }
            else
            {
                upCount = SqlHelper.ExecuteNonQuery(tran, CommandType.Text, strSql, objPara);
            }

            return upCount;
        }

        #endregion


        #region ɾ����¼ӳ��

        /// <summary>
        /// ɾ����¼ӳ��
        /// </summary>
        /// <param name="objEntity">ʵ��</param>
        /// <param name="conn">���ݿ�����</param>
        /// <returns>Ӱ������</returns>
        public static int Delete(EntityObjectBase objEntity)
        {
            return Delete(objEntity, null);
        }

        /// <summary>
        /// ɾ����¼ӳ��
        /// </summary>
        /// <param name="objEntity">ʵ��</param>
        /// <param name="tran">���ݿ��������</param>
        /// <returns>Ӱ������</returns>
        //public static int Delete(EntityObjectBase objEntity, SqlTransaction tran)
        //{
        //    return Delete(objEntity, null, tran);
        //}


        /// <summary>
        /// ɾ����¼ӳ��
        /// </summary>
        /// <param name="objEntity">ʵ��</param>
        /// <param name="conn">���ݿ�����</param>
        /// <param name="tran">���ݿ��������</param>
        /// <returns>Ӱ������</returns>
        public static int Delete(EntityObjectBase objEntity , SqlTransaction tran)
        {
            TableAttributes taEntity = objEntity.GetEntityColumns();

            string strKeyColumns = String.Empty;

            List<SqlParameter> lstPara = new List<SqlParameter>();            
            for (int i = 0; i < taEntity.Columns.Count; i++)
            {// ��װ����
                ColumnAttributes caCurrent = taEntity.Columns[i] as ColumnAttributes;
                if (caCurrent.IsPrimaryKey)
                {
                    strKeyColumns += caCurrent.ColumnName + "=@" + caCurrent.ColumnName + " AND ";
                }
                else
                {
                    continue;
                }

                SqlParameter paraCurrent = new SqlParameter("@" + caCurrent.ColumnName, caCurrent.Value);
                lstPara.Add(paraCurrent);
            }
			SqlParameter[] objPara = new SqlParameter[lstPara.Count];
			for(int i=0; i < lstPara.Count; i++)
			{
				objPara[i] = lstPara[i] as SqlParameter;
			}


            string strCondition = strKeyColumns;
            string strSql = "DELETE FROM [TableName] WHERE [Condition]";
            // �滻��ǰ������
            strSql = strSql.Replace("[TableName]", taEntity.TableName);
            strSql = strSql.Replace("[Condition]", strCondition.Substring(0, strCondition.Length - 5));

            int upCount = 0;
            if (null == tran)
            {
                upCount = SqlHelper.ExecuteNonQuery(strSql, objPara);
            }
            else
            {
                upCount = SqlHelper.ExecuteNonQuery(tran, CommandType.Text, strSql, objPara);
            }

            return upCount;
        }

        #endregion

    }
}
