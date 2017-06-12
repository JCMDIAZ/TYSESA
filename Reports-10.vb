Imports System.Text
Imports System.IO
Public Class Reports_10

    Private Sub Reports_10_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim r As New rptexist2
        Dim cx As New CrystalDecisions.Shared.ConnectionInfo
        Dim t As CrystalDecisions.CrystalReports.Engine.Table
        Dim ts As CrystalDecisions.CrystalReports.Engine.Tables
        Dim td As New CrystalDecisions.Shared.TableLogOnInfo
        'Dim data As New String("({LOTEEX2.almacen} = ('" & consinventarios.Cbalm.Text & "') ) ")
        'Dim Archivo As New StreamReader("Config.txt")
        Dim Server, BD, User1, PWD1 As String
        'Server = Archivo.ReadLine
        'BD = Archivo.ReadLine
        'User1 = Archivo.ReadLine
        'PWD1 = Archivo.ReadLine

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
        'CrystalReportViewer1.SelectionFormula = data
        r.DataDefinition.FormulaFields("UnboundString2").Text = "'" & consinventarios.Cbalm.Text & "'"
        CrystalReportViewer1.ReportSource = r
    End Sub

End Class