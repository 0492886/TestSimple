using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SimpleServings.UI.UDC.SimpleServings.Supplier
{
    public partial class ContractGrid : System.Web.UI.UserControl
    {

        public List<int> GetSelectedContractIDs()
        {
            List<int> contractIDs = new List<int> { };
            int contractID = 0;
            foreach (GridViewRow row in gvContract.Rows)
            {
                if ((row.FindControl("cbCheck") as CheckBox).Checked)
                {
                    Int32.TryParse((row.FindControl("lblContractID") as Label).Text, out contractID);
                    contractIDs.Add(contractID);

                }
            }
            return contractIDs;
        }

        public List<string> GetSelectedContractNames()
        {
            List<string> contractIDs = new List<string> { };

            foreach (GridViewRow row in gvContract.Rows)
            {
                if ((row.FindControl("cbCheck") as CheckBox).Checked)
                {
                    contractIDs.Add((row.FindControl("lblContractName") as Label).Text);

                }
            }
            return contractIDs;
        }


        public void CheckSelectedContractsonGird(List<int> selectedContratcs)
        {
            int contractID = 0;
            foreach (GridViewRow row in gvContract.Rows)
            {
                Int32.TryParse((row.FindControl("lblContractID") as Label).Text, out contractID);

                if (selectedContratcs.Contains(contractID))
                {
                    (row.FindControl("cbCheck") as CheckBox).Checked = true;
 
                }
 
            }
 
        }




        public void PopGrid(SimpleServingsLibrary.SupplierRelationship.Contracts contracts)
        {

            if (contracts != null)
            {
                this.gvContract.DataSource = contracts;
                this.gvContract.DataBind();
            }
            else
            {
                this.gvContract.DataSource = null;
                this.gvContract.DataBind();
            }
        }
    }
}