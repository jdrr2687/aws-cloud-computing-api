using System;
using System.ComponentModel;
using System.Reflection;

namespace Amazon.Integration.Utils
{
    public static class ExtensionMethods
    {
        public static string GetDescription(this Enum enumObj)
        {
            if (enumObj == null)
                return string.Empty;

            FieldInfo fieldInfo = enumObj.GetType().GetField(enumObj.ToString());
            object[] attribArray = fieldInfo.GetCustomAttributes(false);

            for (int i = 0; i < attribArray.Length; i++)
            {
                if (attribArray[i].ToString().Contains("Description"))
                    return ((DescriptionAttribute)attribArray[i]).Description;
            }
            return string.Empty;
        }
    }
}
