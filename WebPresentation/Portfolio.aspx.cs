using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Test;

namespace WebPresentation.Transactions.PortfolioManagement
{
    public partial class Portfolio1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            ProfitGainLoss profitGainLostObj = Program.GetProfitGainLossInfo();

            List<PositionInfo> positionInfoList = profitGainLostObj.maxProfitPeriodInfo.totalTransactionInfo.positionInfoList;
            //portfolioListGridView.DataSource = positionInfoList;

            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
            dt.Columns.Add(new DataColumn("Tip", typeof(string)));
            dt.Columns.Add(new DataColumn("Fiyat", typeof(string)));
            dt.Columns.Add(new DataColumn("Tarih", typeof(string)));

            for(int i=0; i<positionInfoList.Count; i++)
            {
                PositionInfo item = positionInfoList[i];
                dr = dt.NewRow();
                dr["RowNumber"] = 1;
                dr["Tip"] = item.Type;
                dr["Fiyat"] = item.Price;
                dr["Tarih"] = item.Date;
                dt.Rows.Add(dr);
            }

           

            //Store the DataTable in ViewState
            ViewState["CurrentTable"] = dt;

            portfolioListGridView.DataSource = dt;
            portfolioListGridView.DataBind();


        }


        protected void addButton_ServerClick(object sender, EventArgs e)
        {
            //ORGANIZATION organizationToAdd = new ORGANIZATION();
            //organizationToAdd.OrganizationName = newOrganizationNameText.ValueWithNull();
            //organizationToAdd.SignBoardName = newSignBoardNameText.ValueWithNull();
            //organizationToAdd.DescriptiveName = newDescriptiveNameText.ValueWithNull();
            //organizationToAdd.FoundationDate = ConvertDateTime(newFoundationDateText.ValueWithNull());
            //organizationToAdd.UserID = CurrentUserID;
            //orgHelper.AddOrganization(organizationToAdd);
            //ClearInputFields(addNewRecordContent);
            //BindData();

        }

        protected void portfolioListGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //contentOrgList.Attributes.CssStyle.Remove("overflow");
            //ORGANIZATION organizationToUpdate = orgHelper.GetSingleOrganization(Convert.ToInt64(e.Keys["ID"]));
            //if (organizationToUpdate != null)
            //{
            //    organizationToUpdate.OrganizationName = e.NewValues["OrganizationName"].ToString();
            //    organizationToUpdate.SignBoardName = e.NewValues["SignBoardName"].ToString();
            //    organizationToUpdate.DescriptiveName = e.NewValues["DescriptiveName"].ToString();
            //    organizationToUpdate.FoundationDate = ConvertDateTime(e.NewValues["FoundationDate"].ToString());

            //    orgHelper.UpdateOrganization(organizationToUpdate);
            //}

            //portfolioListGridView.EditIndex = -1;
            //BindData();
        }

        protected void portfolioListGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //contentOrgList.Attributes.CssStyle.Add("overflow", "scroll");
            //portfolioListGridView.EditIndex = e.NewEditIndex;
            //BindData();
        }

        protected void portfolioListGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //contentOrgList.Attributes.CssStyle.Remove("overflow");
            //long organizationID = Convert.ToInt64(e.Keys["ID"]);
            //orgHelper.DeleteOrganization(new ORGANIZATION { ID = organizationID });
            //BindData();
        }

        protected void portfolioListGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            //contentOrgList.Attributes.CssStyle.Remove("overflow");
            //portfolioListGridView.EditIndex = -1;
            //BindData();
        }
    }
}