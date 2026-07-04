using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Enums.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDisplayName(this Enum value)
        {
            var member = value.GetType().GetMember(value.ToString()).FirstOrDefault();

            if (member != null)
            {
                var display = member.GetCustomAttribute<DisplayAttribute>();
                if (display != null)
                    return display.Name!;
            }

            return value.ToString();
        }
    }
}
