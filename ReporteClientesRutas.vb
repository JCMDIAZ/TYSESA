Public Class ReporteClientesRutas

    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click
        Me.Close()
    End Sub

    Private Sub ReporteClientesRutas_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ReporteClieRutas As New rptclientesrutas
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
        ts = ReporteClieRutas.Database.Tables
        For Each t In ts
            td = t.LogOnInfo
            td.ConnectionInfo = cx
            t.ApplyLogOnInfo(td)
        Next
        Me.CRVClientesRutas.ReportSource = ReporteClieRutas
    End Sub

    Private Sub TSOpciones_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles TSOpciones.ItemClicked

    End Sub
End Class