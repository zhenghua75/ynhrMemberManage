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

        /*            ������API ������������
*********************************************************************
*  ��һ����ͨ��������ʶ�����ҵ����������ӵļ�����,���÷���Ϊ�� NTFindFirst
�ڶ�����ͨ��NTpassword ����������¼���룩��¼ָ��������ʶ����ļ����������÷���Ϊ��NTLogin
����������������¼�󣬼��ɽ������²�����
??                      ��д���洢�����ݵ��÷���Ϊ��NTWrite, NTRead
���Ĳ���������м�����������������ǳ���NTLogout��.
     �����ϵĲ��������У�����ʧ��ʱ����ʹ��Rtn����ֵ���õ������ԭ�� 
    
*********************************************************************
*/



        private static int Rtn = 1;//Rtn�����������ú���շ���ֵ��������ִ����򷵻�ֵΪ������
        //String sStr = "FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF";//��ֵ�ַ���

        private static bool FindFirst(string NTCode,out string strret)//��ȡ��������ʶ����
        {
            Rtn = NT77API.NTFindFirst(NTCode);//����ָ��������ʶ����ļ��������������ֵΪ 0����ʾ���������ڡ�
            //�������ֵ��Ϊ0�������ͨ������ֵRtn�鿴�������
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
            HardwareID = new StringBuilder(32);// Ӳ�����к�
            if (!FindFirst(strNTCode, out strret)) return false;//throw new Exception(strret);
            if (!Login(strNTpassword, out strret)) return false;//throw new Exception(strret);
            if (!Read(10, 9, pBuffer, out strret)) return false;//throw new Exception(strret);

            
            Rtn = NT77API.NTGetHardwareID(HardwareID);//��ȡӲ�����кţ��������ֵΪ 0����ʾ��ȡӲ�����кųɹ���
            //�������ֵ��Ϊ0�������ͨ������ֵRtn�鿴�������
            strret = GetStr(Rtn);

            if (!Logout(out strret)) return false;//throw new Exception(strret);
            //if (!pBuffer.ToString().Equals(strwrite)) return false;
            if (Rtn != 0) return false;
            return true;

        }

        private static bool Login(string NTpassword, out string strret)
        {
            //String NTpassword = this.textNTpassword.Text;// ��¼����
            Rtn = NT77API.NTLogin(NTpassword); //��¼���������������ֵΪ 0����ʾ��������¼�ɹ���
            //�������ֵ��Ϊ0�������ͨ������ֵRtn�鿴�������
            strret = GetStr(Rtn);
            return Rtn == 0 ? true : false;   
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="address">��������ȡ���ݵ���ʼλ��,�����Զ����������ȡ���ݵ���ʼλ�ã����Ϊ1024</param>
        /// <param name="Length">��������ȡ���ݵĳ��ȣ������Զ����������ȡ���ݵĳ��ȣ����Ϊ1024</param>
        /// <param name="pBuffer"></param>
        /// <param name="strret"></param>
        private static bool Write(int address, int Length, StringBuilder pBuffer, out string strret)
        {
            //int address = 0; //��������ȡ���ݵ���ʼλ��,�����Զ����������ȡ���ݵ���ʼλ�ã����Ϊ1024
            //int Length = 64; //��������ȡ���ݵĳ��ȣ������Զ����������ȡ���ݵĳ��ȣ����Ϊ1024
            //StringBuilder pBuffer = new StringBuilder(64);
            //pBuffer = pBuffer.Append(sStr);

            Rtn = NT77API.NTWrite(address, Length, pBuffer);//�洢������д�룬�������ֵΪ 0����ʾ����д��ɹ���
            //�������ֵ��Ϊ0�������ͨ������ֵRtn�鿴�������
            strret = GetStr(Rtn);
            return Rtn == 0 ? true : false;   
        }

        private static bool Read(int address, int Length, StringBuilder pBuffer, out string strret)
        {
            //int address = 0; //��������ȡ���ݵ���ʼλ��,�����Զ����������ȡ���ݵ���ʼλ�ã����Ϊ1024
            //int Length = 64;//��������ȡ���ݵĳ��ȣ������Զ����������ȡ���ݵĳ��ȣ����Ϊ1024

            //StringBuilder pBuffer = new StringBuilder(64);//�洢�����ݶ�ȡ���������ֵΪ 0����ʾ����д��ɹ���
            //�������ֵ��Ϊ0�������ͨ������ֵRtn�鿴�������

            Rtn = NT77API.NTRead(address, Length, pBuffer);
            strret = GetStr(Rtn);
            return Rtn == 0 ? true : false;   
        }

        private static bool Logout(out string strret)
        {
            Rtn = NT77API.NTLogout();
            strret = GetStr(Rtn);
            return Rtn == 0 ? true : false;   
            //�������ǳ�����NTFindFirst�ɶ�ʹ��
        }

        private static string GetStr(int ret)
        {
            string strret = "";
            switch (ret)
            {
                case 0:
                    strret = "�ɹ�";
                    break;
                case 1:
                    strret = "δ�ҵ���ϵͳ��ekey";
                    break;
                case 2:
                    strret = "�������Ϸ�";
                    break;
                case 9:
                    strret = "��ЧKey���";
                    break;
                case 16:
                    strret = "HIDд��������";
                    break;
                case 19:
                    strret = "��ʼ��ʧ��";
                    break;
                case 20:
                    strret = "�����ekey���µ�¼";
                    break;
                case 21:
                    strret = "�����ekey���µ�¼";
                    break;
                case 25:
                    strret = "Ȩ�޲���";
                    break;
                case 29:
                    strret = "HID������ʧ��";
                    break;
                case 32:
                    strret = "ekey������";
                    break;
                case 33:
                    strret = "��¼�������";
                    break;
                case 35:
                    strret = "HID������ʧ��";
                    break;
                case 39:
                    strret = "��¼���벻�Ϸ�";
                    break;
                case 41:
                    strret = "�����������";
                    break;
                case 43:
                    strret = "�������벻�Ϸ�";
                    break;
                case 44:
                    strret = "���������ʽ����";
                    break;
                case 45:
                    strret = "�������벻�Ϸ�";
                    break;
                case 47:
                    strret = "��¼�����ʽ����";
                    break;
                case 49:
                    strret = "ekeyδ��¼";
                    break;
                case 74:
                    strret = "ekey������";
                    break;
                case 77:
                    strret = "�����������";
                    break;
                case 78:
                    strret = "�����������";
                    break;
                case 81:
                    strret = "��¼ekeyʧ��";
                    break;
                case 82:
                    strret = "Ȩ�޲���";
                    break;
                case 85:
                    strret = "��ֻ������д����ʧ��";
                    break;
                case 86:
                    strret = "δ֪����";
                    break;
                default:
                    return "δ֪����";

            }
            return strret;
        }
    }
}
