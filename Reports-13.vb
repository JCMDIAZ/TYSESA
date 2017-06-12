Imports System.Text
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.CrystalReports.Engine

Public Class Reports_13

    Private Sub CargaALMACEN()
        Dim SqlSelEmp As New SqlCommand("SELECT Abreviatura From ALMACENES ORDER BY Abreviatura", SqlCnn)
        'Dim SqlSelEmp As New SqlCommand("SELECT a.almacen FROM usuarios_almacen a, usuarios b WHERE a.usuario = b.Usuario AND b.Nombre = '" & MDIPrincipal.StbUSER.Text & "' ORDER BY a.almacen", SqlCnn)
        Dim SqlRead As SqlDataReader
        Try
            SqlRead = SqlSelEmp.ExecuteReader
            While SqlRead.Read
                Me.Cbalm.Items.Add(SqlRead.GetString(0))

            End While
            SqlRead.Close()
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Sub QRYReporte()
        Dim r As New rpttotalesNEx
        'Dim r As New rpttotales
        'Dim cx As New CrystalDecisions.Shared.ConnectionInfo
        'Dim t As CrystalDecisions.CrystalReports.Engine.Table
        'Dim ts As CrystalDecisions.CrystalReports.Engine.Tables
        'Dim td As New CrystalDecisions.Shared.TableLogOnInfo
        'Dim data As New String("({LOTEEX2.almacen} = ('" & consinventarios.Cbalm.Text & "') ) ")
        Dim data As New String("({LOTEEX2.almacen} = ('" & Me.Cbalm.Text.Trim & "') ) ")
        'Dim Archivo As New StreamReader("Config.txt")
        'With cx
        '    .ServerName = noserv
        '    .DatabaseName = nobd
        '    .UserID = nous
        '    .Password = nopa
        'End With
        'ts = r.Database.Tables
        'For Each t In ts
        '    td = t.LogOnInfo
        '    td.ConnectionInfo = cx
        '    t.ApplyLogOnInfo(td)
        'Next

        r.DataSourceConnections.Clear()

        Dim boConnectionInfo As ConnectionInfo = New ConnectionInfo
        boConnectionInfo.ServerName = noserv
        boConnectionInfo.DatabaseName = nobd
        boConnectionInfo.UserID = nous
        boConnectionInfo.Password = nopa
        boConnectionInfo.Type = ConnectionInfoType.SQL

        For Each t As Table In r.Database.Tables
            Dim boTableLogOnInfo As TableLogOnInfo = t.LogOnInfo
            boTableLogOnInfo.ConnectionInfo = boConnectionInfo
            t.ApplyLogOnInfo(boTableLogOnInfo)
        Next

        'CrystalReportViewer1.SelectionFormula = data
        r.DataDefinition.FormulaFields("UnboundString2").Text = "'" & Me.Cbalm.Text.Trim & "'"
        CrystalReportViewer1.ReportSource = r
    End Sub
    Private Sub Reports_13_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Me.CargaALMACEN()
        Me.DTPDe.Value = Today()
        Me.DTPA.Value = Today()
        Me.DTPDe.Focus()
        Me.DTPDe.Select()
    End Sub

    Private Sub DTPDe_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles DTPDe.GotFocus
        Me.DTPDe.Select()
    End Sub

    Private Sub DTPDe_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DTPDe.KeyPress
        'Dim FechaDe As String = Format(Me.DTPDe.Value, "yyyy.MM.dd")


        If e.KeyChar = Chr(13) Then
            'GUARDATOTALES(FechaDe)
            'Call Me.QRYReporte()
        End If
    End Sub

    Private Sub Cbalm_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cbalm.SelectionChangeCommitted

        'GUARDATOTALES(Me.DTPDe.Value, Me.DTPA.Value, Trim(Me.Cbalm.SelectedItem))
        GUARDATOTALES(Me.DTPDe.Value, Me.DTPDe.Value, Trim(Me.Cbalm.SelectedItem))
        Call Me.QRYReporte()
        Me.DTPDe.Focus()
    End Sub
End Class