using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SimpleServings.UI.UDC.SimpleServings.Staff
{
    public partial class ContractGrid : System.Web.UI.UserControl
    {
        public bool ShowCheckBoxColumn
        {
            set { this.gvContract.Columns[0].Visible = value; }
        }

        public void PopGrid(SimpleServingsLibrary.SupplierRelationship.Contracts contracts)
        {
            try
            {
                gvContract.DataSource = contracts;
                gvContract.DataBind();
            }
            catch
            {
                gvContract.DataSource = null;
                gvContract.DataBind();
            }

        }
        public List<int> GetSelectedContractIDs()
        {
            List<int> IDs = new List<int>();
            foreach (GridViewRow row in gvContract.Rows)
            {
                CheckBox cbCheck = row.FindControl("cbCheck") as CheckBox;
                if (cbCheck.Checked)
                {
                    int contractID = 0;
                    Int32.TryParse(gvContract.DataKeys[row.RowIndex].Value.ToString(), out contractID);
                    IDs.Add(contractID);
                }

            }
            return IDs;
            
        }
        public void CheckBoxOnGrid(int inContractID)
        {
            foreach (GridViewRow row in gvContract.Rows)
            {
                int contractID = 0;
                Int32.TryParse(gvContract.DataKeys[row.RowIndex].Value.ToString(), out contractID);
                
                if (inContractID == contractID)
                {
                    CheckBox cbCheck = row.FindControl("cbCheck") as CheckBox;
                    cbCheck.Checked = true;
                    break;
                }

            }

        }
    }
}