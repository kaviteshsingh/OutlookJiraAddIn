using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace OutlookJiraAddIn
{
    public class RegistryOperation
    {
        public static readonly string szAppRegPath = "Software\\KaviteshSingh\\OutlookJiraAddin";
        public static readonly string szSubkeyGeneral = "General";
        public static readonly string szSubkeyTemplate = "Templates";

        public static readonly string szAppRegPathGeneral = "Software\\KaviteshSingh\\OutlookJiraAddin\\General";
        public static readonly string szKeyNameJiraEmail = "JiraEmail";
        public static readonly string szKeyNamebToEmail = "bToEmail";
        public static readonly string szKeyNamebCcEmail = "bCcEmail";
        public static readonly string szKeyNamebRemoveRecipients = "bRemoveRecipients";
        public static readonly string szKeyNameLastError = "LastError";

        public static readonly string szAppRegPathTemplates = "Software\\KaviteshSingh\\OutlookJiraAddin\\Templates";
        public static readonly string szKeyNameTemplateDefault = "DefaultTemplateName";
        public static readonly string szSubKeyNameTemplateDefault = "Default";
        public static readonly string szKeyNameTemplateContent = "Content";

        public static byte[] ToBinaryData(string StringData)
        {
            if(StringData != null && StringData.Length > 0)
            {
                System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
                return encoding.GetBytes(StringData);
            }
            return null;
        }

        public static string ToStringData(byte[] BinData)
        {
            if(BinData != null && BinData.Length > 0)
            {
                System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
                return encoding.GetString(BinData);
            }
            return null;
        }

        public static String GetBinaryKeyValueInString(string szRegPath, string KeyName)
        {
            RegistryKey rk = OpenAppRegKey(szRegPath);

            byte[] data = rk.GetValue(KeyName, null) as byte[];

            if(data != null)
            {
                return ToStringData(data);
            }
            else
                return null;
        }

        public static Int64 GetBinaryKeyValueInInt64(string szRegPath, string KeyName, long DefaultValue)
        {
            string szData = GetBinaryKeyValueInString(szRegPath, KeyName);
            long output = 0;
            if(Int64.TryParse(szData, out output))
            {
                return output;
            }
            else
                return DefaultValue;
        }

        public static bool GetBinaryKeyValueInBool(string szRegPath, string KeyName)
        {
            Int64 value = GetBinaryKeyValueInInt64(szRegPath, KeyName, 0);

            if(value != 0)
                return true;
            else
                return false;
        }

        public static bool CreateBinaryKeyValue(string szRegPath, string KeyName, string Data)
        {
            bool status = false;
            byte[] binData = ToBinaryData(Data);
            RegistryKey rk = OpenAppRegKey(szRegPath);

            if(rk == null)
                return false;

            try
            {
                rk.SetValue(KeyName, binData, RegistryValueKind.Binary);
                status = true;
            }
            catch(Exception Ex)
            {
                Console.WriteLine(Ex.Message);
                status = false;
            }
            finally
            {
                rk.Close();
            }
            return status;
        }

        public static bool CreateSubKey(string szRegPath, string SubKeyName)
        {
            bool status = false;
            RegistryKey rk = OpenAppRegKey(szRegPath);

            if(rk == null)
                return false;

            try
            {
                rk.CreateSubKey(SubKeyName, RegistryKeyPermissionCheck.ReadWriteSubTree);
                status = true;
            }
            catch(Exception Ex)
            {
                Console.WriteLine(Ex.Message);
                status = false;
            }
            finally
            {
                rk.Close();
            }
            return status;
        }

        public static String[] GetAppSubKeys(string szRegPath)
        {
            RegistryKey rk = OpenAppRegKey(szRegPath);

            if(null != rk)
            {
                String[] SubKeys = rk.GetSubKeyNames();
                rk.Close();
                return SubKeys;
            }
            else
                return null;
        }

        public static RegistryKey OpenAppRegKey(string szRegPath)
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey(szRegPath, true);
            if(null == rk)
            {
                rk = Registry.CurrentUser.CreateSubKey(szRegPath, RegistryKeyPermissionCheck.ReadWriteSubTree);
            }

            return rk;
        }

        public static void DeleteRegistrySubKey(string szRegPath, string SubKeyName)
        {
            RegistryKey rk = OpenAppRegKey(szRegPath);

            if(rk == null)
                return;

            rk.DeleteSubKey(SubKeyName, false);
        }

    }

}
