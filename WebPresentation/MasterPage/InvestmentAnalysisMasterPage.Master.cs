using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebPresentation.MasterPage
{
    public partial class InvestmentAnalysisMasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SiteMapPath1_ItemCreated(object sender, System.Web.UI.WebControls.SiteMapNodeItemEventArgs e)
        {
            if (e.Item.ItemIndex == 0 | (e.Item.ItemIndex == 1 && e.Item.ItemType == SiteMapNodeItemType.PathSeparator))
            {
                e.Item.Visible = false;
            }
        }
    }
}