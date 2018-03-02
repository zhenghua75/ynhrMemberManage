using System;
using System.Collections.Generic;
using System.Text;
using CardCommon.CardDef;

namespace CardCommon.CardRef
{
    public class NT77
    {
        public static bool Verify()
        {
            string strret="";
            string strNTCode = System.Configuration.ConfigurationManager.AppSettings["RegisterCode"];//"ynhrMemberManage";
            string strNTpassword = System.Configuration.ConfigurationManager.AppSettings["RegisterPwd"];// "e880ee65905ad1c3bb9e66a1a9dbe091";
            //string strwrite = System.Configuration.ConfigurationManager.AppSettings["RegisterInfo"]; //"dx_ynrcsc";
            // StringBuilder pBuffer = new StringBuilder(strwrite.Length);
            if (!FindFirst(strNTCode, out strret)) return false;// throw new Exception(strret);
            if (!Login(strNTpassword, out strret)) return false;//throw new Exception(strret);
            //if (!Read(1, 9, pBuffer, out strret)) throw new Exception(strret);            
            if (!Logout(out strret)) return false;//throw new Exception(strret);
            //if (!pBuffer.ToString().Equals(strwrite)) return false;
            return true;
        }

        /*            加密锁API 函数调用流程
*********************************************************************
*  第一步：通过加密锁识别码找到机器上连接的加密锁,调用方法为： NTFindFirst
第二步：通过NTpassword （加密锁登录密码）登录指定加密锁识别码的加密锁，调用方法为：NTLogin
第三步：加密锁登录后，即可进行如下操作：
??                      读写掉存储区数据调用方法为：NTWrite, NTRead
第四步：完成所有加密锁操作后加密锁登出（NTLogout）.
     在以上的操作过程中，调用失败时可以使用Rtn返回值来得到出错的原因。 
    
*********************************************************************
*/



        private static int Rtn = 1;//Rtn函数方法调用后接收返回值，如果出现错误则返回值为错误码
        //String sStr = "FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF";//赋值字符串

        private static bool FindFirst(string NTCode,out string strret)//获取到加密锁识别码
        {
            Rtn = NT77API.NTFindFirst(NTCode);//查找指定加密锁识别码的加密锁，如果返回值为 0，表示加密锁存在。
            //如果返回值不为0，则可以通过返回值Rtn查看错误代码
            strret = GetStr(Rtn);
            return Rtn == 0 ? true : false;         
  

        }

        public static bool GetHardwareID(out StringBuilder HardwareID,out StringBuilder pBuffer, out string strret)
        {
            //StringBuilder 
            
            //return Rtn == 0 ? true : false;

            //string strret = "";
            string strNTCode = System.Configuration.ConfigurationManager.AppSettings["RegisterCode"];//"ynhrMemberManage";
            string strNTpassword = System.Configuration.ConfigurationManager.AppSettings["RegisterPwd"];// "e880ee65905ad1c3bb9e66a1a9dbe091";
            //string strwrite = System.Configuration.ConfigurationManager.AppSettings["RegisterInfo"]; //"dx_ynrcsc";
            pBuffer = new StringBuilder(32);
            HardwareID = new StringBuilder(32);// 硬件序列号
            if (!FindFirst(strNTCode, out strret)) return false;//throw new Exception(strret);
            if (!Login(strNTpassword, out strret)) return false;//throw new Exception(strret);
            if (!Read(10, 9, pBuffer, out strret)) return false;//throw new Exception(strret);

            
            Rtn = NT77API.NTGetHardwareID(HardwareID);//获取硬件序列号，如果返回值为 0，表示获取硬件序列号成功。
            //如果返回值不为0，则可以通过返回值Rtn查看错误代码
            strret = GetStr(Rtn);

            if (!Logout(out strret)) return false;//throw new Exception(strret);
            //if (!pBuffer.ToString().Equals(strwrite)) return false;
            if (Rtn != 0) return false;
            return true;

        }

