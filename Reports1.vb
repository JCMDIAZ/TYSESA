Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports System.IO
Public Class Reports1

    Private Sub Reports1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        
        Dim r As New rptinventariosN
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
        Dim tfor As String = "dd/MM/yyyy"
        ''CrystalReportViewer1.SelectionFormula = "({Inventarios.Inv_Fecha} = DateValue ('" & consinventarios.DateTimePicker1.Text & "'))"
        'CrystalReportViewer1.SelectionFormula = "({Inventarios.Inv_Fecha} = DateTime ('" & Format(consinventarios.DateTimePicker1.Value, "dd/MM/yyyy") & "'))"
        ''''CrystalReportViewer1.SelectionFormula = "datepart({Inventariosa.Inva_Fecha}) = datetime ('" & consinventarios.DateTimePicker1.Value.ToShortDateString & "')"
        'r.DataDefinition.FormulaFields("UnboundString2").Text = "'" & MDIPrincipal.stbempresa.Text & "'"
        CrystalReportViewer1.ReportSource = r

    End Sub
   
    Private Sub CrystalReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CrystalReportViewer1.Load



    End Sub
End Class