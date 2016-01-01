# OutlookJiraAddIn
Adds a Jira template to generate Jira tickets when responding to an email via Outlook.

At my work, we use Jira (https://www.atlassian.com/software/jira/) to track issues. To create an issue we simply add a Jira server email when replying back to the email which describes the issue. We have to add few details like whom to assign the issue and the category the issue falls in. All this information is added at the top of the message body of the email which we will as Jira Headers.
When you respond with this information added to the email, Jira server creates a ticket and assigns it to the assignee mentioned in the Jira Headers. This became a little repetitive because most of the times the Jira headers are same or needs a little modification for just one or two parameters.

The motivation to develop this Outlook plugin was to address following things:

1. Have a reply button in the Outlook Ribbon which would automatically add the default template when raising a ticket Jira via email.

2. Have an ability to create multiple templates and provide the user with an option to select one of them and reply with that template.

3. Additional templates can be added in the plugin and user can select any of them as default template.

4. User can select the Jira server email in To/Cc section and can even remove the recipients and only send it to Jira server email. To/Cc can be useful if you have mail filters on Outlook to route emails to particular folder. Removing all recipients other than Jira Server email helps reduce the amount of emails everyone gets on the mailing list receives.