        private static bool Login(string NTpassword, out string strret)
        {
            //String NTpassword = this.textNTpassword.Text;// 登录密码
            Rtn = NT77API.NTLogin(NTpassword); //登录加密锁，如果返回值为 0，表示加密锁登录成功。
            //如果返回值不为0，则可以通过返回值Rtn查看错误代码
            strret = GetStr(Rtn);
            return Rtn == 0 ? true : false;   
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="address">加密锁读取数据的起始位置,可以自定义加密锁读取数据的起始位置，最大为1024</param>
        /// <param name="Length">加密锁读取数据的长度，可以自定义加密锁读取数据的长度，最大为1024</param>
        /// <param name="pBuffer"></param>
        /// <param name="strret"></param>
        private static bool Write(int address, int Length, StringBuilder pBuffer, out string strret)
        {
            //int address = 0; //加密锁读取数据的起始位置,可以自定义加密锁读取数据的起始位置，最大为1024
            //int Length = 64; //加密锁读取数据的长度，可以自定义加密锁读取数据的长度，最大为1024
            //StringBuilder pBuffer = new StringBuilder(64);
            //pBuffer = pBuffer.Append(sStr);

            Rtn = NT77API.NTWrite(address, Length, pBuffer);//存储区数据写入，如果返回值为 0，表示数据写入成功。
            //如果返回值不为0，则可以通过返回值Rtn查看错误代码
            strret = GetStr(Rtn);
            return Rtn == 0 ? true : false;   
        }

        private static bool Read(int address, int Length, StringBuilder pBuffer, out string strret)
        {
            //int address = 0; //加密锁读取数据的起始位置,可以自定义加密锁读取数据的起始位置，最大为1024
            //int Length = 64;//加密锁读取数据的长度，可以自定义加密锁读取数据的长度，最大为1024

            //StringBuilder pBuffer = new StringBuilder(64);//存储区数据读取，如果返回值为 0，表示数据写入成功。
            //如果返回值不为0，则可以通过返回值Rtn查看错误代码

            Rtn = NT77API.NTRead(address, Length, pBuffer);
            strret = GetStr(Rtn);
            return Rtn == 0 ? true : false;   
        }

        private static bool Logout(out string strret)
        {
            Rtn = NT77API.NTLogout();
            strret = GetStr(Rtn);
            return Rtn == 0 ? true : false;   
            //加密锁登出，与NTFindFirst成对使用
        }

        private static string GetStr(int ret)
        {
            string strret = "";
            switch (ret)
            {
                case 0:
                    strret = "成功";
                    break;
                case 1:
                    strret = "未找到本系统的ekey";
                    break;
                case 2:
                    strret = "参数不合法";
                    break;
                case 9:
                    strret = "无效Key句柄";
                    break;
                case 16:
                    strret = "HID写操作错误";
                    break;
                case 19:
                    strret = "初始化失败";
                    break;
                case 20:
                    strret = "请插入ekey重新登录";
                    break;
                case 21:
                    strret = "请插入ekey重新登录";
                    break;
                case 25:
                    strret = "权限不足";
                    break;
                case 29:
                    strret = "HID驱动打开失败";
                    break;
                case 32:
                    strret = "ekey已死锁";
                    break;
                case 33:
                    strret = "登录密码错误";
                    break;
                case 35:
                    strret = "HID驱动打开失败";
                    break;
                case 39:
                    strret = "登录密码不合法";
                    break;
                case 41:
                    strret = "管理密码错误";
                    break;
                case 43:
                    strret = "管理密码不合法";
                    break;
                case 44:
                    strret = "管理密码格式错误";
                    break;
                case 45:
                    strret = "管理密码不合法";
                    break;
                case 47:
                    strret = "登录密码格式错误";
                    break;
                case 49:
                    strret = "ekey未登录";
                    break;
                case 74:
                    strret = "ekey已死锁";
                    break;
                case 77:
                    strret = "管理密码错误";
                    break;
                case 78:
                    strret = "管理密码错误";
                    break;
                case 81:
                    strret = "登录ekey失败";
                    break;
                case 82:
                    strret = "权限不足";
                    break;
                case 85:
                    strret = "对只读区域写操作失败";
                    break;
                case 86:
                    strret = "未知错误";
                    break;
                default:
                    return "未知错误";

            }
            return strret;
        }
    }
}
