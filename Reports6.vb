Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports System.IO
Public Class Reports6

    Private Sub Reports6_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim r As New rptpedido
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
        CrystalReportViewer1.SelectionFormula = "({pedidos_det.ID_PED} = (" & BuscaPedido.LBPED.Text & "))"
        r.DataDefinition.FormulaFields("UnboundString2").Text = "'" & MDIPrincipal.stbempresa.Text & "'"
        CrystalReportViewer1.ReportSource = r
    End Sub

End Class