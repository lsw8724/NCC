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
        public List<List<object[]>> ItemsList = new List<List<object[]>>();

        public SheetItems(params List<object>[] items)
        {
            RecommandNextCalibDate =  "※ 권장 차기 교정일 : " + DateTime.Now.AddYears(1).ToString("yyyy.MM.dd");
 
            var item_list = new List<object[]>();
            foreach (var obj in items[0])
            {
                var expandObj = obj as ExpandoObject;
                List<object> objs = new List<object>();
                foreach (var e in expandObj)
                    objs.Add(e.Value);
                item_list.Add(objs.ToArray());
            }
            ItemsList.Add(item_list);

            if (items.Length > 1)
            {
                item_list = new List<object[]>();
                foreach (var obj in items[1])
                {
                    var expandObj = obj as ExpandoObject;
                    List<object> objs = new List<object>();
                    var freq = (int)expandObj.Where(x => x.Key.Equals("Frequency")).First().Value;
                    objs.Add(freq);
                    objs.Add(freq * 60);
                    var kp1 = expandObj.Where(x => x.Key.Equals("Kp1")).First().Value;
                    objs.Add(kp1);
                    objs.Add(null);
                    objs.Add(null);
                    objs.Add(null);
                    var kp2 = expandObj.Where(x => x.Key.Equals("Kp2")).First().Value;
                    objs.Add(kp2);
                    item_list.Add(objs.ToArray());
                }
                ItemsList.Add(item_list);
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
                Console.WriteLine(ex.Message);
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

            BulkInsertRow(sheetItems.ItemsList[0], "$DataArea", worksheet);
            BulkInsertRow(sheetItems.ItemsList[1],"$DataArea2",worksheet);

            ReleaseObject(ref worksheet);
        }

        private void BulkInsertRow(List<object[]> items, string tag ,Excel.Worksheet ws)
        {
            var cell_dataArea = ws.Cells.Find(tag);
            if (cell_dataArea == null) return;
            int num = cell_dataArea.Row;
            foreach (var item in items)
            {
                var range = ws.get_Range("D" + num, "M" + num++);
                range.Value2 = item;
                ReleaseObject(ref range);
            }
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
