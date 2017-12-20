Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports System.IO
Public Class Reports5

    Private Sub Reports5_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    
        Dim r As New rptdif2
        Dim cx As New CrystalDecisions.Shared.ConnectionInfo
        Dim t As CrystalDecisions.CrystalReports.Engine.Table
        Dim ts As CrystalDecisions.CrystalReports.Engine.Tables
        Dim td As New CrystalDecisions.Shared.TableLogOnInfo
        With cx

            .ServerName = noserv
            .DatabaseName = nobd
            .UserID = nous
            .Password = nopa

        End With
        ts = r.Database.Tables
        For Each t In ts
            td = t.LogOnInfo
            td.ConnectionInfo = cx
            t.ApplyLogOnInfo(td)
        Next
       
        'CrystalReportViewer1.SelectionFormula = "({ALMACEN.ALMACEN} = ('" & consinventarios.Cbalm.Text & "') AND {InventariosA.Inva_Fecha} = DateValue ('" & consinventarios.DateTimePicker1.Text & "') AND {InventariosA.Inva_Almi} = ('" & consinventarios.Cbalm.Text & "'))"
        r.DataDefinition.FormulaFields("UnboundString2").Text = "'" & consinventarios.Cbalm.Text & "'"
        CrystalReportViewer1.ReportSource = r
    End Sub
End Class