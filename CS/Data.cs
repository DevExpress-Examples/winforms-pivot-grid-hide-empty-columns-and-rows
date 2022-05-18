// Developer Express Code Central Example:
// How to hide empty Field Values (Columns/Rows)
// 
// It is necessary to use the PivotGridControl.CustomFieldValueCells
// (ms-help://MS.VSCC.v90/MS.VSIPCC.v90/DevExpress.NETv10.2/DevExpress.WindowsForms/DevExpressXtraPivotGridPivotGridControl_CustomFieldValueCellstopic.htm)
// event to accomplish this task. See Also:
// http://www.devexpress.com/scid=E2769
// 
// You can find sample updates and versions for different programming languages here:
// http://www.devexpress.com/example=E2807

// Developer Express Code Central Example:
// How to hide particular rows and columns
// 
// The following example demonstrates how to hide particular rows and columns by
// handling the CustomFieldValueCells event.
// In this example, the event handler
// iterates through all row headers and removes rows that correspond to the
// &quot;Employee B&quot; field value, and that are not Total Rows.
// 
// You can find sample updates and versions for different programming languages here:
// http://www.devexpress.com/example=E2769

using System.Data;
using DevExpress.XtraPivotGrid;

namespace XtraPivotGrid_HidingColumnsAndRows {
    public static class PivotHelper {
        public const string Employee = "Employee";
        public const string Widget = "Widget";
        public const string Month = "Month";
        public const string RetailPrice = "Retail Price";
        public const string WholesalePrice = "Wholesale Price";
        public const string Quantity = "Quantity";
        public const string Remains = "Remains";

        public const string EmployeeA = "Employee A";
        public const string EmployeeB = "Employee B";
        public const string WidgetA = "Widget A";
        public const string WidgetB = "Widget B";
        public const string WidgetC = "Widget C";

        public static void FillPivot(PivotGridControl pivot) {
            pivot.Fields.AddDataSourceColumn(Employee, PivotArea.RowArea);
            pivot.Fields.AddDataSourceColumn(Widget, PivotArea.RowArea);
            pivot.Fields.AddDataSourceColumn(Month, PivotArea.ColumnArea).AreaIndex = 0;
            pivot.Fields.AddDataSourceColumn(RetailPrice, PivotArea.DataArea);
            pivot.Fields.AddDataSourceColumn(WholesalePrice, PivotArea.DataArea);
            pivot.Fields.AddDataSourceColumn(Quantity, PivotArea.DataArea);
            pivot.Fields.AddDataSourceColumn(Remains, PivotArea.DataArea);
            //foreach (PivotGridField field in pivot.Fields) {
            //    field.AllowedAreas = GetAllowedArea(field.Area);
            //}
            pivot.OptionsView.RowTotalsLocation = PivotRowTotalsLocation.Far;
            pivot.OptionsView.ColumnTotalsLocation = PivotTotalsLocation.Far;
            pivot.OptionsDataField.Area = PivotDataArea.ColumnArea;
            pivot.OptionsDataField.AreaIndex = 1;
        }
        static PivotGridAllowedAreas GetAllowedArea(PivotArea area) {
            switch (area) {
                case PivotArea.ColumnArea:
                    return PivotGridAllowedAreas.ColumnArea;
                case PivotArea.RowArea:
                    return PivotGridAllowedAreas.RowArea;
                case PivotArea.DataArea:
                    return PivotGridAllowedAreas.DataArea;
                case PivotArea.FilterArea:
                    return PivotGridAllowedAreas.FilterArea;
                default:
                    return PivotGridAllowedAreas.All;
            }
        }
        public static DataTable GetDataTable() {
            DataTable table = new DataTable();
            table.Columns.Add(Employee, typeof(string));
            table.Columns.Add(Widget, typeof(string));
            table.Columns.Add(Month, typeof(int));
            table.Columns.Add(RetailPrice, typeof(double));
            table.Columns.Add(WholesalePrice, typeof(double));
            table.Columns.Add(Quantity, typeof(int));
            table.Columns.Add(Remains, typeof(int));
            table.Rows.Add(EmployeeA, WidgetA, 6, 45.6, 0, 3, 0);
            table.Rows.Add(EmployeeA, WidgetA, 7, 38.9, 0, 6, 1);
            table.Rows.Add(EmployeeA, WidgetB, 6, 24.7, 0, 7, 0);
            table.Rows.Add(EmployeeA, WidgetB, 7, 8.3, 0, 5, 1);
            table.Rows.Add(EmployeeA, WidgetC, 6, 10.0, 0, 4, 0);
            table.Rows.Add(EmployeeA, WidgetC, 7, 20.0, 0, 5, 1);
            table.Rows.Add(EmployeeB, WidgetA, 6, 77.8, 0, 2, 0);
            table.Rows.Add(EmployeeB, WidgetA, 7, 32.5, 0, 1, 1);
            table.Rows.Add(EmployeeB, WidgetB, 6, 12, 0, 0, 0);
            table.Rows.Add(EmployeeB, WidgetB, 7, 6.7, 5, 4, 1);
            table.Rows.Add(EmployeeB, WidgetC, 6, 0, 0, 0, 0);
            table.Rows.Add(EmployeeB, WidgetC, 7, 0, 0, 0, 0);
            return table;
        }
    }

}
