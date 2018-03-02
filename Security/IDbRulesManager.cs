using System;
namespace ynhrMemeberManage.Security
{
    interface IDbRulesManager
    {
        void AddRoleToRule(string ruleName, string roleName);
        void AddUserToRule(string ruleName, string username);
        
        void CreateRule(string ruleName, string description, string[] roles);
        void InsertRule(string name, string expression, string description);

        void DeleteRuleById(int ruleId);
        void DeleteRuleByName(string ruleName);
        
        string[] GetAllRules();
        string[] GetRulesForRole(string rolename);
        string[] GetRulesForUser(string username);
        string[] GetRulesForUser(System.Security.Principal.IPrincipal principal);
        
        void RemoveRoleFromRule(string ruleName, string roleName);
        void RemoveUserFromRule(string ruleName, string username);
       
        void UpdateRuleById(int ruleId, string name, string description,string expression);
        void UpdateRuleByName(string ruleName, string ruleExpression);
    }
}
