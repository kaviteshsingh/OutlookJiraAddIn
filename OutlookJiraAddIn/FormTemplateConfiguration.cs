using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OutlookJiraAddIn
{
    public partial class FormTemplateConfiguration : Form
    {
        string editTemplateName = null;
        DataModel dataModel = null;

        /// <summary>
        /// For adding new template
        /// </summary>
        /// <param name="dataModel"></param>
        public FormTemplateConfiguration(DataModel dataModel)
        {
            InitializeComponent();
            this.dataModel = dataModel;
        }

        /// <summary>
        /// Call this when editing template
        /// </summary>
        /// <param name="jiraTemplate"></param>
        public FormTemplateConfiguration(DataModel dataModel, string editTemplateName)
            : this(dataModel)
        {
            this.editTemplateName = editTemplateName;

            foreach(JiraTemplate item in dataModel.JiraTemplates)
            {
                if(0 == String.Compare(item.Name, editTemplateName, true))
                {
                    tbName.Text = item.Name;
                    rbContent.Text = item.Content;
                    break;
                }
            }
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            string Name = tbName.Text;
            string Content = rbContent.Text;
            bool bIsDefault = false;

            if(
                Name == null || Name.Length < 1 ||
                Content == null || Content.Length < 1
                )
            {
                MessageBox.Show("Invalid Name/Content.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            JiraTemplate jt = new JiraTemplate(Name, Content);

            if(editTemplateName == null || editTemplateName.Length < 1)
            {
                // this means it is new template                
                Globals.ThisAddIn.dataModel.AddJiraTemplateToDataModel(jt);
            }
            else
            {
                if(0 == String.Compare(editTemplateName, Globals.ThisAddIn.dataModel.DefaultTemplate.Name))
                {
                    bIsDefault = true;
                }
                // remove the old registry and add new one. 
                // This ensures there are no duplicate entries in the datamodel.                 
                Globals.ThisAddIn.dataModel.RemoveJiraTemplateFromDataModel(editTemplateName);
                Globals.ThisAddIn.dataModel.AddJiraTemplateToDataModel(jt);
                // since we remove the current item, we need to set the default again
                if(bIsDefault)
                {
                    Globals.ThisAddIn.dataModel.DefaultTemplate = jt; 
                }
            }

            this.Close();
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
