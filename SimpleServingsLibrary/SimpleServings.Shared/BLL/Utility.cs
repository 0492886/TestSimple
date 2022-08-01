using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Configuration;
using System.Collections;
using System.Net.Mail;
using SimpleServingsLibrary.SupplierRelationship;

namespace SimpleServingsLibrary.Shared
{
    public class Utility
    {
        private static string SMTPServer
        {
            get { return ConfigurationManager.AppSettings["SmtpServer"]; }
        }
        public static bool SendMail(string from,List<string> to,string subject,string body)
        {
            if (to == null || to.Count < 1) return false;

            try
            {
                SmtpClient client = new SmtpClient(SMTPServer);

                MailMessage message = new MailMessage();
                message.From = new MailAddress(from);
                //message.From = new MailAddress(ConfigurationManager.AppSettings["AdminEmail"].ToString());

                for (int i = 0; i < to.Count; i++)
                {
                    if (to[i]!=null && to[i].ToString()!="")
                    {
                        try
                        {
                            message.Bcc.Add(to[i].ToString());
                        }
                        catch { }
                    }
                }
                message.Subject = subject;
                message.Body = body;
                message.IsBodyHtml = true;
                client.Send(message);
                return true;
            }
            catch
            {
                return false;
            }
        }
        
    
        
        
        public static void GetCodesByTypeAndUserGroupSelect(DropDownList lst, Code.CodeTypes type, int userGroupID, string oldValue)
        {
            try
            {
                lst.DataSource = Code.GetCodesByTypeAndUserGroup(type, userGroupID);
                lst.DataTextField = "CodeDescription";
                lst.DataValueField = "CodeID";
                lst.DataBind();
                lst.Items.Insert(0, new ListItem("[Select]", GlobalEnum.EmptyCode.ToString()));

                try
                {
                    if (oldValue.Trim() != "")
                    {
                        lst.ClearSelection();
                        lst.Items.FindByValue(oldValue).Selected = true;
                    }
                }
                catch { }
            }
            catch {
                lst.Items.Clear();
                lst.Items.Insert(0, new ListItem("[Select]", GlobalEnum.EmptyCode.ToString()));
            }
        }

        public static void GetCodesByType(DropDownList lst, Code.CodeTypes type, bool isActive, string oldValue)
        {
            try
            {
                lst.DataSource = Code.GetCodesByType(type, isActive);
                lst.DataTextField = "CodeDescription";
                lst.DataValueField = "CodeID";
                lst.DataBind();
                lst.Items.Insert(0, new ListItem("[Select]", GlobalEnum.EmptyCode.ToString()));

                try
                {
                    if (oldValue.Trim() != "")
                    {
                        lst.ClearSelection();
                        lst.Items.FindByValue(oldValue).Selected = true;
                    }
                }
                catch { }
            }
            catch {
                lst.Items.Clear();
                lst.Items.Insert(0, new ListItem("[Select]", GlobalEnum.EmptyCode.ToString()));
            }
        }

        public static void GetCodesByTypeAndUserGroup(DropDownList lst, Code.CodeTypes type, int userGroupID, string oldValue)
        {
            try
            {
                lst.DataSource = Code.GetCodesByTypeAndUserGroup(type,userGroupID);
                lst.DataTextField = "CodeDescription";
                lst.DataValueField = "CodeID";
                lst.DataBind();
                lst.Items.Insert(0, new ListItem("[All]", GlobalEnum.EmptyCode.ToString()));
                try
                {
                    if (oldValue.Trim() != "")
                    {
                        lst.ClearSelection();
                        lst.Items.FindByValue(oldValue).Selected = true;
                    }
                }
                catch { }
            }
            catch {
                lst.Items.Clear();
                lst.Items.Insert(0, new ListItem("[All]", GlobalEnum.EmptyCode.ToString()));
            }
        }
        public static void GetCodesByTypeAndUserGroupNoSelectNoAll(DropDownList lst, Code.CodeTypes type, int userGroupID, string oldValue)
        {
            try
            {
                lst.DataSource = Code.GetCodesByTypeAndUserGroup(type, userGroupID);
                lst.DataTextField = "CodeDescription";
                lst.DataValueField = "CodeID";
                lst.DataBind();
                try
                {
                    if (oldValue.Trim() != "")
                    {
                        lst.ClearSelection();
                        lst.Items.FindByValue(oldValue).Selected = true;
                    }
                }
                catch { }
            }
            catch 
            {
                lst.Items.Clear();
            }
        }

