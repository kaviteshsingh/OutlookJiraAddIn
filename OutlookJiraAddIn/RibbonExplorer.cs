using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;


namespace OutlookJiraAddIn
{
    public partial class RibbonExplorer
    {
        private void RibbonExplorer_Load(object sender, RibbonUIEventArgs e)
        {
            cbCcField.Checked = Globals.ThisAddIn.dataModel.bCcEmail;
            cbToField.Checked = Globals.ThisAddIn.dataModel.bToEmail;
            cbRemoveRecipients.Checked = Globals.ThisAddIn.dataModel.bRemoveRecipients;
            ebToEmail.Text = Globals.ThisAddIn.dataModel.JiraEmail;
            
            mReplyWithJiraTab.Dynamic = true;
            mReplyWithMailTab.Dynamic = true;

            PopulateTemplatesFromDataModel();
        }

        public void PopulateTemplatesFromDataModel()
        {
            // remove any existing items in menu
            mReplyWithJiraTab.Items.Clear();
            mReplyWithMailTab.Items.Clear();
            ddDefaultTemplate.Items.Clear();

            foreach(JiraTemplate item in Globals.ThisAddIn.dataModel.JiraTemplates)
            {
                RibbonButton rb1 = this.Factory.CreateRibbonButton();
                rb1.Click += rbReplyWithTemplate_Click;
                rb1.Label = item.Name;
                mReplyWithJiraTab.Items.Add(rb1);

                RibbonButton rb2 = this.Factory.CreateRibbonButton();
                rb2.Click += rbReplyWithTemplate_Click;
                rb2.Label = item.Name;
                mReplyWithMailTab.Items.Add(rb2);

                RibbonDropDownItem rddt = this.Factory.CreateRibbonDropDownItem();
                rddt.Label = item.Name;
                ddDefaultTemplate.Items.Add(rddt);
            }
            SelectDefaultItemInDropDown();
        }

        void SelectDefaultItemInDropDown()
        {
            string TemplateName = Globals.ThisAddIn.dataModel.DefaultTemplate.Name;
            if(ddDefaultTemplate.Items.Count > 0 && TemplateName != null && TemplateName.Length > 1)
            {
                foreach(RibbonDropDownItem item in ddDefaultTemplate.Items)
                {
                    if(0 == String.Compare(item.Label, TemplateName,true))
                    {
                        ddDefaultTemplate.SelectedItem = item;
                    }
                }
            }
        }

        void rbReplyWithTemplate_Click(object sender, RibbonControlEventArgs e)
        {
            RibbonButton rb = sender as RibbonButton;
            if(rb != null)
            {
                JiraTemplate jt = Globals.ThisAddIn.dataModel.GetJiraTemplateFromTemplateName(rb.Label);
                Globals.ThisAddIn.HandleReplyWithTemplate(jt);
            }           
        }

        private void ebJiraEmail_TextChanged(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.dataModel.JiraEmail = ebToEmail.Text;
        }

        private void bDefaultReply_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.HandleReplyWithTemplate(Globals.ThisAddIn.dataModel.DefaultTemplate);         
        }

        private void cbToField_Click(object sender, RibbonControlEventArgs e)
        {
            if(cbToField.Checked == false && cbCcField.Checked == false)
            {
                cbToField.Checked = true;
            }
            Globals.ThisAddIn.dataModel.bToEmail = cbToField.Checked;
        }

        private void cbCcField_Click(object sender, RibbonControlEventArgs e)
        {
            if(cbToField.Checked == false && cbCcField.Checked == false)
            {
                cbToField.Checked = true;
            }
            Globals.ThisAddIn.dataModel.bCcEmail = cbCcField.Checked;
        }

        private void cbRemoveRecipients_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.dataModel.bRemoveRecipients = cbRemoveRecipients.Checked;
        }

        private void bDeleteSelected_Click(object sender, RibbonControlEventArgs e)
        {               
            if(ddDefaultTemplate.Items.Count > 0)
            {
                string selectedItem = ddDefaultTemplate.SelectedItem.Label;

                if(true == Globals.ThisAddIn.dataModel.RemoveJiraTemplateFromDataModel(selectedItem))
                {
                    SelectDefaultItemInDropDown();
                    PopulateTemplatesFromDataModel();
                }                
            }
        }

        private void bEditSelected_Click(object sender, RibbonControlEventArgs e)
        {
            if(ddDefaultTemplate.Items.Count > 0)
            {
                string jiraTemplateName = ddDefaultTemplate.SelectedItem.Label;

                FormTemplateConfiguration ftc = new FormTemplateConfiguration(Globals.ThisAddIn.dataModel, jiraTemplateName);
                ftc.ShowDialog();

                // update the default template list. The showdialog box till dialog is closed.
                PopulateTemplatesFromDataModel(); 
            }
        }

        private void bAddNewTemplate_Click(object sender, RibbonControlEventArgs e)
        {
            FormTemplateConfiguration ftc = new FormTemplateConfiguration(Globals.ThisAddIn.dataModel);
            ftc.ShowDialog();
            
            // update the default template list. The showdialog box till dialog is closed.
            PopulateTemplatesFromDataModel();

        }

        private void bSetDefault_Click(object sender, RibbonControlEventArgs e)
        {
            if(ddDefaultTemplate.Items.Count > 0)
            {
                string jiraTemplateName = ddDefaultTemplate.SelectedItem.Label;
                Globals.ThisAddIn.dataModel.MarkJiraItemDefault(jiraTemplateName);
                SelectDefaultItemInDropDown();
            }
        }

        private void bReportBug_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.ReportBug();
        }

        private void bAbout_Click(object sender, RibbonControlEventArgs e)
        {
            // Don't make it showDialog because you cannot launch another email item when
            // dialog box is open and it will crash.
            AboutBox1 ab = new AboutBox1();
            ab.Show();
        }
    }
}
