Imports Microsoft.VisualBasic
Imports System
Imports System.Windows.Forms
Imports DevExpress.XtraReports.UI

Namespace RepAlignCheckBoxTableCell
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			Dim report As New XtraReport1()

			report.DataSource = ManualDataSet.CreateData()

			CType(New ReportPrintTool(report), ReportPrintTool).ShowPreviewDialog()
		End Sub
	End Class
End Namespace
