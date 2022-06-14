using System.ComponentModel;
using System.Reflection;

namespace TestZhilfond.Models.Enums
{
    public enum DateGroupTypeEnum
    {
        [Description("День")]
        Day,

        [Description("Неделя")]
        Week,

        [Description("Месяц")]
        Month,

        [Description("Год")]
        Year,

        [Description("Квартал")]
        Quarter
    }

    public static class DateGroupTypeEnumExtensions
    {
        public static DateGroupTypeEnum GetEnum (string typeName)
        {
            switch (typeName)
            {
                case "day": return DateGroupTypeEnum.Day;
                case "week": return DateGroupTypeEnum.Week;
                case "month": return DateGroupTypeEnum.Month;
                case "year": return DateGroupTypeEnum.Year;
                case "quarter": return DateGroupTypeEnum.Quarter;
                default: throw new ArgumentException("Неверно задано название периода");
            }
        }

        public static string GetEnumName (DateGroupTypeEnum typeEnum)
        {
            string output = null;
            Type type = typeEnum.GetType();
            FieldInfo fi = type.GetField(typeEnum.ToString());
            var attrs = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

            if (attrs.Length > 0) 
            { 
                output = attrs[0].Description; 
            }

            return output;
        }
    }
}
