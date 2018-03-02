using System;
using System.IO;
using System.Xml;
using System.Configuration;

namespace ynhrMemberManage.Common
{
	/// <summary>
	/// �����ļ���������.
	/// zhenghua@create 2007.11.09
	/// </summary>
	public class ConfigAdapter
	{
        /// <summary>
        /// ��̬������
        /// </summary>
        ConfigAdapter()
        {
            // ���������ļ�·��
        }

		/// <summary>
        /// ȡ������
        /// </summary>
        /// <param name="strNoteName">����������</param>
        /// <returns>������ֵ</returns>
        public static string GetConfigNote(string strNoteName)
        {
            return System.Configuration.ConfigurationManager.AppSettings[strNoteName];
        }

        /// <summary>
        /// ����������
        /// </summary>
        /// <param name="strNoteName">����������</param>
        /// <param name="strNoteValue">������ֵ</param>
        public static void SetConfigNote(string strNoteName, string strNoteValue)
        {
            XmlDocument xmldoc = new XmlDocument();
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(System.Windows.Forms.Application.ExecutablePath);
            xmldoc.Load(config.FilePath);
            XmlNode ne2 = xmldoc.SelectSingleNode("//configuration/appSettings/add[@key='"+strNoteName+"']");
            ne2.Attributes["value"].Value = strNoteValue;
            xmldoc.Save(config.FilePath);
            System.Configuration.ConfigurationManager.RefreshSection("appSettings");
        }

	}
}