        /// <summary>
        /// Return diet types by staff ID 
        /// </summary>
        /// <param name="lst"></param>
        /// <param name="staffID"></param>
        /// <param name="oldValue"></param>
        public static void GetDietTypeCodesByStaffID(DropDownList lst, int staffID, string oldValue)
        {
            try
            {
                lst.DataSource = Code.GetDietTypeCodesByStaffID(staffID);
                lst.DataTextField = "CodeDescription";
                lst.DataValueField = "CodeID";
                lst.DataBind();
                try
                {
                    if (oldValue.Trim() != "")
                    {
                        lst.ClearSelection();
                        lst.Items.FindByValue(oldValue).Selected = true;
                    }
                }
                catch { }
            }
            catch
            {
                lst.Items.Clear();
            }
 
        }


        public static void GetMenuCycles(DropDownList lst, Code.CodeTypes type, int userGroupID, string oldValue)
        {
            try
            {
                lst.DataSource = Code.GetMenuCycles(type, userGroupID);
                lst.DataTextField = "CodeDescription";
                lst.DataValueField = "CodeID";
                lst.DataBind();
                lst.Items.Insert(0, new ListItem("[Select]", GlobalEnum.EmptyCode.ToString()));
                try
                {
                    if (oldValue.Trim() != "")
                    {
                        lst.ClearSelection();
                        lst.Items.FindByValue(oldValue).Selected = true;
                    }
                }
                catch { }
            }
            catch 
            {
                lst.Items.Clear();
                lst.Items.Insert(0, new ListItem("[Select]", GlobalEnum.EmptyCode.ToString()));
            }
        }

        public static void GetCodesByTypeAndDependsOnAndUserGroup(DropDownList lst, Code.CodeTypes type,int dependsOn, int userGroupID, string oldValue)
        {
            try
            {
                lst.DataSource = Code.GetCodesByTypeAndDependsOnAndUserGroup(type,dependsOn, userGroupID);
                lst.DataTextField = "CodeDescription";
                lst.DataValueField = "CodeID";
                lst.DataBind();
                if (! (lst.Items.Count == 1))//if lst has only one item, let it be selected by default.
                {
                    lst.Items.Insert(0, new ListItem("[Select]", GlobalEnum.EmptyCode.ToString()));
                }
                try
                {
                    if (oldValue.Trim() != "")
                    {
                        lst.ClearSelection();
                        lst.Items.FindByValue(oldValue).Selected = true;
                    }
                }
                catch { }
            }
            catch
            {
                lst.Items.Clear();
                lst.Items.Insert(0, new ListItem("[Select]", GlobalEnum.EmptyCode.ToString()));
            }
        }
        public static void GetCodesByTypeAndDependsOnAndUserGroupAll(DropDownList lst, Code.CodeTypes type, int dependsOn, int userGroupID, string oldValue)
        {
            try
            {
                lst.DataSource = Code.GetCodesByTypeAndDependsOnAndUserGroup(type, dependsOn, userGroupID);
                lst.DataTextField = "CodeDescription";
                lst.DataValueField = "CodeID";
                lst.DataBind();
                lst.Items.Insert(0, new ListItem("[Select]", GlobalEnum.EmptyCode.ToString()));
                try
                {
                    if (oldValue.Trim() != "")
                    {
                        lst.ClearSelection();
                        lst.Items.FindByValue(oldValue).Selected = true;
                    }
                }
                catch { }
            }
            catch 
            {
                lst.Items.Clear();
                lst.Items.Insert(0, new ListItem("[Select]", GlobalEnum.EmptyCode.ToString()));
            }
        }
        public static void GetCodesByTypeAndUserGroup(CheckBoxList lst, Code.CodeTypes type, int userGroupID)
        {
            try
            {
                lst.DataSource = Code.GetCodesByTypeAndUserGroup(type, userGroupID);
                lst.DataTextField = "CodeDescription";
                lst.DataValueField = "CodeID";
                lst.DataBind();
               
            }
            catch
            {
                lst.Items.Clear();
            }
        }
        public static void GetCodesByTypeAndDependsOnAndUserGroup(CheckBoxList lst, Code.CodeTypes type, int dependsOn, int userGroupID)
        {
            try
            {
                lst.DataSource = Code.GetCodesByTypeAndDependsOnAndUserGroup(type, dependsOn, userGroupID);
                lst.DataTextField = "CodeDescription";
                lst.DataValueField = "CodeID";
                lst.DataBind();
                
            }
            catch
            {
                lst.Items.Clear();
            }
        }
        public static bool IsAllowedOperation(int moduleID, int staffID, int groupID,ModulePermission.ModuleCheckType checkType )
        {
            switch (ModulePermission.GetModulePermission(moduleID, staffID, groupID))
            {
                case ModulePermission.Permissions.ViewOnly:
                    if (checkType == ModulePermission.ModuleCheckType.View)
                        return true;
                    break;
                case ModulePermission.Permissions.AddOnly:
                    if (checkType == ModulePermission.ModuleCheckType.Add
                        || checkType == ModulePermission.ModuleCheckType.View)
                        return true;
                    break;

                case ModulePermission.Permissions.EditOnly:
                    if (checkType == ModulePermission.ModuleCheckType.Edit
                        || checkType == ModulePermission.ModuleCheckType.View)
                        return true;
                    break;
                case ModulePermission.Permissions.AddEdit:
                    if (checkType == ModulePermission.ModuleCheckType.Add
                        || checkType == ModulePermission.ModuleCheckType.Edit
                        || checkType == ModulePermission.ModuleCheckType.View)
                        return true;
                    break;

                case ModulePermission.Permissions.AddEditDelete:
                    if (checkType == ModulePermission.ModuleCheckType.Add
                        || checkType == ModulePermission.ModuleCheckType.Edit
                        || checkType == ModulePermission.ModuleCheckType.Delete
                        || checkType == ModulePermission.ModuleCheckType.View)
                        return true;
                    break;
                default:
                    return false;
            }
            return false;

        }
        public static string ConvertToYesNo(bool val)
        {
            if (val.ToString() != null && val.ToString().Trim().ToLower() == "true")
                return "Yes";
            else if (val.ToString() != null && val.ToString().Trim().ToLower() == "false")
                return "No";
            else
                return val.ToString();
        }

