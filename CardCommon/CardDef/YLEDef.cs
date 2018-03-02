using System;
using System.Runtime.InteropServices;

namespace ynhrMemberManage.CardCommon.CardDef
{
	/// <summary>
	/// YLEDef 的摘要说明。
	/// </summary>
	public class YLEDef
	{
		public YLEDef()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		[DllImport("YLE300_API.dll", EntryPoint="YLE300_Open",  SetLastError=true,
			 CharSet=CharSet.Auto , ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
		public static extern int YLE300_Open(Int16 port);

		[DllImport("YLE300_API.dll", EntryPoint="YLE300_Close",  SetLastError=true,
			 CharSet=CharSet.Auto , ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
		public static extern int YLE300_Close();

		[DllImport("YLE300_API.dll", EntryPoint="YLE300_Reset",  SetLastError=true,
			 CharSet=CharSet.Auto , ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
		public static extern int YLE300_Reset(Int16 ResetWay);

		[DllImport("YLE300_API.dll", EntryPoint="YLE300_Read",  SetLastError=true,
			 CharSet=CharSet.Auto, ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
		public static extern Int16 YLE300_Read(Int16 TrackNo, [MarshalAs(UnmanagedType.LPArray)]byte[] databuff);

		[DllImport("YLE300_API.dll", EntryPoint="YLE300_Write",  SetLastError=true,
			 CharSet=CharSet.Auto, ExactSpelling=false,
			 CallingConvention=CallingConvention.StdCall)]
		public static extern Int16 YLE300_Write(Int16 TrackNo, [MarshalAs(UnmanagedType.LPArray)]byte[] databuff);
	}
}
