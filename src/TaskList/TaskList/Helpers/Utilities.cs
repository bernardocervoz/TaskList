using TaskList.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace TaskList
{
    public static class Utilities
    {
        //public static SelectList GetPeiod(int ano)
        //{
        //    var list = new List<ListItem>();
        //    for (int i = 1; i <= 12; i++)
        //    {
        //        var listItem = new ListItem();
        //        listItem.Text = DateTimeFormatInfo.GetInstance(null).GetMonthName(i).FirstCapitalLetter();
        //        listItem.Value = new DateTime(ano, i, 01).ToShortDateString(); ;
        //        //listItem.Selected = i == DateTime.Now.Month;
        //        list.Add(listItem);
        //    }
        //    return new SelectList(list, "Value", "Text");
        //}

        //public static SelectList GetResultado()
        //{
            //var list = new List<ListItem>();
            //foreach (Resultado item in Enum.GetValues(typeof(Resultado)))
            //{
            //    list.Add
            //    (
            //        new ListItem()
            //        {
            //            Value = ((int)item).ToString(),
            //            Text = item.ToDescription()
            //        }
            //    );
            //}


            //var list = new List<ListItem>()
            //{
            //    new ListItem()
            //    {
            //        Value = "1",
            //        Text ="Individual"
            //    }
            //};


            //return new SelectList(list, "Value", "Text");
        //}

        public static T GetValueFromDescription<T>(string description)
        {
            var type = typeof(T);
            if (!type.IsEnum) throw new InvalidOperationException();
            foreach (var field in type.GetFields())
            {
                var attribute = Attribute.GetCustomAttribute(field,
                    typeof(DescriptionAttribute)) as DescriptionAttribute;
                if (attribute != null)
                {
                    if (attribute.Description == description)
                        return (T)field.GetValue(null);
                }
                else
                {
                    if (field.Name == description)
                        return (T)field.GetValue(null);
                }
            }
            throw new ArgumentException("Not found.", "description");
            // or return default(T);
        }
    }
}