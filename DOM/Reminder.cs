using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOM
{
    public class Reminder
    {
        public DateTime date { get; set; }
        public string description { get; set; }

        public Reminder(DateTime date, string description)
        {
            this.date = date;
            this.description = description;
        }

        public Reminder()
        {

        }
    }
}
