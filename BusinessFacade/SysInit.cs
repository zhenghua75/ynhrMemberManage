using System;
using System.Collections.Generic;
using System.Text;
using ynhrMemberManage.Domain;
using ynhrMemberManage.ORM;
using System.Data.SqlClient;
using System.Data;
using ynhrMemberManage.Common;
namespace ynhrMemberManage.BusinessFacade
{
    public class SysInit
    {
        public static void LoadPara(ConstApp ca)
        {
            ca.dtNameCode = SqlHelper.ExecuteDataTable(CommandType.Text, "select * from tbNameCode");
            ca.dtMemberCode = SqlHelper.ExecuteDataTable(CommandType.Text, "select * from tbMemberCode");

            ca.alMemberType.Clear();
            ca.alEnterpriseType.Clear();
            ca.alProduct.Clear();
            ca.alTrade.Clear();
            ca.alInMoneyDiscount.Clear();

            DataRow[] drMemberTypes = ca.dtNameCode.Select("cnvcType='" + ConstApp.MemberType + "'");
            foreach (DataRow drMemberType in drMemberTypes)
            {
                NameCode nameCode = new NameCode(drMemberType);
                ca.alMemberType.Add(nameCode.cnvcValue);
            }

            DataRow[] drEnterpriseTypes = ca.dtNameCode.Select("cnvcType='" + ConstApp.EnterpriseType + "'");
            foreach (DataRow drEnterpriseType in drEnterpriseTypes)
            {
                NameCode nameCode = new NameCode(drEnterpriseType);
                ca.alEnterpriseType.Add(nameCode.cnvcValue);
            }

            DataRow[] drProducts = ca.dtNameCode.Select("cnvcType='" + ConstApp.Product + "'");
            foreach (DataRow drProduct in drProducts)
            {
                NameCode nameCode = new NameCode(drProduct);
                ca.alProduct.Add(nameCode.cnvcValue);
            }

            DataRow[] drTrades = ca.dtNameCode.Select("cnvcType='" + ConstApp.Trade + "'");
            foreach (DataRow drTrade in drTrades)
            {
                NameCode nameCode = new NameCode(drTrade);
                ca.alTrade.Add(nameCode.cnvcValue);
            }
            //ЁДж╣уш©ш
            DataRow[] drInMoneyDiscounts = ca.dtNameCode.Select("cnvcType='" + ConstApp.InMoneyDiscount + "'");
            foreach (DataRow drInMoneyDiscount in drInMoneyDiscounts)
            {
                NameCode nameCode = new NameCode(drInMoneyDiscount);
                ca.alInMoneyDiscount.Add(nameCode.cnvcValue);
            }

            DataRow[] drJobBookDates = ca.dtNameCode.Select("cnvcType='" + ConstApp.BookDate + "'");
            if (drJobBookDates.Length > 0)
            {
                NameCode nameCode = new NameCode(drJobBookDates[0]);
                ca.iBookDate = int.Parse(nameCode.cnvcValue);
            }


            DataRow[] drTishis = ca.dtNameCode.Select("cnvcType='" + ConstApp.tishi + "'");
            if (drTishis.Length > 0)
            {
                NameCode nameCode = new NameCode(drTishis[0]);
                ca.iTishi = int.Parse(nameCode.cnvcValue);
            }

            DataRow[] drTouchFlash = ca.dtNameCode.Select("cnvcType='" + ConstApp.TouchFlash + "'");
            if (drTouchFlash.Length > 0)
            {
                NameCode nameCode = new NameCode(drTouchFlash[0]);
                ca.iTouchFlash = int.Parse(nameCode.cnvcValue);
            }

            DataRow[] drTouchBookBeginDate = ca.dtNameCode.Select("cnvcType='" + ConstApp.TouchBookBeginDate + "'");
            if (drTouchBookBeginDate.Length > 0)
            {
                NameCode nameCode = new NameCode(drTouchBookBeginDate[0]);
                ca.dTouchBookBeginDate = nameCode.cnvcValue;
            }
            DataRow[] drTouchBookEndDate = ca.dtNameCode.Select("cnvcType='" + ConstApp.TouchBookEndDate + "'");
            if (drTouchBookEndDate.Length > 0)
            {
                NameCode nameCode = new NameCode(drTouchBookEndDate[0]);
                ca.dTouchBookEndDate = nameCode.cnvcValue;
            }

            DataRow[] drTouchSignInBeginDate = ca.dtNameCode.Select("cnvcType='" + ConstApp.TouchSignInBeginDate + "'");
            if (drTouchSignInBeginDate.Length > 0)
            {
                NameCode nameCode = new NameCode(drTouchSignInBeginDate[0]);
                ca.dTouchSignInBeginDate = nameCode.cnvcValue;
            }

            DataRow[] drTouchSignInEndDate = ca.dtNameCode.Select("cnvcType='" + ConstApp.TouchSignInEndDate + "'");
            if (drTouchSignInEndDate.Length > 0)
            {
                NameCode nameCode = new NameCode(drTouchSignInEndDate[0]);
                ca.dTouchSignInEndDate = nameCode.cnvcValue;
            }
            DataRow[] drJobBeginDate = ca.dtNameCode.Select("cnvcType='" + ConstApp.JobListBeginDate + "'");
            if (drJobBeginDate.Length > 0)
            {
                NameCode nameCode = new NameCode(drJobBeginDate[0]);
                ca.strJobBeginDate = nameCode.cnvcValue;
            }
            DataRow[] drJobEndDate = ca.dtNameCode.Select("cnvcType='" + ConstApp.JobListEndDate + "'");
            if (drJobEndDate.Length > 0)
            {
                NameCode nameCode = new NameCode(drJobEndDate[0]);
                ca.strJobEndDate = nameCode.cnvcValue;
            }

            DataRow[] drJobBookingBeginDate = ca.dtNameCode.Select("cnvcType='" + ConstApp.JobBookingListBeginDate + "'");
            if (drJobBookingBeginDate.Length > 0)
            {
                NameCode nameCode = new NameCode(drJobBookingBeginDate[0]);
                ca.strJobBookingBeginDate = nameCode.cnvcValue;
            }
            DataRow[] drJobBookingEndDate = ca.dtNameCode.Select("cnvcType='" + ConstApp.JobBookingListEndDate + "'");
            if (drJobBookingEndDate.Length > 0)
            {
                NameCode nameCode = new NameCode(drJobBookingEndDate[0]);
                ca.strJobBookingEndDate = nameCode.cnvcValue;
            }

            DataRow[] drJobRemainBeginDate = ca.dtNameCode.Select("cnvcType='" + ConstApp.JobRemainListBeginDate + "'");
            if (drJobRemainBeginDate.Length > 0)
            {
                NameCode nameCode = new NameCode(drJobRemainBeginDate[0]);
                ca.strJobRemainBeginDate = nameCode.cnvcValue;
            }
            DataRow[] drJobRemainEndDate = ca.dtNameCode.Select("cnvcType='" + ConstApp.JobRemainListEndDate + "'");
            if (drJobRemainEndDate.Length > 0)
            {
                NameCode nameCode = new NameCode(drJobRemainEndDate[0]);
                ca.strJobRemainEndDate = nameCode.cnvcValue;
            }

            DataRow[] drInMoneySetting = ca.dtNameCode.Select("cnvcType='" + ConstApp.InMoneySetting + "'");
            if (drInMoneySetting.Length > 0)
            {
                NameCode nameCode = new NameCode(drInMoneySetting[0]);
                ca.bInMoneyDonate = nameCode.cnvcValue=="1"?true:false;
            }

            DataRow[] drCardTypes = ca.dtNameCode.Select("cnvcType='" + ConstApp.CardType + "'");
            if (drCardTypes.Length > 0)
            {
                NameCode nameCode = new NameCode(drCardTypes[0]);
                ca.strCardType = nameCode.cnvcValue;
            }
            //zhh 20140611
            DataRow[] drCardTypeL6s = ca.dtNameCode.Select("cnvcType='" + ConstApp.CardType_L6 + "'");
            if (drCardTypeL6s.Length > 0)
            {
                NameCode nameCode = new NameCode(drCardTypeL6s[0]);
                ca.strCardTypeL6Name = nameCode.cnvcValue;
            }
            DataRow[] drCardTypeL8s = ca.dtNameCode.Select("cnvcType='" + ConstApp.CardType_L8 + "'");
            if (drCardTypeL8s.Length > 0)
            {
                NameCode nameCode = new NameCode(drCardTypeL8s[0]);
                ca.strCardTypeL8Name = nameCode.cnvcValue;
            }
            ca.htFree.Clear();
            ca.htBookDate.Clear();
            ca.htDisabledDate.Clear();
            ca.htDisabledDateMinAmount.Clear();
            ca.htMemberDiscount.Clear();
            ca.htMemberSeats.Clear();
            ca.htDept.Clear();
            ca.htMemberFee.Clear();            
            DataRow[] drFreeTypes = ca.dtMemberCode.Select("cnvcMemberType='" + ConstApp.FreeType + "'");
            foreach (DataRow drFreeType in drFreeTypes)
            {
                MemberCode memberCode = new MemberCode(drFreeType);
                ca.htFree.Add(memberCode.cnvcMemberName, memberCode.cnvcMemberValue);
            }
            DataRow[] drBookDates = ca.dtMemberCode.Select("cnvcMemberType='" + ConstApp.BookDate + "'");
            foreach (DataRow drBookDate in drBookDates)
            {
                MemberCode memberCode = new MemberCode(drBookDate);
                ca.htBookDate.Add(memberCode.cnvcMemberName, memberCode.cnvcMemberValue);
            }

            DataRow[] drDisabledDates = ca.dtMemberCode.Select("cnvcMemberType='" + ConstApp.DisabledDate + "'");
            foreach (DataRow drDisabledDate in drDisabledDates)
            {
                MemberCode memberCode = new MemberCode(drDisabledDate);
                ca.htDisabledDate.Add(memberCode.cnvcMemberName, memberCode.cnvcMemberValue);
            }
            //zhh 20130315
            DataRow[] drDisabledDateMinAmounts = ca.dtMemberCode.Select("cnvcMemberType='" + ConstApp.DisabledDateMinAmount + "'");
            foreach (DataRow drDisabledDateMinAmount in drDisabledDateMinAmounts)
            {
                MemberCode memberCode = new MemberCode(drDisabledDateMinAmount);
                ca.htDisabledDateMinAmount.Add(memberCode.cnvcMemberName, memberCode.cnvcMemberValue);
            }
            //end zhh 20130315
            DataRow[] drMemberDiscounts = ca.dtMemberCode.Select("cnvcMemberType='" + ConstApp.MemberDiscount + "'");
            foreach (DataRow drMemberDiscount in drMemberDiscounts)
            {
                MemberCode memberCode = new MemberCode(drMemberDiscount);
                ca.htMemberDiscount.Add(memberCode.cnvcMemberName, memberCode.cnvcMemberValue);
            }

            DataRow[] drMemberSeats = ca.dtMemberCode.Select("cnvcMemberType='" + ConstApp.MemberSeats + "'");
            foreach (DataRow drMemberSeat in drMemberSeats)
            {
                MemberCode memberCode = new MemberCode(drMemberSeat);
                ca.htMemberSeats.Add(memberCode.cnvcMemberName, memberCode.cnvcMemberValue);
            }

            DataRow[] drMemberFees = ca.dtMemberCode.Select("cnvcMemberType='" + ConstApp.MemberFee + "'");
            foreach (DataRow drMemberFee in drMemberFees)
            {
                MemberCode memberCode = new MemberCode(drMemberFee);
                ca.htMemberFee.Add(memberCode.cnvcMemberName, memberCode.cnvcMemberValue);
            }

            DataTable dtDept = SqlHelper.ExecuteDataTable(CommandType.Text, "select * from tbDept");
            foreach (DataRow drDept in dtDept.Rows)
            {
                Dept dept = new Dept(drDept);
                ca.htDept.Add(dept.cnnDeptID, dept);
            }
            //zhh 2014-06-06
            ca.htIsJob.Clear();
            DataRow[] drIsJobs = ca.dtMemberCode.Select("cnvcMemberType='" + ConstApp.IsJob + "'");
            foreach (DataRow drIsJob in drIsJobs)
            {
                MemberCode memberCode = new MemberCode(drIsJob);
                ca.htIsJob.Add(memberCode.cnvcMemberName, memberCode.cnvcMemberValue);
            }
            ca.htIsMemberFee.Clear();
            DataRow[] drIsMemberFees = ca.dtMemberCode.Select("cnvcMemberType='" + ConstApp.IsMemberFee + "'");
            foreach (DataRow drIsMemberFee in drIsMemberFees)
            {
                MemberCode memberCode = new MemberCode(drIsMemberFee);
                ca.htIsMemberFee.Add(memberCode.cnvcMemberName, memberCode.cnvcMemberValue);
            }
            ca.htIsInMoney.Clear();
            DataRow[] drIsInMoneys = ca.dtMemberCode.Select("cnvcMemberType='" + ConstApp.IsInMoney + "'");
            foreach (DataRow drIsInMoney in drIsInMoneys)
            {
                MemberCode memberCode = new MemberCode(drIsInMoney);
                ca.htIsInMoney.Add(memberCode.cnvcMemberName, memberCode.cnvcMemberValue);
            }
            ca.htIsProduct.Clear();
            DataRow[] drIsProducts = ca.dtMemberCode.Select("cnvcMemberType='" + ConstApp.IsProduct + "'");
            foreach (DataRow drIsProduct in drIsProducts)
            {
                MemberCode memberCode = new MemberCode(drIsProduct);
                ca.htIsProduct.Add(memberCode.cnvcMemberName, memberCode.cnvcMemberValue);
            }
            ca.htIsProductSelect.Clear();
            DataRow[] drIsProductSelects = ca.dtMemberCode.Select("cnvcMemberType='" + ConstApp.IsProductSelect + "'");
            foreach (DataRow drIsProductSelect in drIsProductSelects)
            {
                MemberCode memberCode = new MemberCode(drIsProductSelect);
                ca.htIsProductSelect.Add(memberCode.cnvcMemberName, memberCode.cnvcMemberValue);
            }
            ca.htIsFeeType.Clear();
            DataRow[] drIsFeeTypes = ca.dtMemberCode.Select("cnvcMemberType='" + ConstApp.IsFeeType + "'");
            foreach (DataRow drIsFeeType in drIsFeeTypes)
            {
                MemberCode memberCode = new MemberCode(drIsFeeType);
                ca.htIsFeeType.Add(memberCode.cnvcMemberName, memberCode.cnvcMemberValue);
            }
            ca.htIsDisabledDate.Clear();
            DataRow[] drIsDisabledDates = ca.dtMemberCode.Select("cnvcMemberType='" + ConstApp.IsDisabledDate + "'");
            foreach (DataRow drIsDisabledDate in drIsDisabledDates)
            {
                MemberCode memberCode = new MemberCode(drIsDisabledDate);
                ca.htIsDisabledDate.Add(memberCode.cnvcMemberName, memberCode.cnvcMemberValue);
            }

        }        
    }
}
