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

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace XtraPivotGrid_HidingColumnsAndRows {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}