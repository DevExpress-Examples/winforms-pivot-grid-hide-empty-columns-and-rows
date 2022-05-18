' Developer Express Code Central Example:
' How to hide empty Field Values (Columns/Rows)
' 
' It is necessary to use the PivotGridControl.CustomFieldValueCells
' (ms-help://MS.VSCC.v90/MS.VSIPCC.v90/DevExpress.NETv10.2/DevExpress.WindowsForms/DevExpressXtraPivotGridPivotGridControl_CustomFieldValueCellstopic.htm)
' event to accomplish this task. See Also:
' http://www.devexpress.com/scid=E2769
' 
' You can find sample updates and versions for different programming languages here:
' http://www.devexpress.com/example=E2807

' Developer Express Code Central Example:
' How to hide particular rows and columns
' 
' The following example demonstrates how to hide particular rows and columns by
' handling the CustomFieldValueCells event.
' In this example, the event handler
' iterates through all row headers and removes rows that correspond to the
' &quot;Employee B&quot; field value, and that are not Total Rows.
' 
' You can find sample updates and versions for different programming languages here:
' http://www.devexpress.com/example=E2769


Imports Microsoft.VisualBasic
Imports System.Data
Imports DevExpress.XtraPivotGrid

Namespace XtraPivotGrid_HidingColumnsAndRows
	Public NotInheritable Class PivotHelper
		Public Const Employee As String = "Employee"
		Public Const Widget As String = "Widget"
		Public Const Month As String = "Month"
		Public Const RetailPrice As String = "Retail Price"
		Public Const WholesalePrice As String = "Wholesale Price"
		Public Const Quantity As String = "Quantity"
		Public Const Remains As String = "Remains"

		Public Const EmployeeA As String = "Employee A"
		Public Const EmployeeB As String = "Employee B"
		Public Const WidgetA As String = "Widget A"
		Public Const WidgetB As String = "Widget B"
		Public Const WidgetC As String = "Widget C"

		Private Sub New()
		End Sub
		Public Shared Sub FillPivot(ByVal pivot As PivotGridControl)
			pivot.Fields.AddDataSourceColumn(Employee, PivotArea.RowArea)
			pivot.Fields.AddDataSourceColumn(Widget, PivotArea.RowArea)
			pivot.Fields.AddDataSourceColumn(Month, PivotArea.ColumnArea).AreaIndex = 0
			pivot.Fields.AddDataSourceColumn(RetailPrice, PivotArea.DataArea)
			pivot.Fields.AddDataSourceColumn(WholesalePrice, PivotArea.DataArea)
			pivot.Fields.AddDataSourceColumn(Quantity, PivotArea.DataArea)
			pivot.Fields.AddDataSourceColumn(Remains, PivotArea.DataArea)
			'foreach (PivotGridField field in pivot.Fields) {
			'    field.AllowedAreas = GetAllowedArea(field.Area);
			'}
			pivot.OptionsView.RowTotalsLocation = PivotRowTotalsLocation.Far
			pivot.OptionsView.ColumnTotalsLocation = PivotTotalsLocation.Far
			pivot.OptionsDataField.Area = PivotDataArea.ColumnArea
			pivot.OptionsDataField.AreaIndex = 1
		End Sub
		Private Shared Function GetAllowedArea(ByVal area As PivotArea) As PivotGridAllowedAreas
			Select Case area
				Case PivotArea.ColumnArea
					Return PivotGridAllowedAreas.ColumnArea
				Case PivotArea.RowArea
					Return PivotGridAllowedAreas.RowArea
				Case PivotArea.DataArea
					Return PivotGridAllowedAreas.DataArea
				Case PivotArea.FilterArea
					Return PivotGridAllowedAreas.FilterArea
				Case Else
					Return PivotGridAllowedAreas.All
			End Select
		End Function
		Public Shared Function GetDataTable() As DataTable
			Dim table As New DataTable()
			table.Columns.Add(Employee, GetType(String))
			table.Columns.Add(Widget, GetType(String))
			table.Columns.Add(Month, GetType(Integer))
			table.Columns.Add(RetailPrice, GetType(Double))
			table.Columns.Add(WholesalePrice, GetType(Double))
			table.Columns.Add(Quantity, GetType(Integer))
			table.Columns.Add(Remains, GetType(Integer))
			table.Rows.Add(EmployeeA, WidgetA, 6, 45.6, 0, 3, 0)
			table.Rows.Add(EmployeeA, WidgetA, 7, 38.9, 0, 6, 1)
			table.Rows.Add(EmployeeA, WidgetB, 6, 24.7, 0, 7, 0)
			table.Rows.Add(EmployeeA, WidgetB, 7, 8.3, 0, 5, 1)
			table.Rows.Add(EmployeeA, WidgetC, 6, 10.0, 0, 4, 0)
			table.Rows.Add(EmployeeA, WidgetC, 7, 20.0, 0, 5, 1)
			table.Rows.Add(EmployeeB, WidgetA, 6, 77.8, 0, 2, 0)
			table.Rows.Add(EmployeeB, WidgetA, 7, 32.5, 0, 1, 1)
			table.Rows.Add(EmployeeB, WidgetB, 6, 12, 0, 0, 0)
			table.Rows.Add(EmployeeB, WidgetB, 7, 6.7, 5, 4, 1)
			table.Rows.Add(EmployeeB, WidgetC, 6, 0, 0, 0, 0)
			table.Rows.Add(EmployeeB, WidgetC, 7, 0, 0, 0, 0)
			Return table
		End Function
	End Class

End Namespace
