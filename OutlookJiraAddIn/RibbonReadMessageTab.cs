using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;

namespace OutlookJiraAddIn
{
    public partial class RibbonReadMessageTab
    {
        private void Ribbon1_Load(object sender, RibbonUIEventArgs e)
        {
            ribbonExplorer.PopulateTemplatesFromDataModel();
        }
    }
}
