using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskList.Helpers
{
    public class MessageDialog
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public HtmlString Buttons { get; set; }
        public bool Modal { get; set; }

        public MessageDialog(string title, string message, bool modal)
        {
            Title = title;
            Message = message;
            Buttons = new HtmlString("");
            Modal = modal;
        }

        public MessageDialog(string title, string message, bool modal, HtmlString buttons)
        {
            Title = title;
            Message = message;
            Buttons = buttons;
            Modal = modal;
        }
    }
}