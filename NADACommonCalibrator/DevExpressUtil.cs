using DevExpress.XtraEditors.Repository;
using DevExpress.XtraTreeList.Nodes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NADACommonCalibrator
{
    public static class DevExpressExtension
    {
        public static void BindEnum<T>(this RepositoryItemLookUpEdit control) where T : IConvertible
        {
            var nameValueList = new List<KeyValuePair<string, T>>();

            foreach (var e in Enum.GetValues(typeof(T)) as T[])
            {
                var fi = typeof(T).GetField(e.ToString());
                var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
                var newItem = new KeyValuePair<string, T>((attributes.Length > 0) ? attributes[0].Description : e.ToString(), e);
                nameValueList.Add(newItem);
            }

            Bind(control, nameValueList);
        }

        public static void BindArray<T>(this RepositoryItemLookUpEdit control, T[] array)
        {
            var source = (from T t in array select new KeyValuePair<string, T>(t.ToString(), (T)t)).ToList();
            Bind(control, source);
        }

        public static void Bind<T>(this RepositoryItemLookUpEdit control, IList<KeyValuePair<string, T>> source)
        {
            control.DataSource = source;
            control.DisplayMember = "Key";
            control.ValueMember = "Value";
            control.ShowHeader = false;
            control.ShowFooter = false;
            control.ForceInitialize();
            control.PopulateColumns();
            control.Columns[1].Visible = false;
        }

        public static void SetComboBox<T>(this DevExpress.XtraVerticalGrid.PropertyGridControl control, string fieldName, params T[] values)
        {
            var row = control.GetRowByFieldName(fieldName);
            if (row != null)
            {
                var editor = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
                editor.Items.AddRange(values);
                row.Properties.RowEdit = editor;
            }
        }
    }
}
