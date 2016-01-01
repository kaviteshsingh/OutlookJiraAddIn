namespace OutlookJiraAddIn
{
    partial class RibbonComposeMessageTab : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public RibbonComposeMessageTab()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if(disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabNewMessage = this.Factory.CreateRibbonTab();
            this.gJiraInsert = this.Factory.CreateRibbonGroup();
            this.bInsertDefault = this.Factory.CreateRibbonButton();
            this.mInsertTemplate = this.Factory.CreateRibbonMenu();
            this.tabNewMessage.SuspendLayout();
            this.gJiraInsert.SuspendLayout();
            // 
            // tabNewMessage
            // 
            this.tabNewMessage.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tabNewMessage.ControlId.OfficeId = "TabNewMailMessage";
            this.tabNewMessage.Groups.Add(this.gJiraInsert);
            this.tabNewMessage.Label = "TabNewMailMessage";
            this.tabNewMessage.Name = "tabNewMessage";
            // 
            // gJiraInsert
            // 
            this.gJiraInsert.Items.Add(this.bInsertDefault);
            this.gJiraInsert.Items.Add(this.mInsertTemplate);
            this.gJiraInsert.Label = "Jira";
            this.gJiraInsert.Name = "gJiraInsert";
            // 
            // bInsertDefault
            // 
            this.bInsertDefault.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.bInsertDefault.Image = global::OutlookJiraAddIn.Properties.Resources.JIRAKB;
            this.bInsertDefault.Label = "Insert";
            this.bInsertDefault.Name = "bInsertDefault";
            this.bInsertDefault.ShowImage = true;
            this.bInsertDefault.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.bInsertDefault_Click);
            // 
            // mInsertTemplate
            // 
            this.mInsertTemplate.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.mInsertTemplate.Dynamic = true;
            this.mInsertTemplate.Image = global::OutlookJiraAddIn.Properties.Resources.Jira400;
            this.mInsertTemplate.Label = "Insert Template";
            this.mInsertTemplate.Name = "mInsertTemplate";
            this.mInsertTemplate.ShowImage = true;
            // 
            // RibbonComposeMessageTab
            // 
            this.Name = "RibbonComposeMessageTab";
            this.RibbonType = "Microsoft.Outlook.Mail.Compose, Microsoft.Outlook.Response.Compose";
            this.Tabs.Add(this.tabNewMessage);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.RibbonMessageTab_Load);
            this.tabNewMessage.ResumeLayout(false);
            this.tabNewMessage.PerformLayout();
            this.gJiraInsert.ResumeLayout(false);
            this.gJiraInsert.PerformLayout();

        }

        #endregion

        public Microsoft.Office.Tools.Ribbon.RibbonTab tabNewMessage;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup gJiraInsert;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton bInsertDefault;
        internal Microsoft.Office.Tools.Ribbon.RibbonMenu mInsertTemplate;

    }

    partial class ThisRibbonCollection
    {
        internal RibbonComposeMessageTab RibbonMessageTab
        {
            get { return this.GetRibbon<RibbonComposeMessageTab>(); }
        }
    }
}
