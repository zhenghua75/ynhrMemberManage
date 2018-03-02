using System;
using System.Runtime.InteropServices;

namespace ynhrMemberManage.CardCommon.CardDef
{
	/// <summary>
	/// RDDef ��ժҪ˵����
	/// </summary>
	public class RDDef
	{
		public RDDef()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}

		#region �豸����
		public int icdev ; // ͨѶ�豸��ʶ��
		public int st; //����ֵ
		[DllImport("Mwic_32.dll", EntryPoint="auto_init",  SetLastError=true,
			 CharSet=CharSet.Auto , ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//˵������ʼ��ͨѶ�ӿ�
		public static extern int auto_init(Int16 port, int baud);

		[DllImport("Mwic_32.dll", EntryPoint="ic_init",  SetLastError=true,
			 CharSet=CharSet.Auto , ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//˵������ʼ��ͨѶ�ӿ�
		public static extern int ic_init(Int16 port, int baud);

		[DllImport("Mwic_32.dll", EntryPoint="get_status",  SetLastError=true,
			 CharSet=CharSet.Auto , ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//˵���������豸��ǰ״̬
		public static extern Int16 get_status(int icdev,[MarshalAs(UnmanagedType.LPArray)]byte[] state);

		[DllImport("Mwic_32.dll", EntryPoint="set_baud",  SetLastError=true,
			 CharSet=CharSet.Auto, ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//˵�������ô��ڷ�ʽ�µĲ����ʻ򲢿ڵ�ͨѶ��ʽ
		public static extern Int16 set_baud(int icdev, int _b);

		[DllImport("Mwic_32.dll", EntryPoint="chk_baud",  SetLastError=true,
			 CharSet=CharSet.Auto, ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//˵�������ô��ڷ�ʽ�µĲ����ʻ򲢿ڵ�ͨѶ��ʽ
		public static extern Int16 chk_baud(Int16 port);

		[DllImport("Mwic_32.dll", EntryPoint="cmp_dvsc",  SetLastError=true,
			 CharSet=CharSet.Auto, ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//˵�����Ƚ��豸����
		public static extern Int16 cmp_dvsc(int icdev,int length,[MarshalAs(UnmanagedType.LPArray)]byte[] databuffer);
		
		[DllImport("Mwic_32.dll", EntryPoint="srd_dvsc",  SetLastError=true,
			 CharSet=CharSet.Auto, ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//˵���������豸����
		public static extern Int16 srd_dvsc(int icdev,int length,[MarshalAs(UnmanagedType.LPArray)]byte[] databuffer);

		[DllImport("Mwic_32.dll", EntryPoint="swr_dvsc",  SetLastError=true,
			 CharSet=CharSet.Auto, ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//˵������д�豸����
		public static extern Int16 swr_dvsc(int icdev,int length,[MarshalAs(UnmanagedType.LPArray)]byte[] databuffer);

		[DllImport("Mwic_32.dll", EntryPoint="setsc_md",  SetLastError=true,
			 CharSet=CharSet.Auto, ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//˵���������豸����ģʽ�����豸�����Ƿ���Ч
		public static extern Int16 setsc_md(int icdev,int mode);

		[DllImport("Mwic_32.dll", EntryPoint="turn_on",  SetLastError=true,
			 CharSet=CharSet.Auto, ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//˵�����Կ��ϵ�
		public static extern Int16 turn_on(int icdev);

		[DllImport("Mwic_32.dll", EntryPoint="turn_off",  SetLastError=true,
			 CharSet=CharSet.Auto, ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//˵�����Կ��µ�
		public static extern Int16 turn_off(int icdev);

		[DllImport("Mwic_32.dll", EntryPoint="srd_ver",  SetLastError=true,
			 CharSet=CharSet.Auto, ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//˵������ȡ�豸�汾��
		public static extern Int16 srd_ver(int icdev,int length,[MarshalAs(UnmanagedType.LPArray)]byte[] databuffer);

		[DllImport("Mwic_32.dll", EntryPoint="auto_pull",  SetLastError=true,
			 CharSet=CharSet.Auto, ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//˵�����Զ�������ֻ�������Ե�ʽ����
		public static extern Int16 auto_pull(int icdev);

		[DllImport("Mwic_32.dll", EntryPoint="dv_beep",  SetLastError=true,
			 CharSet=CharSet.Auto, ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//˵������д������
		public static extern Int16 dv_beep(int icdev,int time);

		[DllImport("Mwic_32.dll", EntryPoint="ic_exit",  SetLastError=true,
			 CharSet=CharSet.Auto, ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//˵�����ر�ͨѶ��
		public static extern Int16 ic_exit(int icdev);

		[DllImport("Mwic_32.dll", EntryPoint="lib_ver",  SetLastError=true,
			 CharSet=CharSet.Auto, ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//˵������������汾��
		public static extern Int16 lib_ver([MarshalAs(UnmanagedType.LPArray)]byte[] databuffer);

		[DllImport("Mwic_32.dll", EntryPoint="srd_eeprom",  SetLastError=true,
			 CharSet=CharSet.Auto, ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//˵�������豸��ע�����ܳ�384�ֽڣ�
		public static extern Int16 srd_eeprom(int icdev, int offset, int len, [MarshalAs(UnmanagedType.LPArray)]byte[] databuff);

		[DllImport("Mwic_32.dll", EntryPoint="srd_snr",  SetLastError=true,
			 CharSet=CharSet.Auto, ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//˵���������豸��ʶ��
		public static extern Int16 srd_snr(int icdev,int length,[MarshalAs(UnmanagedType.LPArray)]byte[] databuffer);

		[DllImport("Mwic_32.dll", EntryPoint="val_read",  SetLastError=true,
			 CharSet=CharSet.Auto, ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//˵������ȡ�豸����ֵ
		public static extern Int16 val_read(int icdev,out uint snr);
		#endregion

		#region 4442������
		[DllImport("Mwic_32.dll", EntryPoint="chk_4442",  SetLastError=true,
			 CharSet=CharSet.Auto, ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//˵������鿨���Ƿ���ȷ
		public static extern Int16 chk_4442(int icdev);

		[DllImport("Mwic_32.dll", EntryPoint="csc_4442",  SetLastError=true,
			 CharSet=CharSet.Auto, ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//˵�����˶Կ�����
		public static extern Int16 csc_4442(int icdev,int length,[MarshalAs(UnmanagedType.LPArray)]byte[] databuffer);

		[DllImport("Mwic_32.dll", EntryPoint="prd_4442",  SetLastError=true,
			 CharSet=CharSet.Auto, ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//˵����������λ
		public static extern Int16 prd_4442(int icdev,int length,[MarshalAs(UnmanagedType.LPArray)]byte[] databuffer);

		[DllImport("Mwic_32.dll", EntryPoint="pwr_4442",  SetLastError=true,
			 CharSet=CharSet.Auto, ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//˵��������ָ����ַ������
		public static extern Int16 pwr_4442(int icdev, int offset, int len, [MarshalAs(UnmanagedType.LPArray)]byte[] databuff);

		[DllImport("Mwic_32.dll", EntryPoint="rsc_4442",  SetLastError=true,
			 CharSet=CharSet.Auto, ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//˵��������������
		public static extern Int16 rsc_4442(int icdev,int length,[MarshalAs(UnmanagedType.LPArray)]byte[] databuffer);

		[DllImport("Mwic_32.dll", EntryPoint="rsct_4442",  SetLastError=true,
			 CharSet=CharSet.Auto, ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//˵��������������������ֵ
		public static extern Int16 rsct_4442(int icdev,out Int16 counter);

		[DllImport("Mwic_32.dll", EntryPoint="srd_4442",  SetLastError=true,
			 CharSet=CharSet.Auto, ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//˵������ָ����ַ������
		public static extern Int16 srd_4442(int icdev, int offset, int len, [MarshalAs(UnmanagedType.LPArray)]byte[] databuff);

		[DllImport("Mwic_32.dll", EntryPoint="swr_4442",  SetLastError=true,
			 CharSet=CharSet.Auto, ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//˵������ָ����ַд����
		public static extern Int16 swr_4442(int icdev, int offset, int len, [MarshalAs(UnmanagedType.LPArray)]byte[] databuff);

		[DllImport("Mwic_32.dll", EntryPoint="wsc_4442",  SetLastError=true,
			 CharSet=CharSet.Auto, ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
			//˵������д������
		public static extern Int16 wsc_4442(int icdev, int len, [MarshalAs(UnmanagedType.LPArray)]byte[] databuff);
		#endregion
	}
}
