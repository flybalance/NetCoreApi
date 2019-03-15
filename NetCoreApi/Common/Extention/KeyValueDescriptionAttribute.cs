using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace NetCoreApi.Common.Extention
{
    public class KeyValueDescriptionAttribute : DescriptionAttribute
    {
        public KeyValueDescriptionAttribute(string code)
           : base(code)
        {
        }

        public KeyValueDescriptionAttribute(string code, string message)
            : base(code)
        {
            Message = message;
        }

        public string Message { get; set; }
    }

    public static class EnumOperate
    {
        /// <summary>
        /// 扩展方法：获得枚举的自定义Description
        /// </summary>
        /// <param name="value">枚举值</param>
        /// <param name="nameInstead">当枚举值没有定义DescriptionAttribute，是否使用枚举名代替，默认是使用</param>
        /// <returns>枚举的Description</returns>
        public static EnumItem GetBaseDescription(this Enum value, bool nameInstead = true)
        {
            EnumItem e = new EnumItem();

            Type type = value.GetType();
            string name = Enum.GetName(type, value);
            if (string.IsNullOrEmpty(name))
            {
                return null;
            }

            FieldInfo field = type.GetField(name);
            KeyValueDescriptionAttribute attribute = Attribute.GetCustomAttribute(field, typeof(KeyValueDescriptionAttribute)) as KeyValueDescriptionAttribute;

            if (null == attribute && nameInstead)
            {
                e.Code = name;
                e.Message = name;
            }
            else
            {
                e.Code = attribute.Description;
                e.Message = attribute.Message;
            }

            return e;
        }

        /// <summary>
        /// 扩展方法：获得枚举的Description
        /// </summary>
        /// <param name="value">枚举值</param>
        /// <param name="nameInstead">当枚举值没有定义DescriptionAttribute，是否使用枚举名代替，默认是使用</param>
        /// <returns>枚举的Description</returns>
        public static string GetDescription(this Enum value, bool nameInstead = true)
        {
            Type type = value.GetType();
            string name = Enum.GetName(type, value);
            if (string.IsNullOrEmpty(name))
            {
                return null;
            }

            FieldInfo field = type.GetField(name);
            DescriptionAttribute attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;

            if (null == attribute && nameInstead)
            {
                return name;
            }

            return attribute?.Description;
        }

        /// <summary>
        /// 把枚举转换为键值对集合
        /// <![CDATA[Dictionary<Int32, String> dic = EnumUtil.EnumToDictionary(typeof(Season), e => e.GetDescription());]]>
        /// </summary>
        /// <param name="enumType">枚举类型</param>
        /// <param name="getText">获得值得文本</param>
        /// <returns>以枚举值为key，枚举文本为value的键值对集合</returns>
        public static Dictionary<int, string> EnumToDictionary(Type enumType, Func<Enum, string> getText)
        {
            if (!enumType.IsEnum)
            {
                throw new ArgumentException("传入的参数必须是枚举类型", "enumType");
            }

            Dictionary<int, string> enumDic = new Dictionary<int, string>();

            Array enumValues = Enum.GetValues(enumType);
            foreach (Enum enumValue in enumValues)
            {
                int key = Convert.ToInt32(enumValue);
                string value = getText(enumValue);

                enumDic.Add(key, value);
            }

            return enumDic;
        }

        /// <summary>
        /// 获取枚举的相关信息
        /// </summary>
        /// <param name="e">枚举的类型</param>
        /// <returns></returns>
        public static List<EnumItem> GetEnumItems(Type e)
        {
            List<EnumItem> itemList = new List<EnumItem>();

            foreach (Enum v in Enum.GetValues(e))
            {
                EnumItem item = v.GetBaseDescription();
                item.EnumKey = Convert.ToInt32(v);
                item.EnumValue = v.ToString();

                itemList.Add(item);
            }

            return itemList;
        }

        public class EnumItem
        {
            public int EnumKey { get; set; }

            public string EnumValue { get; set; }

            public string Code { get; set; }

            public string Message { get; set; }
        }
    }
}