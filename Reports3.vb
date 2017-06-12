Imports System.IO
Public Class Reports3

    Private Sub Reports3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim r As New rptprodmov
        Dim cx As New CrystalDecisions.Shared.ConnectionInfo
        Dim t As CrystalDecisions.CrystalReports.Engine.Table
        Dim ts As CrystalDecisions.CrystalReports.Engine.Tables
        Dim td As New CrystalDecisions.Shared.TableLogOnInfo
        Dim data As New String("({Movimientos.FECHA_MOV} = DateValue ('" & PRODUCTOS.DTFECHADE.Text & "') to DateValue ('" & PRODUCTOS.DTFECHAA.Text & "')) ")



        'If PRODUCTOS.CBCLIENTE.Text = Nothing Then
        '    MsgBox("Error, requiere seleccionar Cliente")
        '    Me.Close()
        'Else
        '    'MsgBox("agrega cliente")
        '    data = data & "AND {Movimientos.CLIEN_MOV} = '" & PRODUCTOS.CBCLIENTE.Text & "' "
        'End If

        If PRODUCTOS.TxtCodigo.Text = Nothing Then
            MsgBox("Error, requiere ingresar codigo")
            Me.Close()
        Else
            'MsgBox("agrega codigo")
            data = data & "AND {Movimientos.Codigo de Producto} = '" & PRODUCTOS.TxtCodigo.Text & "' "
        End If

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
        CrystalReportViewer1.SelectionFormula = data
        'r.DataDefinition.FormulaFields("UnboundString2").Text = "'" & MDIPrincipal.stbempresa.Text & "'"
        CrystalReportViewer1.ReportSource = r
    End Sub

    Private Sub CrystalReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CrystalReportViewer1.Load

    End Sub
End Class