using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Transactions_OrganizationManagement_Organization : System.Web.UI.Page
{

    //OrganizationHelper orgHelper = new OrganizationHelper();
    //ProgramHelper programHelper = new ProgramHelper();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindData();
        }
    }

    private void BindData()
    {
        //List<ORGANIZATION> organizationList = orgHelper.GetAllOrganizations(CurrentUserID);
        //organizationListGridView.DataSource = organizationList;
        //organizationListGridView.DataBind();

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

    protected void organizationListGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
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

        //organizationListGridView.EditIndex = -1;
        //BindData();
    }

    protected void organizationListGridView_RowEditing(object sender, GridViewEditEventArgs e)
    {
        //contentOrgList.Attributes.CssStyle.Add("overflow", "scroll");
        //organizationListGridView.EditIndex = e.NewEditIndex;
        //BindData();
    }

    protected void organizationListGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //contentOrgList.Attributes.CssStyle.Remove("overflow");
        //long organizationID = Convert.ToInt64(e.Keys["ID"]);
        //orgHelper.DeleteOrganization(new ORGANIZATION { ID = organizationID });
        //BindData();
    }

    protected void organizationListGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        //contentOrgList.Attributes.CssStyle.Remove("overflow");
        //organizationListGridView.EditIndex = -1;
        //BindData();
    }


}