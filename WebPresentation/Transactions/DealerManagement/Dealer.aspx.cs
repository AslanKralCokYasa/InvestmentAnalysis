using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Transactions_DealerManagement_Dealer : System.Web.UI.Page
{
    //OrganizationHelper orgHelper = new OrganizationHelper();
    //DealerHelper dealerHelper = new DealerHelper();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillOrganizationList();
        }
    }

    private void FillOrganizationList()
    {
        //List<ORGANIZATION> orgList = orgHelper.GetAllOrganizations(CurrentUserID);
        //organizationList.DataValueField = "ID";
        //organizationList.DataTextField = "OrganizationName";
        //organizationList.DataSource = orgList;
        //organizationList.DataBind();
        //organizationList_ServerChange(null, null);
    }
    private void BindData()
    {
        //long selectedOrg = 0;
        //if (long.TryParse(organizationList.Value, out selectedOrg))
        //{
        //    List<DEALER> dealerList = dealerHelper.GetAllDealersWithLocation(selectedOrg);
        //    dealerListGridView.DataSource = dealerList;
        //    dealerListGridView.DataBind();
        //}
    }

    #region Events
    protected void organizationList_ServerChange(object sender, EventArgs e)
    {
        BindData();
    }

    protected void btnEkle_ServerClick(object sender, EventArgs e)
    {
        //DEALER dealerToAdd = new DEALER();
        //dealerToAdd.LocationName = txtNewYer.ValueWithNull();
        //dealerToAdd.LocationAdress = txtYerAdres.ValueWithNull();
        //dealerToAdd.IsActive = txtAktifMi.Checked;
        //dealerToAdd.OrganizationID = long.Parse(organizationList.Value);
        //dealerToAdd.CreationDate = ConvertDateTime(txtNewEklenmeTarihi.ValueWithNull());
        //dealerHelper.AddDealer(dealerToAdd);

        //ClearInputFields(addNewRecordContent);
        //BindData();

    }

    protected void dealerListGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        //contentDealerList.Attributes.CssStyle.Remove("overflow");
        //DEALER dealerToUpdate = dealerHelper.GetSingleDealerWithLocation(Convert.ToInt64(e.Keys["ID"]));
        //if (dealerToUpdate != null)
        //{
        //    dealerToUpdate.LocationName = e.NewValues["LocationName"].ToString();
        //    dealerToUpdate.LocationAdress = e.NewValues["LocationAdress"].ToString();
        //    dealerToUpdate.IsActive = bool.Parse(e.NewValues["IsActive"].ToString());
        //    dealerToUpdate.CreationDate = ConvertDateTime(e.NewValues["CreationDate"].ToString());
        //    dealerHelper.UpdateDealerWithLocation(dealerToUpdate);
        //}

        //dealerListGridView.EditIndex = -1;
        //BindData();
    }
    protected void dealerListGridView_RowEditing(object sender, GridViewEditEventArgs e)
    {
        //contentDealerList.Attributes.CssStyle.Add("overflow","scroll");
        //dealerListGridView.EditIndex = e.NewEditIndex;
        //BindData();
    }
    protected void dealerListGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //contentDealerList.Attributes.CssStyle.Remove("overflow");
        //long dealerId = Convert.ToInt64(e.Keys["ID"]);
        //dealerHelper.DeleteDealer(new DEALER { ID = dealerId });
        //BindData();
    }
    protected void dealerListGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        //contentDealerList.Attributes.CssStyle.Remove("overflow");
        //dealerListGridView.EditIndex = -1;
        //BindData();
    }
    #endregion
}