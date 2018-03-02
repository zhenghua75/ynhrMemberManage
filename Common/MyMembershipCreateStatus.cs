using System;
using System.Collections.Generic;
using System.Text;

namespace ynhrMemberManage.Common
{
    public class MyMembershipCreateStatus
    {
        public const string Success="创建用户成功。";
        public const string InvalidUserName = "在数据库中未找到用户名。";
        public const string InvalidPassword = "密码的格式设置不正确。";
        public const string InvalidQuestion = "密码提示问题的格式设置不正确。";
        public const string InvalidAnswer = "密码提示问题答案的格式设置不正确。";
        public const string InvalidEmail = "电子邮件地址的格式设置不正确。";
        public const string DuplicateUserName = "用户名已存在于应用程序的数据库中。";
        public const string DuplicateEmail = "电子邮件地址已存在于应用程序的数据库中。";
        public const string UserRejected = "因为提供程序定义的某个原因而未创建用户。";
        public const string InvalidProviderUserKey = "提供程序用户键值的类型或格式无效。";
        public const string DuplicateProviderUserKey = "提供程序用户键值已存在于应用程序的数据库中。";
        public const string ProviderError = "提供程序返回一个未由其他 MyMembershipCreateStatus描述的错误。";
        public const string DuplicateCardNo = "操作员卡号已存在";
        public const string CardOperException = "卡操作异常";
    }
}
