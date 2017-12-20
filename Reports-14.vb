Public Class Reports_14

    Private Sub Reports_14_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ReporteClieRutas As New ReportUbicaciones
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
        Me.CRVUbi.ReportSource = ReporteClieRutas
    End Sub
End Class