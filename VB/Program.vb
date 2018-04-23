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
Imports System
Imports System.Collections.Generic
Imports System.Windows.Forms

Namespace XtraPivotGrid_HidingColumnsAndRows
	Friend NotInheritable Class Program
		''' <summary>
		''' The main entry point for the application.
		''' </summary>
		Private Sub New()
		End Sub
		<STAThread> _
		Shared Sub Main()
			Application.EnableVisualStyles()
			Application.SetCompatibleTextRenderingDefault(False)
			Application.Run(New Form1())
		End Sub
	End Class
End Namespace