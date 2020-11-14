using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.IO;
using System.Data.OleDb;
using System.Data;
using ExcelDataReader;

namespace WebApplication1
{
    public partial class ExcelTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            if (FP.PostedFile.ContentLength <= 0)
            {
                Label1.Text = "vacio";
            }

            //Get the file extension  
            string fileExtension = Path.GetExtension(FP.FileName);

            //If file is not in excel format then return  
            if (fileExtension != ".xls" && fileExtension != ".xlsx")
            { Label1.Text = "no es de excel"; }
            else { 
            
            string path = Server.MapPath("~/excelstemp/" + FP.FileName);
            //////saving the file inside the MyFolder of the server
            FP.SaveAs(path);
            using (var stream = File.Open(path, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var result = reader.AsDataSet();
                    DataTable table = result.Tables[0];
                    DataRow row = table.Rows[0];
                    string cell = row[1].ToString();
                    Label1.Text = cell;
                    //DataTable table = result.Tables[0];
                    //GridView1.DataSource = table;
                    //GridView1.DataBind();
                }
            }
            File.Delete(path);
            }


           

           

        }

    }
}
