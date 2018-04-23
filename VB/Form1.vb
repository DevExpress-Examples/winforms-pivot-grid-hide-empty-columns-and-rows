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


Imports Microsoft.VisualBasic
Imports System
Imports System.Globalization
Imports System.Windows.Forms
Imports DevExpress.XtraPivotGrid

Namespace XtraPivotGrid_HidingColumnsAndRows
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
			AddHandler pivotGridControl1.CustomFieldValueCells, AddressOf pivotGrid_CustomFieldValueCells
		End Sub
		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			PivotHelper.FillPivot(pivotGridControl1)
			pivotGridControl1.DataSource = PivotHelper.GetDataTable()
			pivotGridControl1.BestFit()
		End Sub

		Protected Sub pivotGrid_CustomFieldValueCells(ByVal sender As Object, ByVal e As PivotCustomFieldValueCellsEventArgs)
			If radioGroup1.SelectedIndex = 0 Then
				Return
			End If
			HideEmptyValues(True, e)
			HideEmptyValues(False, e)
		End Sub

		Private Sub HideEmptyValues(ByVal isColumn As Boolean, ByVal e As PivotCustomFieldValueCellsEventArgs)
			For i As Integer = e.GetCellCount(isColumn) - 1 To 0 Step -1
				Dim cell As FieldValueCell = e.GetCell(isColumn, i)
				If cell Is Nothing Then
					Continue For
				End If
				If cell.EndLevel = e.GetLevelCount(isColumn) - 1 Then
					If IsValueEmpty(isColumn, cell.MaxIndex, e) Then
						e.Remove(cell)
					End If
				End If
			Next i
		End Sub

		Private Function IsValueEmpty(ByVal isColumn As Boolean, ByVal valueIndex As Integer, ByVal e As PivotCustomFieldValueCellsEventArgs) As Boolean
			If isColumn Then
				Return IsCollumnEmpty(valueIndex, e)
			Else
				Return IsRowEmpty(valueIndex, e)
			End If
		End Function

		Private Function IsRowEmpty(ByVal rowIndex As Integer, ByVal e As PivotCustomFieldValueCellsEventArgs) As Boolean
			For j As Integer = 0 To e.ColumnCount - 1
				Dim value As Decimal = Convert.ToDecimal(e.GetCellValue(j, rowIndex))
				If value <> 0 Then
					Return False
				End If
			Next j
			Return True
		End Function


		Private Function IsCollumnEmpty(ByVal columnIndex As Integer, ByVal e As PivotCustomFieldValueCellsEventArgs) As Boolean

			For j As Integer = 0 To e.RowCount - 1
				Dim value As Decimal = Convert.ToDecimal(e.GetCellValue(columnIndex, j))
				If value <> 0 Then
					Return False
				End If
			Next j
			Return True
		End Function
		Private Sub pivotGridControl1_FieldValueDisplayText(ByVal sender As Object, ByVal e As PivotFieldDisplayTextEventArgs) Handles pivotGridControl1.FieldValueDisplayText
			If Object.ReferenceEquals(e.Field, pivotGridControl1.Fields(PivotHelper.Month)) Then
				e.DisplayText = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(CInt(Fix(e.Value)))
			End If
		End Sub
		Private Sub radioGroup1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles radioGroup1.SelectedIndexChanged
			Me.pivotGridControl1.LayoutChanged()
			pivotGridControl1.BestFit()
		End Sub
	End Class
End Namespace