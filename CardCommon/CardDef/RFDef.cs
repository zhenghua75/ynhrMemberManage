using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ynhrMemberManage.CardCommon.CardDef
{
	/// <summary>
	/// RFDef 的摘要说明。
	/// </summary>
	public class RFDef
	{
		public RFDef()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		#region 设备操作
		public int icdev ; // 通讯设备标识符
		public int st; //返回值
		[DllImport("mwrf32.dll", EntryPoint="rf_init",  SetLastError=true,
			 CharSet=CharSet.Auto , ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//说明：初始化通讯接口
		public static extern int rf_init(Int16 port, int baud);

		[DllImport("mwrf32.dll", EntryPoint="rf_exit",  SetLastError=true,
			 CharSet=CharSet.Auto, ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//说明：    关闭通讯口
		public static extern Int16 rf_exit(int icdev);

		[DllImport("mwrf32.dll", EntryPoint="rf_get_status",  SetLastError=true,
			 CharSet=CharSet.Auto, ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//说明：     返回设备当前状态
		public static extern Int16 rf_get_status(int icdev,[MarshalAs(UnmanagedType.LPArray)]byte[] state);

		[DllImport("mwrf32.dll", EntryPoint="rf_beep",  SetLastError=true,
			 CharSet=CharSet.Auto, ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//说明：     返回设备当前状态
		public static extern Int16 rf_beep(int icdev,int msec);

		[DllImport("mwrf32.dll", EntryPoint="rf_load_key",  SetLastError=true,
			 CharSet=CharSet.Auto, ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//说明：     返回设备当前状态
		public static extern Int16 rf_load_key(int icdev,int mode, int secnr,[MarshalAs(UnmanagedType.LPArray)]byte[] keybuff );

		[DllImport("mwrf32.dll", EntryPoint="rf_load_key_hex",  SetLastError=true,
			 CharSet=CharSet.Auto, ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//说明：     返回设备当前状态
		public static extern Int16 rf_load_key_hex(int icdev,int mode, int secnr,[MarshalAs(UnmanagedType.LPArray)]byte[] keybuff );


		[DllImport("mwrf32.dll", EntryPoint="a_hex",  SetLastError=true,
			 CharSet=CharSet.Auto, ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//说明：     返回设备当前状态
		public static extern Int16 a_hex([MarshalAs(UnmanagedType.LPArray)]byte[] asc,[MarshalAs(UnmanagedType.LPArray)]byte[] hex, int len );

		[DllImport("mwrf32.dll", EntryPoint="hex_a",  SetLastError=true,
			 CharSet=CharSet.Auto, ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//说明：     返回设备当前状态
		public static extern Int16 hex_a([MarshalAs(UnmanagedType.LPArray)]byte[] hex,[MarshalAs(UnmanagedType.LPArray)]byte[] asc, int len );
		
		[DllImport("mwrf32.dll", EntryPoint="rf_reset",  SetLastError=true,
			 CharSet=CharSet.Auto, ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//说明：     返回设备当前状态
		public static extern Int16 rf_reset(int icdev, int msec);
		
		[DllImport("mwrf32.dll", EntryPoint="rf_clr_control_bit",  SetLastError=true,
			 CharSet=CharSet.Auto, ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//说明：     返回设备当前状态
		public static extern Int16 rf_clr_control_bit(int icdev,int _b);
		
		[DllImport("mwrf32.dll", EntryPoint="rf_set_control_bit",  SetLastError=true,
			 CharSet=CharSet.Auto, ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//说明：     返回设备当前状态
		public static extern Int16 rf_set_control_bit(int icdev, int _b);
		
		[DllImport("mwrf32.dll", EntryPoint="rf_disp8",  SetLastError=true,
			 CharSet=CharSet.Auto, ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//说明：     返回设备当前状态
		public static extern Int16 rf_disp8(int icdev, short mode, [MarshalAs(UnmanagedType.LPArray)]byte[] disp);
		
		[DllImport("mwrf32.dll", EntryPoint="rf_disp",  SetLastError=true,
			 CharSet=CharSet.Auto, ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//说明：     返回设备当前状态
		public static extern Int16 rf_disp(int icdev,short mode, int digit);
		
		[DllImport("mwrf32.dll", EntryPoint="rf_encrypt",  SetLastError=true,
			 CharSet=CharSet.Auto, ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//说明：     返回设备当前状态
		public static extern Int16 rf_encrypt([MarshalAs(UnmanagedType.LPArray)]byte[] key,[MarshalAs(UnmanagedType.LPArray)]byte[] ptrsource, int len,[MarshalAs(UnmanagedType.LPArray)]byte[] ptrdest);
		
		[DllImport("mwrf32.dll", EntryPoint="rf_decrypt",  SetLastError=true,
			 CharSet=CharSet.Auto, ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//说明：     返回设备当前状态
		public static extern Int16 rf_decrypt([MarshalAs(UnmanagedType.LPArray)]byte[] key,[MarshalAs(UnmanagedType.LPArray)]byte[] ptrsource, int len,[MarshalAs(UnmanagedType.LPArray)]byte[] ptrdest);
		
		[DllImport("mwrf32.dll", EntryPoint="rf_srd_eeprom",  SetLastError=true,
			 CharSet=CharSet.Auto, ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//说明：     返回设备当前状态
		public static extern Int16 rf_srd_eeprom(int icdev, int offset, int len, [MarshalAs(UnmanagedType.LPArray)]byte[] databuff);
		
		[DllImport("mwrf32.dll", EntryPoint="rf_swr_eeprom",  SetLastError=true,
			 CharSet=CharSet.Auto, ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//说明：     返回设备当前状态
		public static extern Int16 rf_swr_eeprom(int icdev, int offset, int len, [MarshalAs(UnmanagedType.LPArray)]byte[] databuff);
		
		[DllImport("mwrf32.dll", EntryPoint="rf_setport",  SetLastError=true,
			 CharSet=CharSet.Auto, ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//说明：     返回设备当前状态
		public static extern Int16 rf_setport(int icdev, byte _byte);
		
		[DllImport("mwrf32.dll", EntryPoint="rf_getport",  SetLastError=true,
			 CharSet=CharSet.Auto, ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//说明：     返回设备当前状态
		public static extern Int16 rf_getport(int icdev,  out byte _byte);
		
		[DllImport("mwrf32.dll", EntryPoint="rf_gettime",  SetLastError=true,
			 CharSet=CharSet.Auto, ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//说明：     返回设备当前状态
		public static extern Int16 rf_gettime(int icdev, [MarshalAs(UnmanagedType.LPArray)]byte[] time);
		
		
		[DllImport("mwrf32.dll", EntryPoint="rf_gettime_hex",  SetLastError=true,
			 CharSet=CharSet.Auto, ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//说明：     返回设备当前状态
		public static extern Int16 rf_gettime_hex(int icdev, [MarshalAs(UnmanagedType.LPArray)]byte[] time);

		[DllImport("mwrf32.dll", EntryPoint="rf_settime_hex",  SetLastError=true,
			 CharSet=CharSet.Auto, ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//说明：     返回设备当前状态
		public static extern Int16 rf_settime_hex(int icdev, [MarshalAs(UnmanagedType.LPArray)]byte[] time);

		[DllImport("mwrf32.dll", EntryPoint="rf_settime",  SetLastError=true,
			 CharSet=CharSet.Auto, ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//说明：     返回设备当前状态
		public static extern Int16 rf_settime(int icdev, [MarshalAs(UnmanagedType.LPArray)]byte[] time);

		[DllImport("mwrf32.dll", EntryPoint=" rf_setbright",  SetLastError=true,
			 CharSet=CharSet.Auto, ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//说明：     返回设备当前状态
		public static extern Int16  rf_setbright(int icdev, byte bright);

		[DllImport("mwrf32.dll", EntryPoint="rf_ctl_mode",  SetLastError=true,
			 CharSet=CharSet.Auto, ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//说明：     返回设备当前状态
		public static extern Int16 rf_ctl_mode(int icdev, int mode);

		[DllImport("mwrf32.dll", EntryPoint="rf_disp_mode",  SetLastError=true,
			 CharSet=CharSet.Auto, ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//说明：     返回设备当前状态
		public static extern Int16 rf_disp_mode(int icdev, int mode);

		[DllImport("mwrf32.dll", EntryPoint="lib_ver",  SetLastError=true,
			 CharSet=CharSet.Auto, ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//说明：     返回设备当前状态
		public static extern Int16 lib_ver([MarshalAs(UnmanagedType.LPArray)]byte[] ver);
		#endregion

		#region M1卡操作
		[DllImport("mwrf32.dll", EntryPoint="rf_request",  SetLastError=true,
			 CharSet=CharSet.Auto, ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//说明：     返回设备当前状态
		public static extern Int16 rf_request(int icdev, int mode, out UInt16 tagtype);
		
		[DllImport("mwrf32.dll", EntryPoint="rf_request_std",  SetLastError=true,
			 CharSet=CharSet.Auto, ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//说明：     返回设备当前状态
		public static extern Int16 rf_request_std(int icdev, int mode, out UInt16 tagtype);

		[DllImport("mwrf32.dll", EntryPoint="rf_anticoll",  SetLastError=true,
			 CharSet=CharSet.Auto, ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//说明：     返回设备当前状态
		public static extern Int16 rf_anticoll(int icdev, int bcnt,out uint snr);

		[DllImport("mwrf32.dll", EntryPoint="rf_select",  SetLastError=true,
			 CharSet=CharSet.Auto, ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//说明：     返回设备当前状态
		public static extern Int16 rf_select(int icdev, uint snr,out byte size);

		[DllImport("mwrf32.dll", EntryPoint="rf_authentication",  SetLastError=true,
			 CharSet=CharSet.Auto, ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//说明：     返回设备当前状态
		public static extern Int16 rf_authentication(int icdev, int mode,int secnr);

		[DllImport("mwrf32.dll", EntryPoint="rf_authentication_2",  SetLastError=true,
			 CharSet=CharSet.Auto, ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//说明：     返回设备当前状态
		public static extern Int16 rf_authentication_2(int icdev, int mode,int keynr,int blocknr);

		[DllImport("mwrf32.dll", EntryPoint="rf_read",  SetLastError=true,
			 CharSet=CharSet.Auto, ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//说明：     返回设备当前状态
		public static extern Int16 rf_read(int icdev,int blocknr, [MarshalAs(UnmanagedType.LPArray)]byte[] databuff);

		[DllImport("mwrf32.dll", EntryPoint="rf_read_hex",  SetLastError=true,
			 CharSet=CharSet.Auto, ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//说明：     返回设备当前状态
		public static extern Int16 rf_read_hex(int icdev,int blocknr, [MarshalAs(UnmanagedType.LPArray)]byte[] databuff);

		[DllImport("mwrf32.dll", EntryPoint="rf_write_hex",  SetLastError=true,
			 CharSet=CharSet.Auto, ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//说明：     返回设备当前状态
		public static extern Int16 rf_write_hex(int icdev,int blocknr, [MarshalAs(UnmanagedType.LPArray)]byte[] databuff);

		[DllImport("mwrf32.dll", EntryPoint="rf_write",  SetLastError=true,
			 CharSet=CharSet.Auto, ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//说明：     返回设备当前状态
		public static extern Int16 rf_write(int icdev, int blocknr, [MarshalAs(UnmanagedType.LPArray)]byte[] databuff);

		[DllImport("mwrf32.dll", EntryPoint="rf_halt",  SetLastError=true,
			 CharSet=CharSet.Auto, ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//说明：     返回设备当前状态
		public static extern Int16 rf_halt(int icdev);

		[DllImport("mwrf32.dll", EntryPoint="rf_initval",  SetLastError=true,
			 CharSet=CharSet.Auto, ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//说明：     返回设备当前状态
		public static extern Int16 rf_initval(int icdev,int blocknr, uint val);

		[DllImport("mwrf32.dll", EntryPoint="rf_readval",  SetLastError=true,
			 CharSet=CharSet.Auto, ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//说明：     返回设备当前状态
		public static extern Int16 rf_readval(int icdev,int blocknr, out uint val);

		[DllImport("mwrf32.dll", EntryPoint="rf_increment",  SetLastError=true,
			 CharSet=CharSet.Auto, ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//说明：     返回设备当前状态
		public static extern Int16 rf_increment(int icdev,int blocknr, uint val);

		[DllImport("mwrf32.dll", EntryPoint="rf_decrement",  SetLastError=true,
			 CharSet=CharSet.Auto, ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//说明：     返回设备当前状态
		public static extern Int16 rf_decrement(int icdev,int blocknr,uint val);

		[DllImport("mwrf32.dll", EntryPoint="rf_restore",  SetLastError=true,
			 CharSet=CharSet.Auto, ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//说明：     返回设备当前状态
		public static extern Int16 rf_restore(int icdev,int blocknr);

		[DllImport("mwrf32.dll", EntryPoint="rf_transfer",  SetLastError=true,
			 CharSet=CharSet.Auto, ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//说明：     返回设备当前状态
		public static extern Int16 rf_transfer(int icdev,int blocknr);

		[DllImport("mwrf32.dll", EntryPoint="rf_changeb3",  SetLastError=true,
			 CharSet=CharSet.Auto, ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//说明：     返回设备当前状态
		public static extern Int16 rf_changeb3(int icdev,int secnr,[MarshalAs(UnmanagedType.LPArray)]byte[] akeybuff,int B0,int B1,int B2,int B3,int Bk,[MarshalAs(UnmanagedType.LPArray)]byte[] bkeybuff);
		#endregion


        [DllImport("ekey.dll", EntryPoint = "GetEkeySN", SetLastError = true,
             CharSet = CharSet.Auto, ExactSpelling = false,
             CallingConvention = CallingConvention.StdCall)]
        //说明：     返回设备当前状态
        public static extern string GetEkeySN([MarshalAs(UnmanagedType.LPArray)]byte[] databuff);

        [DllImport("ekey.dll", EntryPoint = "PutOut", SetLastError = true,
             CharSet = CharSet.Auto, ExactSpelling = false,
             CallingConvention = CallingConvention.StdCall)]
        //说明：     返回设备当前状态
        public static extern string PutOut([MarshalAs(UnmanagedType.LPArray)]char[] databuff);

        [DllImport("ekey.dll", EntryPoint = "Verify", SetLastError = true,
             CharSet = CharSet.Ansi, ExactSpelling = false,
             CallingConvention = CallingConvention.StdCall)]
        //说明：     返回设备当前状态
        public static extern StringBuilder Verify([MarshalAs(UnmanagedType.LPStr)]StringBuilder databuff);

	}
}
