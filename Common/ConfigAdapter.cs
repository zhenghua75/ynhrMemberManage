using System;
using System.IO;
using System.Xml;
using System.Configuration;

namespace ynhrMemberManage.Common
{
	/// <summary>
	/// 配置文件适配器类.
	/// zhenghua@create 2007.11.09
	/// </summary>
	public class ConfigAdapter
	{
        /// <summary>
        /// 静态构造器
        /// </summary>
        ConfigAdapter()
        {
            // 设置配置文件路径
        }

		/// <summary>
        /// 取配置项
        /// </summary>
        /// <param name="strNoteName">配置项名称</param>
        /// <returns>配置项值</returns>
        public static string GetConfigNote(string strNoteName)
        {
            return System.Configuration.ConfigurationManager.AppSettings[strNoteName];
        }

        /// <summary>
        /// 设置配置项
        /// </summary>
        /// <param name="strNoteName">配置项名称</param>
        /// <param name="strNoteValue">配置项值</param>
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
