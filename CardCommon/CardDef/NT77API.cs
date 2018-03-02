using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace CardCommon.CardDef
{
    public class NT77API
    {
        //查找加密锁
        [DllImport("NT77.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int NTFindFirst(string appID);

        //查询硬件ID
        [DllImport("NT77.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int NTGetHardwareID(StringBuilder hardwareID);


        //登录加密锁
        [DllImport("NT77.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int NTLogin(string userPin);


        //存储区数据读取
        [DllImport("NT77.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int NTRead(int address, int Length, StringBuilder pBuffer);



        //存储区数据写入
        [DllImport("NT77.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int NTWrite(int address, int Length, StringBuilder pBuffer);

        //登出加密锁
        [DllImport("NT77.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int NTLogout();

    }
}
