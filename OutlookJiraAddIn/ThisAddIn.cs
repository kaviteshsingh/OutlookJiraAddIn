using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;
using Word = Microsoft.Office.Interop.Word;



/* 
 * Useful links
 * http://blogs.msdn.com/b/vsto/archive/2009/12/15/making-a-custom-group-appear-in-the-message-tab-of-a-mail-item-norm-estabrook.aspx
 * https://msdn.microsoft.com/en-us/library/cc668191.aspx
 * http://blogs.msdn.com/b/vsto/archive/2008/12/19/setting-the-width-of-a-drop-down-combo-box-or-edit-box-in-the-ribbon-designer.aspx
 * https://www.add-in-express.com/creating-addins-blog/2012/10/19/customize-outlook2013-inline-response/
 * https://msdn.microsoft.com/en-us/library/bhczd18c.aspx
 * https://msdn.microsoft.com/en-us/library/bb157876.aspx
 * http://stackoverflow.com/questions/12021797/how-to-access-methods-in-thisaddin-cs-file
 * https://msdn.microsoft.com/en-us/library/ms268994.aspx
 * https://msdn.microsoft.com/en-us/library/office/ff866458.aspx
 * https://msdn.microsoft.com/en-us/library/dd492012(v=office.12).aspx
 * http://stackoverflow.com/questions/6124865/c-sharp-vsto-add-in-convert-plain-text-email-to-html
 * https://www.add-in-express.com/creating-addins-blog/2015/02/23/outlook-htmlbody-guide/
 * https://msdn.microsoft.com/en-us/library/2a9dt54a.aspx
 * https://www.iconfinder.com/
 * 
 * Deploy
 * https://msdn.microsoft.com/en-us/library/bb772100.aspx
 * https://msdn.microsoft.com/en-us/library/xc3tc5xx.aspx
 */

namespace OutlookJiraAddIn
{
    public partial class ThisAddIn
    {
        public string Author = "Kavitesh Singh";
        public string AuthorEmail = "kaviteshsingh@ymail.com";
        public DataModel dataModel { get; set; }
        public Outlook.Inspectors inspectors { get; set; }

        void CreateNewMailItem(string toEmail, string Subject)
        {
            Outlook.MailItem mailItem = (Outlook.MailItem)this.Application.CreateItem(Outlook.OlItemType.olMailItem);

            mailItem.Subject = Subject;
            Outlook.Recipient rcTo = mailItem.Recipients.Add(toEmail);
            rcTo.Type = (int)Outlook.OlMailRecipientType.olTo;
            mailItem.Recipients.ResolveAll();
            mailItem.Display();
        }

        public void ReportFeedback()
        {
            CreateNewMailItem(AuthorEmail, "[OutlookJiraAddin]: Feedback: ");
        }
        
        public void ReportBug()
        {
            CreateNewMailItem(AuthorEmail, "[OutlookJiraAddin]: Bug: ");
        }

