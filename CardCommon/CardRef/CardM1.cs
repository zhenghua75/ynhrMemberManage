using System;
using System.Text;
using ynhrMemberManage.CardCommon.CardDef;

namespace ynhrMemberManage.CardCommon.CardRef
{
	/// <summary>
	/// CardM1 的摘要说明。
	/// </summary>
	public class CardM1
	{
		public int icdev ; // 通讯设备标识符
		public Int16 st; //返回值
		public int sec; //扇区
		public Int16 port; //端口
		public int baud; //波特率
        private UInt16 tagtype = 0;
        private byte size = 0;
        private uint snr = 0;
        private string stroldakey = "123456789012";
        private string stroldbkey = "123456789012";
        private string strakey = "123456789012";
        private string strbkey = "123456789012";
        private string strbkey2 = "123456789012";
        private string strbkey3 = "123456789012";
		public CardM1()
		{
			port=0;
			baud=9600;
			sec=1;
			st=0;
		}
        private bool FindCard(out string ret)
        {
            //初始化
            icdev = RFDef.rf_init(port, baud);
            if (icdev < 0)
            {				
                quit();
                ret = ConstMsg.RFINITERR;
                return false;
            }

            //寻卡
            RFDef.rf_reset(icdev, 10);
            st = RFDef.rf_request(icdev, 1, out tagtype);
            if (st != 0)
            {
                quit();
                ret = ConstMsg.RFREQUESTERR;
                return false;
            }

            st = RFDef.rf_anticoll(icdev, 0, out snr);
            if (st != 0)
            {
                quit();
                ret = ConstMsg.RFANTICOLLERR;
                return false;
            }

            st = RFDef.rf_select(icdev, snr, out size);
            if (st != 0)
            {
                quit();
                ret = ConstMsg.RFSELECTERR;
                return false;
            }
            ret = ConstMsg.RFOK;
            return true;
        }
        private bool VerifyOldAKey(out string ret)
        {
            //验证
            byte[] akey1 = new byte[16];
            byte[] akey2 = new byte[6];

            akey1 = Encoding.ASCII.GetBytes(stroldakey);
            RFDef.a_hex(akey1, akey2, 12);
            st = RFDef.rf_load_key(icdev, 0, sec, akey2);
            if (st != 0)
            {
                quit();
                ret = ConstMsg.RFLOADKEY_A_ERR;
                return false;
            }
            st = RFDef.rf_authentication(icdev, 0, sec);
            if (st != 0)
            {
                quit();
                ret = ConstMsg.RFAUTHENTICATION_A_ERR;
                return false;
            }
            ret = ConstMsg.RFOK;
            return true;
        }

        private bool VerifyBKey(out string ret)
        {
            byte[] bkey1 = new byte[16];
            byte[] bkey2 = new byte[6];
            bkey1 = Encoding.ASCII.GetBytes(strbkey);
            RFDef.a_hex(bkey1, bkey2, 12);
            st = RFDef.rf_load_key(icdev, 4, sec, bkey2);
            if (st != 0)
            {
                quit();
                ret = ConstMsg.RFLOADKEY_B_ERR;
                return false;

            }
            st = RFDef.rf_authentication(icdev, 4, sec);
            if (st != 0)
            {
                //验证失败只能从头再来
                quit();
                ret = ConstMsg.RFAUTHENTICATION_B_ERR;
                return false;
            }
            ret = ConstMsg.RFOK;
            return true;
        }
        private bool VerifyBKey2(out string ret)
        {
            byte[] bkey1 = new byte[16];
            byte[] bkey2 = new byte[6];
            bkey1 = Encoding.ASCII.GetBytes(strbkey2);
            RFDef.a_hex(bkey1, bkey2, 12);
            st = RFDef.rf_load_key(icdev, 4, sec, bkey2);
            if (st != 0)
            {
                quit();
                ret = ConstMsg.RFLOADKEY_B_ERR;
                return false;

            }
            st = RFDef.rf_authentication(icdev, 4, sec);
            if (st != 0)
            {
                //验证失败只能从头再来
                quit();
                ret = ConstMsg.RFAUTHENTICATION_B_ERR;
                return false;
            }
            ret = ConstMsg.RFOK;
            return true;
        }
        private bool VerifyBKey3(out string ret)
        {
            byte[] bkey1 = new byte[16];
            byte[] bkey2 = new byte[6];
            bkey1 = Encoding.ASCII.GetBytes(strbkey3);
            RFDef.a_hex(bkey1, bkey2, 12);
            st = RFDef.rf_load_key(icdev, 4, sec, bkey2);
            if (st != 0)
            {
                quit();
                ret = ConstMsg.RFLOADKEY_B_ERR;
                return false;

            }
            st = RFDef.rf_authentication(icdev, 4, sec);
            if (st != 0)
            {
                //验证失败只能从头再来
                quit();
                ret = ConstMsg.RFAUTHENTICATION_B_ERR;
                return false;
            }
            ret = ConstMsg.RFOK;
            return true;
        }
        
