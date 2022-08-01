using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml;
using System.Text;
using SimpleServingsLibrary.SupplierRelationship;
using SimpleServingsLibrary.Shared;
using AjaxControlToolkit;

namespace SimpleServings.UI.Page
{
    
    public partial class TestPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {     
                    POP();               
                    //PopMymenu();
                    //PopMyDraft();
                }
                catch (ApplicationException ex)
                {
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    lblMsg.Text = ex.Message;
                }
            }
        }

        private void POP()
        {
            SimpleServingsLibrary.Shared.Staffs staffs = new SimpleServingsLibrary.Shared.Staffs();
            staffs = SimpleServingsLibrary.Shared.Staff.GetAllStaff(true);

            foreach (Staff staff in staffs)
            {
                string fullname = staff.FirstName.TrimEnd();
                string[] words = fullname.Split(' ');
                int len = words.Length;
                string fname = words[0];
                string lname = words[len-1];
                string password = fname[0] + lname;
                //bool done = SimpleServingsLibrary.Shared.Staff.UpdateTempStaff(staff.StaffID, fname, lname, password);
            }
        }
       
        /*
        private void PopMymenu()
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"];
            if (staff == null) Response.Redirect("~/UI/Page/login.aspx");


            SimpleServingsLibrary.Menu.Menus menus = new SimpleServingsLibrary.Menu.Menus();
            try
            {
                menus = SimpleServingsLibrary.Menu.Menu.GetMyMenusByUserID(staff.StaffID);
            }
            catch { }
            MenuGrid1.PopGrid(menus);
        }

        private void PopMyDraft()
        {
            SimpleServingsLibrary.Shared.Staff staff = (SimpleServingsLibrary.Shared.Staff)Session["UserObject"];
            if (staff == null) Response.Redirect("~/UI/Page/login.aspx");


            SimpleServingsLibrary.Menu.Menus menus = new SimpleServingsLibrary.Menu.Menus();
            try
            {
                menus = SimpleServingsLibrary.Menu.Menu.GetMenusByCreatedbyAndStatus(staff.StaffID,GlobalEnum.MenuStatus_Draft);
            }
            catch { }
            MenuGrid2.PopGrid(menus);
        }
        */
        
        private void ReadInput2()
        {
            string text = System.IO.File.ReadAllText(@"C:\ContractList.csv");
            string[] tokrnStr;
            tokrnStr = text.Split(',','\r','\n','\f','"');
            int tok = tokrnStr.Length;
            int j = 2;
            int assignedTo = 0;
            for (int i = 0; i < tok;)
            {
                Contract contract = new Contract();
                int contractID = Contract.AddContractTemp(tokrnStr[i+3],Convert.ToString(j++),Convert.ToInt32(tokrnStr[i+2].Trim()),1,tokrnStr[i+9],1,1,tokrnStr[i+8],tokrnStr[i+1],assignedTo);
                //int sporsorID = Sponsor.AddSponsorTemp(tokrnStr[i+1],tokrnStr[i+6],1,1,tokrnStr[i+7],tokrnStr[i+0]);
                i = i + 11;
                if (i >= 4970)
                    break;
                
                    
            }
            
        }

        private void ReadInput()
        {
            string text = System.IO.File.ReadAllText(@"C:\SporsorList.csv");
            string[] tokrnStr;
            tokrnStr = text.Split(',','\r','\n','\f','"');
            int tok = tokrnStr.Length;
            for (int i = 0; i < tok;)
            {
                Sponsor sponsor = new Sponsor();
                int sporsorID = Sponsor.AddSponsorTemp(tokrnStr[i+1],tokrnStr[i+6],1,1,tokrnStr[i+7],tokrnStr[i+0]);
                i = i + 9;
                if (i >= 1080)
                    break;
                
                    
            }
        }

        protected void Rating1_Changed(object sender, RatingEventArgs e)
        {
            //System.Diagnostics.Debugger.Launch();

            Rating rating = (Rating)sender;
            labelValue1.Text = rating.CurrentRating.ToString();
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('" + rating.CurrentRating.ToString() + "');", true);
        } 
    }   
}

