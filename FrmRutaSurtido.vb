Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.CrystalReports.Engine

Public Class FrmRutaSurtido

    Private Sub FrmRutaSurtido_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub TSBSaveExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBSaveExit.Click

       
    End Sub

    Private Sub TSBSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBSalir.Click
        Me.Close()
    End Sub

    Private Sub TSOpciones_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs)

    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        'Dim r As New rptSurtidoFechayHora
        'Dim r As New ReportFirmaSurteFyHCredN
        'Dim cx As New CrystalDecisions.Shared.ConnectionInfo
        'Dim t As CrystalDecisions.CrystalReports.Engine.Table
        'Dim ts As CrystalDecisions.CrystalReports.Engine.Tables
        'Dim td As New CrystalDecisions.Shared.TableLogOnInfo
        'Dim PARAMFIELDS As New ParameterFields
        'Dim paramField1 As New ParameterField
        'Dim paramField2 As New ParameterField
        'Dim discreteValue1 As New ParameterDiscreteValue
        'Dim discreteValue2 As New ParameterDiscreteValue

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
        'CrystalReportViewer1.ReportSource = r

        ''paramField1.ParameterFieldName = "FI"
        ''paramField2.ParameterFieldName = "FF"
        'paramField1.ParameterFieldName = "@f1"
        'paramField2.ParameterFieldName = "@f2"
        'discreteValue1.Value = Me.DTFECHADE.Value
        'discreteValue2.Value = Me.DTFECHAA.Value
        'paramField1.CurrentValues.Add(discreteValue1)
        'paramField2.CurrentValues.Add(discreteValue2)
        'PARAMFIELDS.Add(paramField1)
        'PARAMFIELDS.Add(paramField2)
        'Me.CrystalReportViewer1.ParameterFieldInfo = PARAMFIELDS



        Dim r As New ReportFirmaSurteFyHCredN
        'Dim cx As New CrystalDecisions.Shared.ConnectionInfo
        'Dim t As CrystalDecisions.CrystalReports.Engine.Table
        'Dim ts As CrystalDecisions.CrystalReports.Engine.Tables
        'Dim td As New CrystalDecisions.Shared.TableLogOnInfo
        Dim PARAMFIELDS As New ParameterFields
        Dim paramField1 As New ParameterField
        Dim paramField2 As New ParameterField
        Dim discreteValue1 As New ParameterDiscreteValue
        Dim discreteValue2 As New ParameterDiscreteValue

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

        'r.SetDatabaseLogon(nous, nopa, noserv, nobd, False)

        CrystalReportViewer1.ReportSource = r

        'paramField1.ParameterFieldName = "FI"
        'paramField2.ParameterFieldName = "FF"
        paramField1.ParameterFieldName = "@f1"
        paramField2.ParameterFieldName = "@f2"
        discreteValue1.Value = Me.DTFECHADE.Value
        discreteValue2.Value = Me.DTFECHAA.Value
        paramField1.CurrentValues.Add(discreteValue1)
        paramField2.CurrentValues.Add(discreteValue2)
        PARAMFIELDS.Add(paramField1)
        PARAMFIELDS.Add(paramField2)
        Me.CrystalReportViewer1.ParameterFieldInfo = PARAMFIELDS

    End Sub
End Class