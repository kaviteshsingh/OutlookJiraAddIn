using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutlookJiraAddIn
{
    public class JiraTemplate
    {
        public string Name { get; set; }
        public string Content { get; set; }

        public JiraTemplate()
        {
            this.Name = null;
            this.Content = null;
        }

        public JiraTemplate(string Name, string Content)
        {
            this.Name = Name;
            this.Content = Content;
        }

        public JiraTemplate(JiraTemplate jiraTemplate)
        {
            this.Name = jiraTemplate.Name;
            this.Content = jiraTemplate.Content;
        }

        public static string GetDefaultTemplateContent()
        {
            string data = "@assignee=" + Environment.UserName + "\n" + "@labels= \n" + "@components= \n" + "@chipset= \n";
            //string data = "<html><body><p>@assignee=" + Environment.UserName + "<br>" + "@labels= <br>" + "@components= <br>" + "@chipset= </p></body></html>";
            return data;
        }

        //public static string ConvertTextToHTML(string PlainText)
        //{
        //    StringBuilder sb = new StringBuilder(PlainText.Length * 2);

        //    sb.Append("<html><body><p>");

        //    sb.Append(PlainText);
        //    sb.Replace("\n\r", "<br>");
        //    sb.Replace("\r\n", "<br>");
        //    sb.Replace("\n", "<br>");
        //    sb.Replace("\r", "<br>");

        //    sb.Append("</p></body></html>");

        //    return sb.ToString();
        //}
    }

}
