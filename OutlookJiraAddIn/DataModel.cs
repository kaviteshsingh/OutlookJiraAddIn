using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace OutlookJiraAddIn
{
    public class DataModel
    {
        private string _JiraEmail;
        public string JiraEmail
        {
            get { return _JiraEmail; }
            set
            {
                _JiraEmail = value;
                WriteJiraEmailToRegistry();
            }
        }

        private bool _bToEmail;
        public bool bToEmail
        {
            get { return _bToEmail; }
            set
            {
                _bToEmail = value;
                WritebToEmailToRegistry();
            }
        }

        private bool _bCcEmail;
        public bool bCcEmail
        {
            get { return _bCcEmail; }
            set
            {
                _bCcEmail = value;
                WritebCcEmailToRegistry();
            }
        }

        private bool _bRemoveRecipients;
        public bool bRemoveRecipients
        {
            get { return _bRemoveRecipients; }
            set
            {
                _bRemoveRecipients = value;
                WritebRemoveRecipientsToRegistry();
            }
        }

        private JiraTemplate _DefaultTemplate;
        public JiraTemplate DefaultTemplate
        {
            get { return _DefaultTemplate; }
            set
            {
                // This ensures we are copying the values of the passed object and not
                // doing reference copy.
                _DefaultTemplate.Name = value.Name;
                _DefaultTemplate.Content = value.Content;
                WriteDefaultTemplateToRegistry();
            }
        }

        public List<JiraTemplate> JiraTemplates { get; set; }

        public JiraTemplate GetJiraTemplateFromTemplateName(string TemplateName)
        {
            foreach(var item in this.JiraTemplates)
            {
                if(0 == String.Compare(item.Name, TemplateName, true))
                    return item;
            }
            return null;
        }

        public void MarkJiraItemDefault(string jiraTemplateName)
        {
            if(jiraTemplateName != null && jiraTemplateName.Length > 0)
            {
                foreach(JiraTemplate item in this.JiraTemplates)
                {
                    if(0 == String.Compare(item.Name, jiraTemplateName, true))
                    {
                        this.DefaultTemplate = item;
                        break;
                    }
                }
            }
        }

        public void AddJiraTemplateToDataModel(JiraTemplate jiraTemplate)
        {
            if(jiraTemplate == null)
                return;

            this.JiraTemplates.Add(jiraTemplate);
            WriteJiraTemplateItemToRegistry(jiraTemplate);
        }

        public void AddJiraTemplateToDataModel(string Name, string Content)
        {
            if(Name == null || Content == null)
                return;

            JiraTemplate jiraTemplate = new JiraTemplate(Name, Content);
            AddJiraTemplateToDataModel(jiraTemplate);
        }

        public bool RemoveJiraTemplateFromDataModel(string jiraTemplateName)
        {
            // delete the selected item. Also, check if it default item as well.
            // if yes, then pick the first item in the list and make it as default.
            // Also, if only one item is left, then don't delete it.   
            if(jiraTemplateName == null || jiraTemplateName.Length < 1)
                return false;

            string DefaultTemplate = this.DefaultTemplate.Name;

            // minimum 2 is needed: to delete one and fallback on the remaining one.
            if(this.JiraTemplates.Count > 1)
            {
                foreach(JiraTemplate item in this.JiraTemplates)
                {
                    if(0 == String.Compare(item.Name, jiraTemplateName, true))
                    {
                        this.JiraTemplates.Remove(item);
                        DeleteJiraTemplateItemFromRegistry(item);

                        if(0 == String.Compare(jiraTemplateName, DefaultTemplate, true))
                        {
                            // pick first item and make it default.
                            this.DefaultTemplate = this.JiraTemplates[0];
                        }
                        return true;
                    }
                }
            }
            else
            {
                MessageBox.Show("Cannot delete the last remaining template.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false;
        }

        void WriteDefaultTemplateToRegistry()
        {
            //if(Default != null && Default.Name.Length > 0)
            {
                RegistryOperation.CreateBinaryKeyValue(RegistryOperation.szAppRegPathTemplates, RegistryOperation.szKeyNameTemplateDefault, DefaultTemplate.Name);
            }
        }

        void WriteJiraEmailToRegistry()
        {
            //if(JiraEmail != null && JiraEmail.Length > 0)
            {
                RegistryOperation.CreateBinaryKeyValue(RegistryOperation.szAppRegPathGeneral, RegistryOperation.szKeyNameJiraEmail, JiraEmail);
            }
        }

        void WritebToEmailToRegistry()
        {
            if(bToEmail)
            {
                RegistryOperation.CreateBinaryKeyValue(RegistryOperation.szAppRegPathGeneral, RegistryOperation.szKeyNamebToEmail, "1");
            }
            else
            {
                RegistryOperation.CreateBinaryKeyValue(RegistryOperation.szAppRegPathGeneral, RegistryOperation.szKeyNamebToEmail, "0");
            }
        }

        void WritebCcEmailToRegistry()
        {
            if(bCcEmail)
            {
                RegistryOperation.CreateBinaryKeyValue(RegistryOperation.szAppRegPathGeneral, RegistryOperation.szKeyNamebCcEmail, "1");
            }
            else
            {
                RegistryOperation.CreateBinaryKeyValue(RegistryOperation.szAppRegPathGeneral, RegistryOperation.szKeyNamebCcEmail, "0");
            }
        }

        void WritebRemoveRecipientsToRegistry()
        {
            if(bRemoveRecipients)
            {
                RegistryOperation.CreateBinaryKeyValue(RegistryOperation.szAppRegPathGeneral, RegistryOperation.szKeyNamebRemoveRecipients, "1");
            }
            else
            {
                RegistryOperation.CreateBinaryKeyValue(RegistryOperation.szAppRegPathGeneral, RegistryOperation.szKeyNamebRemoveRecipients, "0");
            }
        }

        void WriteJiraTemplateItemToRegistry(JiraTemplate jiraTemplate)
        {
            if(jiraTemplate == null)
                return;

            RegistryOperation.CreateSubKey(RegistryOperation.szAppRegPathTemplates, jiraTemplate.Name);
            RegistryOperation.CreateBinaryKeyValue(RegistryOperation.szAppRegPathTemplates + "\\" + jiraTemplate.Name,
                RegistryOperation.szKeyNameTemplateContent, jiraTemplate.Content);
        }

        void DeleteJiraTemplateItemFromRegistry(JiraTemplate jiraTemplate)
        {
            if(jiraTemplate == null)
                return;

            RegistryOperation.DeleteRegistrySubKey(RegistryOperation.szAppRegPathTemplates, jiraTemplate.Name);

        }

        void WriteJiraTemplateListToRegistry()
        {
            // delete an existing subkey and re-populate from data model
            RegistryOperation.DeleteRegistrySubKey(RegistryOperation.szAppRegPath, RegistryOperation.szSubkeyTemplate);

            // Add all what is in datamodel jira list.
            foreach(JiraTemplate item in JiraTemplates)
            {
                if(
                    item.Name != null && item.Name.Length > 0 &&
                    item.Content != null && item.Content.Length > 0
                    )
                {
                    RegistryOperation.CreateSubKey(RegistryOperation.szAppRegPathTemplates, item.Name);
                    RegistryOperation.CreateBinaryKeyValue(RegistryOperation.szAppRegPathTemplates + "\\" + item.Name,
                        RegistryOperation.szKeyNameTemplateContent, item.Content);
                }
            }
        }

        public DataModel()
        {
            JiraEmail = RegistryOperation.GetBinaryKeyValueInString(RegistryOperation.szAppRegPathGeneral, RegistryOperation.szKeyNameJiraEmail);
            bToEmail = RegistryOperation.GetBinaryKeyValueInBool(RegistryOperation.szAppRegPathGeneral, RegistryOperation.szKeyNamebToEmail);
            bCcEmail = RegistryOperation.GetBinaryKeyValueInBool(RegistryOperation.szAppRegPathGeneral, RegistryOperation.szKeyNamebCcEmail);
            bRemoveRecipients = RegistryOperation.GetBinaryKeyValueInBool(RegistryOperation.szAppRegPathGeneral, RegistryOperation.szKeyNamebRemoveRecipients);

            // if we create using public property then it will crash at setter because of null reference. 
            _DefaultTemplate = new JiraTemplate();

            if(bToEmail == false && bCcEmail == false)
            {
                bToEmail = true;
                // create registry for next time as well
                RegistryOperation.CreateBinaryKeyValue(RegistryOperation.szAppRegPathGeneral, RegistryOperation.szKeyNamebToEmail, "1");
            }

            JiraTemplates = new List<JiraTemplate>();
            string[] TemplateSubKeys = RegistryOperation.GetAppSubKeys(RegistryOperation.szAppRegPathTemplates);
            if(TemplateSubKeys != null && TemplateSubKeys.Length > 0)
            {
                string DefaultTemp = RegistryOperation.GetBinaryKeyValueInString(RegistryOperation.szAppRegPathTemplates, RegistryOperation.szKeyNameTemplateDefault);

                foreach(string keyName in TemplateSubKeys)
                {
                    string data = RegistryOperation.GetBinaryKeyValueInString(RegistryOperation.szAppRegPathTemplates + "\\" + keyName, RegistryOperation.szKeyNameTemplateContent);
                    if(data != null && data.Length > 0)
                    {
                        JiraTemplate jt = new JiraTemplate();
                        jt.Name = keyName;
                        jt.Content = data;
                        JiraTemplates.Add(jt);

                        if(0 == String.Compare(keyName, DefaultTemp, true))
                        {
                            DefaultTemplate = jt;
                        }
                    }
                }
            }
            else
            {
                // create default template and update the registry for next time.
                string szDefaultTemplate = JiraTemplate.GetDefaultTemplateContent();

                RegistryOperation.CreateSubKey(RegistryOperation.szAppRegPathTemplates, RegistryOperation.szSubKeyNameTemplateDefault);
                RegistryOperation.CreateBinaryKeyValue(RegistryOperation.szAppRegPathTemplates + "\\" + RegistryOperation.szSubKeyNameTemplateDefault,
                    RegistryOperation.szKeyNameTemplateContent, szDefaultTemplate);

                JiraTemplate jt = new JiraTemplate();
                jt.Name = RegistryOperation.szSubKeyNameTemplateDefault;
                jt.Content = szDefaultTemplate;
                JiraTemplates.Add(jt);
                DefaultTemplate = jt;
            }
        }

        void WriteDataModelToRegistry()
        {
            WritebCcEmailToRegistry();
            WritebToEmailToRegistry();
            WriteJiraEmailToRegistry();
            WriteJiraTemplateListToRegistry();
            WritebRemoveRecipientsToRegistry();
            WriteDefaultTemplateToRegistry();
        }
    }
}
