namespace OutlookJiraAddIn
{
    partial class RibbonExplorer : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public RibbonExplorer()
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
            Microsoft.Office.Tools.Ribbon.RibbonGroup gJiraReplyMailTab;
            this.bDefaultReplyTabMail = this.Factory.CreateRibbonButton();
            this.mReplyWithMailTab = this.Factory.CreateRibbonMenu();
            this.tJira = this.Factory.CreateRibbonTab();
            this.tJiraOption = this.Factory.CreateRibbonTab();
            this.gReplyOptions = this.Factory.CreateRibbonGroup();
            this.bDefaultReplyJiraTab = this.Factory.CreateRibbonButton();
            this.separator1 = this.Factory.CreateRibbonSeparator();
            this.mReplyWithJiraTab = this.Factory.CreateRibbonMenu();
            this.gEmailSetting = this.Factory.CreateRibbonGroup();
            this.box2 = this.Factory.CreateRibbonBox();
            this.ebToEmail = this.Factory.CreateRibbonEditBox();
            this.box3 = this.Factory.CreateRibbonBox();
            this.cbToField = this.Factory.CreateRibbonCheckBox();
            this.cbCcField = this.Factory.CreateRibbonCheckBox();
            this.cbRemoveRecipients = this.Factory.CreateRibbonCheckBox();
            this.gTemplates = this.Factory.CreateRibbonGroup();
            this.box4 = this.Factory.CreateRibbonBox();
            this.ddDefaultTemplate = this.Factory.CreateRibbonDropDown();
            this.box1 = this.Factory.CreateRibbonBox();
            this.bSetDefault = this.Factory.CreateRibbonButton();
            this.bEditSelected = this.Factory.CreateRibbonButton();
            this.bDeleteSelected = this.Factory.CreateRibbonButton();
            this.separator2 = this.Factory.CreateRibbonSeparator();
            this.bAddNewTemplate = this.Factory.CreateRibbonButton();
            this.gFeedback = this.Factory.CreateRibbonGroup();
            this.bReportBug = this.Factory.CreateRibbonButton();
            this.separator3 = this.Factory.CreateRibbonSeparator();
            this.bAbout = this.Factory.CreateRibbonButton();
            gJiraReplyMailTab = this.Factory.CreateRibbonGroup();
            gJiraReplyMailTab.SuspendLayout();
            this.tJira.SuspendLayout();
            this.tJiraOption.SuspendLayout();
            this.gReplyOptions.SuspendLayout();
            this.gEmailSetting.SuspendLayout();
            this.box2.SuspendLayout();
            this.box3.SuspendLayout();
            this.gTemplates.SuspendLayout();
            this.box4.SuspendLayout();
            this.box1.SuspendLayout();
            this.gFeedback.SuspendLayout();
            // 
            // gJiraReplyMailTab
            // 
            gJiraReplyMailTab.Items.Add(this.bDefaultReplyTabMail);
            gJiraReplyMailTab.Items.Add(this.mReplyWithMailTab);
            gJiraReplyMailTab.Label = "Jira";
            gJiraReplyMailTab.Name = "gJiraReplyMailTab";
            // 
            // bDefaultReplyTabMail
            // 
            this.bDefaultReplyTabMail.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.bDefaultReplyTabMail.Image = global::OutlookJiraAddIn.Properties.Resources.JIRAKB;
            this.bDefaultReplyTabMail.Label = "Reply";
            this.bDefaultReplyTabMail.Name = "bDefaultReplyTabMail";
            this.bDefaultReplyTabMail.ShowImage = true;
            this.bDefaultReplyTabMail.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.bDefaultReply_Click);
            // 
            // mReplyWithMailTab
            // 
            this.mReplyWithMailTab.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.mReplyWithMailTab.Dynamic = true;
            this.mReplyWithMailTab.Image = global::OutlookJiraAddIn.Properties.Resources.Jira400;
            this.mReplyWithMailTab.Label = "Reply with";
            this.mReplyWithMailTab.Name = "mReplyWithMailTab";
            this.mReplyWithMailTab.ShowImage = true;
            // 
            // tJira
            // 
            this.tJira.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tJira.ControlId.OfficeId = "TabMail";
            this.tJira.Groups.Add(gJiraReplyMailTab);
            this.tJira.Label = "TabMail";
            this.tJira.Name = "tJira";
            // 
            // tJiraOption
            // 
            this.tJiraOption.Groups.Add(this.gReplyOptions);
            this.tJiraOption.Groups.Add(this.gEmailSetting);
            this.tJiraOption.Groups.Add(this.gTemplates);
            this.tJiraOption.Groups.Add(this.gFeedback);
            this.tJiraOption.Label = "JIRA";
            this.tJiraOption.Name = "tJiraOption";
            // 
            // gReplyOptions
            // 
            this.gReplyOptions.Items.Add(this.bDefaultReplyJiraTab);
            this.gReplyOptions.Items.Add(this.separator1);
            this.gReplyOptions.Items.Add(this.mReplyWithJiraTab);
            this.gReplyOptions.Label = "Jira";
            this.gReplyOptions.Name = "gReplyOptions";
            // 
            // bDefaultReplyJiraTab
            // 
            this.bDefaultReplyJiraTab.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.bDefaultReplyJiraTab.Image = global::OutlookJiraAddIn.Properties.Resources.JIRAKB;
            this.bDefaultReplyJiraTab.Label = "Reply";
            this.bDefaultReplyJiraTab.Name = "bDefaultReplyJiraTab";
            this.bDefaultReplyJiraTab.ShowImage = true;
            this.bDefaultReplyJiraTab.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.bDefaultReply_Click);
            // 
            // separator1
            // 
            this.separator1.Name = "separator1";
            // 
            // mReplyWithJiraTab
            // 
            this.mReplyWithJiraTab.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.mReplyWithJiraTab.Dynamic = true;
            this.mReplyWithJiraTab.Image = global::OutlookJiraAddIn.Properties.Resources.Jira400;
            this.mReplyWithJiraTab.Label = "Reply with";
            this.mReplyWithJiraTab.Name = "mReplyWithJiraTab";
            this.mReplyWithJiraTab.ShowImage = true;
            // 
            // gEmailSetting
            // 
            this.gEmailSetting.Items.Add(this.box2);
            this.gEmailSetting.Items.Add(this.box3);
            this.gEmailSetting.Label = "Jira Email";
            this.gEmailSetting.Name = "gEmailSetting";
            // 
            // box2
            // 
            this.box2.Items.Add(this.ebToEmail);
            this.box2.Name = "box2";
            // 
            // ebToEmail
            // 
            this.ebToEmail.Label = "Email: ";
            this.ebToEmail.MaxLength = 512;
            this.ebToEmail.Name = "ebToEmail";
            this.ebToEmail.SizeString = "Instead of number, it needs chars to widen the box.";
            this.ebToEmail.Text = null;
            this.ebToEmail.TextChanged += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.ebJiraEmail_TextChanged);
            // 
            // box3
            // 
            this.box3.Items.Add(this.cbToField);
            this.box3.Items.Add(this.cbCcField);
            this.box3.Items.Add(this.cbRemoveRecipients);
            this.box3.Name = "box3";
            // 
            // cbToField
            // 
            this.cbToField.Label = "To Field";
            this.cbToField.Name = "cbToField";
            this.cbToField.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.cbToField_Click);
            // 
            // cbCcField
            // 
            this.cbCcField.Label = "Cc Field";
            this.cbCcField.Name = "cbCcField";
            this.cbCcField.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.cbCcField_Click);
            // 
            // cbRemoveRecipients
            // 
            this.cbRemoveRecipients.Label = "Remove Recipients";
            this.cbRemoveRecipients.Name = "cbRemoveRecipients";
            this.cbRemoveRecipients.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.cbRemoveRecipients_Click);
            // 
            // gTemplates
            // 
            this.gTemplates.Items.Add(this.box4);
            this.gTemplates.Items.Add(this.box1);
            this.gTemplates.Items.Add(this.separator2);
            this.gTemplates.Items.Add(this.bAddNewTemplate);
            this.gTemplates.Label = "Templates";
            this.gTemplates.Name = "gTemplates";
            // 
            // box4
            // 
            this.box4.BoxStyle = Microsoft.Office.Tools.Ribbon.RibbonBoxStyle.Vertical;
            this.box4.Items.Add(this.ddDefaultTemplate);
            this.box4.Name = "box4";
            // 
            // ddDefaultTemplate
            // 
            this.ddDefaultTemplate.Label = "Templates";
            this.ddDefaultTemplate.Name = "ddDefaultTemplate";
            this.ddDefaultTemplate.SizeString = "Make it bigger";
            // 
            // box1
            // 
            this.box1.BoxStyle = Microsoft.Office.Tools.Ribbon.RibbonBoxStyle.Vertical;
            this.box1.Items.Add(this.bSetDefault);
            this.box1.Items.Add(this.bEditSelected);
            this.box1.Items.Add(this.bDeleteSelected);
            this.box1.Name = "box1";
            // 
            // bSetDefault
            // 
            this.bSetDefault.Image = global::OutlookJiraAddIn.Properties.Resources.check;
            this.bSetDefault.Label = "Set Default";
            this.bSetDefault.Name = "bSetDefault";
            this.bSetDefault.ShowImage = true;
            this.bSetDefault.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.bSetDefault_Click);
            // 
            // bEditSelected
            // 
            this.bEditSelected.Image = global::OutlookJiraAddIn.Properties.Resources.new_edit;
            this.bEditSelected.Label = "Edit Selected";
            this.bEditSelected.Name = "bEditSelected";
            this.bEditSelected.ShowImage = true;
            this.bEditSelected.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.bEditSelected_Click);
            // 
            // bDeleteSelected
            // 
            this.bDeleteSelected.Image = global::OutlookJiraAddIn.Properties.Resources.delete;
            this.bDeleteSelected.Label = "Delete Selected";
            this.bDeleteSelected.Name = "bDeleteSelected";
            this.bDeleteSelected.ShowImage = true;
            this.bDeleteSelected.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.bDeleteSelected_Click);
            // 
            // separator2
            // 
            this.separator2.Name = "separator2";
            // 
            // bAddNewTemplate
            // 
            this.bAddNewTemplate.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.bAddNewTemplate.Image = global::OutlookJiraAddIn.Properties.Resources.add;
            this.bAddNewTemplate.Label = "Add New Template";
            this.bAddNewTemplate.Name = "bAddNewTemplate";
            this.bAddNewTemplate.ShowImage = true;
            this.bAddNewTemplate.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.bAddNewTemplate_Click);
            // 
            // gFeedback
            // 
            this.gFeedback.Items.Add(this.bReportBug);
            this.gFeedback.Items.Add(this.separator3);
            this.gFeedback.Items.Add(this.bAbout);
            this.gFeedback.Label = "Feedback";
            this.gFeedback.Name = "gFeedback";
            // 
            // bReportBug
            // 
            this.bReportBug.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.bReportBug.Image = global::OutlookJiraAddIn.Properties.Resources.bug;
            this.bReportBug.Label = "Report Bug";
            this.bReportBug.Name = "bReportBug";
            this.bReportBug.ShowImage = true;
            this.bReportBug.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.bReportBug_Click);
            // 
            // separator3
            // 
            this.separator3.Name = "separator3";
            // 
            // bAbout
            // 
            this.bAbout.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.bAbout.Image = global::OutlookJiraAddIn.Properties.Resources.about;
            this.bAbout.Label = "About";
            this.bAbout.Name = "bAbout";
            this.bAbout.ShowImage = true;
            this.bAbout.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.bAbout_Click);
            // 
            // RibbonExplorer
            // 
            this.Name = "RibbonExplorer";
            this.RibbonType = "Microsoft.Outlook.Explorer";
            this.Tabs.Add(this.tJira);
            this.Tabs.Add(this.tJiraOption);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.RibbonExplorer_Load);
            gJiraReplyMailTab.ResumeLayout(false);
            gJiraReplyMailTab.PerformLayout();
            this.tJira.ResumeLayout(false);
            this.tJira.PerformLayout();
            this.tJiraOption.ResumeLayout(false);
            this.tJiraOption.PerformLayout();
            this.gReplyOptions.ResumeLayout(false);
            this.gReplyOptions.PerformLayout();
            this.gEmailSetting.ResumeLayout(false);
            this.gEmailSetting.PerformLayout();
            this.box2.ResumeLayout(false);
            this.box2.PerformLayout();
            this.box3.ResumeLayout(false);
            this.box3.PerformLayout();
            this.gTemplates.ResumeLayout(false);
            this.gTemplates.PerformLayout();
            this.box4.ResumeLayout(false);
            this.box4.PerformLayout();
            this.box1.ResumeLayout(false);
            this.box1.PerformLayout();
            this.gFeedback.ResumeLayout(false);
            this.gFeedback.PerformLayout();

        }

        #endregion

        public Microsoft.Office.Tools.Ribbon.RibbonTab tJira;
        private Microsoft.Office.Tools.Ribbon.RibbonTab tJiraOption;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup gReplyOptions;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton bDefaultReplyJiraTab;
        public Microsoft.Office.Tools.Ribbon.RibbonButton bDefaultReplyTabMail;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup gTemplates;
        internal Microsoft.Office.Tools.Ribbon.RibbonSeparator separator1;
        public Microsoft.Office.Tools.Ribbon.RibbonMenu mReplyWithJiraTab;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton bEditSelected;
        internal Microsoft.Office.Tools.Ribbon.RibbonCheckBox cbToField;
        internal Microsoft.Office.Tools.Ribbon.RibbonCheckBox cbCcField;
        internal Microsoft.Office.Tools.Ribbon.RibbonCheckBox cbRemoveRecipients;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton bDeleteSelected;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton bAddNewTemplate;
        internal Microsoft.Office.Tools.Ribbon.RibbonMenu mReplyWithMailTab;
        internal Microsoft.Office.Tools.Ribbon.RibbonBox box3;
        internal Microsoft.Office.Tools.Ribbon.RibbonBox box2;
        internal Microsoft.Office.Tools.Ribbon.RibbonBox box4;
        internal Microsoft.Office.Tools.Ribbon.RibbonBox box1;
        internal Microsoft.Office.Tools.Ribbon.RibbonSeparator separator2;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton bSetDefault;
        private Microsoft.Office.Tools.Ribbon.RibbonGroup gEmailSetting;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox ebToEmail;
        private Microsoft.Office.Tools.Ribbon.RibbonDropDown ddDefaultTemplate;
        private Microsoft.Office.Tools.Ribbon.RibbonGroup gFeedback;
        private Microsoft.Office.Tools.Ribbon.RibbonButton bReportBug;
        private Microsoft.Office.Tools.Ribbon.RibbonButton bAbout;
        private Microsoft.Office.Tools.Ribbon.RibbonSeparator separator3;
    }

    partial class ThisRibbonCollection
    {
        internal RibbonExplorer RibbonExplorer
        {
            get { return this.GetRibbon<RibbonExplorer>(); }
        }
    }
}
