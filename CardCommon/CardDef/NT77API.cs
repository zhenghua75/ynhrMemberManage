using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace CardCommon.CardDef
{
    public class NT77API
    {
        //���Ҽ�����
        [DllImport("NT77.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int NTFindFirst(string appID);

        //��ѯӲ��ID
        [DllImport("NT77.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int NTGetHardwareID(StringBuilder hardwareID);


        //��¼������
        [DllImport("NT77.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int NTLogin(string userPin);


        //�洢�����ݶ�ȡ
        [DllImport("NT77.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int NTRead(int address, int Length, StringBuilder pBuffer);



        //�洢������д��
        [DllImport("NT77.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int NTWrite(int address, int Length, StringBuilder pBuffer);

        //�ǳ�������
        [DllImport("NT77.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int NTLogout();

    }
}
