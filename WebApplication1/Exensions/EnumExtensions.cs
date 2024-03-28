using System;
using System.ComponentModel.DataAnnotations;

namespace EStore.Exensions
{
    public static class EnumExtensions
    {
        public static string GetDisplayName(this Enum enumValue)
        {
            var displayAttribute = enumValue.GetType()
                                           .GetMember(enumValue.ToString())
                                           .First()
                                           .GetCustomAttributes(typeof(DisplayAttribute), false)
                                           .FirstOrDefault() as DisplayAttribute;

            return displayAttribute != null ? displayAttribute.GetName() : enumValue.ToString();
        }
    }
}
