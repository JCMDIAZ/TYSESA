Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports System.IO
Public Class Reports9
    Public NomAlm As String
    Public F1 As Date
    Private Sub Reports9_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim r As New rptinventariosC
        Dim cx As New CrystalDecisions.Shared.ConnectionInfo
        Dim t As CrystalDecisions.CrystalReports.Engine.Table
        Dim ts As CrystalDecisions.CrystalReports.Engine.Tables
        Dim td As New CrystalDecisions.Shared.TableLogOnInfo

        With cx

            .ServerName = Server
            .DatabaseName = BD
            .UserID = User1
            .Password = PWD1

        End With
        ts = r.Database.Tables
        For Each t In ts
            td = t.LogOnInfo
            td.ConnectionInfo = cx
            t.ApplyLogOnInfo(td)
        Next
        'CrystalReportViewer1.SelectionFormula = "({InventariosA.Inva_Caduce} = DateValue ('" & Format(consinventarios.DateTimePicker1.Value, "yyyy/MM/dd") & "') AND {InventariosA.Inva_Almi} = ('" & consinventarios.Cbalm.Text & "'))"
        CrystalReportViewer1.SelectionFormula = "{InventariosA.Inva_Caduce} = ('" & Format(F1, "yyyy-MM-dd") & "') and {InventariosA.Inva_Almi} = ('" & NomAlm & "')"
        'CrystalReportViewer1.SelectionFormula = "{InventariosA.Inva_Almi} = ('" & NomAlm & "')"
        'CrystalReportViewer1.SelectionFormula = "({InventariosA.Inva_Caduce} = '" & Format(consinventarios.DateTimePicker1.Value, "yyyy/MM/dd") & "' )"
        'r.DataDefinition.FormulaFields("UnboundString2").Text = "'" & MDIPrincipal.stbempresa.Text & "'"
        CrystalReportViewer1.ReportSource = r

    End Sub
End Class