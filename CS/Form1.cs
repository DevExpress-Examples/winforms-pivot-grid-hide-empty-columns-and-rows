using System;
using System.Globalization;
using System.Windows.Forms;
using DevExpress.XtraPivotGrid;

namespace XtraPivotGrid_HidingColumnsAndRows {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            pivotGridControl1.CustomFieldValueCells += new PivotCustomFieldValueCellsEventHandler(pivotGrid_CustomFieldValueCells);
        }
        void Form1_Load(object sender, EventArgs e) {
            PivotHelper.FillPivot(pivotGridControl1);
            pivotGridControl1.DataSource = PivotHelper.GetDataTable();
            pivotGridControl1.BestFit();
        }
        protected void pivotGrid_CustomFieldValueCells(object sender, PivotCustomFieldValueCellsEventArgs e) {
            if (radioGroup1.SelectedIndex == 0) return;
            HideEmptyValues(true, e);
            HideEmptyValues(false, e);
        }
        private void HideEmptyValues(bool isColumn, PivotCustomFieldValueCellsEventArgs e) {
            for (int i = e.GetCellCount(isColumn) - 1; i >= 0; i--) {
                FieldValueCell cell = e.GetCell(isColumn, i);
                if (cell == null) continue;
                if (cell.EndLevel == e.GetLevelCount(isColumn) - 1) {
                    if (IsValueEmpty(isColumn, cell.MaxIndex, e)) {
                        e.Remove(cell);
                    }                        
                }
            }
        }
        private bool IsValueEmpty( bool isColumn, int valueIndex, PivotCustomFieldValueCellsEventArgs e) {
            if (isColumn)
                return IsCollumnEmpty(valueIndex, e);
            else
                return IsRowEmpty(valueIndex, e);
        }
        private bool IsRowEmpty(int rowIndex, PivotCustomFieldValueCellsEventArgs e) {
            for (int j = 0; j < e.ColumnCount ; j++) {
                decimal value = Convert.ToDecimal(e.GetCellValue(j, rowIndex));
                if (value != 0)
                    return false;
            }
            return true;
        }
        private bool IsCollumnEmpty(int columnIndex, PivotCustomFieldValueCellsEventArgs e) {
            
            for (int j = 0; j < e.RowCount; j++) {
                decimal value = Convert.ToDecimal(e.GetCellValue(columnIndex, j));
                if (value != 0)
                    return false;
            }
            return true;
        }
        void pivotGridControl1_FieldValueDisplayText(object sender, PivotFieldDisplayTextEventArgs e) {
            if (object.ReferenceEquals(e.Field, pivotGridControl1.Fields[PivotHelper.Month])) {
                e.DisplayText = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName((int)e.Value);
            }
        }
        void radioGroup1_SelectedIndexChanged(object sender, EventArgs e) {
            this.pivotGridControl1.LayoutChanged();
            pivotGridControl1.BestFit();
        }
    }
}
