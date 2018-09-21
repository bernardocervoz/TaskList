﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskList.Domain.Commons.Helpers
{
    public static class ExtensionMethods
    {
        public static string ToDescription(this Enum value)
        {
            var attributes = (DescriptionAttribute[])value.GetType().GetField(value.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
            string descricao = attributes.Length > 0 ? attributes[0].Description : value.ToString();
            return descricao;
        }
    }
}
