namespace OutlookJiraAddIn
{
    partial class RibbonReadMessageTab : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        RibbonExplorer ribbonExplorer;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public RibbonReadMessageTab()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
            // kavi
            ribbonExplorer = new RibbonExplorer();
            this.tabReadMessage.Groups.Add(ribbonExplorer.gReplyOptions);
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
            this.tabReadMessage = this.Factory.CreateRibbonTab();
            this.tabReadMessage.SuspendLayout();
            // 
            // tabReadMessage
            // 
            this.tabReadMessage.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tabReadMessage.ControlId.OfficeId = "TabReadMessage";
            this.tabReadMessage.Label = "TabReadMessage";
            this.tabReadMessage.Name = "tabReadMessage";
            // 
            // RibbonReadMessageTab
            // 
            this.Name = "RibbonReadMessageTab";
            this.RibbonType = "Microsoft.Outlook.Mail.Read";
            this.Tabs.Add(this.tabReadMessage);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.Ribbon1_Load);
            this.tabReadMessage.ResumeLayout(false);
            this.tabReadMessage.PerformLayout();

        }

        #endregion

        public Microsoft.Office.Tools.Ribbon.RibbonTab tabReadMessage;
    }

    partial class ThisRibbonCollection
    {
        internal RibbonReadMessageTab Ribbon1
        {
            get { return this.GetRibbon<RibbonReadMessageTab>(); }
        }
    }
}