        private bool WriteCardNo(out string ret,string strCardID)
        {
            //写卡号
            byte[] databuff = new byte[16];
            byte[] buff = new byte[32];
            string data = strCardID.PadRight(32, '0');
            buff = Encoding.ASCII.GetBytes(data);
            RFDef.a_hex(buff, databuff, 32);
            st = RFDef.rf_write(icdev, sec * 4, databuff);
            if (st != 0)
            {
                quit();
                ret = ConstMsg.RFWRITEERR;
                return false;
            }
            ret = ConstMsg.RFOK;
            return true;
        }
        private bool ChangePwd(out string ret)
        {
            //改密码
            byte[] akey1 = new byte[16];
            byte[] akey2 = new byte[6];
            byte[] bkey1 = new byte[16];
            byte[] bkey2 = new byte[6];
            akey1 = Encoding.ASCII.GetBytes(strakey);
            bkey1 = Encoding.ASCII.GetBytes(strbkey);
            RFDef.a_hex(akey1, akey2, 12);
            RFDef.a_hex(bkey1, bkey2, 12);
            st = RFDef.rf_changeb3(icdev, sec, akey2, 3, 3, 3, 3, 0, bkey2);
            if (st != 0)
            {
                quit();
                ret = ConstMsg.RFCHANGEB3ERR;
                return false;
            }
            ret = ConstMsg.RFOK;
            return true;
        }
        
		#region 发卡
		public string PutOutCard(string strCardID)
		{
            string ret = "";            
            if (!FindCard(out ret)) return ret;

            if (!VerifyOldAKey(out ret)) return ret;
            if (!WriteCardNo(out ret,strCardID)) return ret;			
			if(!ChangePwd(out ret)) return ret;
			//蜂鸣
			st = RFDef.rf_beep(icdev,3);
			quit();
			return ConstMsg.RFOK;
		}
		#endregion

		#region 刷卡
		public string ReadCard(out string strCardID)//,out double dCurCharge,out int iCurIg)
		{
#if DEBUG
            strCardID = "000174";
            return ConstMsg.RFOK;
#endif
            strCardID ="";
            string ret = "";
            int i = 0;
            byte[] databuff = new byte[16];
            byte[] buff = new byte[32];

            for (i = 0; i < 16; i++)
                databuff[i] = 0;
            for (i = 0; i < 32; i++)
                buff[i] = 0;
            if (!FindCard(out ret)) return ret;
            if (!VerifyBKey(out ret))
            {
                if (!FindCard(out ret)) return ret;
                if (!VerifyBKey2(out ret)) //return ret;
                {
                    if (!FindCard(out ret)) return ret;
                    if (!VerifyBKey3(out ret)) return ret;
                }
            }
            //读卡号
            st = RFDef.rf_read(icdev, sec * 4, databuff);
            if (st != 0)
            {
                quit();
                return ConstMsg.RFREADERR;
            }
            else
            {
                RFDef.hex_a(databuff, buff, 16);
                string strtemp = System.Text.Encoding.ASCII.GetString(buff);
                strtemp = strtemp.ToLower();
                if (strtemp.StartsWith("aaa"))
                    strCardID = strtemp.Substring(0, 8);
                else if (strtemp.StartsWith("bbb"))
                    strCardID = strtemp.Substring(3, 8);
                else
                    strCardID = strtemp.Substring(0, 6);
            }
            
			//蜂鸣
			st = RFDef.rf_beep(icdev,3);
			quit();
			return ConstMsg.RFOK;
		}
		#endregion

		#region 卡回收
		public string RecycleCard()
		{
            string ret = "";
            if (!FindCard(out ret)) return ret;
            if (!VerifyBKey(out ret)) //return ret;
            {
                quit();
                if (!FindCard(out ret)) return ret;
                if (!VerifyBKey2(out ret)) return ret;
            }
			//原始化卡号信息
			byte[] databuff=new byte[16];
			byte[] buff=new byte[32];
			
			string data="00000000000000000000000000000000";
			buff=Encoding.ASCII.GetBytes(data);
			RFDef.a_hex(buff,databuff,32);
			st = RFDef.rf_write(icdev,sec*4,databuff);
			if(st!=0)
			{
				quit();
				return ConstMsg.RFWRITEERR;
			}
			
			//改密码
			byte[] akey1=new byte[16];
			byte[] akey2=new byte[6];
            byte[] bkey1 = new byte[16];
            byte[] bkey2 = new byte[6];
			akey1=Encoding.ASCII.GetBytes(stroldakey);
			bkey1=Encoding.ASCII.GetBytes(stroldbkey);
			RFDef.a_hex(akey1,akey2,12);
			RFDef.a_hex(bkey1,bkey2,12);
			st = RFDef.rf_changeb3(icdev,sec,akey2,0,0,0,1,0,bkey2);
			if(st!=0)
			{
				quit();
				return ConstMsg.RFCHANGEB3ERR;
			}

			//蜂鸣
			st = RFDef.rf_beep(icdev,3);
			quit();
			return ConstMsg.RFOK;
		}
		#endregion

		#region 关闭读卡器
		public void quit()
		{
			st=0;
			RFDef.rf_reset(icdev,10);
			st=RFDef.rf_exit(icdev);
			icdev=-1;
		}
		#endregion

	}
}
