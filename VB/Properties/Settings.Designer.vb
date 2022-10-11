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
'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:2.0.50727.4952
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------
Namespace XtraPivotGrid_HidingColumnsAndRows.Properties

    <Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute()>
    <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "8.0.0.0")>
    Friend NotInheritable Partial Class Settings
        Inherits Global.System.Configuration.ApplicationSettingsBase

        Private Shared defaultInstance As XtraPivotGrid_HidingColumnsAndRows.Properties.Settings = CType((Global.System.Configuration.ApplicationSettingsBase.Synchronized(New XtraPivotGrid_HidingColumnsAndRows.Properties.Settings())), XtraPivotGrid_HidingColumnsAndRows.Properties.Settings)

        Public Shared ReadOnly Property [Default] As Settings
            Get
                Return XtraPivotGrid_HidingColumnsAndRows.Properties.Settings.defaultInstance
            End Get
        End Property

        <Global.System.Configuration.ApplicationScopedSettingAttribute()>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute()>
        <Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.ConnectionString)>
        <Global.System.Configuration.DefaultSettingValueAttribute("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\nwind.mdb;Persist Se" & "curity Info=True")>
        Public ReadOnly Property nwindConnectionString As String
            Get
                Return(CStr((Me("nwindConnectionString"))))
            End Get
        End Property
    End Class
End Namespace
