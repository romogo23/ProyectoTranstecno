using BL;
using DOM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI
{
    public partial class LoadTemplate : System.Web.UI.Page
    {
        private Hashtable _schedleData;

        protected void Page_Load(object sender, EventArgs e)
        {
            _schedleData = GetSchedule();

            Calendar1.FirstDayOfWeek = FirstDayOfWeek.Sunday;
            Calendar1.NextPrevFormat = NextPrevFormat.ShortMonth;
            Calendar1.TitleFormat = TitleFormat.MonthYear;
            Calendar1.ShowGridLines = true;
            Calendar1.DayStyle.HorizontalAlign = HorizontalAlign.Left;
            Calendar1.DayStyle.VerticalAlign = VerticalAlign.Top;
            Calendar1.DayStyle.Height = new Unit(75);
            Calendar1.DayStyle.Width = new Unit(100);
            Calendar1.OtherMonthDayStyle.BackColor = System.Drawing.Color.LightGray;
        }

        private Hashtable GetSchedule()
        {
            Hashtable schedule = new Hashtable();
            List<Reminder> reminderClientList = new List<Reminder>();
            List<Reminder> reminderSupplierList = new List<Reminder>();
            InvoiceClientManager clientMan = new InvoiceClientManager();
            InvoiceSupplierManager supplierMan = new InvoiceSupplierManager();

            reminderClientList = clientMan.LoadClientMonthReminder();
            reminderSupplierList = supplierMan.LoadSupplierMonthReminder();

            foreach (Reminder rem in reminderClientList)
            {
                schedule[rem.date.ToShortDateString()] = "Cliente: "  + rem.description;
            }
            foreach (Reminder remS in reminderSupplierList)
            {
                schedule[remS.date.ToShortDateString()] = "Proveedor: " + remS.description;
            }

            return schedule;
        }

        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            if (_schedleData[e.Day.Date.ToShortDateString()] != null)
            {
                Literal lit = new Literal();
                lit.Text = "<br/>";
                e.Cell.Controls.Add(lit);

                Label lbl = new Label();
                lbl.Text = (String)_schedleData[e.Day.Date.ToShortDateString()];
                lbl.Font.Size = new FontUnit(FontSize.Smaller);
                lbl.ForeColor = System.Drawing.Color.DarkOrange;
                e.Cell.Controls.Add(lbl);
            }
        }
    }
}