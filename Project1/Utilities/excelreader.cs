using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop;
using Microsoft.Office.Interop.Excel;
using Project1.Framework;

namespace Project1.Utilities
{
    public class excelreader
    {
        public static Application xlapp;
        public static Workbook xlworkbook;
        public static Worksheet xlworksheet;
        public static Range xlrange;

        public static int lastrowno;
        public static int lastcolno;

        //  Load excel fine and store no. of rows and no. of columns.
        public static void loadexcel(string filename)
        {
            xlapp = new Application();
            xlworkbook = xlapp.Workbooks.Open(constants.projectpath + @"\Testdata\" + filename + ".xlsx");
            xlworksheet = xlworkbook.Sheets[1];
            xlrange = xlworksheet.UsedRange;
            lastrowno = xlrange.Rows.Count;
            lastcolno = xlrange.Columns.Count;
        }

        // Read excel file and store values in "key value" pairs
        public static Dictionary<string,string> getdata(string filename)
        {
            Dictionary<string, string> dicdata = new Dictionary<string, string>();

            loadexcel(filename);
            lastrowno = xlrange.Rows.Count;
            lastcolno = xlrange.Columns.Count;

            for(int i=1; i<=lastcolno; i++)
            {
                dicdata.Add(xlrange.Cells[1, i].Value2.ToString(),
                            xlrange.Cells[2, i].Value2.ToString());

            }

            closeexcel();

            return dicdata;
        }

        public static void closeexcel()
        {
            xlworkbook.Close();
            xlapp.Quit();
            System.Threading.Thread.Sleep(5000);
        }



    }
}
