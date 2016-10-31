using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Collections;
using System.Drawing;
using System.Dynamic;

namespace NADACommonCalibrator
{
    public class SheetItems
    {
        public string RecommandNextCalibDate;
        public List<object[]> Items = new List<object[]>();

        public SheetItems(List<object> items)
        {
            RecommandNextCalibDate =  "※ 권장 차기 교정일 : " + DateTime.Now.AddYears(1).ToString("yyyy.MM.dd");
            foreach (var obj in items)
            {
                ExpandoObject expandObj = obj as ExpandoObject;
                List<object> objs = new List<object>();
                foreach (var e in expandObj)
                    objs.Add(e.Value);
                Items.Add(objs.ToArray());
            }
        }
    }

    public class ExcelIOManager
    {
        public void CreateExcel(string templateFileName, string savePath, SheetItems items)
        {
            Excel.Application excel = null;
            Excel.Workbook workbook = null;
            try
            {
                excel = new Excel.Application();
                workbook = excel.Workbooks.Open(Application.StartupPath+"\\ReportTemplate\\"+templateFileName);
                GenerateReport(workbook, items);
                workbook.SaveAs(savePath);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                workbook.Close(false);
                ReleaseObject(ref workbook);
                excel.Quit();
                ReleaseObject(ref excel);
            }
        }

        private void GenerateReport(Excel.Workbook workbook, SheetItems sheetItems)
        {
            Excel.Worksheet worksheet = workbook.Worksheets.get_Item(1) as Excel.Worksheet;

            var cell_recommandDate = worksheet.Cells.Find("$RecommandNextClaibDate");
            if (cell_recommandDate != null) cell_recommandDate.Value = sheetItems.RecommandNextCalibDate;

            var cell_dataArea1 = worksheet.Cells.Find("$DataArea");
            if (cell_dataArea1 != null)
            {
                int num = 12;
                foreach (var item in sheetItems.Items)
                {
                    var range2 = worksheet.get_Range("D" + num, "M" + num++);
                    range2.Value2 = item;
                    ReleaseObject(ref range2);
                }
            }
            ReleaseObject(ref worksheet);
        }

        private static void ReleaseObject<T>(ref T obj) where T : class
        {
            if (obj != null && Marshal.IsComObject(obj))
            {
                Marshal.ReleaseComObject(obj);
            }
            obj = null;
        }
    }
}
