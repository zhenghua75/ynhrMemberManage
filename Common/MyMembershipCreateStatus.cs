using System;
using System.Collections.Generic;
using System.Text;

namespace ynhrMemberManage.Common
{
    public class MyMembershipCreateStatus
    {
        public const string Success="�����û��ɹ���";
        public const string InvalidUserName = "�����ݿ���δ�ҵ��û�����";
        public const string InvalidPassword = "����ĸ�ʽ���ò���ȷ��";
        public const string InvalidQuestion = "������ʾ����ĸ�ʽ���ò���ȷ��";
        public const string InvalidAnswer = "������ʾ����𰸵ĸ�ʽ���ò���ȷ��";
        public const string InvalidEmail = "�����ʼ���ַ�ĸ�ʽ���ò���ȷ��";
        public const string DuplicateUserName = "�û����Ѵ�����Ӧ�ó�������ݿ��С�";
        public const string DuplicateEmail = "�����ʼ���ַ�Ѵ�����Ӧ�ó�������ݿ��С�";
        public const string UserRejected = "��Ϊ�ṩ�������ĳ��ԭ���δ�����û���";
        public const string InvalidProviderUserKey = "�ṩ�����û���ֵ�����ͻ��ʽ��Ч��";
        public const string DuplicateProviderUserKey = "�ṩ�����û���ֵ�Ѵ�����Ӧ�ó�������ݿ��С�";
        public const string ProviderError = "�ṩ���򷵻�һ��δ������ MyMembershipCreateStatus�����Ĵ���";
        public const string DuplicateCardNo = "����Ա�����Ѵ���";
        public const string CardOperException = "�������쳣";
    }
}
