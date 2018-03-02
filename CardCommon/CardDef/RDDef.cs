using System;
using System.Runtime.InteropServices;

namespace ynhrMemberManage.CardCommon.CardDef
{
	/// <summary>
	/// RDDef 的摘要说明。
	/// </summary>
	public class RDDef
	{
		public RDDef()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		#region 设备操作
		public int icdev ; // 通讯设备标识符
		public int st; //返回值
		[DllImport("Mwic_32.dll", EntryPoint="auto_init",  SetLastError=true,
			 CharSet=CharSet.Auto , ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//说明：初始化通讯接口
		public static extern int auto_init(Int16 port, int baud);

		[DllImport("Mwic_32.dll", EntryPoint="ic_init",  SetLastError=true,
			 CharSet=CharSet.Auto , ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//说明：初始化通讯接口
		public static extern int ic_init(Int16 port, int baud);

		[DllImport("Mwic_32.dll", EntryPoint="get_status",  SetLastError=true,
			 CharSet=CharSet.Auto , ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//说明：返回设备当前状态
		public static extern Int16 get_status(int icdev,[MarshalAs(UnmanagedType.LPArray)]byte[] state);

		[DllImport("Mwic_32.dll", EntryPoint="set_baud",  SetLastError=true,
			 CharSet=CharSet.Auto, ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//说明：设置串口方式下的波特率或并口的通讯方式
		public static extern Int16 set_baud(int icdev, int _b);

		[DllImport("Mwic_32.dll", EntryPoint="chk_baud",  SetLastError=true,
			 CharSet=CharSet.Auto, ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//说明：设置串口方式下的波特率或并口的通讯方式
		public static extern Int16 chk_baud(Int16 port);

		[DllImport("Mwic_32.dll", EntryPoint="cmp_dvsc",  SetLastError=true,
			 CharSet=CharSet.Auto, ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//说明：比较设备密码
		public static extern Int16 cmp_dvsc(int icdev,int length,[MarshalAs(UnmanagedType.LPArray)]byte[] databuffer);
		
		[DllImport("Mwic_32.dll", EntryPoint="srd_dvsc",  SetLastError=true,
			 CharSet=CharSet.Auto, ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//说明：读出设备密码
		public static extern Int16 srd_dvsc(int icdev,int length,[MarshalAs(UnmanagedType.LPArray)]byte[] databuffer);

		[DllImport("Mwic_32.dll", EntryPoint="swr_dvsc",  SetLastError=true,
			 CharSet=CharSet.Auto, ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//说明：改写设备密码
		public static extern Int16 swr_dvsc(int icdev,int length,[MarshalAs(UnmanagedType.LPArray)]byte[] databuffer);

		[DllImport("Mwic_32.dll", EntryPoint="setsc_md",  SetLastError=true,
			 CharSet=CharSet.Auto, ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//说明：设置设备密码模式，即设备密码是否有效
		public static extern Int16 setsc_md(int icdev,int mode);

		[DllImport("Mwic_32.dll", EntryPoint="turn_on",  SetLastError=true,
			 CharSet=CharSet.Auto, ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//说明：对卡上电
		public static extern Int16 turn_on(int icdev);

		[DllImport("Mwic_32.dll", EntryPoint="turn_off",  SetLastError=true,
			 CharSet=CharSet.Auto, ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//说明：对卡下电
		public static extern Int16 turn_off(int icdev);

		[DllImport("Mwic_32.dll", EntryPoint="srd_ver",  SetLastError=true,
			 CharSet=CharSet.Auto, ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//说明：读取设备版本号
		public static extern Int16 srd_ver(int icdev,int length,[MarshalAs(UnmanagedType.LPArray)]byte[] databuffer);

		[DllImport("Mwic_32.dll", EntryPoint="auto_pull",  SetLastError=true,
			 CharSet=CharSet.Auto, ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//说明：自动弹卡，只适用于自弹式卡座
		public static extern Int16 auto_pull(int icdev);

		[DllImport("Mwic_32.dll", EntryPoint="dv_beep",  SetLastError=true,
			 CharSet=CharSet.Auto, ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//说明：读写器蜂鸣
		public static extern Int16 dv_beep(int icdev,int time);

		[DllImport("Mwic_32.dll", EntryPoint="ic_exit",  SetLastError=true,
			 CharSet=CharSet.Auto, ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//说明：关闭通讯口
		public static extern Int16 ic_exit(int icdev);

		[DllImport("Mwic_32.dll", EntryPoint="lib_ver",  SetLastError=true,
			 CharSet=CharSet.Auto, ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//说明：读函数库版本号
		public static extern Int16 lib_ver([MarshalAs(UnmanagedType.LPArray)]byte[] databuffer);

		[DllImport("Mwic_32.dll", EntryPoint="srd_eeprom",  SetLastError=true,
			 CharSet=CharSet.Auto, ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//说明：读设备备注区（总长384字节）
		public static extern Int16 srd_eeprom(int icdev, int offset, int len, [MarshalAs(UnmanagedType.LPArray)]byte[] databuff);

		[DllImport("Mwic_32.dll", EntryPoint="srd_snr",  SetLastError=true,
			 CharSet=CharSet.Auto, ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//说明：读出设备标识号
		public static extern Int16 srd_snr(int icdev,int length,[MarshalAs(UnmanagedType.LPArray)]byte[] databuffer);

		[DllImport("Mwic_32.dll", EntryPoint="val_read",  SetLastError=true,
			 CharSet=CharSet.Auto, ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//说明：读取设备计数值
		public static extern Int16 val_read(int icdev,out uint snr);
		#endregion

		#region 4442卡操作
		[DllImport("Mwic_32.dll", EntryPoint="chk_4442",  SetLastError=true,
			 CharSet=CharSet.Auto, ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//说明：检查卡型是否正确
		public static extern Int16 chk_4442(int icdev);

		[DllImport("Mwic_32.dll", EntryPoint="csc_4442",  SetLastError=true,
			 CharSet=CharSet.Auto, ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//说明：核对卡密码
		public static extern Int16 csc_4442(int icdev,int length,[MarshalAs(UnmanagedType.LPArray)]byte[] databuffer);

		[DllImport("Mwic_32.dll", EntryPoint="prd_4442",  SetLastError=true,
			 CharSet=CharSet.Auto, ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//说明：读保护位
		public static extern Int16 prd_4442(int icdev,int length,[MarshalAs(UnmanagedType.LPArray)]byte[] databuffer);

		[DllImport("Mwic_32.dll", EntryPoint="pwr_4442",  SetLastError=true,
			 CharSet=CharSet.Auto, ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//说明：保护指定地址的数据
		public static extern Int16 pwr_4442(int icdev, int offset, int len, [MarshalAs(UnmanagedType.LPArray)]byte[] databuff);

		[DllImport("Mwic_32.dll", EntryPoint="rsc_4442",  SetLastError=true,
			 CharSet=CharSet.Auto, ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//说明：读出卡密码
		public static extern Int16 rsc_4442(int icdev,int length,[MarshalAs(UnmanagedType.LPArray)]byte[] databuffer);

		[DllImport("Mwic_32.dll", EntryPoint="rsct_4442",  SetLastError=true,
			 CharSet=CharSet.Auto, ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//说明：读出密码错误计数器值
		public static extern Int16 rsct_4442(int icdev,out Int16 counter);

		[DllImport("Mwic_32.dll", EntryPoint="srd_4442",  SetLastError=true,
			 CharSet=CharSet.Auto, ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//说明：从指定地址读数据
		public static extern Int16 srd_4442(int icdev, int offset, int len, [MarshalAs(UnmanagedType.LPArray)]byte[] databuff);

		[DllImport("Mwic_32.dll", EntryPoint="swr_4442",  SetLastError=true,
			 CharSet=CharSet.Auto, ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//说明：向指定地址写数据
		public static extern Int16 swr_4442(int icdev, int offset, int len, [MarshalAs(UnmanagedType.LPArray)]byte[] databuff);

		[DllImport("Mwic_32.dll", EntryPoint="wsc_4442",  SetLastError=true,
			 CharSet=CharSet.Auto, ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//说明：改写卡密码
		public static extern Int16 wsc_4442(int icdev, int len, [MarshalAs(UnmanagedType.LPArray)]byte[] databuff);
		#endregion
	}
}
