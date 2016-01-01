using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;

namespace OutlookJiraAddIn
{
    public partial class RibbonComposeMessageTab
    {
        private void RibbonMessageTab_Load(object sender, RibbonUIEventArgs e)
        {
            PopulateTemplatesFromDataModel();
        }

        private void bInsertDefault_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.InsertDefaultTemplateInReply(Globals.ThisAddIn.dataModel.DefaultTemplate);
        }

        public void PopulateTemplatesFromDataModel()
        {
            // remove any existing items in menu
            mInsertTemplate.Items.Clear();
            foreach(JiraTemplate item in Globals.ThisAddIn.dataModel.JiraTemplates)
            {
                RibbonButton rb = this.Factory.CreateRibbonButton();
                rb.Click += bInsertTemplate_Click; ;
                rb.Label = item.Name;
                mInsertTemplate.Items.Add(rb);
            }            
        }

        void bInsertTemplate_Click(object sender, RibbonControlEventArgs e)
        {
            RibbonButton rb = sender as RibbonButton;
            if(rb != null)
            {
                JiraTemplate jt = Globals.ThisAddIn.dataModel.GetJiraTemplateFromTemplateName(rb.Label);
                Globals.ThisAddIn.InsertDefaultTemplateInReply(jt);
            }  
        }


    }
}