        public void AddTemplateDataToMailItem(Outlook._MailItem mailItem, JiraTemplate jiraTemplate)
        {
            /* https://msdn.microsoft.com/EN-US/library/office/ff863703.aspx
             * Depending on the type of recipient, this property returns or sets a Long corresponding to the numeric equivalent of one of the following constants:
             *      JournalItem recipient: the OlJournalRecipientType constant olAssociatedContact.
             *      MailItem recipient: one of the following OlMailRecipientType constants: olBCC, olCC, olOriginator, or olTo.
             *      MeetingItem recipient: one of the following OlMeetingRecipientType constants: olOptional, olOrganizer, olRequired, or olResource.
             *      TaskItem recipient: either of the following OlTaskRecipientType constants: olFinalStatus, or olUpdate.
             *  Name                          Value                         Description
             *  olBCC                           3                           The recipient is specified in the BCC property of the Item.
             *  olCC                            2                           The recipient is specified in the CC property of the Item.
             *  olOriginator                    0                           Originator (sender) of the Item.
             *  olTo                            1                           The recipient is specified in the To property of the Item.
             *  
             * https://msdn.microsoft.com/en-us/library/office/ff184598.aspx
             * 
            */

            if(dataModel.bRemoveRecipients)
            {
                // Dont use the for loop because the index changes every time item is 
                // deleted. The below loop ensures all objects are removed without
                // keeping track of the index. it removes the first item in the list
                // Also Remove(i) where remove expects the array index to be 1-based
                // instead of 0. 
                while(mailItem.Recipients.Count > 0)
                {
                    mailItem.Recipients.Remove(1);
                }
            }

            if(dataModel.bToEmail)
            {
                //mailItem.To = mailItem.To + ";" + dataModel.JiraEmail;
                Outlook.Recipient rcTo = mailItem.Recipients.Add(dataModel.JiraEmail);
                rcTo.Type = (int)Outlook.OlMailRecipientType.olTo;
                mailItem.Recipients.ResolveAll();
            }

            if(dataModel.bCcEmail)
            {
                //mailItem.CC = mailItem.CC + ";" + dataModel.JiraEmail;
                Outlook.Recipient rcCc = mailItem.Recipients.Add(dataModel.JiraEmail);
                rcCc.Type = (int)Outlook.OlMailRecipientType.olCC;
                mailItem.Recipients.ResolveAll();
            }

            try
            {
                Word.Document word = mailItem.GetInspector.WordEditor;
                Word.Range range = word.Range(0, 0);
                range.InsertAfter(jiraTemplate.Content);
            }
            catch(Exception)
            {
                // Don't do anything.

            }

            // tried below options but seems like only way to keep formatting in both html and rich text is to 
            // use the word editor option to insert text and keep fonts correct.
            //switch(mailItem.BodyFormat)
            //{
            //    //case Outlook.OlBodyFormat.olFormatHTML:
            //    //    mailItem.HTMLBody = JiraTemplate.ConvertTextToHTML(dataModel.JiraTemplates[0].Content) + mailItem.HTMLBody;
            //    //    break;

            //    default:
            //        {
            //            Word.Document word = mailItem.GetInspector.WordEditor;
            //            Word.Range range = word.Range(0, 0);
            //            range.InsertAfter(dataModel.JiraTemplates[0].Content);

            //            //word.Content.SetRange(0, 0);
            //            //word.Content.Text = dataModel.JiraTemplates[0].Content + word.Content.Text;
            //        }
            //        break;
            //    //case Outlook.OlBodyFormat.olFormatRichText:
            //    //    {
            //    //        //http://stackoverflow.com/questions/415291/best-way-to-combine-two-or-more-byte-arrays-in-c-sharp
            //    //        byte[] template = RegistryOperation.ToBinaryData(dataModel.JiraTemplates[0].Content);
            //    //        byte[] rtfBody = mailItem.RTFBody;
            //    //        byte[] result = new byte[template.Length + rtfBody.Length];

            //    //        System.Buffer.BlockCopy(template, 0, result, 0, template.Length);
            //    //        System.Buffer.BlockCopy(rtfBody, 0, result, template.Length, rtfBody.Length);
            //    //        mailItem.RTFBody = result;
            //    //    }
            //    //    break;

            //    //default:
            //    //    mailItem.Body = dataModel.JiraTemplates[0].Content + mailItem.Body;
            //    //    break;
            //}
        }

        public void HandleReplyWithTemplate(JiraTemplate jiraTemplate)
        {
            if(dataModel.JiraEmail == null || dataModel.JiraEmail.Length < 1)
            {
                MessageBox.Show("Invalid Jira Email.\nPlease update email address in Jira Tab.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(jiraTemplate == null)
            {
                // fallback to default
                jiraTemplate = dataModel.DefaultTemplate;
            }

            try
            {
                Outlook._Explorer exp = Globals.ThisAddIn.Application.ActiveExplorer();
                if(exp != null && exp.Selection != null && exp.Selection.Count > 0)
                {
                    foreach(Object item in exp.Selection)
                    {
                        if(item is Outlook._MailItem)
                        {
                            Outlook._MailItem mailItem = (item as Outlook._MailItem);
                            Outlook._MailItem reply = mailItem.ReplyAll();

                            AddTemplateDataToMailItem(reply, jiraTemplate);
                            reply.Display();
                        }
                    }
                }
            }
            catch(Exception Ex)
            {
                // To see this exception: Click on the email folders tree's top node i.e. the one which shows like a startup page
                // and contains Calendar information, tasks and messages overview. After that from ribbon click on the reply button.
                // http://stackoverflow.com/questions/17211827/how-to-check-if-a-vsto-outlook-explorer-object-has-been-closed
                // Ex.Message = "The Explorer has been closed and cannot be used for further operations. Review your code and restart Outlook."
                // Outlook gives valid explorer but selection paramter generates exception.
                //MessageBox.Show(Ex.Message + "\n" + Ex.StackTrace, "Error!!!");
                RegistryOperation.CreateBinaryKeyValue(RegistryOperation.szAppRegPathGeneral, RegistryOperation.szKeyNameLastError,
                    Ex.Message.ToString() + "\n" + Ex.StackTrace.ToString());
            }
        }

        public void InsertDefaultTemplateInReply(JiraTemplate jiraTemplate)
        {
            if(dataModel.JiraEmail == null || dataModel.JiraEmail.Length < 1)
            {
                MessageBox.Show("Invalid Jira Email.\nPlease update email address in Jira Tab.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Outlook.Inspector Inspector = Globals.ThisAddIn.Application.ActiveInspector();
            if(Inspector != null)
            {
                if(jiraTemplate == null)
                    jiraTemplate = dataModel.DefaultTemplate;

                Outlook._MailItem reply = Inspector.CurrentItem as Outlook._MailItem;
                if(reply != null)
                {
                    AddTemplateDataToMailItem(reply, jiraTemplate);
                }
            }
        }

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            try
            {
                this.dataModel = new DataModel();
                inspectors = this.Application.Inspectors;
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
            // https://msdn.microsoft.com/en-us/library/ee720183(v=office.14).aspx
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }



        #endregion
    }
}
