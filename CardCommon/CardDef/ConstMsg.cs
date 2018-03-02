using System;

namespace ynhrMemberManage.CardCommon.CardDef
{
	/// <summary>
	/// ConstMsg 的摘要说明。
	/// </summary>
	public class ConstMsg
	{
		public const string RFINITERR="卡异常";//RF001初始化失败
		public const string RFREQUESTERR="卡异常";//卡异常 RF002未找到卡
		public const string RFANTICOLLERR="RF003";
		public const string RFSELECTERR="RF004";
		public const string RFLOADKEY_A_ERR="RF005";
		public const string RFLOADKEY_B_ERR="RF006";
		public const string RFAUTHENTICATION_A_ERR="卡异常";//RF007卡密码错误
		public const string RFAUTHENTICATION_B_ERR="RF008";
		public const string RFREADERR="RF009";
		public const string RFWRITEERR="RF010";
		public const string RFCHANGEB3ERR="RF011";

		public const string RFOK="OPSUCCESS";
	}
}