        public static void SetFocus(System.Web.UI.Page page, System.Web.UI.Control control)
        {
            string script;
            script = "<Script Language 'JavaScript'> document.all('" + control.ClientID + "').focus();</script>";
            //page.RegisterStartupScript("Focus", script);
            page.ClientScript.RegisterStartupScript(script.GetType(),"Focus", script);

        }

        public static void SetDefaultButton(Page thisPage, TextBox textControl, WebControl defaultButton)
        {
            string theImageScript = @"
			<SCRIPT language=""javascript"">
			<!--
			function fnTrapKD(btnID, event)
			{
				
				btn = findObj(btnID);
				if (document.all){
					if (event.keyCode == 13){
						event.returnValue=false;
						event.cancel = true;
						btn.click();
					}
				}
				else if (document.getElementById){
					if (event.which == 13){
						event.returnValue=false;
						event.cancel = true;
						btn.focus();
						btn.click();
					}
				}
				else if(document.layers){
					if(event.which == 13){
						event.returnValue=false;
						event.cancel = true;
						btn.focus();
						btn.click();
					}
				}
				
			}

			function findObj(n, d) {

				
				var p,i,x;  
				if(!d) 
				d=document; 
				if((p=n.indexOf(""?""))>0 && parent.frames.length) {
					d=parent.frames[n.substring(p+1)].document; 
					n=n.substring(0,p);
				}	
				if(!(x=d[n])&&d.all) 
					x=d.all[n]; 
					for (i=0;!x&&i<d.forms.length;i++) 
					x=d.forms[i][n];
					for(i=0;!x&&d.layers&&i<d.layers.length;i++) 
					x=findObj(n,d.layers[i].document);
					if(!x && d.getElementById) 
					x=d.getElementById(n); 
					return x;
				}
				
			// -->
			</SCRIPT>";
            textControl.Attributes.Add("onkeydown", "fnTrapKD('" + defaultButton.ClientID + "',event)");
            //thisPage.RegisterStartupScript("ForceDefaultToScriptImage", theImageScript);
            thisPage.ClientScript.RegisterStartupScript(theImageScript.GetType(), "ForceDefaultToScriptImage", theImageScript);

        }

        public static string GetCatererByContractID(int contractId, int staffId)
        {
           return Code.GetCatererByContractID(contractId,staffId);
        }



        public static string GetCatererNameByMenuID(int MenuID)
        {
            return Code.GetCatererNameByMenuID(MenuID);
        }

        public static bool IsCatererByMenuID(int MenuID)
        {
            return Code.IsCatererByMenuID(MenuID);
        }




    }
}
