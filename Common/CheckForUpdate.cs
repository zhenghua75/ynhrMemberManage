using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;

namespace ynhrMemberManage.Common
{
    public class CheckForUpdate
    {
        public static bool IsUpdate()
        {
            string updateUrl = string.Empty;
            string tempUpdatePath = string.Empty;
            XmlFiles updaterXmlFiles = null;
            int availableUpdate = 0;
            //			if (!CheckInetConnection())
            //			{
            //				MessageBox.Show("无网络连接!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //				//this.Close();
            //				return false;
            //			}

            //panel2.Visible = false;
            //btnFinish.Visible = false;

            string localXmlFile = Application.StartupPath + "\\UpdateList.xml";
            string serverXmlFile = string.Empty;


            try
            {
                //从本地读取更新配置文件信息
                updaterXmlFiles = new XmlFiles(localXmlFile);
            }
            catch
            {
                MessageBox.Show("配置文件出错!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //this.Close();
                return false;
            }
            //获取服务器地址
            updateUrl = updaterXmlFiles.GetNodeValue("//Url");

            AppUpdater appUpdater = new AppUpdater();
            appUpdater.UpdaterUrl = updateUrl + "/UpdateList.xml";

            //与服务器连接,下载更新配置文件
            try
            {
                tempUpdatePath = Environment.GetEnvironmentVariable("Temp") + "\\" + "_" + updaterXmlFiles.FindNode("//Application").Attributes["applicationId"].Value + "_" + "y" + "_" + "x" + "_" + "m" + "_" + "\\";
                appUpdater.DownAutoUpdateFile(tempUpdatePath);
            }
            catch
            {
                MessageBox.Show("与服务器连接失败,操作超时!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //this.Close();
                return false;

            }

            //获取更新文件列表
            Hashtable htUpdateFile = new Hashtable();

            serverXmlFile = tempUpdatePath + "\\UpdateList.xml";
            if (!File.Exists(serverXmlFile))
            {
                return false;
            }

            availableUpdate = appUpdater.CheckForUpdate(serverXmlFile, localXmlFile, out htUpdateFile);
            if (availableUpdate > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
