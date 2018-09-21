using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskList.Helpers
{ 
    public class JQueryDataTablesResponse<T>
    {
        public JQueryDataTablesResponse(IEnumerable<T> items,
            int totalRecords,
            int totalDisplayRecords,
            int sEcho)
        {
            aaData = items;
            iTotalRecords = totalRecords;
            iTotalDisplayRecords = totalDisplayRecords;
            this.sEcho = sEcho;
        }

        public int iTotalRecords { get; private set; }

        public int iTotalDisplayRecords { get; private set; }

        public int sEcho { get; private set; }

        public IEnumerable<T> aaData { get; private set; }
    }
}